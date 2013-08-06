using System;
using System.ComponentModel;
using System.Drawing;
using Lignite.Controls.Events;

namespace Lignite.Controls
{
    /// <summary>
    /// The Lignite shared event controller is the data path used for 
    /// communication between user controls and parent forms and objects.
    /// </summary>
    [ToolboxBitmap(typeof (EventController))]
    public class EventController : Component
    {
        #region Public Vars

        private string m_uid;

        /// <summary>
        /// Gets the unique instance id for this object.
        /// </summary>
        /// <value>The UID.</value>
        public string UID
        {
            get
            {
                if (m_uid != null) return m_uid;

                UID = Guid.NewGuid().ToString();

                return m_uid;
            }
            private set { m_uid = value; }
        }

        #endregion

        // Thread Processor Events

        public event DisplayMessageEventHandler DisplayMessage;

        /// <summary>
        /// Invokes the display message event. This notifies listening controls that a text message has been sent.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Lignite.Controls.Events.DisplayMessageEventArgs"/> instance containing the event data.</param>
        public virtual void InvokeDisplayMessage(object sender, DisplayMessageEventArgs e)
        {
            if (DisplayMessage != null) DisplayMessage(sender, e);
        }

        public event EventHandler StartDataProcessor;
        
        public event ShowPlaceBetControlEventHandler ShowBetPlacementControl;

        /// <summary>
        /// Invokes the show bet placement control event. This notifies the listsening controls that the operator intends to place a bet on a selection.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Lignite.Controls.Events.ShowPlaceBetControlEventArgs"/> instance containing the event data.</param>
        public virtual void InvokeShowBetPlacementControl(object sender, ShowPlaceBetControlEventArgs e)
        {
            var showBetPlacementControlHandler = ShowBetPlacementControl;
            if (showBetPlacementControlHandler != null) showBetPlacementControlHandler(sender, e);
        }

        //////////////////////////////////////////////////////////////////

        /// <summary>
        /// Invokes the start data processor.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public virtual void InvokeStartDataProcessor(object sender, EventArgs e)
        {
            var startDataProcessorHandler = StartDataProcessor;
            if (startDataProcessorHandler != null) startDataProcessorHandler(sender, e);
        }

        public event EventHandler DataProcessorStarted;

        public virtual void InvokeDataProcessorStarted(object sender, EventArgs e)
        {
            var dataProcessorStartedHandler = DataProcessorStarted;
            if (dataProcessorStartedHandler != null) dataProcessorStartedHandler(sender, e);
        }

        public event EventHandler PauseDataProcessor;

        public virtual void InvokePauseDataProcessor(object sender, EventArgs e)
        {
            var pauseDataProcessorHandler = PauseDataProcessor;
            if (pauseDataProcessorHandler != null) pauseDataProcessorHandler(sender, e);
        }

        public event EventHandler DataProcessorPaused;

        public virtual void InvokeDataProcessorPaused(object sender, EventArgs e)
        {
            var dataProcessorPausedHandler = DataProcessorPaused;
            if (dataProcessorPausedHandler != null) dataProcessorPausedHandler(sender, e);
        }

        public event EventHandler StopDataProcessor;

        public virtual void InvokeStopDataProcessor(object sender, EventArgs e)
        {
            var stopDataProcessorHandler = StopDataProcessor;
            if (stopDataProcessorHandler != null) stopDataProcessorHandler(sender, e);
        }

        public event EventHandler DataProcessorStopped;

        public virtual void InvokeDataProcessorStopped(object sender, EventArgs e)
        {
            var dataProcessorStoppedHandler = DataProcessorStopped;
            if (dataProcessorStoppedHandler != null) dataProcessorStoppedHandler(sender, e);
        }

        public event EventHandler RestartDataProcessor;

        public virtual void InvokeRestartDataProcessor(object sender, EventArgs e)
        {
            var restartDataProcessorHandler = RestartDataProcessor;
            if (restartDataProcessorHandler != null) restartDataProcessorHandler(sender, e);
        }

        public event EventHandler DataProcessorRestarting;

        public virtual void InvokeDataProcessorRestarting(object sender, EventArgs e)
        {
            var dataProcessorRestartingHandler = DataProcessorRestarting;
            if (dataProcessorRestartingHandler != null) dataProcessorRestartingHandler(sender, e);
        }

        public event DataProcessorMarketThreadStatusChangedEventHandler DataProcessorMarketThreadStatusChanged;

