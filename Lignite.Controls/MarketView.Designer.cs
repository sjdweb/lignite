using Lignite.Controls.Events;

namespace Lignite.Controls
{
    partial class MarketView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        ///// <summary> 
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMainContainer = new System.Windows.Forms.Panel();
            this.panelThreadControlBody = new System.Windows.Forms.Panel();
            this.lblMarketName = new System.Windows.Forms.Label();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.lblTimeToStart = new System.Windows.Forms.Label();
            this.panelStatusIcon = new System.Windows.Forms.Panel();
            this.lblNumberingId = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRunnersOuterContainer = new System.Windows.Forms.Panel();
            this.panelSelections = new System.Windows.Forms.Panel();
            this.panelSelectionViewControls = new Lignite.Controls.MarketView.SelectionViewsPanel();
            this.panelMarketInfo = new System.Windows.Forms.Panel();
            this.lblMenuPath = new System.Windows.Forms.LinkLabel();
            this.lblTotalMatchedAmount = new System.Windows.Forms.Label();
            this.panelSelectionsHeading = new System.Windows.Forms.Panel();
            this.lblBackOverRound = new System.Windows.Forms.Label();
            this.lblBackLabel = new System.Windows.Forms.Label();
            this.lblStartingPriceLabel = new System.Windows.Forms.Label();
            this.lblSelections = new System.Windows.Forms.Label();
            this.lblLayLabel = new System.Windows.Forms.Label();
            this.lblLayOverRound = new System.Windows.Forms.Label();
            this.lblMenuPathHeading = new System.Windows.Forms.Label();
            this.toolTipMarketThreadControl = new System.Windows.Forms.ToolTip(this.components);
            this.eventController = new Lignite.Controls.EventController();
            this.panelMainContainer.SuspendLayout();
            this.panelThreadControlBody.SuspendLayout();
            this.panelRunnersOuterContainer.SuspendLayout();
            this.panelSelections.SuspendLayout();
            this.panelMarketInfo.SuspendLayout();
            this.panelSelectionsHeading.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainContainer
            // 
            this.panelMainContainer.Controls.Add(this.panelThreadControlBody);
            this.panelMainContainer.Controls.Add(this.panelRight);
            this.panelMainContainer.Controls.Add(this.panelLeft);
            this.panelMainContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainContainer.Location = new System.Drawing.Point(3, 3);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.Size = new System.Drawing.Size(744, 26);
            this.panelMainContainer.TabIndex = 0;
            this.panelMainContainer.Click += new System.EventHandler(this.topBar_Click);
            // 
            // panelThreadControlBody
            // 
            this.panelThreadControlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panelThreadControlBody.Controls.Add(this.lblMarketName);
            this.panelThreadControlBody.Controls.Add(this.lblEventDate);
            this.panelThreadControlBody.Controls.Add(this.lblTimeToStart);
            this.panelThreadControlBody.Controls.Add(this.panelStatusIcon);
            this.panelThreadControlBody.Controls.Add(this.lblNumberingId);
            this.panelThreadControlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelThreadControlBody.Location = new System.Drawing.Point(12, 0);
            this.panelThreadControlBody.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panelThreadControlBody.Name = "panelThreadControlBody";
            this.panelThreadControlBody.Padding = new System.Windows.Forms.Padding(2);
            this.panelThreadControlBody.Size = new System.Drawing.Size(720, 26);
            this.panelThreadControlBody.TabIndex = 5;
            this.panelThreadControlBody.Click += new System.EventHandler(this.topBar_Click);
            // 
            // lblMarketName
            // 
            this.lblMarketName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarketName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketName.ForeColor = System.Drawing.Color.White;
            this.lblMarketName.Location = new System.Drawing.Point(39, 2);
            this.lblMarketName.Name = "lblMarketName";
            this.lblMarketName.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblMarketName.Size = new System.Drawing.Size(463, 22);
            this.lblMarketName.TabIndex = 8;
            this.lblMarketName.Text = "Ludl 16th Oct - 16:20 2m Mdn Hrd";
            this.lblMarketName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMarketName.UseCompatibleTextRendering = true;
            this.lblMarketName.Click += new System.EventHandler(this.topBar_Click);
            // 
            // lblEventDate
            // 
            this.lblEventDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblEventDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventDate.ForeColor = System.Drawing.Color.White;
            this.lblEventDate.Location = new System.Drawing.Point(502, 2);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblEventDate.Size = new System.Drawing.Size(119, 22);
            this.lblEventDate.TabIndex = 7;
            this.lblEventDate.Text = "16/10/2008 16:20";
            this.lblEventDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEventDate.UseCompatibleTextRendering = true;
            this.lblEventDate.Click += new System.EventHandler(this.topBar_Click);
            // 
            // lblTimeToStart
            // 
            this.lblTimeToStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTimeToStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeToStart.ForeColor = System.Drawing.Color.White;
            this.lblTimeToStart.Location = new System.Drawing.Point(621, 2);
            this.lblTimeToStart.Name = "lblTimeToStart";
            this.lblTimeToStart.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblTimeToStart.Size = new System.Drawing.Size(75, 22);
            this.lblTimeToStart.TabIndex = 6;
            this.lblTimeToStart.Text = "12:21:50";
            this.lblTimeToStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTimeToStart.UseCompatibleTextRendering = true;
            this.lblTimeToStart.Click += new System.EventHandler(this.topBar_Click);
            // 
            // panelStatusIcon
            // 
            this.panelStatusIcon.BackgroundImage = global::Lignite.Controls.Properties.Resources.bullet_ball_glass_grey;
            this.panelStatusIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelStatusIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelStatusIcon.Location = new System.Drawing.Point(696, 2);
            this.panelStatusIcon.Name = "panelStatusIcon";
            this.panelStatusIcon.Size = new System.Drawing.Size(22, 22);
            this.panelStatusIcon.TabIndex = 4;
            this.toolTipMarketThreadControl.SetToolTip(this.panelStatusIcon, " Yellow:\\tSleeping \\n Green:\\tWorking \\n Blue:\\tWorking custom strategy dll \\n Gr" +
                    "ey:\\tInitialized and waiting to wake up");
            this.panelStatusIcon.Click += new System.EventHandler(this.topBar_Click);
            // 
            // lblNumberingId
            // 
            this.lblNumberingId.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNumberingId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberingId.ForeColor = System.Drawing.Color.White;
            this.lblNumberingId.Location = new System.Drawing.Point(2, 2);
            this.lblNumberingId.Name = "lblNumberingId";
            this.lblNumberingId.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblNumberingId.Size = new System.Drawing.Size(37, 22);
            this.lblNumberingId.TabIndex = 0;
            this.lblNumberingId.Text = "1234";
            this.lblNumberingId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNumberingId.UseCompatibleTextRendering = true;
            this.lblNumberingId.Click += new System.EventHandler(this.topBar_Click);
            // 
            // panelRight
            // 
            this.panelRight.BackgroundImage = global::Lignite.Controls.Properties.Resources.ThreadControlBackgroundRightUp;
            this.panelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(732, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(12, 26);
            this.panelRight.TabIndex = 4;
            this.panelRight.Click += new System.EventHandler(this.panelRight_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackgroundImage = global::Lignite.Controls.Properties.Resources.ThreadControlBackgroundLeft;
            this.panelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(12, 26);
            this.panelLeft.TabIndex = 3;
            this.panelLeft.Click += new System.EventHandler(this.topBar_Click);
            // 
            // panelRunnersOuterContainer
            // 
            this.panelRunnersOuterContainer.BackColor = System.Drawing.Color.White;
            this.panelRunnersOuterContainer.Controls.Add(this.panelSelections);
            this.panelRunnersOuterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRunnersOuterContainer.Location = new System.Drawing.Point(3, 29);
            this.panelRunnersOuterContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panelRunnersOuterContainer.Name = "panelRunnersOuterContainer";
            this.panelRunnersOuterContainer.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.panelRunnersOuterContainer.Size = new System.Drawing.Size(744, 48);
            this.panelRunnersOuterContainer.TabIndex = 1;
            // 
            // panelSelections
            // 
            this.panelSelections.BackColor = System.Drawing.Color.Silver;
            this.panelSelections.Controls.Add(this.panelSelectionViewControls);
            this.panelSelections.Controls.Add(this.panelMarketInfo);
            this.panelSelections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelections.Location = new System.Drawing.Point(12, 0);
            this.panelSelections.Name = "panelSelections";
            this.panelSelections.Padding = new System.Windows.Forms.Padding(3);
            this.panelSelections.Size = new System.Drawing.Size(720, 48);
            this.panelSelections.TabIndex = 0;
            // 
            // panelSelectionViewControls
            // 
            this.panelSelectionViewControls.Controller = null;
            this.panelSelectionViewControls.Currency = null;
            this.panelSelectionViewControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelectionViewControls.ExchangeId = 0;
            this.panelSelectionViewControls.IsBSPMarket = false;
            this.panelSelectionViewControls.Location = new System.Drawing.Point(3, 45);
            this.panelSelectionViewControls.MarketId = 0;
            this.panelSelectionViewControls.Name = "panelSelectionViewControls";
            this.panelSelectionViewControls.ShowStartingPricesIfAvailable = false;
            this.panelSelectionViewControls.Size = new System.Drawing.Size(714, 0);
            this.panelSelectionViewControls.TabIndex = 2;
            this.panelSelectionViewControls.HeightChanged += new System.EventHandler(this.panelSelectionViewControls_Resize);
            // 
            // panelMarketInfo
            // 
            this.panelMarketInfo.BackColor = System.Drawing.Color.Silver;
            this.panelMarketInfo.Controls.Add(this.lblMenuPath);
            this.panelMarketInfo.Controls.Add(this.lblTotalMatchedAmount);
            this.panelMarketInfo.Controls.Add(this.panelSelectionsHeading);
            this.panelMarketInfo.Controls.Add(this.lblMenuPathHeading);
            this.panelMarketInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMarketInfo.Location = new System.Drawing.Point(3, 3);
            this.panelMarketInfo.Name = "panelMarketInfo";
            this.panelMarketInfo.Size = new System.Drawing.Size(714, 42);
            this.panelMarketInfo.TabIndex = 1;
            // 
            // lblMenuPath
            // 
            this.lblMenuPath.AutoSize = true;
            this.lblMenuPath.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblMenuPath.Location = new System.Drawing.Point(76, 0);
            this.lblMenuPath.Name = "lblMenuPath";
            this.lblMenuPath.Size = new System.Drawing.Size(102, 13);
            this.lblMenuPath.TabIndex = 8;
            this.lblMenuPath.TabStop = true;
            this.lblMenuPath.Text = "\\evenet\\market\\etc";
            this.toolTipMarketThreadControl.SetToolTip(this.lblMenuPath, "Click to open the Betfair market in your default web browser");
            this.lblMenuPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblMenuPath_LinkClicked);
            // 
            // lblTotalMatchedAmount
            // 
            this.lblTotalMatchedAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalMatchedAmount.Location = new System.Drawing.Point(496, 9);
            this.lblTotalMatchedAmount.Name = "lblTotalMatchedAmount";
            this.lblTotalMatchedAmount.Size = new System.Drawing.Size(214, 14);
            this.lblTotalMatchedAmount.TabIndex = 7;
            this.lblTotalMatchedAmount.Text = "Matched: GBP 58976";
            this.lblTotalMatchedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelSelectionsHeading
            // 
            this.panelSelectionsHeading.BackColor = System.Drawing.Color.LightGray;
            this.panelSelectionsHeading.Controls.Add(this.lblBackOverRound);
            this.panelSelectionsHeading.Controls.Add(this.lblBackLabel);
            this.panelSelectionsHeading.Controls.Add(this.lblStartingPriceLabel);
            this.panelSelectionsHeading.Controls.Add(this.lblSelections);
            this.panelSelectionsHeading.Controls.Add(this.lblLayLabel);
            this.panelSelectionsHeading.Controls.Add(this.lblLayOverRound);
            this.panelSelectionsHeading.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSelectionsHeading.Location = new System.Drawing.Point(0, 26);
            this.panelSelectionsHeading.Name = "panelSelectionsHeading";
            this.panelSelectionsHeading.Padding = new System.Windows.Forms.Padding(1);
            this.panelSelectionsHeading.Size = new System.Drawing.Size(714, 16);
            this.panelSelectionsHeading.TabIndex = 5;
            // 
            // lblBackOverRound
            // 
            this.lblBackOverRound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(211)))), ((int)(((byte)(231)))));
            this.lblBackOverRound.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBackOverRound.ForeColor = System.Drawing.Color.Black;
            this.lblBackOverRound.Location = new System.Drawing.Point(198, 1);
            this.lblBackOverRound.Margin = new System.Windows.Forms.Padding(3);
            this.lblBackOverRound.Name = "lblBackOverRound";
            this.lblBackOverRound.Size = new System.Drawing.Size(115, 14);
            this.lblBackOverRound.TabIndex = 6;
            this.lblBackOverRound.Text = "100%";
            this.lblBackOverRound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBackLabel
            // 
            this.lblBackLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(211)))), ((int)(((byte)(231)))));
            this.lblBackLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackLabel.ForeColor = System.Drawing.Color.Black;
            this.lblBackLabel.Location = new System.Drawing.Point(313, 1);
            this.lblBackLabel.Margin = new System.Windows.Forms.Padding(3);
            this.lblBackLabel.Name = "lblBackLabel";
            this.lblBackLabel.Size = new System.Drawing.Size(50, 14);
            this.lblBackLabel.TabIndex = 5;
            this.lblBackLabel.Text = "Back ";
            this.lblBackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStartingPriceLabel
            // 
            this.lblStartingPriceLabel.BackColor = System.Drawing.Color.White;
            this.lblStartingPriceLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStartingPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartingPriceLabel.ForeColor = System.Drawing.Color.Black;
            this.lblStartingPriceLabel.Location = new System.Drawing.Point(363, 1);
            this.lblStartingPriceLabel.Margin = new System.Windows.Forms.Padding(3);
            this.lblStartingPriceLabel.Name = "lblStartingPriceLabel";
            this.lblStartingPriceLabel.Size = new System.Drawing.Size(185, 14);
            this.lblStartingPriceLabel.TabIndex = 3;
            this.lblStartingPriceLabel.Text = "Starting Price";
            this.lblStartingPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStartingPriceLabel.Visible = false;
            // 
            // lblSelections
            // 
            this.lblSelections.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSelections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelections.ForeColor = System.Drawing.Color.Black;
            this.lblSelections.Location = new System.Drawing.Point(1, 1);
            this.lblSelections.Margin = new System.Windows.Forms.Padding(3);
            this.lblSelections.Name = "lblSelections";
            this.lblSelections.Size = new System.Drawing.Size(547, 14);
            this.lblSelections.TabIndex = 2;
            this.lblSelections.Text = "Selections ()";
            this.lblSelections.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLayLabel
            // 
            this.lblLayLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(186)))), ((int)(((byte)(214)))));
            this.lblLayLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblLayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLayLabel.ForeColor = System.Drawing.Color.Black;
            this.lblLayLabel.Location = new System.Drawing.Point(548, 1);
            this.lblLayLabel.Margin = new System.Windows.Forms.Padding(3);
            this.lblLayLabel.Name = "lblLayLabel";
            this.lblLayLabel.Size = new System.Drawing.Size(50, 14);
            this.lblLayLabel.TabIndex = 1;
            this.lblLayLabel.Text = " Lay";
            this.lblLayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLayOverRound
            // 
            this.lblLayOverRound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(186)))), ((int)(((byte)(214)))));
            this.lblLayOverRound.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblLayOverRound.ForeColor = System.Drawing.Color.Black;
            this.lblLayOverRound.Location = new System.Drawing.Point(598, 1);
            this.lblLayOverRound.Margin = new System.Windows.Forms.Padding(3);
            this.lblLayOverRound.Name = "lblLayOverRound";
            this.lblLayOverRound.Size = new System.Drawing.Size(115, 14);
            this.lblLayOverRound.TabIndex = 0;
            this.lblLayOverRound.Text = "100%";
            this.lblLayOverRound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMenuPathHeading
            // 
            this.lblMenuPathHeading.AutoSize = true;
            this.lblMenuPathHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuPathHeading.Location = new System.Drawing.Point(3, 0);
            this.lblMenuPathHeading.Name = "lblMenuPathHeading";
            this.lblMenuPathHeading.Size = new System.Drawing.Size(72, 13);
            this.lblMenuPathHeading.TabIndex = 4;
            this.lblMenuPathHeading.Text = "Menu Path:";
            // 
            // eventController
            // 
            this.eventController.DataProcessorMarketThreadStatusChanged += new Lignite.Controls.Events.DataProcessorMarketThreadStatusChangedEventHandler(this.eventController_DataProcessorMarketThreadStatusChanged);
            this.eventController.MarketDataUpdate += new Lignite.Controls.Events.MarketDataUpdateEventHandler(this.eventController_MarketDataUpdate);
            // 
            // MarketView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelRunnersOuterContainer);
            this.Controls.Add(this.panelMainContainer);
            this.MinimumSize = new System.Drawing.Size(580, 28);
            this.Name = "MarketView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(750, 80);
            this.panelMainContainer.ResumeLayout(false);
            this.panelThreadControlBody.ResumeLayout(false);
            this.panelRunnersOuterContainer.ResumeLayout(false);
            this.panelSelections.ResumeLayout(false);
            this.panelMarketInfo.ResumeLayout(false);
            this.panelMarketInfo.PerformLayout();
            this.panelSelectionsHeading.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.Panel panelThreadControlBody;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRunnersOuterContainer;
        private System.Windows.Forms.Panel panelSelections;
        private System.Windows.Forms.Label lblNumberingId;
        private System.Windows.Forms.Panel panelStatusIcon;
        private System.Windows.Forms.Label lblTimeToStart;
        private System.Windows.Forms.Label lblMarketName;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.Panel panelMarketInfo;
        private System.Windows.Forms.Label lblMenuPathHeading;
        private System.Windows.Forms.Panel panelSelectionsHeading;
        private System.Windows.Forms.Label lblLayLabel;
        private System.Windows.Forms.Label lblLayOverRound;
        private System.Windows.Forms.Label lblSelections;
        private System.Windows.Forms.Label lblStartingPriceLabel;
        private System.Windows.Forms.ToolTip toolTipMarketThreadControl;
        private System.Windows.Forms.Label lblTotalMatchedAmount;
        private System.Windows.Forms.LinkLabel lblMenuPath;
        private System.Windows.Forms.Label lblBackOverRound;
        private System.Windows.Forms.Label lblBackLabel;
        private EventController eventController;
        private SelectionViewsPanel panelSelectionViewControls;

    }
}
