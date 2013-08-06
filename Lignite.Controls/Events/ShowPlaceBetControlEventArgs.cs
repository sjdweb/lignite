using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Lignite.Controls.Events
{
    public delegate void ShowPlaceBetControlEventHandler(object sender, ShowPlaceBetControlEventArgs e);

    [Serializable]
    [ComVisible(true)]
    public class ShowPlaceBetControlEventArgs : LigniteControlEventArgs
    {
        public Betfair.Collections.Bet Bet  { get; set; }

        public string SelectionName { get; set; }

        public int MarketId { get; set; }

        public int ExchangeId { get; set; }
    }
}
