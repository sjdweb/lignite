namespace Lignite.ConfigurationEditor
{
    partial class StrategyLoadPaternsView
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
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.txtCustomLibrary = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxOnMarketLoad = new System.Windows.Forms.GroupBox();
            this.rbGetMarketPricesComplete = new System.Windows.Forms.RadioButton();
            this.rbGetMarketPrices = new System.Windows.Forms.RadioButton();
            this.chkTerminateMarketThread = new System.Windows.Forms.CheckBox();
            this.chkGetExtendedRunnerInfo = new System.Windows.Forms.CheckBox();
            this.chkGetBets = new System.Windows.Forms.CheckBox();
            this.chkGetCompleteMarketTradedVolume = new System.Windows.Forms.CheckBox();
            this.groupBoxFilterMarketResults = new System.Windows.Forms.GroupBox();
            this.dgFilterGetAllMarketsResultsWhere = new System.Windows.Forms.DataGridView();
            this.fieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.operatorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsGetAllMarketsResultsFilters = new System.Data.DataSet();
            this.TableGetAllMarketsResultsFilter = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDirectoryBrowser = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnShowPluginForm = new System.Windows.Forms.Button();
            this.groupBoxDescription.SuspendLayout();
            this.groupBoxOnMarketLoad.SuspendLayout();
            this.groupBoxFilterMarketResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFilterGetAllMarketsResultsWhere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGetAllMarketsResultsFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableGetAllMarketsResultsFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Controls.Add(this.btnShowPluginForm);
            this.groupBoxDescription.Controls.Add(this.btnDirectoryBrowser);
            this.groupBoxDescription.Controls.Add(this.txtCustomLibrary);
            this.groupBoxDescription.Controls.Add(this.label4);
            this.groupBoxDescription.Controls.Add(this.txtVersion);
            this.groupBoxDescription.Controls.Add(this.label3);
            this.groupBoxDescription.Controls.Add(this.txtName);
            this.groupBoxDescription.Controls.Add(this.txtKey);
            this.groupBoxDescription.Controls.Add(this.label2);
            this.groupBoxDescription.Controls.Add(this.label1);
            this.groupBoxDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDescription.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Size = new System.Drawing.Size(552, 136);
            this.groupBoxDescription.TabIndex = 27;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Description";
            // 
            // txtCustomLibrary
            // 
            this.txtCustomLibrary.Location = new System.Drawing.Point(100, 100);
            this.txtCustomLibrary.Name = "txtCustomLibrary";
            this.txtCustomLibrary.Size = new System.Drawing.Size(259, 20);
            this.txtCustomLibrary.TabIndex = 32;
            this.txtCustomLibrary.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtCustomLibrary.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_string);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Custom Library";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(66, 74);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(293, 20);
            this.txtVersion.TabIndex = 30;
            this.txtVersion.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtVersion.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_string);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Version";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(66, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(293, 20);
            this.txtName.TabIndex = 28;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_string);
            // 
            // txtKey
            // 
            this.txtKey.Enabled = false;
            this.txtKey.Location = new System.Drawing.Point(66, 48);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(293, 20);
            this.txtKey.TabIndex = 27;
            this.txtKey.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtKey.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_string);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Key";
            // 
            // groupBoxOnMarketLoad
            // 
            this.groupBoxOnMarketLoad.Controls.Add(this.rbGetMarketPricesComplete);
            this.groupBoxOnMarketLoad.Controls.Add(this.rbGetMarketPrices);
            this.groupBoxOnMarketLoad.Controls.Add(this.chkTerminateMarketThread);
            this.groupBoxOnMarketLoad.Controls.Add(this.chkGetExtendedRunnerInfo);
            this.groupBoxOnMarketLoad.Controls.Add(this.chkGetBets);
            this.groupBoxOnMarketLoad.Controls.Add(this.chkGetCompleteMarketTradedVolume);
            this.groupBoxOnMarketLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxOnMarketLoad.Location = new System.Drawing.Point(0, 136);
            this.groupBoxOnMarketLoad.Name = "groupBoxOnMarketLoad";
            this.groupBoxOnMarketLoad.Size = new System.Drawing.Size(552, 170);
            this.groupBoxOnMarketLoad.TabIndex = 28;
            this.groupBoxOnMarketLoad.TabStop = false;
            this.groupBoxOnMarketLoad.Text = "On Market Load Actions";
            // 
            // rbGetMarketPricesComplete
            // 
            this.rbGetMarketPricesComplete.AutoSize = true;
            this.rbGetMarketPricesComplete.Location = new System.Drawing.Point(25, 41);
            this.rbGetMarketPricesComplete.Name = "rbGetMarketPricesComplete";
            this.rbGetMarketPricesComplete.Size = new System.Drawing.Size(157, 17);
            this.rbGetMarketPricesComplete.TabIndex = 7;
            this.rbGetMarketPricesComplete.TabStop = true;
            this.rbGetMarketPricesComplete.Text = "Get Market Prices Complete";
            this.rbGetMarketPricesComplete.UseVisualStyleBackColor = true;
            this.rbGetMarketPricesComplete.CheckedChanged += new System.EventHandler(this.chkGetCompleteMarketTradedVolume_CheckedChanged);
            // 
            // rbGetMarketPrices
            // 
            this.rbGetMarketPrices.AutoSize = true;
            this.rbGetMarketPrices.Checked = true;
            this.rbGetMarketPrices.Location = new System.Drawing.Point(25, 19);
            this.rbGetMarketPrices.Name = "rbGetMarketPrices";
            this.rbGetMarketPrices.Size = new System.Drawing.Size(110, 17);
            this.rbGetMarketPrices.TabIndex = 6;
            this.rbGetMarketPrices.TabStop = true;
            this.rbGetMarketPrices.Text = "Get Market Prices";
            this.rbGetMarketPrices.UseVisualStyleBackColor = true;
            this.rbGetMarketPrices.CheckedChanged += new System.EventHandler(this.chkGetCompleteMarketTradedVolume_CheckedChanged);
            // 
            // chkTerminateMarketThread
            // 
            this.chkTerminateMarketThread.AutoSize = true;
            this.chkTerminateMarketThread.Enabled = false;
            this.chkTerminateMarketThread.Location = new System.Drawing.Point(25, 133);
            this.chkTerminateMarketThread.Name = "chkTerminateMarketThread";
            this.chkTerminateMarketThread.Size = new System.Drawing.Size(146, 17);
            this.chkTerminateMarketThread.TabIndex = 5;
            this.chkTerminateMarketThread.Text = "Terminate Market Thread";
            this.chkTerminateMarketThread.UseVisualStyleBackColor = true;
            this.chkTerminateMarketThread.CheckedChanged += new System.EventHandler(this.chkGetCompleteMarketTradedVolume_CheckedChanged);
            // 
            // chkGetExtendedRunnerInfo
            // 
            this.chkGetExtendedRunnerInfo.AutoSize = true;
            this.chkGetExtendedRunnerInfo.Location = new System.Drawing.Point(25, 110);
            this.chkGetExtendedRunnerInfo.Name = "chkGetExtendedRunnerInfo";
            this.chkGetExtendedRunnerInfo.Size = new System.Drawing.Size(199, 17);
            this.chkGetExtendedRunnerInfo.TabIndex = 4;
            this.chkGetExtendedRunnerInfo.Text = "Get Extended Runner Info (Silks etc)";
            this.chkGetExtendedRunnerInfo.UseVisualStyleBackColor = true;
            this.chkGetExtendedRunnerInfo.CheckedChanged += new System.EventHandler(this.chkGetCompleteMarketTradedVolume_CheckedChanged);
            // 
            // chkGetBets
            // 
            this.chkGetBets.AutoSize = true;
            this.chkGetBets.Location = new System.Drawing.Point(25, 87);
            this.chkGetBets.Name = "chkGetBets";
            this.chkGetBets.Size = new System.Drawing.Size(67, 17);
            this.chkGetBets.TabIndex = 3;
            this.chkGetBets.Text = "Get Bets";
            this.chkGetBets.UseVisualStyleBackColor = true;
            this.chkGetBets.CheckedChanged += new System.EventHandler(this.chkGetCompleteMarketTradedVolume_CheckedChanged);
            // 
            // chkGetCompleteMarketTradedVolume
            // 
            this.chkGetCompleteMarketTradedVolume.AutoSize = true;
            this.chkGetCompleteMarketTradedVolume.Location = new System.Drawing.Point(25, 64);
            this.chkGetCompleteMarketTradedVolume.Name = "chkGetCompleteMarketTradedVolume";
            this.chkGetCompleteMarketTradedVolume.Size = new System.Drawing.Size(201, 17);
            this.chkGetCompleteMarketTradedVolume.TabIndex = 2;
            this.chkGetCompleteMarketTradedVolume.Text = "Get Complete Market Traded Volume";
            this.chkGetCompleteMarketTradedVolume.UseVisualStyleBackColor = true;
            this.chkGetCompleteMarketTradedVolume.CheckedChanged += new System.EventHandler(this.chkGetCompleteMarketTradedVolume_CheckedChanged);
            // 
            // groupBoxFilterMarketResults
            // 
            this.groupBoxFilterMarketResults.Controls.Add(this.dgFilterGetAllMarketsResultsWhere);
            this.groupBoxFilterMarketResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFilterMarketResults.Location = new System.Drawing.Point(0, 306);
            this.groupBoxFilterMarketResults.Name = "groupBoxFilterMarketResults";
            this.groupBoxFilterMarketResults.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxFilterMarketResults.Size = new System.Drawing.Size(552, 139);
            this.groupBoxFilterMarketResults.TabIndex = 29;
            this.groupBoxFilterMarketResults.TabStop = false;
            this.groupBoxFilterMarketResults.Text = "Filter Get All Markets Response";
            // 
            // dgFilterGetAllMarketsResultsWhere
            // 
            this.dgFilterGetAllMarketsResultsWhere.AllowUserToOrderColumns = true;
            this.dgFilterGetAllMarketsResultsWhere.AutoGenerateColumns = false;
            this.dgFilterGetAllMarketsResultsWhere.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgFilterGetAllMarketsResultsWhere.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fieldDataGridViewTextBoxColumn,
            this.operatorDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.dgFilterGetAllMarketsResultsWhere.DataMember = "TableGetAllMarketsResultsFilter";
            this.dgFilterGetAllMarketsResultsWhere.DataSource = this.dsGetAllMarketsResultsFilters;
            this.dgFilterGetAllMarketsResultsWhere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFilterGetAllMarketsResultsWhere.Location = new System.Drawing.Point(6, 19);
            this.dgFilterGetAllMarketsResultsWhere.Name = "dgFilterGetAllMarketsResultsWhere";
            this.dgFilterGetAllMarketsResultsWhere.RowHeadersWidth = 44;
            this.dgFilterGetAllMarketsResultsWhere.Size = new System.Drawing.Size(540, 114);
            this.dgFilterGetAllMarketsResultsWhere.TabIndex = 0;
            this.dgFilterGetAllMarketsResultsWhere.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgFilterGetAllMarketsResultsWhere_DataBindingComplete);
            // 
            // fieldDataGridViewTextBoxColumn
            // 
            this.fieldDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fieldDataGridViewTextBoxColumn.DataPropertyName = "Field";
            this.fieldDataGridViewTextBoxColumn.FillWeight = 150F;
            this.fieldDataGridViewTextBoxColumn.HeaderText = "Field";
            this.fieldDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "marketId",
            "name",
            "type",
            "status",
            "eventDate",
            "menuPath",
            "eventHierarchy",
            "betDelay",
            "exchangeId",
            "country",
            "numberOfRunners",
            "numberOfWinners",
            "totalAmountMatched",
            "bspMarket",
            "turningInPlay"});
            this.fieldDataGridViewTextBoxColumn.Name = "fieldDataGridViewTextBoxColumn";
            this.fieldDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fieldDataGridViewTextBoxColumn.Width = 54;
            // 
            // operatorDataGridViewTextBoxColumn
            // 
            this.operatorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.operatorDataGridViewTextBoxColumn.DataPropertyName = "Operator";
            this.operatorDataGridViewTextBoxColumn.FillWeight = 150F;
            this.operatorDataGridViewTextBoxColumn.HeaderText = "Operator";
            this.operatorDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "EQUAL",
            "NOT_EQUAL",
            "CONTAINS",
            "NOT_CONTAINS",
            "GREATER_THAN",
            "LESS_THAN",
            "REGEX_IS_MATCH",
            "REGEX_NOT_MATCH"});
            this.operatorDataGridViewTextBoxColumn.Name = "operatorDataGridViewTextBoxColumn";
            this.operatorDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.operatorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.operatorDataGridViewTextBoxColumn.Width = 73;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.FillWeight = 150F;
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.Width = 59;
            // 
            // dsGetAllMarketsResultsFilters
            // 
            this.dsGetAllMarketsResultsFilters.DataSetName = "dsGetAllMarketsResultsFilters";
            this.dsGetAllMarketsResultsFilters.Tables.AddRange(new System.Data.DataTable[] {
            this.TableGetAllMarketsResultsFilter});
            // 
            // TableGetAllMarketsResultsFilter
            // 
            this.TableGetAllMarketsResultsFilter.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.TableGetAllMarketsResultsFilter.TableName = "TableGetAllMarketsResultsFilter";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.Caption = "Field";
            this.dataColumn1.ColumnName = "Field";
            // 
            // dataColumn2
            // 
            this.dataColumn2.AllowDBNull = false;
            this.dataColumn2.Caption = "Operator";
            this.dataColumn2.ColumnName = "Operator";
            // 
            // dataColumn3
            // 
            this.dataColumn3.AllowDBNull = false;
            this.dataColumn3.Caption = "Value";
            this.dataColumn3.ColumnName = "Value";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnDirectoryBrowser
            // 
            this.btnDirectoryBrowser.FlatAppearance.BorderSize = 0;
            this.btnDirectoryBrowser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDirectoryBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDirectoryBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectoryBrowser.Location = new System.Drawing.Point(362, 100);
            this.btnDirectoryBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.btnDirectoryBrowser.Name = "btnDirectoryBrowser";
            this.btnDirectoryBrowser.Size = new System.Drawing.Size(29, 20);
            this.btnDirectoryBrowser.TabIndex = 33;
            this.btnDirectoryBrowser.Text = "...";
            this.btnDirectoryBrowser.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolTip1.SetToolTip(this.btnDirectoryBrowser, "Directory browser.");
            this.btnDirectoryBrowser.UseVisualStyleBackColor = true;
            this.btnDirectoryBrowser.Click += new System.EventHandler(this.btnDirectoryBrowser_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // btnShowPluginForm
            // 
            this.btnShowPluginForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowPluginForm.Location = new System.Drawing.Point(394, 97);
            this.btnShowPluginForm.Name = "btnShowPluginForm";
            this.btnShowPluginForm.Size = new System.Drawing.Size(139, 25);
            this.btnShowPluginForm.TabIndex = 34;
            this.btnShowPluginForm.Text = "Edit Plugin Configuration";
            this.btnShowPluginForm.UseVisualStyleBackColor = true;
            this.btnShowPluginForm.Click += new System.EventHandler(this.btnShowPluginForm_Click);
            // 
            // StrategyLoadPaternsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(380, 445);
            this.Controls.Add(this.groupBoxFilterMarketResults);
            this.Controls.Add(this.groupBoxOnMarketLoad);
            this.Controls.Add(this.groupBoxDescription);
            this.Name = "StrategyLoadPaternsView";
            this.Size = new System.Drawing.Size(552, 445);
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxDescription.PerformLayout();
            this.groupBoxOnMarketLoad.ResumeLayout(false);
            this.groupBoxOnMarketLoad.PerformLayout();
            this.groupBoxFilterMarketResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFilterGetAllMarketsResultsWhere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGetAllMarketsResultsFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableGetAllMarketsResultsFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDescription;
        private System.Windows.Forms.TextBox txtCustomLibrary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxOnMarketLoad;
        private System.Windows.Forms.RadioButton rbGetMarketPricesComplete;
        private System.Windows.Forms.RadioButton rbGetMarketPrices;
        private System.Windows.Forms.CheckBox chkTerminateMarketThread;
        private System.Windows.Forms.CheckBox chkGetExtendedRunnerInfo;
        private System.Windows.Forms.CheckBox chkGetBets;
        private System.Windows.Forms.CheckBox chkGetCompleteMarketTradedVolume;
        private System.Windows.Forms.GroupBox groupBoxFilterMarketResults;
        private System.Windows.Forms.DataGridView dgFilterGetAllMarketsResultsWhere;
        private System.Data.DataSet dsGetAllMarketsResultsFilters;
        private System.Data.DataTable TableGetAllMarketsResultsFilter;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewComboBoxColumn fieldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn operatorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnDirectoryBrowser;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnShowPluginForm;
    }
}
