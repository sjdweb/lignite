namespace Lignite.Controls.Events
{
    public delegate void BroadcastMarketStateRequestEventHandler(object sender, BroadcastMarketStateRequestEventArgs e);

    public class BroadcastMarketStateRequestEventArgs : LigniteControlEventArgs
    {
        /// <summary>
        /// Gets or sets the thread process id.
        /// </summary>
        /// <value>The thread process id.</value>
        public string ThreadProcessId { get; set; }
    }
}
