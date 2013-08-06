using System;
using System.Collections.Generic;
using Betfair.Collections;
using Lignite.Plugin;

namespace ExampleStrategy
{
    /// <summary>
    /// The code to execute your custom strategy implementation
    /// </summary>
    public class MyStrategy : IPluginBase
    {
        /// <summary>
        /// This market, used to validate successive execution envocations.
        /// </summary>
        private Market m_market;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleStrategy"/> class.
        /// </summary>
        public MyStrategy()
        {
            m_market = new Market();
            Bets = new List<Bet>();
        }

        #region Variables

        /// <summary>
        /// The display name you have given to this strategy
        /// </summary>
        public string Name
        {
            get { return m_name; }
        }

        private const string m_name = "My Custom Betting Implementation";

        /// <summary>
        /// The version of this strategy file
        /// </summary>
        public string Version
        {
            get { return m_version; }
        }

        private const string m_version = "Version 1.0";

        /// <summary>
        /// A description of what this strategy does or other reference information
        /// </summary>
        public string Description
        {
            get { return m_description; }
        }

        private const string m_description = "Full text description of \"My Custom Betting Implementation.\"";

        #endregion

        #region IPluginBase Members

        /// <summary>
        /// Gets or sets the bets.
        /// </summary>
        /// <value>The bets.</value>
        public List<Bet> Bets { get; set; }

        /// <summary>
        /// Gets or sets the custom user configuration for this instance.
        /// </summary>
        /// <value>The configuration.</value>
        public PluginConfigurationBase Configuration { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has a form.
        /// </summary>
        /// <value><c>true</c> if this instance has form; otherwise, <c>false</c>.</value>
        public bool HasWinForm
        {
            get { return true; }
        }

        private static MyStrategyForm m_myStrategyForm;

        /// <summary>
        /// Shows the plugin's main form.
        /// </summary>
        public void ShowForm()
        {
            if (m_myStrategyForm == null)
                m_myStrategyForm = new MyStrategyForm();

            if(m_myStrategyForm.IsDisposed)
                m_myStrategyForm = new MyStrategyForm();

            m_myStrategyForm.Show();
        }

        /// <summary>
        /// Run the StartUp logic and initializers.
        /// </summary>
        /// <param name="processorId">The processor id.</param>
        /// <param name="market"></param>
        /// <param name="requestTimeGmt">The request time GMT.</param>
        /// <returns></returns>
        public bool StartUp(string processorId, Market market, DateTime requestTimeGmt)
        {
            m_market = market;

            return (true);
        }

        /// <summary>
        /// The main entry point that will be called from the  Lignite for Betfair engine
        /// </summary>
        /// <param name="processorId"></param>
        /// <param name="market"></param>
        /// <param name="requestTimeGmt"></param>
        /// <returns></returns>
        public bool Execute(string processorId, Market market, DateTime requestTimeGmt)
        {
            m_market = market;

            return (true);
        }

        /// <summary>
        /// The shutdown method in your class gets excuted when the thread terminates.
        /// use this to elegantly close down data sources etc.
        /// </summary>
        /// <param name="processorId">The processor id.</param>
        /// <param name="market"></param>
        /// <param name="requestTimeGmt">The request time GMT.</param>
        /// <returns></returns>
        public bool ShutDown(string processorId, Market market, DateTime requestTimeGmt)
        {
            m_market = null;

            return (true);
        }

        #endregion
    }
}