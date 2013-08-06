namespace Lignite.Console
{
    partial class SimplePlaceBetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimplePlaceBetForm));
            this.simplePlaceBetControl = new Lignite.Controls.SimplePlaceBetControl();
            this.eventController = new Lignite.Controls.EventController();
            this.SuspendLayout();
            // 
            // simplePlaceBetControl
            // 
            this.simplePlaceBetControl.BackColor = System.Drawing.Color.Transparent;
            this.simplePlaceBetControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simplePlaceBetControl.BackgroundImage")));
            this.simplePlaceBetControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.simplePlaceBetControl.BetRequest = ((Betfair.Collections.Bet)(resources.GetObject("simplePlaceBetControl.BetRequest")));
            this.simplePlaceBetControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simplePlaceBetControl.Location = new System.Drawing.Point(0, 0);
            this.simplePlaceBetControl.Margin = new System.Windows.Forms.Padding(0);
            this.simplePlaceBetControl.Name = "simplePlaceBetControl";
            this.simplePlaceBetControl.Padding = new System.Windows.Forms.Padding(3);
            this.simplePlaceBetControl.SelectionName = null;
            this.simplePlaceBetControl.Size = new System.Drawing.Size(291, 183);
            this.simplePlaceBetControl.TabIndex = 0;
            this.simplePlaceBetControl.CloseClicked += new System.EventHandler(this.simplePlaceBetControl_CloseClicked);
            // 
            // eventController
            // 
            this.eventController.ShowBetPlacementControl += new Lignite.Controls.Events.ShowPlaceBetControlEventHandler(this.EventController_ShowBetPlacementControl);
            // 
            // SimplePlaceBetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(291, 183);
            this.ControlBox = false;
            this.Controls.Add(this.simplePlaceBetControl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SimplePlaceBetForm";
            this.Opacity = 0.98;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MarketViewPlaceBetForm";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Lignite.Controls.SimplePlaceBetControl simplePlaceBetControl;
        private Lignite.Controls.EventController eventController;

    }
}