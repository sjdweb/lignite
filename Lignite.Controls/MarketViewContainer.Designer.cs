using Lignite.Controls;

namespace Lignite.Controls
{
    partial class MarketViewContainer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelThreadHeaders = new System.Windows.Forms.Panel();
            this.lblMarketName = new System.Windows.Forms.Label();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.lblTimeToOff = new System.Windows.Forms.Label();
            this.lblThreadId = new System.Windows.Forms.Label();
            this.toolTipMarketView = new System.Windows.Forms.ToolTip(this.components);
            this.panelLoadingNewMarketItem = new System.Windows.Forms.Panel();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.panelThreadControls = new System.Windows.Forms.Panel();
            this.panelThreadViewPaging = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.listItemsPerPage = new System.Windows.Forms.ComboBox();
            this.lblShowingPageXofY = new System.Windows.Forms.Label();
            this.eventController = new Lignite.Controls.EventController();
            this.panelThreadHeaders.SuspendLayout();
            this.panelThreadViewPaging.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelThreadHeaders
            // 
            this.panelThreadHeaders.BackColor = System.Drawing.Color.White;
            this.panelThreadHeaders.Controls.Add(this.lblMarketName);
            this.panelThreadHeaders.Controls.Add(this.lblEventDate);
            this.panelThreadHeaders.Controls.Add(this.lblTimeToOff);
            this.panelThreadHeaders.Controls.Add(this.lblThreadId);
            this.panelThreadHeaders.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelThreadHeaders.Location = new System.Drawing.Point(0, 0);
            this.panelThreadHeaders.MinimumSize = new System.Drawing.Size(570, 0);
            this.panelThreadHeaders.Name = "panelThreadHeaders";
            this.panelThreadHeaders.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panelThreadHeaders.Size = new System.Drawing.Size(700, 21);
            this.panelThreadHeaders.TabIndex = 7;
            // 
            // lblMarketName
            // 
            this.lblMarketName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMarketName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarketName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMarketName.Location = new System.Drawing.Point(38, 3);
            this.lblMarketName.Name = "lblMarketName";
            this.lblMarketName.Size = new System.Drawing.Size(427, 18);
            this.lblMarketName.TabIndex = 15;
            this.lblMarketName.Text = "Market name";
            this.lblMarketName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTipMarketView.SetToolTip(this.lblMarketName, "The name of this market");
            this.lblMarketName.Click += new System.EventHandler(this.lblMarketName_Click);
            // 
            // lblEventDate
            // 
            this.lblEventDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEventDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblEventDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblEventDate.Location = new System.Drawing.Point(465, 3);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.Size = new System.Drawing.Size(152, 18);
            this.lblEventDate.TabIndex = 14;
            this.lblEventDate.Text = "Event date";
            this.lblEventDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTipMarketView.SetToolTip(this.lblEventDate, "The market start date");
            this.lblEventDate.Click += new System.EventHandler(this.lblEventDate_Click);
            // 
            // lblTimeToOff
            // 
            this.lblTimeToOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTimeToOff.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTimeToOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeToOff.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTimeToOff.Location = new System.Drawing.Point(617, 3);
            this.lblTimeToOff.Name = "lblTimeToOff";
            this.lblTimeToOff.Size = new System.Drawing.Size(83, 18);
            this.lblTimeToOff.TabIndex = 12;
            this.lblTimeToOff.Text = "Time to off";
            this.lblTimeToOff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTipMarketView.SetToolTip(this.lblTimeToOff, "Time before the off since the last update was received");
            this.lblTimeToOff.Click += new System.EventHandler(this.lblEventDate_Click);
            // 
            // lblThreadId
            // 
            this.lblThreadId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblThreadId.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblThreadId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThreadId.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblThreadId.Location = new System.Drawing.Point(0, 3);
            this.lblThreadId.Name = "lblThreadId";
            this.lblThreadId.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblThreadId.Size = new System.Drawing.Size(38, 18);
            this.lblThreadId.TabIndex = 9;
            this.lblThreadId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelLoadingNewMarketItem
            // 
            this.panelLoadingNewMarketItem.BackColor = System.Drawing.Color.White;
            this.panelLoadingNewMarketItem.BackgroundImage = global::Lignite.Controls.Properties.Resources.NewItemAdded;
            this.panelLoadingNewMarketItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLoadingNewMarketItem.Location = new System.Drawing.Point(4, 4);
            this.panelLoadingNewMarketItem.Name = "panelLoadingNewMarketItem";
            this.panelLoadingNewMarketItem.Size = new System.Drawing.Size(24, 24);
            this.panelLoadingNewMarketItem.TabIndex = 5;
            this.toolTipMarketView.SetToolTip(this.panelLoadingNewMarketItem, "A new market has been added");
            this.panelLoadingNewMarketItem.Visible = false;
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirstPage.BackgroundImage = global::Lignite.Controls.Properties.Resources.ArrowFirst;
            this.btnFirstPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFirstPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirstPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFirstPage.FlatAppearance.BorderSize = 0;
            this.btnFirstPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFirstPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstPage.Location = new System.Drawing.Point(583, 5);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(21, 21);
            this.btnFirstPage.TabIndex = 3;
            this.toolTipMarketView.SetToolTip(this.btnFirstPage, "Go to first");
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.MouseLeave += new System.EventHandler(this.btnFirstPage_MouseLeave);
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            this.btnFirstPage.MouseEnter += new System.EventHandler(this.btnFirstPage_MouseEnter);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.BackgroundImage = global::Lignite.Controls.Properties.Resources.ArrowLeft;
            this.btnPrevPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrevPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrevPage.FlatAppearance.BorderSize = 0;
            this.btnPrevPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrevPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevPage.Location = new System.Drawing.Point(612, 5);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(21, 21);
            this.btnPrevPage.TabIndex = 2;
            this.toolTipMarketView.SetToolTip(this.btnPrevPage, "Previous");
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.MouseLeave += new System.EventHandler(this.btnPrevPage_MouseLeave);
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            this.btnPrevPage.MouseEnter += new System.EventHandler(this.btnPrevPage_MouseEnter);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.BackgroundImage = global::Lignite.Controls.Properties.Resources.ArrowRight;
            this.btnNextPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNextPage.FlatAppearance.BorderSize = 0;
            this.btnNextPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNextPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Location = new System.Drawing.Point(641, 5);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(21, 21);
            this.btnNextPage.TabIndex = 1;
            this.toolTipMarketView.SetToolTip(this.btnNextPage, "Next");
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.MouseLeave += new System.EventHandler(this.btnNextPage_MouseLeave);
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            this.btnNextPage.MouseEnter += new System.EventHandler(this.btnNextPage_MouseEnter);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastPage.BackgroundImage = global::Lignite.Controls.Properties.Resources.ArrowLast;
            this.btnLastPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLastPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLastPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLastPage.FlatAppearance.BorderSize = 0;
            this.btnLastPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLastPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastPage.Location = new System.Drawing.Point(670, 5);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(21, 21);
            this.btnLastPage.TabIndex = 0;
            this.toolTipMarketView.SetToolTip(this.btnLastPage, "Go to last");
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.MouseLeave += new System.EventHandler(this.btnLastPage_MouseLeave);
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            this.btnLastPage.MouseEnter += new System.EventHandler(this.btnLastPage_MouseEnter);
            // 
            // panelThreadControls
            // 
            this.panelThreadControls.AutoScroll = true;
            this.panelThreadControls.AutoScrollMinSize = new System.Drawing.Size(580, 0);
            this.panelThreadControls.BackColor = System.Drawing.Color.White;
            this.panelThreadControls.BackgroundImage = global::Lignite.Controls.Properties.Resources.li;
            this.panelThreadControls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelThreadControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelThreadControls.Location = new System.Drawing.Point(0, 21);
            this.panelThreadControls.Name = "panelThreadControls";
            this.panelThreadControls.Size = new System.Drawing.Size(700, 350);
            this.panelThreadControls.TabIndex = 14;
            // 
            // panelThreadViewPaging
            // 
            this.panelThreadViewPaging.AutoScroll = true;
            this.panelThreadViewPaging.AutoScrollMinSize = new System.Drawing.Size(580, 0);
            this.panelThreadViewPaging.BackColor = System.Drawing.Color.White;
            this.panelThreadViewPaging.BackgroundImage = global::Lignite.Controls.Properties.Resources.ThreadViewPagingBackground;
            this.panelThreadViewPaging.Controls.Add(this.label1);
            this.panelThreadViewPaging.Controls.Add(this.listItemsPerPage);
            this.panelThreadViewPaging.Controls.Add(this.panelLoadingNewMarketItem);
            this.panelThreadViewPaging.Controls.Add(this.lblShowingPageXofY);
            this.panelThreadViewPaging.Controls.Add(this.btnFirstPage);
            this.panelThreadViewPaging.Controls.Add(this.btnPrevPage);
            this.panelThreadViewPaging.Controls.Add(this.btnNextPage);
            this.panelThreadViewPaging.Controls.Add(this.btnLastPage);
            this.panelThreadViewPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelThreadViewPaging.Location = new System.Drawing.Point(0, 371);
            this.panelThreadViewPaging.Name = "panelThreadViewPaging";
            this.panelThreadViewPaging.Padding = new System.Windows.Forms.Padding(1, 2, 1, 0);
            this.panelThreadViewPaging.Size = new System.Drawing.Size(700, 29);
            this.panelThreadViewPaging.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(34, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Items per page:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listItemsPerPage
            // 
            this.listItemsPerPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listItemsPerPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listItemsPerPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listItemsPerPage.FormattingEnabled = true;
            this.listItemsPerPage.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "30",
            "5"});
            this.listItemsPerPage.Location = new System.Drawing.Point(134, 5);
            this.listItemsPerPage.Name = "listItemsPerPage";
            this.listItemsPerPage.Size = new System.Drawing.Size(38, 21);
            this.listItemsPerPage.TabIndex = 6;
            this.listItemsPerPage.SelectedValueChanged += new System.EventHandler(this.listItemsPerPage_SelectedValueChanged);
            // 
            // lblShowingPageXofY
            // 
            this.lblShowingPageXofY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowingPageXofY.BackColor = System.Drawing.Color.White;
            this.lblShowingPageXofY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowingPageXofY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblShowingPageXofY.Location = new System.Drawing.Point(468, 4);
            this.lblShowingPageXofY.Name = "lblShowingPageXofY";
            this.lblShowingPageXofY.Size = new System.Drawing.Size(109, 23);
            this.lblShowingPageXofY.TabIndex = 4;
            this.lblShowingPageXofY.Text = "Page 1 of 1";
            this.lblShowingPageXofY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // eventController
            // 
            this.eventController.DataProcessorMarketThreadStatusChanged += new Lignite.Controls.Events.DataProcessorMarketThreadStatusChangedEventHandler(this.eventController_DataProcessorMarketThreadStatusChanged);
            this.eventController.MarketDataUpdate += new Lignite.Controls.Events.MarketDataUpdateEventHandler(this.eventController_MarketDataUpdate);
            // 
            // MarketViewContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelThreadControls);
            this.Controls.Add(this.panelThreadViewPaging);
            this.Controls.Add(this.panelThreadHeaders);
            this.Name = "MarketViewContainer";
            this.Size = new System.Drawing.Size(700, 400);
            this.panelThreadHeaders.ResumeLayout(false);
            this.panelThreadViewPaging.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelThreadHeaders;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.Label lblTimeToOff;
        private System.Windows.Forms.Label lblMarketName;
        private System.Windows.Forms.ToolTip toolTipMarketView;
        private System.Windows.Forms.Panel panelThreadViewPaging;
        private System.Windows.Forms.Panel panelThreadControls;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Label lblShowingPageXofY;
        private System.Windows.Forms.Panel panelLoadingNewMarketItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox listItemsPerPage;
        private System.Windows.Forms.Label lblThreadId;
        private EventController eventController;
    }
}
