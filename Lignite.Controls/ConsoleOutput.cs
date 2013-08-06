using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Lignite.Controls.Events;

namespace Lignite.Controls
{
    [ToolboxBitmap(typeof (ConsoleOutput))]
    public partial class ConsoleOutput : UserControl, IUserControl
    {
        private readonly List<string> text = new List<string>();

        private string m_uniqueInstanceID;

        #region Implementation of IUserControl

        /// <summary>
        /// The Lignite control controller is the data path used for communication between controls and the parent form
        /// </summary>
        public EventController Controller
        {
            get { return eventController; }
            set
            {
                eventController.DisplayMessage -= InvokeDisplayMessage;

                eventController = value;

                eventController.DisplayMessage += InvokeDisplayMessage;
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

        public ConsoleOutput()
        {
            InitializeComponent();
        }

        public int MaxLines { get; set; }
        public bool ShowDate { get; set; }

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteLine(string value)
        {
            if (ShowDate)
                text.Add(DateTime.Now + "$ " + value);
            else
                text.Add(value);

            if (text.Count >= MaxLines && MaxLines > 0)
            {
                text.RemoveAt(0);
            }

            textBoxOutput.Lines = text.ToArray();

            textBoxOutput.SelectionStart = textBoxOutput.Text.Length;
            textBoxOutput.ScrollToCaret();
        }

        /// <summary>
        /// Clears the text.
        /// </summary>
        public void ClearText()
        {
            text.Clear();
            textBoxOutput.Clear();
        }

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Lignite.Controls.Events.DisplayMessageEventArgs"/> instance containing the event data.</param>
        private void InvokeDisplayMessage(object sender, DisplayMessageEventArgs e)
        {
            if(InvokeRequired)
            {
                InvokeDisplayMessageCallback d = InvokeDisplayMessage;
                BeginInvoke(d, new[] {sender, e});
            }
            else
            {
                if (e.SenderUID == UniqueInstanceID) return;
                WriteLine(e.Message);
            }
        }

        private delegate void InvokeDisplayMessageCallback(object sender, DisplayMessageEventArgs e);
    }
}