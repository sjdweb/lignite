namespace Lignite.Engine.Events
{
    /// <summary>
    /// Constants are used for event names to keep
    /// things organised and centralised
    /// </summary>
    public abstract class EventNames
    {
        /// <summary>
        /// Notify all listeners that we are preparing to shutdown
        /// </summary>
        public const string Shutdown = "event:action:Shutdown";

        /// <summary>
        /// Non critical error or error condition
        /// encountered on the Engine class
        /// </summary>
        public const string EngineError = "event:error:Lignite.Engine";
        /// <summary>
        /// Non critical error or error condition
        /// encountered on the AutoMarketLoader class
        /// </summary>
        public const string AutoMarketLoaderError = "event:error:Lignite.AutoMarketLoader";
        /// <summary>
        /// Non critical error or error condition
        /// encountered on the MarketProcessor class
        /// </summary>
        public const string MarketProcessorError = "event:error:Lignite.MarketProcessor";

        /// <summary>
        /// Notification message from the Engine class
        /// </summary>
        public const string EngineMessage = "event:message:Lignite.Engine";
        /// <summary>
        /// Notification message from the AutoMarketLoader class
        /// </summary>
        public const string AutoMarketLoaderMessage = "event:message:Lignite.AutoMarketLoader";
        /// <summary>
        /// Notification message from the MarketProcessor class
        /// </summary>
        public const string MarketProcessorMessage = "event:message:Lignite.MarketProcessor";

        /// <summary>
        /// Notification that a new market will be loaded
        /// </summary>
        public const string LoadNewMarketAction = "event:action:LoadNewMarket";

        /// <summary>
        /// The running state of a MarketProcessor thread has changed
        /// </summary>
        public const string MarketProcessorThreadStatusChanged = "event:MarketProcessorThreadStatusChanged";

        /// <summary>
        /// A Betfair.Collectins.Market object data has been updated with external data
        /// </summary>
        public const string MarketDataUpdated = "event:update:Betfair.Collections.Market";
    }
}
