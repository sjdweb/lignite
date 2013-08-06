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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Betfair.Collections;
using Lignite.Console.Properties;
using Lignite.Controls.Events;
using Lignite.Engine;
using Lignite.Engine.Events;

namespace Lignite.Console
{
    public partial class FormMain : Form
    {
        private static Core ligniteEngine { get; set; }
        private static SimplePlaceBetForm placeBetForm { get; set; }
        
        #region InitializeComponent

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            Text = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute))).Title + " - Version  " +
                   Assembly.GetExecutingAssembly().GetName().Version;

            Icon = Resources.lignite;

            marketViewContainer.ClearMarkets();

            systemStatusMonitor1.Start();
            systemStatusMonitor1.RefreshFeed();

            ligniteEngine = new Core();

            /*** Add event handlers so we know when something changes ***/
            if (__NewMessageEventEventHandler == null)
            {
                __NewMessageEventEventHandler = NewLigniteMessageReceived;
                ligniteEngine.OnNewMessage += __NewMessageEventEventHandler;
            }

            if (__MarketProcessorThreadStatusChangedEventHandler == null)
            {
                __MarketProcessorThreadStatusChangedEventHandler = MarketProcessorThreadStatusChanged;
                ligniteEngine.OnMarketProcessorThreadStatusChanged += __MarketProcessorThreadStatusChangedEventHandler;
            }

            if (__MarketDataUpdatedEventEventHandler == null)
            {
                __MarketDataUpdatedEventEventHandler = MarketDataUpdated;
                ligniteEngine.OnMarketDataUpdated += __MarketDataUpdatedEventEventHandler;
            }


            marketViewContainer.ShowMenuPathInDisplayName = Settings.Default.ShowCompleteMenuPath;
            marketViewContainer.ShowStartingPricesIfAvailable = Settings.Default.ShowBetfairStartingPrices;

            placeBetForm = new SimplePlaceBetForm();
            placeBetForm.Show();
            placeBetForm.Hide();
            placeBetForm.Controller = MasterEventController;

            MasterEventController.BroadcastMarketStateRequest += MasterEventController_BroadcastMarketStateRequest;
        }

        #endregion

        #region Event Handlers

        #region NewLigniteMessageReceived

        // This delegate enables asynchronous calls for setting
        // the text property on a consoleOutput1 control.

        private void NewLigniteMessageReceived(object sender, NewMessageEventArgs e)
        {
            BroadcastMessage(e.message);
        }

        #endregion

        #region MarketProcessorThreadStatusChanged

        private void MarketProcessorThreadStatusChanged(object sender, MarketProcessorThreadStatusChangedEventArgs e)
        {
            try
            {
                if (e.senderID != null)
                {
                    MasterEventController.InvokeDataProcessorMarketThreadStatusChanged(this, new DataProcessorMarketThreadStatusChangedEventArgs{SenderID = e.senderID, Status = e.status.ToString()});
                }
            }
            catch (Exception ex)
            {
                BroadcastMessage("---------------- Exception: Start----------------");
                BroadcastMessage(ex.Message);
                BroadcastMessage(ex.ToString());
                BroadcastMessage("---------------- Exception: End----------------");
            }
        }

        #endregion

        #region MarketDataUpdated

        private void MarketDataUpdated(object sender, MarketDataUpdatedEventArgs e)
        {
            try
            {
                if (marketViewContainer.InvokeRequired)
                {
                    MarketDataUpdatedCallback d = MarketDataUpdated;
                    Invoke(d, new[] {sender, e});
                }
                else
                {
                    if (e != null)
                    {
                        try
                        {
                            MasterEventController.InvokeMarketDataUpdate(this, new MarketDataUpdateEventArgs {SenderID = e.senderID, MarketData = e.market as Market });
                        }
                        catch (Exception ex)
                        {
                            BroadcastMessage(
                                "EXCEPTION: private void MarketDataUpdated(object sender, Lignite.Engine.Events.MarketDataUpdatedEventArgs e)\n" +
                                ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BroadcastMessage(
                    "EXCEPTION: private void MarketDataUpdated(object sender, Lignite.Engine.Events.MarketDataUpdatedEventArgs e)\n" +
                    ex);
            }
        }

        private delegate void MarketDataUpdatedCallback(object sender, MarketDataUpdatedEventArgs e);

        #endregion

        private void MasterEventController_BroadcastMarketStateRequest(object sender, BroadcastMarketStateRequestEventArgs e)
        {
            ligniteEngine.ReBroadcastMarketThreadState(e.ThreadProcessId);
        }

        #endregion

        #region Application Variables

        private bool _started;

        #endregion

        #region Start Stop button click

        private void tsButtonStartStop_Click(object sender, EventArgs e)
        {
            if (_started)
            {
                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to STOP the system?\n\nNote: Stopping the system will kill all current threads and\nclear all cached data.",
                        "Stop system?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _started = false;
                    tsButtonStartStop.Image = Resources.bullet_triangle_blue;
                    tsButtonStartStop.Text = "Stopping...";
                    StopLigniteEngine();
                    tsButtonStartStop.Text = "Click to start";

                    startEngineToolStripMenuItem.Enabled = true;
                    nicmStart.Enabled = true;
                    stopEngineToolStripMenuItem.Enabled = false;
                    nicmStop.Enabled = false;
                    pauseEngineToolStripMenuItem.Enabled = false;
                    nicmPause.Enabled = false;
                    tsButtonPause.Enabled = false;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to START the system?", "Start System?",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _started = true;
                    tsButtonStartStop.Image = Resources.bullet_triangle_yellow;
                    tsButtonStartStop.Text = "Starting...";
                    StartLigniteEngine();
                    tsButtonStartStop.Image = Resources.bullet_square_red;
                    tsButtonStartStop.Text = "Running";

                    startEngineToolStripMenuItem.Enabled = false;
                    nicmStart.Enabled = false;
                    stopEngineToolStripMenuItem.Enabled = true;
                    nicmStop.Enabled = true;
                    pauseEngineToolStripMenuItem.Enabled = true;
                    nicmPause.Enabled = true;
                    tsButtonPause.Enabled = true;
                }
            }
        }

        private void startEngineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_started)
            {
                tsButtonStartStop_Click(null, null);
            }
        }

        private void stopEngineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_started)
            {
                tsButtonStartStop_Click(null, null);
            }
        }

        private void pauseEngineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ligniteEngine.PauseEngine())
            {
                tsButtonPause.Text = "Paused...";
                tsButtonPause.Image = Resources.pause_blue;
                nicmPause.Image = Resources.pause_blue;
            }
            else
            {
                tsButtonPause.Text = "Pause";
                tsButtonPause.Image = Resources.pause_grey;
                nicmPause.Image = Resources.pause_grey;
            }
        }

        #endregion

        #region Start Stop Lignite engine

        private MarketDataUpdatedEventEventHandler __MarketDataUpdatedEventEventHandler;
        private MarketProcessorThreadStatusChangedEventHandler __MarketProcessorThreadStatusChangedEventHandler;
        private NewMessageEventEventHandler __NewMessageEventEventHandler;

        private void StartLigniteEngine()
        {
            try
            {
                BroadcastMessage("");
                BroadcastMessage("#######################################################");
                BroadcastMessage(" STARTING LIGNITE ENGINE");
                BroadcastMessage("#######################################################");
                marketViewContainer.ClearMarkets();

                /*** Start the engine ***/
                ligniteEngine.Start();

                /*** Update the status strip ***/
                statusStripMain.Items["tsLabelLoggedInAs"].Text = ligniteEngine.GetLoggedInUsername;
            }
            catch (Exception ex)
            {
                BroadcastMessage("EXCEPTION: private void StartLigniteEngine()\n");
                BroadcastMessage("Message:" + ex.Message);
                BroadcastMessage("Source:" + ex.Source);
                BroadcastMessage("StackTrace:" + ex.StackTrace);
                BroadcastMessage("All:" + ex);
                StopLigniteEngine();
            }
        }

        private void StopLigniteEngine()
        {
            try
            {
                BroadcastMessage("");
                BroadcastMessage("#######################################################");
                BroadcastMessage(" STOPPING LIGNITE ENGINE");
                BroadcastMessage("#######################################################");

                /*** Hide all market dependant controls ***/
                SendControlResizedEvent();

                /*** Stop the engine core processor ***/
                ligniteEngine.Stop();

                ////ligniteEngine.OnNewMessage -= __NewMessageEventEventHandler;
                ////ligniteEngine.OnMarketProcessorThreadStatusChanged -= __MarketProcessorThreadStatusChangedEventHandler;
                ////ligniteEngine.OnMarketDataUpdated -= __MarketDataUpdatedEventEventHandler;

                statusStripMain.Items["tsLabelLoggedInAs"].Text = "Not logged in...";
            }
            catch (Exception ex)
            {
                BroadcastMessage("-----------Exception-----------");
                BroadcastMessage("Message:" + ex.Message);
                BroadcastMessage("Source:" + ex.Source);
                BroadcastMessage("StackTrace:" + ex.StackTrace);
                BroadcastMessage("All:" + ex);
                BroadcastMessage("-----------Exception-----------");
            }
        }

        #endregion

        #region Exit and Close

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopLigniteEngine();
            Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopLigniteEngine();
        }

        #endregion

        #region Timer tick

        private void timerMain_Tick(object sender, EventArgs e)
        {
            try
            {
                statusStripMain.Items["tsLabelCurrentDateTime"].Text = DateTime.Now.ToString("HH:mm:ss - dd MMMM yyyy");
            }
            catch (Exception ex)
            {
                BroadcastMessage("EXCEPTION: private void timerMain_Tick(object sender, EventArgs e)\n" + ex);
            }
        }

        #endregion

        #region Licence

        private void licenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var licence = new License();
            licence.ShowDialog();
        }

        #endregion

        #region Configuration Editor

        private void mainConfigurationFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string exe = Directory.GetCurrentDirectory() + "\\Lignite.ConfigurationEditor.exe";
            Process.Start(exe);
        }

        #endregion

        #region View

        private void showMenuPathInDisplayNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowCompleteMenuPath = showMenuPathInDisplayNameToolStripMenuItem.Checked;
            Settings.Default.Save();

            marketViewContainer.ShowMenuPathInDisplayName = showMenuPathInDisplayNameToolStripMenuItem.Checked;
        }

        private void showTheBetfairStartingPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowBetfairStartingPrices = showTheBetfairStartingPriceToolStripMenuItem.Checked;
            Settings.Default.Save();

            marketViewContainer.ShowStartingPricesIfAvailable = showTheBetfairStartingPriceToolStripMenuItem.Checked;
        }

        #endregion

        #region HelperMethods

        private void SendControlResizedEvent()
        {
            //Broker.Execute(EventNames.ControlResized, this, null);
        }

        #endregion

        #region FormMain_SizeChanged

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            SendControlResizedEvent();
        }

        #endregion

        #region About

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutLignite().ShowDialog();
        }

        #endregion

        #region MinimizeToSystemTray

        private void minimizeToSystemTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.MinimizeToSystemTray = minimizeToSystemTrayToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (!Settings.Default.MinimizeToSystemTray) return;
            if (WindowState != FormWindowState.Minimized) return;

            WindowState = FormWindowState.Normal;
            Hide();
        }

        private void ligniteNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (Visible)
            {
                BringToFront(); 
                return;
            }

            WindowState = FormWindowState.Normal;
            Visible = true;
            Activate();
            Show();
        }

        private void nicmShowHideConsole_Click(object sender, EventArgs e)
        {
            ligniteNotifyIcon_DoubleClick(this, null);
        }

        #endregion

        #region BroadcastMessage

        /// <summary>
        /// Broadcasts the message to listening Lignite controls.
        /// </summary>
        /// <param name="message">The message.</param>
        private void BroadcastMessage(string message)
        {
            MasterEventController.InvokeDisplayMessage(this, new DisplayMessageEventArgs { SenderUID = MasterEventController.UID, Message = message });
        }

        #endregion
    }
}