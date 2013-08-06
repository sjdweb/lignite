using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Betfair.Collections;

namespace Lignite.Controls.Events
{
    public delegate void MarketDataUpdateEventHandler(object sender, MarketDataUpdateEventArgs e);

    public class MarketDataUpdateEventArgs : LigniteControlEventArgs
    {
        /// <summary>
        /// Gets or sets the sender ID.
        /// </summary>
        /// <value>The sender ID.</value>
        public string SenderID { get; set; }

        /// <summary>
        /// Gets or sets the market data.
        /// </summary>
        /// <value>The market data.</value>
        public Market MarketData { get; set; }
    }
}
