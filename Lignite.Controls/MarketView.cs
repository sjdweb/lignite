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
using System.Drawing;
using System.Windows.Forms;
using Betfair.Collections;
using Lignite.Controls.Properties;
using Vossie.Utilities;
using Lignite.Controls.Events;

namespace Lignite.Controls
{
    [ToolboxBitmap(typeof (MarketView))]
    public partial class MarketView : UserControl, IUserControl
    {
        #region Initialize

        public MarketView()
        {
            InitializeComponent();
            panelSelectionViewControls.HeightChanged += panelSelectionViewControls_Resize;
            ControlOrdering = 0;
            ThreadStatus = "";
            toolTipMarketThreadControl.SetToolTip(panelStatusIcon," Yellow:\tSleeping \n Green:\tWorking \n Blue:\tWorking custom strategy dll \n Grey:\tInitialized and waiting to wake up");
        }

        #endregion

        #region Implementation of IUserControl

        /// <summary>
        /// The Lignite control controller is the data path used for communication between controls and the parent form
        /// </summary>
        public EventController Controller
        {
            get { return eventController; }
            set
            {
                if (eventController == value) return;

                eventController.DataProcessorMarketThreadStatusChanged -=
                    eventController_DataProcessorMarketThreadStatusChanged;
                eventController.MarketDataUpdate -= eventController_MarketDataUpdate;

                eventController = value;

                eventController.DataProcessorMarketThreadStatusChanged +=
                    eventController_DataProcessorMarketThreadStatusChanged;
                eventController.MarketDataUpdate += eventController_MarketDataUpdate;

                panelSelectionViewControls.Controller = value;
            }
        }

        /// <summary>
        /// Gets the unique instance id for this object.
        /// </summary>
        /// <value>The unique instance ID.</value>
        public string UniqueInstanceID
        {
            get
            {
                if (m_uniqueInstanceID != null) return m_uniqueInstanceID;

                m_uniqueInstanceID = Guid.NewGuid().ToString();

                return m_uniqueInstanceID;
            }
        }

        #endregion

        #region Variables

        private string m_uniqueInstanceID;
        private bool m_isMaximized = true;
        [NonSerialized] private Market m_market;
        private bool m_maximizeMinimizeEnabled = true;
        private bool m_showStartingPricesIfAvailable = true;
        private bool m_showMenuPathInDisplayName;
        private int m_controlNumber;
        private string m_threadStatus;

