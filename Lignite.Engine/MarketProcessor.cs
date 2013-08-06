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
using System.Reflection;
using System.Threading;
using System.Timers;
using Betfair.Collections;
using Betfair.Utilities;
using Lignite.Configuration;
using Lignite.Engine.Events;
using Vossie.Utilities;
using Runner=Betfair.Utilities.BetfairObjectSync.Runner;

namespace Lignite.Engine
{
    internal class MarketProcessor
    {
        #region Variables

        private readonly Dictionary<string, DateTime> asyncResponsesWaiting;
        private readonly DateTimeCalculations dateTimeCalculations = new DateTimeCalculations();
        private readonly StrategyLoadPatern strategy;
        private string id;
        private Market market;
        private RaceCourseAbreviations raceCourseAbreviations;
        private DateTime requestTime;
        private bool run;
        private DateTime SleepUntill;
        private MarketProcessorThreadStatus status;
        private Plugin.PluginManager plugin;

        public MarketProcessorThreadStatus Status
        {
            get { return status; }
        }

        public RaceCourseAbreviations RaceCourseAbreviations
        {
            get { return raceCourseAbreviations; }
        }

        public string ID
        {
            get
            {
                lock (id)
                {
                    if (id == null)
                    {
                        id = "";
                    }
                    return id;
                }
            }
        }

        public Market Market
        {
            get
            {
                lock (market)
                {
                    return market;
                }
            }
        }

        #endregion

        #region Initialize

        internal MarketProcessor(string id, Market market, StrategyLoadPatern strategy)
        {
            this.id = id;
            this.market = market;
            this.strategy = strategy;

            raceCourseAbreviations = new RaceCourseAbreviations();
            run = false;

            asyncResponsesWaiting = new Dictionary<string, DateTime>();
        }

        #endregion

        #region Start

        internal void Start()
        {
            asyncResponsesWaiting.Clear();
            requestTime = dateTimeCalculations.GetGmtTime();

            // Build initial market view
            UpdateMarket();

            // Update prices etc
            if (strategy.OnMarketLoadActions.GetMarketPrices)
            {
                UpdateMarketPrices(false);
            }
            if (strategy.OnMarketLoadActions.GetMarketPricesComplete)
            {
                UpdateMarketPrices(true);
            }
            if (strategy.OnMarketLoadActions.GetCompleteMarketTradedVolume)
            {
                UpdateTradedVolume();
            }
            if (strategy.OnMarketLoadActions.GetExtendedRunnerInfo)
            {
                UpdateRunnerDisplayDetail();
            }

            // Raise some notification events
            SendMessage(String.Format("Market processor {0} initialized successfully", id));
            MarketUpdatedEvent();

            Core.TimerTick += OnTimedEvent;
            Core.SystemShutdown += OnCloseAllEvent;
            Core.BroadcastMarketThreadState += OnBroadcastThreadState;


            GetDataLoadPatern();

            LoadPlugin();

            ExecuteLoadedCustomStrategyLibrary(dateTimeCalculations.GetGmtTime(), Plugin.PluginManager.PluginBaseMethods.StartUp);

            SetStatus(MarketProcessorThreadStatus.INITIALIZED);

            run = true;
        }

        #endregion

        #region Stop

        internal void Stop()
        {
            requestTime = dateTimeCalculations.GetGmtTime();
            // Close the thread down
            SendMessage(String.Format("Thread {0} closing", id));
            run = false;

            ExecuteLoadedCustomStrategyLibrary(dateTimeCalculations.GetGmtTime(), Plugin.PluginManager.PluginBaseMethods.ShutDown);

            Core.TimerTick -= OnTimedEvent;
            Core.SystemShutdown -= OnCloseAllEvent;
            Core.BroadcastMarketThreadState -= OnBroadcastThreadState;


            raceCourseAbreviations = null;
            plugin = null;
            SetStatus(MarketProcessorThreadStatus.CLOSED);
        }

        private void OnCloseAllEvent(object source, EventArgs e)
        {
            Stop();
        }

        #endregion

        #region OnTimedEvent

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (DateTime.Now >= SleepUntill && run)
            {
                DoWork();
            }
        }

        #endregion

        #region OnBroadcastThreadState

        private void OnBroadcastThreadState(object source, Core.BroadcastMarketThreadStateEventArgs e)
        {
            if (id != e.ThreadProcessId) return;

            MarketUpdatedEvent();
            SetStatus(status);
        }

        #endregion

        #region DoWork

