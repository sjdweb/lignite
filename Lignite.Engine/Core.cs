/* @name Lignite For Betfair Project
 * @author Carel Vosloo
 * @author Betfair Developers Program (http://bdp.betfair.com)
 * @copyright Copyright (C) 2008 Betfair Ltd. All rights reserved.
 * @license This file is part of the Lignite For Betfair Project.
 * The BetfairAPIFramework is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * The "Lignite For Betfair Project" is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with the "Lignite For Betfair Project".  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Timers;
using Betfair.API;
using Betfair.Collections;
using Lignite.Configuration;
using Lignite.Engine.Events;
using Lignite.Plugin;
using Timer=System.Timers.Timer;
using System.ComponentModel;

namespace Lignite.Engine
{
    public class Core : Component
    {
        #region Variables

        private static BetfairAPI __betfairAPI;
        private readonly NewMessageEventEventHandler AutoMarketLoaderMessageEventHandler;
        private readonly NewMessageEventEventHandler EngineMessageEventHandler;

        private readonly NewMarketEventHandler LoadNewMarketActionEventHandler;
        private readonly MarketDataUpdatedEventEventHandler MarketDataUpdatedEventHandler;
        private readonly NewMessageEventEventHandler MarketProcessorMessageEventHandler;
        private readonly MarketProcessorThreadStatusChangedEventHandler MarketProcessorThreadStatusChangedEventHandler;
        private ElapsedEventHandler __TimersElapsedEventHandler;

        /// <summary>
        /// Timer
        /// </summary>
        private Timer EngineCoreTimer;

        /// <summary>
        /// This is a container to hold all the currently running threads
        /// </summary>
        public Dictionary<string, Thread> LigniteEngineThreads { get; private set; }

        /// <summary>
        /// The loaded configuration options
        /// </summary>
        private Settings settings;

        /// <summary>
        /// Betfair data provider
        /// </summary>
        internal static BetfairAPI betfairAPI
        {
            get
            {
                if (__betfairAPI == null)
                {
                    return null;
                }
                lock (__betfairAPI)
                {
                    return __betfairAPI;
                }
            }
            set { __betfairAPI = value; }
        }

        /// <summary>
        /// Gets the logged in username.
        /// </summary>
        /// <value>The get logged in username.</value>
        public string GetLoggedInUsername
        {
            get
            {
                if (settings.Betfair.Username == null)
                {
                    return "";
                }
                return settings.Betfair.Username;
            }
        }

        /// <summary>
        /// Gets the get thread count.
        /// </summary>
        /// <value>The get thread count.</value>
        public int GetThreadCount
        {
            get
            {
                return LigniteEngineThreads != null ? LigniteEngineThreads.Count : 0;
            }
        }

        #endregion

        #region Core

        public Core()
        {
            LoadNewMarketActionEventHandler = LoadNewMarket;
            MarketProcessorThreadStatusChangedEventHandler = MarketProcessorThreadStatusChanged;
            MarketDataUpdatedEventHandler = MarketDataUpdated;
            EngineMessageEventHandler = NewMessage;
            MarketProcessorMessageEventHandler = NewMessage;
            AutoMarketLoaderMessageEventHandler = NewMessage;

            // Clear and create the event broker
            SubscribeToPublicEvents();

            if (File.Exists(Directory.GetCurrentDirectory() + "\\lignite.configuration.xml"))
            {
                // Load the config settings
                settings = new XmlFileOperations().Read(Directory.GetCurrentDirectory() + "\\lignite.configuration.xml");

                //Load plugins
                Loadplugins();
            }
        }

        #endregion

        #region Start

        public void Start()
        {
            Start(Directory.GetCurrentDirectory() + "\\lignite.configuration.xml");
        }

        /// <summary>
        /// The system initialization function, this preps and loads
        /// all the required child elements and services. It also does
        /// sanity check on the entire system
        /// </summary>
        /// <param name="configurationFile">The configuration file.</param>
        public void Start(string configurationFile)
        {
            try
            {
                // Write out to the console
                SendMessage("Lignite Engine Initializing");

                // Load the config settings
                settings = new XmlFileOperations().Read(configurationFile);

                // Load the Betfair data provider
                betfairAPI = new BetfairAPI(
                    settings.Betfair.Username,
                    settings.Betfair.Password,
                    settings.Betfair.ProductId,
                    settings.Betfair.VendorSoftwareId,
                    settings.Betfair.EndPointGlobalAPI,
                    settings.Betfair.EndPointExchangeAPIs[0],
                    settings.Betfair.EndPointExchangeAPIs[1],
                    settings.Betfair.AutoKeepAliveFrequency
                    );

                // make sure the hashtable used for thread tracking is empty and create instance
                if (LigniteEngineThreads != null)
                {
                    LigniteEngineThreads.Clear();
                }
                else
                {
                    LigniteEngineThreads = new Dictionary<string, Thread>();
                }

                // Start the timer
                EngineCoreTimer = new Timer(100);
                __TimersElapsedEventHandler = OnTimedEvent;
                EngineCoreTimer.Elapsed += __TimersElapsedEventHandler;
                EngineCoreTimer.Interval = 100;
                EngineCoreTimer.Enabled = true;

                // Start the market loader
                StartAutoMarketLoaderThread();

                //Load plugins
                Loadplugins();
            }
            catch (Exception ex)
            {
                SendMessage(String.Format("EXCEPTION: {0}", ex.Message));
            }
        }

        #endregion

        #region Stop

        /// <summary>
        /// Basically all we are doing is aborting all the currently active threads
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            try
            {
                /*** Stop and clear the core timer ***/
                EngineCoreTimer.Enabled = false;
                EngineCoreTimer.Elapsed -= __TimersElapsedEventHandler;

                /*** Send the shutdown message to all listeners ***/
                OnSystemShutdownEvent(this, new EventArgs());

                /*** Kill the API session ***/
                betfairAPI.Logout();

                /*** Clear the loaded settings ***/
                settings = new Settings();

                return true;
            }
            catch (Exception ex)
            {
                SendMessage(String.Format("EXCEPTION: {0}\n", ex.Message));
                return false;
            }
        }

        #endregion

        #region ReBroadcastThreadState

        internal static event BroadcastMarketThreadStateEventHandler BroadcastMarketThreadState;

        internal delegate void BroadcastMarketThreadStateEventHandler(object sender, BroadcastMarketThreadStateEventArgs e);

        internal class BroadcastMarketThreadStateEventArgs : EventArgs
        {
            internal string ThreadProcessId{ get; set;}
        }

        /// <summary>
        /// Request a thread to broadcast it's last known state.
        /// </summary>
        /// <param name="threadProcessId">The thread process id.</param>
        public bool ReBroadcastMarketThreadState(string threadProcessId)
        {
            if (BroadcastMarketThreadState != null)
            {
                BroadcastMarketThreadState(this, new BroadcastMarketThreadStateEventArgs {ThreadProcessId = threadProcessId});
                return true;
            }
            return false;
        }

        #endregion

        #region SubscribeToPublicEvents

        private void SubscribeToPublicEvents()
        {
            Broker.UnsubscribeAll();

            /*** General ***/
            Broker.Subscribe(EventNames.MarketDataUpdated, MarketDataUpdatedEventHandler);
            Broker.Subscribe(EventNames.EngineMessage, EngineMessageEventHandler);

            /*** Auto Market Loader ***/
            Broker.Subscribe(EventNames.LoadNewMarketAction, LoadNewMarketActionEventHandler);
            Broker.Subscribe(EventNames.AutoMarketLoaderMessage, AutoMarketLoaderMessageEventHandler);
            Broker.Subscribe(EventNames.AutoMarketLoaderError, AutoMarketLoaderMessageEventHandler);

            /*** Market Processor ***/
            Broker.Subscribe(EventNames.MarketProcessorThreadStatusChanged,
                             MarketProcessorThreadStatusChangedEventHandler);
            Broker.Subscribe(EventNames.MarketProcessorMessage, MarketProcessorMessageEventHandler);
            Broker.Subscribe(EventNames.MarketProcessorError, MarketProcessorMessageEventHandler);
        }

        #endregion

        #region Event Methods

        public void LoadNewMarket(object sender, NewMarketEventArgs e)
        {
            var strat = e.strategyToLoad ?? new StrategyLoadPatern();

            StartMarketProcessorThread(e.exchangeId, e.marketId, strat);
        }

        public event MarketProcessorThreadStatusChangedEventHandler OnMarketProcessorThreadStatusChanged;

        private void MarketProcessorThreadStatusChanged(object sender, MarketProcessorThreadStatusChangedEventArgs e)
        {
            if (e.status == MarketProcessorThreadStatus.CLOSED)
            {
                if (LigniteEngineThreads.ContainsKey(e.senderID))
                {
                    var senderId = e.senderID;
                    var thread = LigniteEngineThreads[senderId];

                    var beforeremove = LigniteEngineThreads.Count;
                    LigniteEngineThreads.Remove(senderId);

                    if (beforeremove <= LigniteEngineThreads.Count)
                    {
                        SendMessage("Thread " + senderId + " not removed from LigniteEngineThreads!");
                    }

                    if (thread.ThreadState == ThreadState.Running)
                    {
                        Thread.Sleep(5);
                        SendMessage("Thread " + senderId + " not terminated!");
                    }
                }
            }

            if (OnMarketProcessorThreadStatusChanged != null)
                OnMarketProcessorThreadStatusChanged(null, e);
        }

        public event MarketDataUpdatedEventEventHandler OnMarketDataUpdated;

        private void MarketDataUpdated(object sender, MarketDataUpdatedEventArgs e)
        {
            if (OnMarketDataUpdated != null)
                OnMarketDataUpdated(null, e);
        }

        public event NewMessageEventEventHandler OnNewMessage;

        private void NewMessage(object sender, NewMessageEventArgs e)
        {
            Console.WriteLine(e.message);

            if (OnNewMessage != null)
                OnNewMessage(null, e);
        }

        #endregion

        #region EventHandLer

        internal static event EventHandler SystemShutdown;

        internal void OnSystemShutdownEvent(object sender, EventArgs e)
        {
            if (SystemShutdown != null)
                SystemShutdown(this, e);
        }

        #endregion

        #region Timer

        internal static event ElapsedEventHandler TimerTick;

        internal void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (TimerTick != null)
                TimerTick(this, e);
        }

        #endregion

        #region Pause Engine

        /// <summary>
        /// Pause the engine timer and as aresult stop thread processing
        /// </summary>
        public bool PauseEngine()
        {
            if (EngineCoreTimer.Enabled)
            {
                EngineCoreTimer.Enabled = false;
                SendMessage("Paused");
                return true;
            }

            EngineCoreTimer.Enabled = true;
            SendMessage("Running");
            return false;
        }

        #endregion

        #region StartAutoMarketLoaderThread

        private void StartAutoMarketLoaderThread()
        {
            // Declare the MarketLoader class to be threaded
            var marketLoader = new AutoMarketLoader(
                betfairAPI.GetSessionToken(),
                settings.GetAllMarketsConfiguration,
                settings.StrategyLoadPaterns);

            // Create the thread and start it
            var marketLoaderThread = new Thread(marketLoader.Start);
            marketLoaderThread.Start();

            // Now lets store the thread so that we can access it later
            LigniteEngineThreads.Add("MARKET_LOADER", marketLoaderThread);

            // Notify the user
            SendMessage(String.Format("MARKET_LOADER: Auto Market Loader Thread Started. {0}",
                                      LigniteEngineThreads.Count));
        }

        #endregion

        #region StartMarketProcessorThread

        private void StartMarketProcessorThread(int exchangeId, int marketId, StrategyLoadPatern strategy)
        {
            // Create the ID to use for this item
            var processId = String.Format("MARKET_PROCESSOR:{0}:{1}", exchangeId, marketId);

            if (LigniteEngineThreads.ContainsKey(processId)) return;

            var market = new Market {exchangeId = exchangeId, marketId = marketId};

            // Make sure the requested strategy is complete, if not replace empty elements with the default config
            var defaultPatern = settings.GetDefaultStrategyLoadPatern();

            if (strategy.OnMarketLoadActions == null)
            {
                strategy.OnMarketLoadActions = defaultPatern.OnMarketLoadActions;
            }

            if (strategy.DataLoadPaterns.Default == null)
            {
                strategy.DataLoadPaterns.Default = defaultPatern.DataLoadPaterns.Default;
            }

            if (strategy.DataLoadPaterns.HasBets == null)
            {
                strategy.DataLoadPaterns.HasBets = defaultPatern.DataLoadPaterns.HasBets;
            }

            if (strategy.DataLoadPaterns.HasUnmatchedBets == null)
            {
                strategy.DataLoadPaterns.HasUnmatchedBets = defaultPatern.DataLoadPaterns.HasUnmatchedBets;
            }

            if (strategy.DataLoadPaterns.Inactive == null)
            {
                strategy.DataLoadPaterns.Inactive = defaultPatern.DataLoadPaterns.Inactive;
            }

            if (strategy.DataLoadPaterns.InPlay == null)
            {
                strategy.DataLoadPaterns.InPlay = defaultPatern.DataLoadPaterns.InPlay;
            }

            if (strategy.DataLoadPaterns.Suspended == null)
            {
                strategy.DataLoadPaterns.Suspended = defaultPatern.DataLoadPaterns.Suspended;
            }

            // Declare the MarketLoader class to be threaded
            var marketProcessor = new MarketProcessor(processId, market, strategy);

            // Create the thread and start it
            var marketProcessorThread = new Thread(marketProcessor.Start);
            marketProcessorThread.Start();

            // Now lets store the thread so that we can access it later
            LigniteEngineThreads.Add(processId, marketProcessorThread);

            // Notify the user
            SendMessage(String.Format("New market submitted for processing. ID = {0}", processId));
        }

        #endregion

        #region Helper Methods

        private void SendMessage(string message)
        {
            if (OnNewMessage != null)
                OnNewMessage(this, new NewMessageEventArgs(message));
        }

        #endregion

        #region Load Plugins

        private Dictionary<string, PluginManager> m_plugins;

        public List<LoadedPlugin> LoadedPlugins { get; private set; }

        /// <summary>
        /// Pre load the plugins specified in the configuration file
        /// </summary>
        private void Loadplugins()
        {
            var pluginNames = new List<string>();
            m_plugins = new Dictionary<string, PluginManager>();
            LoadedPlugins = new List<LoadedPlugin>();

            foreach (var patern in settings.StrategyLoadPaterns)
            {
                if (string.IsNullOrEmpty(patern.CustomLibrary) || pluginNames.Contains(patern.CustomLibrary)) continue;
                
                var plugin = new PluginManager(Directory.GetCurrentDirectory() + "\\" + patern.CustomLibrary,
                                               patern.CustomLibraryConfigSection);

                m_plugins.Add(plugin.Settings.id, plugin);

                var item = new LoadedPlugin
                               {
                                   Name = plugin.Settings.Name,
                                   ID = plugin.Settings.id,
                                   HasWinForm = plugin.Settings.hasForm,
                                   Description = plugin.Settings.Description
                               };

                LoadedPlugins.Add(item);
            }
        }

        public class LoadedPlugin
        {
            public string Description;
            public bool HasWinForm;
            public string ID;
            public string Name;
        }

        #endregion

        #region Show Plugin Form and stats

        /// <summary>
        /// Shows the plugin form if the plugin indicated that it supports a form.
        /// </summary>
        /// <param name="pluginId">The plugin id.</param>
        public void ShowPluginForm(string pluginId)
        {
            if (m_plugins.ContainsKey(pluginId))
                m_plugins[pluginId].ShowWinForm();
        }

        #endregion
    }
}