        /// <summary>
        /// Gets or sets the market thread processor id this instance is linked to.
        /// </summary>
        /// <value>The thread processor id.</value>
        public string ThreadProcessorId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [maximize minimize is enabled].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [maximize is minimize enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool MaximizeMinimizeEnabled
        {
            get
            {
                return m_maximizeMinimizeEnabled;
            }
            set
            {
                // Do nothing if there is no change
                if(value == m_maximizeMinimizeEnabled) return;
                m_maximizeMinimizeEnabled = value;
                m_isMaximized = true;
                SetPanelRight();
            }
        }

        /// <summary>
        /// The controls maximized state
        /// </summary>
        public bool IsMaximized
        {
            get
            {
                return m_isMaximized;
            }
            set
            {
                // Do nothing if there is no change
                if (m_isMaximized == value) return;
                if (!m_maximizeMinimizeEnabled) return;

                m_isMaximized = value;

                UpdateDynamicControlData();

                SetPanelRight();
            }
        }

        /// <summary>
        /// Display the complete menu tree in the market name label
        /// </summary>
        public bool ShowMenuPathInDisplayName
        {
            get { return m_showMenuPathInDisplayName; }
            set
            {
                // Do nothing if there is no change
                if (m_showMenuPathInDisplayName == value) return;
                m_showMenuPathInDisplayName = value;
                SetLabelMarketName();                
            }
        }

        /// <summary>
        /// Gets or sets the market.
        /// </summary>
        /// <value>The market.</value>
        public Market MarketData
        {
            get
            {
                return m_market;
            }
            set
            {
                // There is no data to display so lets reset all the controls
                if (value == null)
                {
                    panelLeft.BackgroundImage = Resources.ThreadControlBackgroundLeft;
                    lblMarketName.Text = "";
                    lblEventDate.Text = "";
                    lblTimeToStart.Text = "";
                    lblTimeToStart.Text = "";
                    lblMenuPath.Text = "";
                    lblTotalMatchedAmount.Text = "";
                    lblSelections.Text = "";
                    lblBackOverRound.Text = "";
                    lblLayOverRound.Text = "";
                    lblStartingPriceLabel.Visible = false;
                    panelStatusIcon.BackgroundImage = Resources.bullet_ball_glass_grey;
                    panelSelectionViewControls.Clear();
                    ControlOrdering = 0;
                    ThreadStatus = "";

                    m_market = null;
                    return;
                }

                // This is a new market so we need to load the static meta data
                if (m_market == null ||
                    m_market.marketId != value.marketId ||
                    m_market.exchangeId != value.exchangeId ||
                    m_market.currency != value.currency ||
                    m_market.bspMarket != value.bspMarket)
                {
                    m_market = value;

                    SetLabelMarketName();
                    SetLabelStartingPrice();
                    SetEventDate();
                    SetMenuPath();

                    panelSelectionViewControls.Clear();
                    panelSelectionViewControls.IsBSPMarket = m_market.bspMarket;
                    panelSelectionViewControls.Currency = m_market.currency;
                    panelSelectionViewControls.ExchangeId = m_market.exchangeId;
                    panelSelectionViewControls.MarketId = m_market.marketId;
                    panelSelectionViewControls.ShowStartingPricesIfAvailable = ShowStartingPricesIfAvailable;
                }

                // Update the dynamic market data
                if (m_market != value) m_market = value;

                UpdateDynamicControlData();
            }
        }

        /// <summary>
        /// Display the Betfair starting prices if this is a BSP market
        /// </summary>
        public bool ShowStartingPricesIfAvailable
        {
            get { return m_showStartingPricesIfAvailable; }
            set
            {
                if (m_showStartingPricesIfAvailable == value) return;

                m_showStartingPricesIfAvailable = value;

                panelSelectionViewControls.ShowStartingPricesIfAvailable = m_showStartingPricesIfAvailable;
                
                SetLabelStartingPrice();
            }
        }

        /// <summary>
        /// Gets or sets the control number. This is the count in the top left of the control
        /// </summary>
        /// <value>The control number.</value>
        public int ControlOrdering
        {
            get { return m_controlNumber; }
            set
            {
                if (m_controlNumber == value) return;

                m_controlNumber = value;
                lblNumberingId.Text = value == 0 ? "" : value.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the thread status.
        /// </summary>
        /// <value>The thread status.</value>
        public string ThreadStatus
        {
            get
            {
                return m_threadStatus;
            }
            set
            {
                if (m_threadStatus == value) return;

                m_threadStatus = value;
                SetThreadStatus(m_threadStatus);
            }
        }

        #endregion

        #region Update Reset

        /// <summary>
        /// Resets the control data.
        /// </summary>
        public void ResetControl()
        {
            ThreadProcessorId = "";
            MarketData = null;
        }

        /// <summary>
        /// Resets the control data.
        /// </summary>
        public void AutoUpdateControl()
        {
            if(String.IsNullOrEmpty(ThreadProcessorId)) return;

            MarketData = null;
            Controller.InvokeBroadcastMarketStateRequest(this, new BroadcastMarketStateRequestEventArgs{ThreadProcessId = ThreadProcessorId});
        }

        /// <summary>
        /// Resets the control data.
        /// </summary>
        public void UpdateControl(Market market)
        {
            MarketData = market;
        }

        /// <summary>
        /// Updates the dynamic control data.
        /// </summary>
        public void UpdateDynamicControlData()
        {
            if (MarketData == null) return;

            SetTimeToStart();
            SetPanelLeft();
            SetLabelStartingPrice();

            if (!IsMaximized) return;

            SetMatchedAmount();
            SetNumberOfSelections();
            SetOverround();
            panelSelectionViewControls.UpdateSelections(m_market.runners);

            if (m_market.marketInformation != null &&
                toolTipMarketThreadControl.GetToolTip(lblMarketName) != (m_market.marketInformation).Replace("<br>", "\n"))
            {
                toolTipMarketThreadControl.SetToolTip(lblMarketName, (m_market.marketInformation).Replace("<br>", "\n"));
            }
        }

        #endregion

        #region SetPanelLeft

        /// <summary>
        /// Sets the panel on the top most left of the control.
        /// </summary>
        private void SetPanelLeft()
        {
            if (MarketData == null && panelLeft.BackgroundImage != Resources.ThreadControlBackgroundLeft)
            {
                panelLeft.BackgroundImage = Resources.ThreadControlBackgroundLeft;
                return;
            }
            if (MarketData == null)
            {
                return;
            }

            /*** Update the market status images on the control ***/
            if (MarketData.status != MarketStatus.ACTIVE)
            {
                if (MarketData.status == MarketStatus.CLOSED &&
                    panelLeft.BackgroundImage != Resources.ThreadControlBackgroundLeftClosed)
                {
                    panelLeft.BackgroundImage = Resources.ThreadControlBackgroundLeftClosed;
                }
                else if (MarketData.status == MarketStatus.INACTIVE &&
                         panelLeft.BackgroundImage != Resources.ThreadControlBackgroundLeftInactive)
                {
                    panelLeft.BackgroundImage = Resources.ThreadControlBackgroundLeftInactive;
                }
                else if (MarketData.status == MarketStatus.SUSPENDED &&
                         panelLeft.BackgroundImage != Resources.ThreadControlBackgroundLeftSuspended)
                {
                    panelLeft.BackgroundImage = Resources.ThreadControlBackgroundLeftSuspended;
                }
            }
            else
            {
                if (MarketData.inPlay &&
                    panelLeft.BackgroundImage != Resources.ThreadControlBackgroundLeftInPlay)
                {
                    panelLeft.BackgroundImage = Resources.ThreadControlBackgroundLeftInPlay;
                }
                else if (panelLeft.BackgroundImage != Resources.ThreadControlBackgroundLeft
                         && panelLeft.BackgroundImage != Resources.ThreadControlBackgroundLeft)
                {
                    panelLeft.BackgroundImage = Resources.ThreadControlBackgroundLeft;
                }
            }
        }

        #endregion

        #region SetPanelRight

        /// <summary>
        /// Sets the panel right to indicate whether the control is maximized or minimized.
        /// </summary>
        private void SetPanelRight()
        {
            if (!IsMaximized && MaximizeMinimizeEnabled) // Minimize the control
            {
                Height = 29;
                panelRight.BackgroundImage = Resources.ThreadControlBackgroundRight;
            }
            else // Maximize the control
            {
                Height = (26 + 54) + (panelSelectionViewControls.Height);

                panelRight.BackgroundImage = MaximizeMinimizeEnabled ? Resources.ThreadControlBackgroundRightUp : Resources.ThreadControlBackgroundRightBlank;
            }
        }

        #endregion

        #region SetLabelMarketName

        /// <summary>
        /// Sets the name of the label market.
        /// </summary>
        public void SetLabelMarketName()
        {
            if (MarketData != null && MarketData.name != null)
            {
                if (ShowMenuPathInDisplayName && lblMarketName.Text != MarketData.fullName)
                {
                    lblMarketName.Text = MarketData.fullName;
                }
                else if (!ShowMenuPathInDisplayName && lblMarketName.Text != MarketData.partialFullName)
                {
                    lblMarketName.Text = MarketData.partialFullName;
                }
            }
            else if (lblMarketName.Text != "") lblMarketName.Text = "";
        }

        #endregion

        #region SetLabelStartingPrice

        /// <summary>
        /// Sets the label starting price.
        /// </summary>
        private void SetLabelStartingPrice()
        {
            if (MarketData == null) return;


            if ((!ShowStartingPricesIfAvailable && lblStartingPriceLabel.Visible) ||
                (!MarketData.bspMarket && lblStartingPriceLabel.Visible))
            {
                lblStartingPriceLabel.Visible = false;
            }
            else
            {
                if (ShowStartingPricesIfAvailable &&
                    !lblStartingPriceLabel.Visible &&
                    MarketData.bspMarket)
                {
                    lblStartingPriceLabel.Visible = true;
                }
            }

            if (lblStartingPriceLabel.Visible)
            {
                if (lblStartingPriceLabel.Width > 75 && MarketData.inPlay)
                {
                    lblStartingPriceLabel.Width = 75;
                    if (lblStartingPriceLabel.BackColor != Color.Gainsboro) lblStartingPriceLabel.BackColor = Color.Gainsboro;
                }

                if (lblStartingPriceLabel.Width < 185 && !MarketData.inPlay)
                {
                    lblStartingPriceLabel.Width = 185;
                    if (lblStartingPriceLabel.BackColor != Color.White) lblStartingPriceLabel.BackColor = Color.White;
                }
            }
        }

        #endregion

        #region SetTimeToStart

        /// <summary>
        /// This will update the display colours accordingly to make the data more readable
        /// </summary>
        private void SetTimeToStart()
        {
            if (MarketData == null) return;

            var span = MarketData.eventDate -
                       DateTime.Now.AddMilliseconds(((new DateTimeCalculations().GetGmtOffset())*(-1)));

            if (MarketData.status != MarketStatus.ACTIVE)
            {
                if (lblTimeToStart.ForeColor != Color.MistyRose)
                {
                    lblTimeToStart.ForeColor = Color.MistyRose;
                    lblMarketName.ForeColor = lblTimeToStart.ForeColor;
                    lblEventDate.ForeColor = lblTimeToStart.ForeColor;
                    lblNumberingId.ForeColor = lblTimeToStart.ForeColor;
                }
            }
            else if (MarketData.inPlay)
            {
                // In-Play Green = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))))
                if (lblTimeToStart.ForeColor != Color.FromArgb(((((176)))), ((((227)))), ((((0))))))
                {
                    lblTimeToStart.ForeColor = Color.FromArgb(((((176)))), ((((227)))), ((((0)))));
                    lblMarketName.ForeColor = lblTimeToStart.ForeColor;
                    lblEventDate.ForeColor = lblTimeToStart.ForeColor;
                    lblNumberingId.ForeColor = lblTimeToStart.ForeColor;
                }
            }
            else if (span.TotalMilliseconds < 0)
            {
                if (lblTimeToStart.ForeColor != Color.Orange)
                {
                    lblTimeToStart.ForeColor = Color.Orange;
                    lblMarketName.ForeColor = lblTimeToStart.ForeColor;
                    lblEventDate.ForeColor = lblTimeToStart.ForeColor;
                    lblNumberingId.ForeColor = lblTimeToStart.ForeColor;
                }
            }
            else if (span.TotalMilliseconds <= 300000)
            {
                if (lblTimeToStart.ForeColor != Color.Gold)
                {
                    lblTimeToStart.ForeColor = Color.Gold;
                    lblMarketName.ForeColor = lblTimeToStart.ForeColor;
                    lblEventDate.ForeColor = lblTimeToStart.ForeColor;
                    lblNumberingId.ForeColor = lblTimeToStart.ForeColor;
                }
            }
            else
            {
                if (lblTimeToStart.ForeColor != Color.White)
                {
                    lblTimeToStart.ForeColor = Color.White;
                    lblMarketName.ForeColor = lblTimeToStart.ForeColor;
                    lblEventDate.ForeColor = lblTimeToStart.ForeColor;
                    lblNumberingId.ForeColor = lblTimeToStart.ForeColor;
                }
            }

            if (span.TotalMilliseconds >= 0)
            {
                if (span.Days > 0 || span.Days < 0)
                {
                    lblTimeToStart.Text = String.Format("{0}:{1:00}:{2:00}:{3:00}", span.Days, span.Hours,
                                                        span.Minutes, span.Seconds);
                }
                else
                {
                    lblTimeToStart.Text = String.Format("{0:00}:{1:00}:{2:00}", span.Hours, span.Minutes,
                                                        span.Seconds);
                }
            }
            else
            {
                if (span.Days > 0 || span.Days < 0)
                {
                    //this.lblTimeToStart.Text = String.Format("- {0}:{1:00}:{2:00}:{3:00}", (span.Hours * -1), (span.Minutes * -1), (span.Seconds * -1));
                    lblTimeToStart.Text = String.Format("-{0:00}:{1:00}:{2:00}", (span.Hours*-1), (span.Minutes*-1),
                                                        (span.Seconds*-1));
                }
                else
                {
                    lblTimeToStart.Text = String.Format("-{0:00}:{1:00}:{2:00}", (span.Hours*-1), (span.Minutes*-1),
                                                        (span.Seconds*-1));
                }
            }
        }

        #endregion

        #region SetThreadStatus

        /// <summary>
        /// Sets the thread status.
        /// </summary>
        /// <param name="status">The status.</param>
        private void SetThreadStatus(string status)
        {
            if (String.IsNullOrEmpty(status)) status = "";

            switch (status)
            {
                case "CLOSED":
                    {
                        panelStatusIcon.BackgroundImage = Resources.bullet_ball_glass_grey;
                        break;
                    }

                case "INITIALIZED":
                    {
                        panelStatusIcon.BackgroundImage = Resources.bullet_ball_glass_grey;
                        break;
                    }

                case "SLEEPING":
                    {
                        panelStatusIcon.BackgroundImage = Resources.bullet_ball_glass_yellow;
                        break;
                    }

                case "WORKING":
                    {
                        panelStatusIcon.BackgroundImage = Resources.bullet_ball_glass_green;
                        break;
                    }

                case "WORKING_CLIENT_LIBRARY":
                    {
                        panelStatusIcon.BackgroundImage = Resources.bullet_ball_blue;
                        break;
                    }
                default:
                    {
                        panelStatusIcon.BackgroundImage = Resources.bullet_ball_glass_grey;
                        break;
                    }
            }
        }

        #endregion

        #region SetEventDate

        /// <summary>
        /// Sets the event date.
        /// </summary>
        private void SetEventDate()
        {
            if(MarketData == null) return;

            lblEventDate.Text =  m_market.eventDate.AddMilliseconds(new DateTimeCalculations().GetGmtOffset()).ToString("yy-MM-dd HH:mm");
        }

        #endregion

        #region SetMenuPath

        private void SetMenuPath()
        {
            if(MarketData == null) return;

            if (lblMenuPath.Text != "" && m_market.menuPath == null)
            {
                lblMenuPath.Text = "";
                return;
            }

            if (lblMenuPath.Text != m_market.menuPath)
                lblMenuPath.Text = m_market.menuPath;
        }

        #endregion

        #region SetMatchedAmount

        private void SetMatchedAmount()
        {
            if(MarketData == null) return;

            var text = String.Format("Matched: {0} {1:0,0}", Helpers.GetCurrencySymbol(MarketData.currency),
                                                       Math.Round(MarketData.totalAmountMatched));

            if( lblTotalMatchedAmount.Text != text)
            {
                lblTotalMatchedAmount.Text = text;
            }
        }

        #endregion

        #region SetOverround

        private void SetOverround()
        {
            if (MarketData == null) return;

            var overroundbackSide = MarketData.overRoundBackSide;

            if (overroundbackSide == 0)
            {
                lblLayLabel.Text = "";
            }
            else
            {
                lblBackOverRound.Text = Math.Round(overroundbackSide, 1) + "%";
            }

            var overroundLaySide = MarketData.overRoundLaySide;
            if (overroundLaySide == 0)
            {
                lblLayOverRound.Text = "";
            }
            else
            {
                lblLayOverRound.Text = Math.Round(overroundLaySide, 1) + "%";
            }
        }

        #endregion

        #region SetNumberOfSelections

        private void SetNumberOfSelections()
        {
            if (MarketData == null) return;

            if (lblSelections.Text != MarketData.numberOfRunners.ToString())
            {
                lblSelections.Text = "Selections(" + MarketData.numberOfRunners + ")";
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Handles the Click event of the panelRight control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void panelRight_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor; 
            SuspendLayout();

            IsMaximized = !IsMaximized;
            Focus();

            ResumeLayout(true);
            Cursor = Cursors.Arrow; 
        }

        /// <summary>
        /// Handles the Click event of the topBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void topBar_Click(object sender, EventArgs e)
        {
            Focus();
        }

        /// <summary>
        /// Handles the LinkClicked event of the lblMenuPath control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lblMenuPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MarketData == null) return;

            Cursor = Cursors.WaitCursor;

            try
            {
                Process.Start(String.Format("http://sports.betfair.com/Index.do?mi={0}&ex={1}", MarketData.marketId,
                                                MarketData.exchangeId));
            }
            finally
            {
                Cursor = Cursors.Arrow; 
            }
        }

        /// <summary>
        /// Handles the MarketDataUpdate event of the eventController control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void eventController_MarketDataUpdate(object sender, MarketDataUpdateEventArgs e)
        {
            if (InvokeRequired)
            {
                if (e != null)
                {
                    eventController_MarketDataUpdateCallback d = eventController_MarketDataUpdate;
                    BeginInvoke(d, new[] { sender, e });
                }
            }

            if (e == null) return;
            if(ThreadProcessorId != e.SenderID) return;
            
            MarketData = e.MarketData;
        }

        private delegate void eventController_MarketDataUpdateCallback(object sender, MarketDataUpdateEventArgs e);

        /// <summary>
        /// Handles the DataProcessorMarketThreadStatusChanged event of the eventController control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void eventController_DataProcessorMarketThreadStatusChanged(object sender, DataProcessorMarketThreadStatusChangedEventArgs e)
        {
            if(InvokeRequired)
            {
                MarketThreadStatusChangedEventDelegate d = eventController_DataProcessorMarketThreadStatusChanged;
                BeginInvoke(d, new[] {sender, e});
            }
            else
            {
                if (e.SenderID != ThreadProcessorId) return;
                ThreadStatus = e.Status;
            }
        }

        private delegate void MarketThreadStatusChangedEventDelegate(object sender, DataProcessorMarketThreadStatusChangedEventArgs e);

        /// <summary>
        /// Handles the Resize event of the panelSelectionViewControls control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void panelSelectionViewControls_Resize(object sender, EventArgs e)
        {
            if(IsMaximized) SetPanelRight();
        }

        #endregion

        #region Nested type: SelectionViewsPanel

        public class SelectionViewsPanel : Panel
        {
            private bool m_isBSPMarket { get; set; }
            private bool m_showStartingPricesIfAvailable = true;

            /// <summary>
            /// Gets or sets the currency.
            /// </summary>
            /// <value>The currency.</value>
            public string Currency { get; set; }

            /// <summary>
            /// Gets or sets the exchange id.
            /// </summary>
            /// <value>The exchange id.</value>
            public int ExchangeId { get; set; }

            /// <summary>
            /// Gets or sets the market id.
            /// </summary>
            /// <value>The market id.</value>
            public int MarketId { get; set; }

            /// <summary>
            /// Gets or sets the event controller.
            /// </summary>
            /// <value>The controller.</value>
            public EventController Controller { get; set; }


            /// <summary>
            /// Gets or sets a value indicating whether [show starting prices if available].
            /// </summary>
            /// <value>
            /// 	<c>true</c> if [show starting prices if available]; otherwise, <c>false</c>.
            /// </value>
            public bool ShowStartingPricesIfAvailable
            {
                get 
                { 
                    return m_showStartingPricesIfAvailable; 
                }
                set
                {
                    if (m_showStartingPricesIfAvailable == value) return;

                    m_showStartingPricesIfAvailable = value;
                    foreach (SelectionView item in Controls) item.ShowStartingPricesIfAvailable = value;
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is a BSP market.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance is BSP market; otherwise, <c>false</c>.
            /// </value>
            public bool IsBSPMarket
            {
                get { return m_isBSPMarket; }
                set
                {
                    m_isBSPMarket = value;
                    foreach (SelectionView item in Controls) item.IsBSPMarket = value;
                }
            }
            
            /// <summary>
            /// Adds the specified selection.
            /// </summary>
            /// <param name="selection">The selection.</param>
            private void Add(Selection selection)
            {
                if (selection == null) return;
                if (selection.selectionId <= 0 && selection.asianLineId <= 0) return;

                var key = String.Format("SID:{0}AID:{1}", selection.selectionId, selection.asianLineId);

                if (Controls.ContainsKey(key) && Controls[key].GetType() == typeof (SelectionView))
                {
                    var selectionViewControl = (SelectionView) Controls[key];

                    selectionViewControl.SelectionData = selection;
                    selectionViewControl.RefreshControlPrices();
                }
                else
                {
                    var selectionViewControl = new SelectionView
                                                   {
                                                       Name = key,
                                                       MarketId = MarketId,
                                                       ExchangeId = ExchangeId,
                                                       Currency = Currency,
                                                       ShowStartingPricesIfAvailable = ShowStartingPricesIfAvailable,
                                                       IsBSPMarket = IsBSPMarket,
                                                       SelectionData = selection,
                                                       Dock = DockStyle.Top
                                                   };

                    selectionViewControl.RefreshControl();

                    if (Controller != null) selectionViewControl.Controller = Controller;

                    Controls.Add(selectionViewControl);
                    selectionViewControl.BringToFront();
                }

                Height = Controls.Count*40;
            }

            /// <summary>
            /// Adds a range of selections.
            /// </summary>
            /// <param name="selections">The selections.</param>
            public void AddRange(SelectionList selections)
            {
                var height = Height;

                foreach (Selection item in selections)
                {
                    Add(item);
                }

                if (height != Height) InvokeHeightChanged();
            }

            /// <summary>
            /// Updates the selections.
            /// </summary>
            /// <param name="selections">The selections.</param>
            public void UpdateSelections(SelectionList selections)
            {
                AddRange(selections);
            }

            /// <summary>
            /// Gets the selection views count.
            /// </summary>
            /// <value>The selection views count.</value>
            public int SelectionViewsCount
            {
                get
                {
                    return Controls.Count;
                }
            }

            /// <summary>
            /// Clears this instance.
            /// </summary>
            public void Clear()
            {
                var height = Height;

                MarketId = 0;
                ExchangeId = 0;
                Currency = "";
                Controls.Clear();
                Height = Controls.Count * 40;

                if (height != Height) InvokeHeightChanged();
                
            }

            /// <summary>
            /// Occurs when the panel height changed.
            /// </summary>
            public event EventHandler HeightChanged;

            /// <summary>
            /// Invokes the height changed event.
            /// </summary>
            private void InvokeHeightChanged()
            {
                if(HeightChanged == null) return;
                HeightChanged(this,new EventArgs());
            }
        }

        #endregion
    }
}