        /// <summary>
        /// Process the market data as described in the configuration file and custom dll
        /// </summary>
        private void DoWork()
        {
            if (market == null) return;

            if (market.removedRunners == null)
                market.removedRunners = new RemovedRunner[0];

            // Pause the timer
            run = false;

            /* Set the loop statement, this allows us to react instantly to
                 * actions required by the client dll, like place bets etc.
                 */
            var loop = true;

            while (loop)
            {
                // Raise some events
                SetStatus(MarketProcessorThreadStatus.WORKING);

                // Get the data frequency patern
                var frequency = GetDataLoadPatern();

                // Calculate the distance in millisecond to the published time to off
                requestTime = dateTimeCalculations.GetGmtTime();
                //var timeToOff = Convert.ToInt32(dateTimeCalculations.CalculteTimeDifference(market.eventDate, true));

                // Do not update prices if the market is closed as there will be none
                if (market.status != MarketStatus.CLOSED)
                {
                    // Update prices & traded volume
                    if (frequency.Actions.GetMarketPrices)
                    {
                        UpdateMarketPrices(false);
                    }
                    if (frequency.Actions.GetMarketPricesComplete)
                    {
                        UpdateMarketPrices(true);
                    }
                    if (frequency.Actions.GetCompleteMarketTradedVolume)
                    {
                        UpdateTradedVolume();
                    }
                    if (frequency.Actions.GetExtendedRunnerInfo)
                    {
                        UpdateRunnerDisplayDetail();
                    }
                }

                // Get the matched and unmatched bets on this market
                if (frequency.Actions.GetBets)
                {
                    /*TODO:*/
                }

                // Call the execute function on the imported client library
                ExecuteLoadedCustomStrategyLibrary(requestTime, Plugin.PluginManager.PluginBaseMethods.Execute);

                // Get the new data frequency patern
                frequency = GetDataLoadPatern();

                // Kill the thread if the following conditions are met
                if (market == null ||
                    frequency == null ||
                    frequency.Actions.TerminateMarketThread ||
                    market.status == MarketStatus.CLOSED)
                {
                    // Close the thread down
                    Stop();
                    //loop = false;
                    return;
                }

                if (market.status != MarketStatus.CLOSED)
                {
                    // Go to sleep
                    SetStatus(MarketProcessorThreadStatus.SLEEPING);
                    loop = false;
                    run = true;
                }

                // notify listeners that we have updated the market data
                if (run)
                    MarketUpdatedEvent();
            }
        }

        #endregion

        #region Get Data Load Frequency Patern To Apply

        private DataLoad GetDataLoadPatern()
        {
            if (strategy != null)
            {
                DataLoad[] paternToSearch;

                #region Load patern from config

                /*** Default ***/
                //if (paternToSearch == null)
                //{
                //    paternToSearch = strategy.DataLoadPaterns.Default;
                //}


                ///*** Has Unmatched Bets ***/
                //else if (market.runners.HasUnMatchedBets && this.strategy.DataLoadPaterns.HasUnMatchedBets != null)
                //{
                //    paternToSearch = this.strategy.DataLoadPaterns.HasUnmatchedBets;
                //}

                /*** Has Bets ***/
                if (market.runnersWithBets.Count > 0 && strategy.DataLoadPaterns.HasBets != null)
                {
                    paternToSearch = strategy.DataLoadPaterns.HasBets;
                }

                    /*** Suspended ***/
                else if (market.status == MarketStatus.SUSPENDED && strategy.DataLoadPaterns.Suspended != null)
                {
                    paternToSearch = strategy.DataLoadPaterns.Suspended;
                }

                    /*** In-Play ***/
                else if (market.inPlay && strategy.DataLoadPaterns.InPlay != null)
                {
                    paternToSearch = strategy.DataLoadPaterns.InPlay;
                }
                else
                {
                    paternToSearch = strategy.DataLoadPaterns.Default;
                }

                #endregion

                /*** Lets start the search ***/
                var actualTimeToOff = new DateTimeCalculations().CalculteTimeDifference(market.eventDate, true);
                var maximumTimeToOff = new DataLoad();

                foreach (var freq in paternToSearch)
                {
                    // Get the greatest distance we can be from the start of the event
                    if (freq.TimeBeforeOff > maximumTimeToOff.TimeBeforeOff)
                    {
                        maximumTimeToOff = freq;
                    }
                }

                var nearestTimeToOff = maximumTimeToOff;

                foreach (var freq in paternToSearch)
                {
                    // Get the nearest near time relative to the current point
                    if (nearestTimeToOff.TimeBeforeOff > freq.TimeBeforeOff &&
                        actualTimeToOff < freq.TimeBeforeOff)
                    {
                        nearestTimeToOff = freq;
                    }
                }

                SleepUntill = DateTime.Now.AddMilliseconds(nearestTimeToOff.Frequency);
                return nearestTimeToOff;
            }

            return null;
        }