        public virtual void InvokeDataProcessorMarketThreadStatusChanged(object sender, DataProcessorMarketThreadStatusChangedEventArgs e)
        {
            var dataProcessorMarketThreadStatusChangedHandler = DataProcessorMarketThreadStatusChanged;
            if (dataProcessorMarketThreadStatusChangedHandler != null)
                dataProcessorMarketThreadStatusChangedHandler(sender, e);
        }

        // Market Events

        public event BroadcastMarketStateRequestEventHandler BroadcastMarketStateRequest;

        public virtual void InvokeBroadcastMarketStateRequest(object sender, BroadcastMarketStateRequestEventArgs e)
        {
            var broadcastMarketStateRequest = BroadcastMarketStateRequest;
            if (broadcastMarketStateRequest != null) broadcastMarketStateRequest(sender, e);
        }

        public event EventHandler MarketDataRequest;

        public virtual void InvokeMarketDataRequest(object sender, EventArgs e)
        {
            var marketDataRequestHandler = MarketDataRequest;
            if (marketDataRequestHandler != null) marketDataRequestHandler(sender, e);
        }

        public event MarketDataUpdateEventHandler MarketDataUpdate;

        public virtual void InvokeMarketDataUpdate(object sender, MarketDataUpdateEventArgs e)
        {
            var marketDataUpdateHandler = MarketDataUpdate;
            if (marketDataUpdateHandler != null) marketDataUpdateHandler(sender, e);
        }

        public event EventHandler MarketStatusChange;

        public virtual void InvokeMarketStatusChange(object sender, EventArgs e)
        {
            var marketStatusChangeHandler = MarketStatusChange;
            if (marketStatusChangeHandler != null) marketStatusChangeHandler(sender, e);
        }

        public event EventHandler RemoveMarket;

        public virtual void InvokeRemoveMarket(object sender, EventArgs e)
        {
            var removeMarketHandler = RemoveMarket;
            if (removeMarketHandler != null) removeMarketHandler(sender, e);
        }

        public event EventHandler RacecardInfoRequest;

        public virtual void InvokeRacecardInfoRequest(object sender, EventArgs e)
        {
            var racecardInfoRequestHandler = RacecardInfoRequest;
            if (racecardInfoRequestHandler != null) racecardInfoRequestHandler(sender, e);
        }

        public event EventHandler RacecardInfoUpdate;

        public virtual void InvokeRacecardInfoUpdate(object sender, EventArgs e)
        {
            var racecardInfoUpdateHandler = RacecardInfoUpdate;
            if (racecardInfoUpdateHandler != null) racecardInfoUpdateHandler(sender, e);
        }

        // Selection specific events

        public event EventHandler PricesUpdateRequest;

        public virtual void InvokePricesUpdateRequest(object sender, EventArgs e)
        {
            var pricesUpdateRequestHandler = PricesUpdateRequest;
            if (pricesUpdateRequestHandler != null) pricesUpdateRequestHandler(sender, e);
        }

        public event EventHandler PricesUpdated;

        public virtual void InvokePricesUpdated(object sender, EventArgs e)
        {
            var pricesUpdatedHandler = PricesUpdated;
            if (pricesUpdatedHandler != null) pricesUpdatedHandler(sender, e);
        }

        // Bet events

        public event EventHandler BetPlacementRequest;

        public virtual void InvokeBetPlacementRequest(object sender, EventArgs e)
        {
            var betPlacementRequestHandler = BetPlacementRequest;
            if (betPlacementRequestHandler != null) betPlacementRequestHandler(sender, e);
        }

        public event EventHandler BetPlacementConfirmation;

        public virtual void InvokeBetPlacementConfirmation(object sender, EventArgs e)
        {
            var betPlacementConfirmationHandler = BetPlacementConfirmation;
            if (betPlacementConfirmationHandler != null) betPlacementConfirmationHandler(sender, e);
        }

        // Account events

        public event EventHandler AccountBalanceRequest;

        public virtual void InvokeAccountBalanceRequest(object sender, EventArgs e)
        {
            var accountBalanceRequestHandler = AccountBalanceRequest;
            if (accountBalanceRequestHandler != null) accountBalanceRequestHandler(sender, e);
        }

        public event EventHandler AccountBalance;

        public virtual void InvokeAccountBalance(object sender, EventArgs e)
        {
            var accountBalanceHandler = AccountBalance;
            if (accountBalanceHandler != null) accountBalanceHandler(sender, e);
        }
    }
}