namespace Lignite.Controls
{
    partial class SystemStatusMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemStatusMonitor));
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.panelFeedUrl = new System.Windows.Forms.Panel();
            this.btnLoadFeedUrl = new System.Windows.Forms.Button();
            this.txtFeedUrl = new System.Windows.Forms.TextBox();
            this.lblFeedUrl = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopRight = new System.Windows.Forms.Panel();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtItemDescriptionResponse = new System.Windows.Forms.TextBox();
            this.panelItemDescription = new System.Windows.Forms.Panel();
            this.lblItemDescription = new System.Windows.Forms.Label();
            this.panelItemLastBuildDate = new System.Windows.Forms.Panel();
            this.txtItemLastBuildDateresponse = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblItemLastBuildDate = new System.Windows.Forms.Label();
            this.panelItemPublishDate = new System.Windows.Forms.Panel();
            this.txtItemPublishDateResponse = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblItemPublishDate = new System.Windows.Forms.Label();
            this.panelItemCategory = new System.Windows.Forms.Panel();
            this.txtItemCategoryResponse = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblItemCategory = new System.Windows.Forms.Label();
            this.panelItemTitle = new System.Windows.Forms.Panel();
            this.txtItemTitleResponse = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblItemTitle = new System.Windows.Forms.Label();
            this.lblFeedChannelTitle = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelBottomRight = new System.Windows.Forms.Panel();
            this.panelBottomLeft = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.eventController = new Lignite.Controls.EventController();
            this.panelFeedUrl.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelItemDescription.SuspendLayout();
            this.panelItemLastBuildDate.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panelItemPublishDate.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panelItemCategory.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelItemTitle.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 300000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // panelFeedUrl
            // 
            this.panelFeedUrl.Controls.Add(this.btnLoadFeedUrl);
            this.panelFeedUrl.Controls.Add(this.txtFeedUrl);
            this.panelFeedUrl.Controls.Add(this.lblFeedUrl);
            this.panelFeedUrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFeedUrl.Location = new System.Drawing.Point(3, 3);
            this.panelFeedUrl.Name = "panelFeedUrl";
            this.panelFeedUrl.Size = new System.Drawing.Size(204, 38);
            this.panelFeedUrl.TabIndex = 1;
            // 
            // btnLoadFeedUrl
            // 
            this.btnLoadFeedUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFeedUrl.AutoSize = true;
            this.btnLoadFeedUrl.BackgroundImage = global::Lignite.Controls.Properties.Resources.rss;
            this.btnLoadFeedUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadFeedUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadFeedUrl.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLoadFeedUrl.FlatAppearance.BorderSize = 0;
            this.btnLoadFeedUrl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnLoadFeedUrl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnLoadFeedUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadFeedUrl.Location = new System.Drawing.Point(187, 16);
            this.btnLoadFeedUrl.Name = "btnLoadFeedUrl";
            this.btnLoadFeedUrl.Size = new System.Drawing.Size(10, 10);
            this.btnLoadFeedUrl.TabIndex = 2;
            this.btnLoadFeedUrl.UseVisualStyleBackColor = true;
            this.btnLoadFeedUrl.Click += new System.EventHandler(this.btnLoadFeedUrl_Click);
            // 
            // txtFeedUrl
            // 
            this.txtFeedUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFeedUrl.BackColor = System.Drawing.Color.White;
            this.txtFeedUrl.Location = new System.Drawing.Point(59, 10);
            this.txtFeedUrl.Name = "txtFeedUrl";
            this.txtFeedUrl.Size = new System.Drawing.Size(123, 20);
            this.txtFeedUrl.TabIndex = 1;
            // 
            // lblFeedUrl
            // 
            this.lblFeedUrl.AutoSize = true;
            this.lblFeedUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeedUrl.ForeColor = System.Drawing.Color.White;
            this.lblFeedUrl.Location = new System.Drawing.Point(0, 15);
            this.lblFeedUrl.Name = "lblFeedUrl";
            this.lblFeedUrl.Size = new System.Drawing.Size(50, 13);
            this.lblFeedUrl.TabIndex = 0;
            this.lblFeedUrl.Text = "Feed Url:";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panelTop.Controls.Add(this.panelTopRight);
            this.panelTop.Controls.Add(this.panelTopLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 21);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(210, 12);
            this.panelTop.TabIndex = 20;
            // 
            // panelTopRight
            // 
            this.panelTopRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTopRight.BackColor = System.Drawing.Color.White;
            this.panelTopRight.BackgroundImage = global::Lignite.Controls.Properties.Resources.RoundedRightTop;
            this.panelTopRight.Location = new System.Drawing.Point(198, 0);
            this.panelTopRight.Name = "panelTopRight";
            this.panelTopRight.Size = new System.Drawing.Size(12, 12);
            this.panelTopRight.TabIndex = 10;
            // 
            // panelTopLeft
            // 
            this.panelTopLeft.BackColor = System.Drawing.Color.White;
            this.panelTopLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTopLeft.BackgroundImage")));
            this.panelTopLeft.Location = new System.Drawing.Point(0, 0);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Size = new System.Drawing.Size(12, 12);
            this.panelTopLeft.TabIndex = 9;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panelBody.Controls.Add(this.panel1);
            this.panelBody.Controls.Add(this.panelFeedUrl);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 21);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(3);
            this.panelBody.Size = new System.Drawing.Size(210, 232);
            this.panelBody.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.txtItemDescriptionResponse);
            this.panel1.Controls.Add(this.panelItemDescription);
            this.panel1.Controls.Add(this.panelItemLastBuildDate);
            this.panel1.Controls.Add(this.panelItemPublishDate);
            this.panel1.Controls.Add(this.panelItemCategory);
            this.panel1.Controls.Add(this.panelItemTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 188);
            this.panel1.TabIndex = 8;
            // 
            // txtItemDescriptionResponse
            // 
            this.txtItemDescriptionResponse.BackColor = System.Drawing.Color.Gainsboro;
            this.txtItemDescriptionResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtItemDescriptionResponse.Location = new System.Drawing.Point(0, 130);
            this.txtItemDescriptionResponse.Multiline = true;
            this.txtItemDescriptionResponse.Name = "txtItemDescriptionResponse";
            this.txtItemDescriptionResponse.ReadOnly = true;
            this.txtItemDescriptionResponse.Size = new System.Drawing.Size(204, 58);
            this.txtItemDescriptionResponse.TabIndex = 13;
            // 
            // panelItemDescription
            // 
            this.panelItemDescription.AutoSize = true;
            this.panelItemDescription.Controls.Add(this.lblItemDescription);
            this.panelItemDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelItemDescription.Location = new System.Drawing.Point(0, 112);
            this.panelItemDescription.Name = "panelItemDescription";
            this.panelItemDescription.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panelItemDescription.Size = new System.Drawing.Size(204, 18);
            this.panelItemDescription.TabIndex = 12;
            // 
            // lblItemDescription
            // 
            this.lblItemDescription.AutoSize = true;
            this.lblItemDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDescription.ForeColor = System.Drawing.Color.White;
            this.lblItemDescription.Location = new System.Drawing.Point(0, 3);
            this.lblItemDescription.Name = "lblItemDescription";
            this.lblItemDescription.Size = new System.Drawing.Size(63, 13);
            this.lblItemDescription.TabIndex = 4;
            this.lblItemDescription.Text = "Description:";
            // 
            // panelItemLastBuildDate
            // 
            this.panelItemLastBuildDate.AutoSize = true;
            this.panelItemLastBuildDate.Controls.Add(this.txtItemLastBuildDateresponse);
            this.panelItemLastBuildDate.Controls.Add(this.panel10);
            this.panelItemLastBuildDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelItemLastBuildDate.Location = new System.Drawing.Point(0, 86);
            this.panelItemLastBuildDate.Name = "panelItemLastBuildDate";
            this.panelItemLastBuildDate.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panelItemLastBuildDate.Size = new System.Drawing.Size(204, 26);
            this.panelItemLastBuildDate.TabIndex = 11;
            // 
            // txtItemLastBuildDateresponse
            // 
            this.txtItemLastBuildDateresponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemLastBuildDateresponse.BackColor = System.Drawing.Color.Gainsboro;
            this.txtItemLastBuildDateresponse.Location = new System.Drawing.Point(88, 1);
            this.txtItemLastBuildDateresponse.Multiline = true;
            this.txtItemLastBuildDateresponse.Name = "txtItemLastBuildDateresponse";
            this.txtItemLastBuildDateresponse.ReadOnly = true;
            this.txtItemLastBuildDateresponse.Size = new System.Drawing.Size(109, 20);
            this.txtItemLastBuildDateresponse.TabIndex = 4;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.lblItemLastBuildDate);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(82, 22);
            this.panel10.TabIndex = 0;
            // 
            // lblItemLastBuildDate
            // 
            this.lblItemLastBuildDate.AutoSize = true;
            this.lblItemLastBuildDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemLastBuildDate.ForeColor = System.Drawing.Color.White;
            this.lblItemLastBuildDate.Location = new System.Drawing.Point(0, 2);
            this.lblItemLastBuildDate.Name = "lblItemLastBuildDate";
            this.lblItemLastBuildDate.Size = new System.Drawing.Size(82, 13);
            this.lblItemLastBuildDate.TabIndex = 1;
            this.lblItemLastBuildDate.Text = "Last Build Date:";
            // 
            // panelItemPublishDate
            // 
            this.panelItemPublishDate.AutoSize = true;
            this.panelItemPublishDate.Controls.Add(this.txtItemPublishDateResponse);
            this.panelItemPublishDate.Controls.Add(this.panel8);
            this.panelItemPublishDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelItemPublishDate.Location = new System.Drawing.Point(0, 57);
            this.panelItemPublishDate.Name = "panelItemPublishDate";
            this.panelItemPublishDate.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panelItemPublishDate.Size = new System.Drawing.Size(204, 29);
            this.panelItemPublishDate.TabIndex = 10;
            // 
            // txtItemPublishDateResponse
            // 
            this.txtItemPublishDateResponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemPublishDateResponse.BackColor = System.Drawing.Color.Gainsboro;
            this.txtItemPublishDateResponse.Location = new System.Drawing.Point(88, 4);
            this.txtItemPublishDateResponse.Multiline = true;
            this.txtItemPublishDateResponse.Name = "txtItemPublishDateResponse";
            this.txtItemPublishDateResponse.ReadOnly = true;
            this.txtItemPublishDateResponse.Size = new System.Drawing.Size(109, 20);
            this.txtItemPublishDateResponse.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblItemPublishDate);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(82, 25);
            this.panel8.TabIndex = 0;
            // 
            // lblItemPublishDate
            // 
            this.lblItemPublishDate.AutoSize = true;
            this.lblItemPublishDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPublishDate.ForeColor = System.Drawing.Color.White;
            this.lblItemPublishDate.Location = new System.Drawing.Point(0, 5);
            this.lblItemPublishDate.Name = "lblItemPublishDate";
            this.lblItemPublishDate.Size = new System.Drawing.Size(70, 13);
            this.lblItemPublishDate.TabIndex = 1;
            this.lblItemPublishDate.Text = "Publish Date:";
            // 
            // panelItemCategory
            // 
            this.panelItemCategory.AutoSize = true;
            this.panelItemCategory.Controls.Add(this.txtItemCategoryResponse);
            this.panelItemCategory.Controls.Add(this.panel4);
            this.panelItemCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelItemCategory.Location = new System.Drawing.Point(0, 28);
            this.panelItemCategory.Name = "panelItemCategory";
            this.panelItemCategory.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panelItemCategory.Size = new System.Drawing.Size(204, 29);
            this.panelItemCategory.TabIndex = 9;
            // 
            // txtItemCategoryResponse
            // 
            this.txtItemCategoryResponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemCategoryResponse.BackColor = System.Drawing.Color.Gainsboro;
            this.txtItemCategoryResponse.Location = new System.Drawing.Point(88, 4);
            this.txtItemCategoryResponse.Multiline = true;
            this.txtItemCategoryResponse.Name = "txtItemCategoryResponse";
            this.txtItemCategoryResponse.ReadOnly = true;
            this.txtItemCategoryResponse.Size = new System.Drawing.Size(109, 20);
            this.txtItemCategoryResponse.TabIndex = 4;
            this.txtItemCategoryResponse.TextChanged += new System.EventHandler(this.txtItemCategoryResponse_TextChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblItemCategory);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(82, 25);
            this.panel4.TabIndex = 0;
            // 
            // lblItemCategory
            // 
            this.lblItemCategory.AutoSize = true;
            this.lblItemCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCategory.ForeColor = System.Drawing.Color.White;
            this.lblItemCategory.Location = new System.Drawing.Point(0, 5);
            this.lblItemCategory.Name = "lblItemCategory";
            this.lblItemCategory.Size = new System.Drawing.Size(52, 13);
            this.lblItemCategory.TabIndex = 1;
            this.lblItemCategory.Text = "Category:";
            // 
            // panelItemTitle
            // 
            this.panelItemTitle.AutoSize = true;
            this.panelItemTitle.Controls.Add(this.txtItemTitleResponse);
            this.panelItemTitle.Controls.Add(this.panel2);
            this.panelItemTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelItemTitle.Location = new System.Drawing.Point(0, 0);
            this.panelItemTitle.Name = "panelItemTitle";
            this.panelItemTitle.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panelItemTitle.Size = new System.Drawing.Size(204, 28);
            this.panelItemTitle.TabIndex = 8;
            // 
            // txtItemTitleResponse
            // 
            this.txtItemTitleResponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemTitleResponse.BackColor = System.Drawing.Color.Gainsboro;
            this.txtItemTitleResponse.Location = new System.Drawing.Point(88, 3);
            this.txtItemTitleResponse.Multiline = true;
            this.txtItemTitleResponse.Name = "txtItemTitleResponse";
            this.txtItemTitleResponse.ReadOnly = true;
            this.txtItemTitleResponse.Size = new System.Drawing.Size(109, 20);
            this.txtItemTitleResponse.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblItemTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(82, 24);
            this.panel2.TabIndex = 0;
            // 
            // lblItemTitle
            // 
            this.lblItemTitle.AutoSize = true;
            this.lblItemTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemTitle.ForeColor = System.Drawing.Color.White;
            this.lblItemTitle.Location = new System.Drawing.Point(0, 4);
            this.lblItemTitle.Name = "lblItemTitle";
            this.lblItemTitle.Size = new System.Drawing.Size(30, 13);
            this.lblItemTitle.TabIndex = 1;
            this.lblItemTitle.Text = "Title:";
            // 
            // lblFeedChannelTitle
            // 
            this.lblFeedChannelTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFeedChannelTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFeedChannelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFeedChannelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeedChannelTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFeedChannelTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFeedChannelTitle.Name = "lblFeedChannelTitle";
            this.lblFeedChannelTitle.Size = new System.Drawing.Size(210, 21);
            this.lblFeedChannelTitle.TabIndex = 23;
            this.lblFeedChannelTitle.Text = "Feed Title";
            this.lblFeedChannelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFeedChannelTitle.Click += new System.EventHandler(this.lblFeedChannelTitle_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panelBottom.Controls.Add(this.panelBottomRight);
            this.panelBottom.Controls.Add(this.panelBottomLeft);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 253);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(210, 12);
            this.panelBottom.TabIndex = 21;
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottomRight.BackColor = System.Drawing.Color.White;
            this.panelBottomRight.BackgroundImage = global::Lignite.Controls.Properties.Resources.RoundedRightBottom;
            this.panelBottomRight.Location = new System.Drawing.Point(198, 0);
            this.panelBottomRight.Name = "panelBottomRight";
            this.panelBottomRight.Size = new System.Drawing.Size(12, 12);
            this.panelBottomRight.TabIndex = 8;
            // 
            // panelBottomLeft
            // 
            this.panelBottomLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelBottomLeft.BackColor = System.Drawing.Color.White;
            this.panelBottomLeft.BackgroundImage = global::Lignite.Controls.Properties.Resources.RoundedLeftBottom;
            this.panelBottomLeft.Location = new System.Drawing.Point(0, 0);
            this.panelBottomLeft.Name = "panelBottomLeft";
            this.panelBottomLeft.Size = new System.Drawing.Size(12, 12);
            this.panelBottomLeft.TabIndex = 7;
            // 
            // SystemStatusMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.lblFeedChannelTitle);
            this.Controls.Add(this.panelBottom);
            this.Name = "SystemStatusMonitor";
            this.Size = new System.Drawing.Size(210, 265);
            this.panelFeedUrl.ResumeLayout(false);
            this.panelFeedUrl.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelItemDescription.ResumeLayout(false);
            this.panelItemDescription.PerformLayout();
            this.panelItemLastBuildDate.ResumeLayout(false);
            this.panelItemLastBuildDate.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panelItemPublishDate.ResumeLayout(false);
            this.panelItemPublishDate.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panelItemCategory.ResumeLayout(false);
            this.panelItemCategory.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelItemTitle.ResumeLayout(false);
            this.panelItemTitle.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.Panel panelFeedUrl;
        private System.Windows.Forms.TextBox txtFeedUrl;
        private System.Windows.Forms.Label lblFeedUrl;
        private System.Windows.Forms.Panel panelTopRight;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelTopLeft;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Label lblFeedChannelTitle;
        private System.Windows.Forms.Panel panelBottomRight;
        private System.Windows.Forms.Panel panelBottomLeft;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnLoadFeedUrl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelItemDescription;
        private System.Windows.Forms.Panel panelItemLastBuildDate;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblItemLastBuildDate;
        private System.Windows.Forms.Panel panelItemPublishDate;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblItemPublishDate;
        private System.Windows.Forms.Panel panelItemCategory;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblItemCategory;
        private System.Windows.Forms.Panel panelItemTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblItemTitle;
        private System.Windows.Forms.TextBox txtItemTitleResponse;
        private System.Windows.Forms.TextBox txtItemDescriptionResponse;
        private System.Windows.Forms.Label lblItemDescription;
        private System.Windows.Forms.TextBox txtItemLastBuildDateresponse;
        private System.Windows.Forms.TextBox txtItemPublishDateResponse;
        private System.Windows.Forms.TextBox txtItemCategoryResponse;
        private System.Windows.Forms.ToolTip toolTip1;
        private EventController eventController;
    }
}
