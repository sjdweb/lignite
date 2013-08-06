using System.Windows.Forms;
using Lignite.Controls;
using Lignite.Controls.Events;

namespace Lignite.Console
{
    public partial class SimplePlaceBetForm : Form
    {
        public SimplePlaceBetForm()
        {
            InitializeComponent();
        }

        public EventController Controller
        {
            get
            {
                return eventController;
            }
            set
            {
                eventController.ShowBetPlacementControl -= (EventController_ShowBetPlacementControl);

                eventController = value;
                simplePlaceBetControl.Controller = Controller;

                eventController.ShowBetPlacementControl += (EventController_ShowBetPlacementControl);
            }
        }


        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    if (Visible)
        //    {
        //        Visible = false;
        //    }
        //}

        /// <summary>
        /// Handles the ShowBetPlacementControl event of the UIEventController control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Lignite.Controls.Events.ShowPlaceBetControlEventArgs"/> instance containing the event data.</param>
        private void EventController_ShowBetPlacementControl(object sender, ShowPlaceBetControlEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new InvokeShowBetPlacementControl(EventController_ShowBetPlacementControl), new[] {sender, e});
            }

            if (!Visible)
            {
                Visible = true;
            }

            BringToFront();

            Location = Cursor.Position;

            simplePlaceBetControl.BetRequest = e.Bet;
        }

        #region Nested type: InvokeShowBetPlacementControl

        private delegate void InvokeShowBetPlacementControl(object sender, ShowPlaceBetControlEventArgs e);

        #endregion

        private void simplePlaceBetControl_CloseClicked(object sender, System.EventArgs e)
        {
            Hide();
        }
    }
}