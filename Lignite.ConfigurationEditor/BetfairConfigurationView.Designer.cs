namespace Lignite.ConfigurationEditor
{
    partial class BetfairConfigurationView
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
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVendorSoftwareId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndPointGlobal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEndPointUK = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEndPointAustralia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxEndPoints = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAutoKeepAlive = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxEndPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(109, 64);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(76, 20);
            this.txtProductId.TabIndex = 18;
            this.txtProductId.Text = "0";
            this.txtProductId.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtProductId.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_int);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(109, 31);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(213, 20);
            this.txtPassword.TabIndex = 16;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_string);
            // 
            // txtUsername
            // 
            this.errorProvider1.SetIconPadding(this.txtUsername, 5);
            this.txtUsername.Location = new System.Drawing.Point(109, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(213, 20);
            this.txtUsername.TabIndex = 15;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_string);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Vendor Software ID";
            // 
            // txtVendorSoftwareId
            // 
            this.txtVendorSoftwareId.Location = new System.Drawing.Point(109, 90);
            this.txtVendorSoftwareId.Name = "txtVendorSoftwareId";
            this.txtVendorSoftwareId.Size = new System.Drawing.Size(76, 20);
            this.txtVendorSoftwareId.TabIndex = 19;
            this.txtVendorSoftwareId.Text = "0";
            this.txtVendorSoftwareId.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtVendorSoftwareId.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Product ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Username";
            // 
            // txtEndPointGlobal
            // 
            this.txtEndPointGlobal.Location = new System.Drawing.Point(103, 19);
            this.txtEndPointGlobal.Name = "txtEndPointGlobal";
            this.txtEndPointGlobal.Size = new System.Drawing.Size(213, 20);
            this.txtEndPointGlobal.TabIndex = 21;
            this.txtEndPointGlobal.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtEndPointGlobal.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_string);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Global";
            // 
            // txtEndPointUK
            // 
            this.txtEndPointUK.Location = new System.Drawing.Point(103, 45);
            this.txtEndPointUK.Name = "txtEndPointUK";
            this.txtEndPointUK.Size = new System.Drawing.Size(213, 20);
            this.txtEndPointUK.TabIndex = 23;
            this.txtEndPointUK.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtEndPointUK.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_string);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "United Kingdom";
            // 
            // txtEndPointAustralia
            // 
            this.txtEndPointAustralia.Location = new System.Drawing.Point(103, 71);
            this.txtEndPointAustralia.Name = "txtEndPointAustralia";
            this.txtEndPointAustralia.Size = new System.Drawing.Size(213, 20);
            this.txtEndPointAustralia.TabIndex = 25;
            this.txtEndPointAustralia.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtEndPointAustralia.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_string);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Australia";
            // 
            // groupBoxEndPoints
            // 
            this.groupBoxEndPoints.AutoSize = true;
            this.groupBoxEndPoints.Controls.Add(this.txtEndPointGlobal);
            this.groupBoxEndPoints.Controls.Add(this.txtEndPointAustralia);
            this.groupBoxEndPoints.Controls.Add(this.label5);
            this.groupBoxEndPoints.Controls.Add(this.label7);
            this.groupBoxEndPoints.Controls.Add(this.label6);
            this.groupBoxEndPoints.Controls.Add(this.txtEndPointUK);
            this.groupBoxEndPoints.Location = new System.Drawing.Point(6, 147);
            this.groupBoxEndPoints.Name = "groupBoxEndPoints";
            this.groupBoxEndPoints.Size = new System.Drawing.Size(347, 110);
            this.groupBoxEndPoints.TabIndex = 26;
            this.groupBoxEndPoints.TabStop = false;
            this.groupBoxEndPoints.Text = "End Points";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Auto Keep Alive";
            // 
            // txtAutoKeepAlive
            // 
            this.txtAutoKeepAlive.Location = new System.Drawing.Point(109, 116);
            this.txtAutoKeepAlive.Name = "txtAutoKeepAlive";
            this.txtAutoKeepAlive.Size = new System.Drawing.Size(76, 20);
            this.txtAutoKeepAlive.TabIndex = 28;
            this.txtAutoKeepAlive.Text = "0";
            this.txtAutoKeepAlive.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtAutoKeepAlive.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating_int);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Milliseconds";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // BetfairConfigurationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(350, 270);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAutoKeepAlive);
            this.Controls.Add(this.groupBoxEndPoints);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtVendorSoftwareId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BetfairConfigurationView";
            this.Size = new System.Drawing.Size(363, 271);
            this.groupBoxEndPoints.ResumeLayout(false);
            this.groupBoxEndPoints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVendorSoftwareId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEndPointGlobal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEndPointUK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEndPointAustralia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxEndPoints;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAutoKeepAlive;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}