        #endregion

        #region Helper Methods

        private void SetStatus(MarketProcessorThreadStatus threadStatus)
        {
            status = threadStatus;

            Broker.Execute(EventNames.MarketProcessorThreadStatusChanged, this,
                           new MarketProcessorThreadStatusChangedEventArgs(id, status));
        }

        private void SendMessage(string message)
        {
            Broker.Execute(EventNames.MarketProcessorMessage, this, new NewMessageEventArgs(message));
        }

        private void SendErrorMessage(string message)
        {
            Broker.Execute(EventNames.MarketProcessorError, this, new NewMessageEventArgs(message));
        }

        private void MarketUpdatedEvent()
        {
            Broker.Execute(EventNames.MarketDataUpdated, this, new MarketDataUpdatedEventArgs(id, market));
        }

        #endregion

        #region UpdateMarket

        private bool UpdateMarket()
        {
            var retryCount = 0;


            while (retryCount < 3)
            {
                try
                {
                    // Get the fresh data from the Betfair API
                    var result = Core.betfairAPI.GetMarketObject(market.exchangeId, market.marketId);
                    if (result != null)
                    {
                        // Lets synchronize the new data with our local Collections.Market object
                        market = new Betfair.Utilities.BetfairObjectSync.Market().BetfairAPIGetMarketRespToMarket(
                            market, result);

                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    retryCount++;
                    
                    SendErrorMessage(String.Format("EXCEPTION: Thread ID:{0} MESSAGE:{1}", ID, ex.Message));

                    Thread.Sleep(10);
                }
            }

            return false;
        }

        #endregion

        #region UpdateMarketPrices

        private bool UpdateMarketPrices(bool completeDepth)
        {
            var retryCount = 0;

            while (retryCount < 3)
            {
                try
                {
                    if (completeDepth)
                    {
                        // Get the fresh data from the Betfair API
                        var result = Core.betfairAPI.GetCompleteMarketPricesCompressedObject(market.exchangeId,
                                                                                                market.marketId,
                                                                                                market.status);
                        if (result != null)
                        {
                            // Lets synchronize the new data with our local Collections.Market object
                            market =
                                new Betfair.Utilities.BetfairObjectSync.Market().CompleteMarketPricessCompressedToMarket
                                    (market, result);
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        // Get the fresh data from the Betfair API
                        var result = Core.betfairAPI.GetMarketPricesCompressedObject(market.exchangeId,
                                                                                        market.marketId);
                        if (result != null)
                        {
                            // Lets synchronize the new data with our local Collections.Market object
                            market =
                                new Betfair.Utilities.BetfairObjectSync.Market().MarketPricessCompressedToMarket(
                                    market, result);
                            return true;
                        }
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    retryCount++;
                    SendErrorMessage(String.Format("EXCEPTION: Thread ID:{0} MESSAGE:{1}", ID, ex.Message));

                    if (retryCount > 3)
                    {
                        return false;
                    }

                    Thread.Sleep(10);
                }
            }
            return false;
        }

        #endregion

        #region UpdateTradedVolume

        private bool UpdateTradedVolume()
        {
            var retryCount = 0;

            while (retryCount < 3)
            {
                try
                {
                    // Get the fresh data from the Betfair API
                    var result = Core.betfairAPI.GetMarketTradedVolumeCompressedObject(market.exchangeId,
                                                                                              market.marketId);
                    if (result != null)
                    {
                        // Lets synchronize the new data with our local Collections.Market object
                        market.runners = new Runner().CompleteTradedVolumeToRunner(market.runners, result);
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    retryCount++;
                    SendErrorMessage(String.Format("EXCEPTION: Thread ID:{0} MESSAGE:{1}", ID, ex.Message));

                    if (retryCount > 3)
                    {
                        return false;
                    }

                    Thread.Sleep(10);
                }
            }
            return false;
        }

        #endregion

        #region UpdateRunnerDisplayDetail

        private bool UpdateRunnerDisplayDetail()
        {
            var retryCount = 0;

            while (retryCount < 3)
            {
                try
                {
                    // Get the fresh data from the Betfair API
                    var result = Core.betfairAPI.GetSilksObject(market.exchangeId, market.marketId);
                    if (result != null)
                    {
                        // Lets synchronize the new data with our local Collections.Market object
                        market.runners =
                            new Betfair.Utilities.BetfairObjectSync.RunnerDisplayDetail().DictionaryToRunnerList(
                                market.runners, result);
                        return true;
                    }
                    return false;
                }

                catch (Exception ex)
                {
                    retryCount++;
                    SendErrorMessage(String.Format("EXCEPTION: Thread ID:{0} MESSAGE:{1}", ID, ex.Message));

                    if (retryCount > 3)
                    {
                        return false;
                    }

                    Thread.Sleep(10);
                }
            }
            return false;
        }

        #endregion

        #region Load Strategy DLLs

        /// <summary>
        /// At the core of this project is the idea of seperating the strategy functions
        /// and Betfair data load etc so that we can (as a community of developers) build
        /// the underlying framework but not necasarily expose our strategies.
        /// This bit of code loads and initializes the guts of what we do.
        /// </summary>
        private void LoadPlugin()
        {
            try
            {
                if(!string.IsNullOrEmpty(strategy.CustomLibrary))
                    plugin = new Plugin.PluginManager(Directory.GetCurrentDirectory() + "\\" + strategy.CustomLibrary, strategy.CustomLibraryConfigSection);
            }
            catch
            {
                SendErrorMessage(
                    "External strategy assembly reference does not exist and will NOT be loaded! Attempted to retrieve from " +
                    plugin.Settings.dllLocation);
            }
        }

        #endregion

        #region ExecuteLoadedCustomStrategyLibrary

        /// <summary>
        /// This function invokes the client libraries if any was specified at load
        /// </summary>
        /// <param name="requestTimeGmt">The request time GMT.</param>
        /// <param name="method">The method.</param>
        private void ExecuteLoadedCustomStrategyLibrary(DateTime requestTimeGmt, Plugin.PluginManager.PluginBaseMethods method)
        {
            try
            {
                if (plugin != null && plugin.Settings.ibaseObject != null)
                {
                    SetStatus(MarketProcessorThreadStatus.WORKING_CLIENT_LIBRARY);


                    // Create the parameter list
                    object[] arguments = null;

                    switch (method)
                    {
                        case Plugin.PluginManager.PluginBaseMethods.StartUp:
                            arguments = new object[] {id, market, requestTimeGmt};
                            break;
                        case Plugin.PluginManager.PluginBaseMethods.Execute:
                            arguments = new object[] {id, market, requestTimeGmt};
                            break;
                        case Plugin.PluginManager.PluginBaseMethods.ShutDown:
                            arguments = new object[] {id, market, requestTimeGmt};
                            break;
                    }

                    // Dynamically Invoke the Object
                    var result = plugin.Settings.type.InvokeMember(method.ToString(),
                                                                       BindingFlags.Default | BindingFlags.InvokeMethod,
                                                                       null,
                                                                       plugin.Settings.ibaseObject,
                                                                       arguments);

                    // Process the results if any
                    if (result.GetType() == typeof (bool))
                    {
                        // Do something
                    }

                    // Process bets
                    var bets = plugin.GetIPluginBasePropertyValue<List<Bet>>(Plugin.PluginManager.PluginBaseProperty.Bets);
                    plugin.SetIPluginBasePropertyValue(Plugin.PluginManager.PluginBaseProperty.Bets, ProcessBetList(bets));

                    SetStatus(MarketProcessorThreadStatus.WORKING);
                }
            }
            catch (Exception ex)
            {
                SendErrorMessage(ex.Message);

                Exception innerException = null;

                if (ex.InnerException != null)
                    innerException = ex.InnerException;

                while (innerException != null)
                {
                    SendErrorMessage(innerException.Message);
                    innerException = innerException.InnerException;
                }
            }
        }
                
        #endregion

        #region Process Bet List

        private List<Bet> ProcessBetList(List<Bet> bets)
        {
            if (bets != null && bets.Count > 0)
            {
                var betGuids = new List<string>();

                foreach (var bet in bets)
                {
                    if (bet.betRequestprocessed) continue;

                    betGuids.Add(bet.betGuidString);
                    SendMessage("New bet " + bet.betGuidString + " for market " + bet.marketId + " selection " +
                                bet.selectionId);
                }

                bets = Core.betfairAPI.PlaceBets(bets);
            }

            return bets;
        }

        #endregion
    }
}