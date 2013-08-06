namespace Lignite.ConfigurationEditor
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Betfair");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Get All Markets");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Default Market Load Actions");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Default Data Load Actions");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Strategy Data Loader Paterns");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateBackup = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateNewDataLoadPatern = new System.Windows.Forms.Button();
            this.btnDeleteDataLoadPatern = new System.Windows.Forms.Button();
            this.panelBetfair = new System.Windows.Forms.Panel();
            this.panelFooter.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.btnCancel);
            this.panelFooter.Controls.Add(this.btnCreateBackup);
            this.panelFooter.Controls.Add(this.btnSave);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 480);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(882, 46);
            this.panelFooter.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(617, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreateBackup
            // 
            this.btnCreateBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateBackup.Location = new System.Drawing.Point(698, 11);
            this.btnCreateBackup.Name = "btnCreateBackup";
            this.btnCreateBackup.Size = new System.Drawing.Size(91, 23);
            this.btnCreateBackup.TabIndex = 1;
            this.btnCreateBackup.Text = "Create Backup";
            this.btnCreateBackup.UseVisualStyleBackColor = true;
            this.btnCreateBackup.Click += new System.EventHandler(this.btnCreateBackup_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(795, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.ForeColor = System.Drawing.Color.Blue;
            treeNode1.Name = "NodeBetfair";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Text = "Betfair";
            treeNode2.Name = "NodeGetAllMarkets";
            treeNode2.Text = "Get All Markets";
            treeNode3.Name = "NodeDefaultOnMarketLoadActions";
            treeNode3.Text = "Default Market Load Actions";
            treeNode4.Name = "NodeDefaultDataLoadActions";
            treeNode4.Text = "Default Data Load Actions";
            treeNode5.Name = "NodeStrategyDataLoaderPaterns";
            treeNode5.Text = "Strategy Data Loader Paterns";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.treeView.Size = new System.Drawing.Size(183, 480);
            this.treeView.TabIndex = 1;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(183, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 480);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panelOptions
            // 
            this.panelOptions.Controls.Add(this.flowLayoutPanel1);
            this.panelOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOptions.Location = new System.Drawing.Point(186, 0);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(696, 30);
            this.panelOptions.TabIndex = 5;
            this.panelOptions.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCreateNewDataLoadPatern);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteDataLoadPatern);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(696, 30);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCreateNewDataLoadPatern
            // 
            this.btnCreateNewDataLoadPatern.AutoSize = true;
            this.btnCreateNewDataLoadPatern.BackColor = System.Drawing.Color.White;
            this.btnCreateNewDataLoadPatern.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateNewDataLoadPatern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNewDataLoadPatern.Location = new System.Drawing.Point(3, 3);
            this.btnCreateNewDataLoadPatern.Name = "btnCreateNewDataLoadPatern";
            this.btnCreateNewDataLoadPatern.Size = new System.Drawing.Size(221, 23);
            this.btnCreateNewDataLoadPatern.TabIndex = 0;
            this.btnCreateNewDataLoadPatern.Text = ">> Create New Data Load Patern <<";
            this.btnCreateNewDataLoadPatern.UseVisualStyleBackColor = false;
            this.btnCreateNewDataLoadPatern.Click += new System.EventHandler(this.btnCreateNewDataLoadPatern_Click);
            // 
            // btnDeleteDataLoadPatern
            // 
            this.btnDeleteDataLoadPatern.AutoSize = true;
            this.btnDeleteDataLoadPatern.BackColor = System.Drawing.Color.White;
            this.btnDeleteDataLoadPatern.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteDataLoadPatern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDataLoadPatern.Location = new System.Drawing.Point(230, 3);
            this.btnDeleteDataLoadPatern.Name = "btnDeleteDataLoadPatern";
            this.btnDeleteDataLoadPatern.Size = new System.Drawing.Size(192, 23);
            this.btnDeleteDataLoadPatern.TabIndex = 1;
            this.btnDeleteDataLoadPatern.Text = ">> Delete Data Load Patern <<";
            this.btnDeleteDataLoadPatern.UseVisualStyleBackColor = false;
            this.btnDeleteDataLoadPatern.Click += new System.EventHandler(this.btnDeleteDataLoadPatern_Click);
            // 
            // panelBetfair
            // 
            this.panelBetfair.BackColor = System.Drawing.Color.Transparent;
            this.panelBetfair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelBetfair.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBetfair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBetfair.Location = new System.Drawing.Point(186, 30);
            this.panelBetfair.Name = "panelBetfair";
            this.panelBetfair.Padding = new System.Windows.Forms.Padding(5);
            this.panelBetfair.Size = new System.Drawing.Size(696, 450);
            this.panelBetfair.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 526);
            this.Controls.Add(this.panelBetfair);
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.panelFooter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Lignite Configuration Editor";
            this.panelFooter.ResumeLayout(false);
            this.panelOptions.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Panel panelBetfair;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreateBackup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCreateNewDataLoadPatern;
        private System.Windows.Forms.Button btnDeleteDataLoadPatern;
    }
}

