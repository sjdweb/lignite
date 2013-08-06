namespace Lignite.Controls.Events
{
    public delegate void DisplayMessageEventHandler(object sender, DisplayMessageEventArgs e);

    public class DisplayMessageEventArgs : LigniteControlEventArgs
    {
        /// <summary>
        /// The message to display.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
    }
}
