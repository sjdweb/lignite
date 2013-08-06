namespace Lignite.Controls.Events
{
    public delegate void DataProcessorMarketThreadStatusChangedEventHandler(object sender, DataProcessorMarketThreadStatusChangedEventArgs e);

    public class DataProcessorMarketThreadStatusChangedEventArgs : LigniteControlEventArgs
    {
        /// <summary>
        /// Gets or sets the sender ID.
        /// </summary>
        /// <value>The sender ID.</value>
        public string SenderID { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; }
    }
}
