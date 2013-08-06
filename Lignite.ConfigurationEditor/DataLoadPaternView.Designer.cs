namespace Lignite.ConfigurationEditor
{
    partial class DataLoadPaternView
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
            this.dsDataLoadPaterns = new System.Data.DataSet();
            this.DataLoad = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgDataLoadFrequency = new System.Windows.Forms.DataGridView();
            this.timeBeforeOffDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getMarketPricesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.getMarketPricesCompleteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.getCompleteMarketTradedVolumeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.getBetsDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.getExtendedRunnerInfoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.terminateMarketThreadDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsDataLoadPaterns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataLoad)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDataLoadFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // dsDataLoadPaterns
            // 
            this.dsDataLoadPaterns.DataSetName = "dsDataLoadPaterns";
            this.dsDataLoadPaterns.Tables.AddRange(new System.Data.DataTable[] {
            this.DataLoad});
            // 
            // DataLoad
            // 
            this.DataLoad.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8});
            this.DataLoad.TableName = "DataLoad";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.ColumnName = "TimeBeforeOff";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.AllowDBNull = false;
            this.dataColumn2.ColumnName = "Frequency";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "GetMarketPrices";
            this.dataColumn3.DataType = typeof(bool);
            this.dataColumn3.DefaultValue = false;
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "GetMarketPricesComplete";
            this.dataColumn4.DataType = typeof(bool);
            this.dataColumn4.DefaultValue = false;
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "GetCompleteMarketTradedVolume";
            this.dataColumn5.DataType = typeof(bool);
            this.dataColumn5.DefaultValue = false;
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "GetBets";
            this.dataColumn6.DataType = typeof(bool);
            this.dataColumn6.DefaultValue = false;
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "GetExtendedRunnerInfo";
            this.dataColumn7.DataType = typeof(bool);
            this.dataColumn7.DefaultValue = false;
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "TerminateMarketThread";
            this.dataColumn8.DataType = typeof(bool);
            this.dataColumn8.DefaultValue = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgDataLoadFrequency);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(774, 349);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Load Frequency Based on the Betfair Start Time";
            // 
            // dgDataLoadFrequency
            // 
            this.dgDataLoadFrequency.AllowUserToOrderColumns = true;
            this.dgDataLoadFrequency.AutoGenerateColumns = false;
            this.dgDataLoadFrequency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDataLoadFrequency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timeBeforeOffDataGridViewTextBoxColumn,
            this.frequencyDataGridViewTextBoxColumn,
            this.getMarketPricesDataGridViewCheckBoxColumn,
            this.getMarketPricesCompleteDataGridViewCheckBoxColumn,
            this.getCompleteMarketTradedVolumeDataGridViewCheckBoxColumn,
            this.getBetsDataGridViewCheckBoxColumn,
            this.getExtendedRunnerInfoDataGridViewCheckBoxColumn,
            this.terminateMarketThreadDataGridViewCheckBoxColumn});
            this.dgDataLoadFrequency.DataMember = "DataLoad";
            this.dgDataLoadFrequency.DataSource = this.dsDataLoadPaterns;
            this.dgDataLoadFrequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDataLoadFrequency.Location = new System.Drawing.Point(6, 19);
            this.dgDataLoadFrequency.Name = "dgDataLoadFrequency";
            this.dgDataLoadFrequency.Size = new System.Drawing.Size(762, 324);
            this.dgDataLoadFrequency.TabIndex = 1;
            this.dgDataLoadFrequency.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgDataLoadFrequency_UserAddedRow);
            this.dgDataLoadFrequency.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgDataLoadFrequency_DataBindingComplete);
            // 
            // timeBeforeOffDataGridViewTextBoxColumn
            // 
            this.timeBeforeOffDataGridViewTextBoxColumn.DataPropertyName = "TimeBeforeOff";
            this.timeBeforeOffDataGridViewTextBoxColumn.HeaderText = "TimeBeforeOff";
            this.timeBeforeOffDataGridViewTextBoxColumn.Name = "timeBeforeOffDataGridViewTextBoxColumn";
            // 
            // frequencyDataGridViewTextBoxColumn
            // 
            this.frequencyDataGridViewTextBoxColumn.DataPropertyName = "Frequency";
            this.frequencyDataGridViewTextBoxColumn.HeaderText = "Frequency";
            this.frequencyDataGridViewTextBoxColumn.Name = "frequencyDataGridViewTextBoxColumn";
            // 
            // getMarketPricesDataGridViewCheckBoxColumn
            // 
            this.getMarketPricesDataGridViewCheckBoxColumn.DataPropertyName = "GetMarketPrices";
            this.getMarketPricesDataGridViewCheckBoxColumn.HeaderText = "GetMarketPrices";
            this.getMarketPricesDataGridViewCheckBoxColumn.Name = "getMarketPricesDataGridViewCheckBoxColumn";
            // 
            // getMarketPricesCompleteDataGridViewCheckBoxColumn
            // 
            this.getMarketPricesCompleteDataGridViewCheckBoxColumn.DataPropertyName = "GetMarketPricesComplete";
            this.getMarketPricesCompleteDataGridViewCheckBoxColumn.HeaderText = "GetMarketPricesComplete";
            this.getMarketPricesCompleteDataGridViewCheckBoxColumn.Name = "getMarketPricesCompleteDataGridViewCheckBoxColumn";
            // 
            // getCompleteMarketTradedVolumeDataGridViewCheckBoxColumn
            // 
            this.getCompleteMarketTradedVolumeDataGridViewCheckBoxColumn.DataPropertyName = "GetCompleteMarketTradedVolume";
            this.getCompleteMarketTradedVolumeDataGridViewCheckBoxColumn.HeaderText = "GetCompleteMarketTradedVolume";
            this.getCompleteMarketTradedVolumeDataGridViewCheckBoxColumn.Name = "getCompleteMarketTradedVolumeDataGridViewCheckBoxColumn";
            // 
            // getBetsDataGridViewCheckBoxColumn
            // 
            this.getBetsDataGridViewCheckBoxColumn.DataPropertyName = "GetBets";
            this.getBetsDataGridViewCheckBoxColumn.HeaderText = "GetBets";
            this.getBetsDataGridViewCheckBoxColumn.Name = "getBetsDataGridViewCheckBoxColumn";
            // 
            // getExtendedRunnerInfoDataGridViewCheckBoxColumn
            // 
            this.getExtendedRunnerInfoDataGridViewCheckBoxColumn.DataPropertyName = "GetExtendedRunnerInfo";
            this.getExtendedRunnerInfoDataGridViewCheckBoxColumn.HeaderText = "GetExtendedRunnerInfo";
            this.getExtendedRunnerInfoDataGridViewCheckBoxColumn.Name = "getExtendedRunnerInfoDataGridViewCheckBoxColumn";
            // 
            // terminateMarketThreadDataGridViewCheckBoxColumn
            // 
            this.terminateMarketThreadDataGridViewCheckBoxColumn.DataPropertyName = "TerminateMarketThread";
            this.terminateMarketThreadDataGridViewCheckBoxColumn.HeaderText = "TerminateMarketThread";
            this.terminateMarketThreadDataGridViewCheckBoxColumn.Name = "terminateMarketThreadDataGridViewCheckBoxColumn";
            // 
            // DataLoadPaternView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DataLoadPaternView";
            this.Size = new System.Drawing.Size(774, 349);
            ((System.ComponentModel.ISupportInitialize)(this.dsDataLoadPaterns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataLoad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDataLoadFrequency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dsDataLoadPaterns;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgDataLoadFrequency;
        private System.Data.DataTable DataLoad;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeBeforeOffDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn getMarketPricesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn getMarketPricesCompleteDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn getCompleteMarketTradedVolumeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn getBetsDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn getExtendedRunnerInfoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn terminateMarketThreadDataGridViewCheckBoxColumn;
    }
}
