namespace Lignite.ConfigurationEditor
{
    partial class GetAllMarketsConfigurationView
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
            this.txtEventDateFrom = new System.Windows.Forms.TextBox();
            this.txtRunMarketsQueryEvery = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEventDateTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCountries = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEventIds = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbExchangeIds = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEventDateFrom
            // 
            this.txtEventDateFrom.Location = new System.Drawing.Point(157, 29);
            this.txtEventDateFrom.Name = "txtEventDateFrom";
            this.txtEventDateFrom.Size = new System.Drawing.Size(82, 20);
            this.txtEventDateFrom.TabIndex = 20;
            this.txtEventDateFrom.TextChanged += new System.EventHandler(this.txtRunMarketsQueryEvery_TextChanged);
            this.txtEventDateFrom.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_int);
            // 
            // txtRunMarketsQueryEvery
            // 
            this.txtRunMarketsQueryEvery.Location = new System.Drawing.Point(157, 3);
            this.txtRunMarketsQueryEvery.Name = "txtRunMarketsQueryEvery";
            this.txtRunMarketsQueryEvery.Size = new System.Drawing.Size(82, 20);
            this.txtRunMarketsQueryEvery.TabIndex = 19;
            this.txtRunMarketsQueryEvery.TextChanged += new System.EventHandler(this.txtRunMarketsQueryEvery_TextChanged);
            this.txtRunMarketsQueryEvery.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Find Markets Starting in";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Search for new markets every";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(245, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Milliseconds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Milliseconds from now up to ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Milliseconds from now";
            // 
            // txtEventDateTo
            // 
            this.txtEventDateTo.Location = new System.Drawing.Point(391, 29);
            this.txtEventDateTo.Name = "txtEventDateTo";
            this.txtEventDateTo.Size = new System.Drawing.Size(104, 20);
            this.txtEventDateTo.TabIndex = 32;
            this.txtEventDateTo.TextChanged += new System.EventHandler(this.txtRunMarketsQueryEvery_TextChanged);
            this.txtEventDateTo.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "ISO3 Country Codes";
            // 
            // txtCountries
            // 
            this.txtCountries.Location = new System.Drawing.Point(157, 55);
            this.txtCountries.Multiline = true;
            this.txtCountries.Name = "txtCountries";
            this.txtCountries.Size = new System.Drawing.Size(152, 90);
            this.txtCountries.TabIndex = 35;
            this.txtCountries.TextChanged += new System.EventHandler(this.txtRunMarketsQueryEvery_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "(one item per line)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "(one item per line)";
            // 
            // txtEventIds
            // 
            this.txtEventIds.Location = new System.Drawing.Point(157, 151);
            this.txtEventIds.Multiline = true;
            this.txtEventIds.Name = "txtEventIds";
            this.txtEventIds.Size = new System.Drawing.Size(152, 92);
            this.txtEventIds.TabIndex = 38;
            this.txtEventIds.TextChanged += new System.EventHandler(this.txtRunMarketsQueryEvery_TextChanged);
            this.txtEventIds.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_int_array);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Event ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Exchanges to search";
            // 
            // cmbExchangeIds
            // 
            this.cmbExchangeIds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExchangeIds.FormattingEnabled = true;
            this.cmbExchangeIds.Items.AddRange(new object[] {
            "UK Only",
            "Aus Only",
            "All"});
            this.cmbExchangeIds.Location = new System.Drawing.Point(157, 249);
            this.cmbExchangeIds.Name = "cmbExchangeIds";
            this.cmbExchangeIds.Size = new System.Drawing.Size(121, 21);
            this.cmbExchangeIds.TabIndex = 41;
            this.cmbExchangeIds.SelectedIndexChanged += new System.EventHandler(this.txtRunMarketsQueryEvery_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // GetAllMarketsConfigurationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(640, 280);
            this.Controls.Add(this.cmbExchangeIds);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEventIds);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCountries);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEventDateTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEventDateFrom);
            this.Controls.Add(this.txtRunMarketsQueryEvery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GetAllMarketsConfigurationView";
            this.Size = new System.Drawing.Size(640, 280);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEventDateFrom;
        private System.Windows.Forms.TextBox txtRunMarketsQueryEvery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEventDateTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCountries;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEventIds;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbExchangeIds;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
