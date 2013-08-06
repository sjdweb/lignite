namespace Lignite.Controls
{
    partial class CurrentBetsView
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
            this.labelCurrentBets = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopRight = new System.Windows.Forms.Panel();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelBottomRight = new System.Windows.Forms.Panel();
            this.panelBottomLeft = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCurrentBets
            // 
            this.labelCurrentBets.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCurrentBets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentBets.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelCurrentBets.Location = new System.Drawing.Point(3, 3);
            this.labelCurrentBets.Name = "labelCurrentBets";
            this.labelCurrentBets.Size = new System.Drawing.Size(241, 21);
            this.labelCurrentBets.TabIndex = 15;
            this.labelCurrentBets.Text = "Current bets";
            this.labelCurrentBets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panelTop.Controls.Add(this.panelTopRight);
            this.panelTop.Controls.Add(this.panelTopLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(3, 24);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(241, 12);
            this.panelTop.TabIndex = 0;
            // 
            // panelTopRight
            // 
            this.panelTopRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTopRight.BackColor = System.Drawing.Color.White;
            this.panelTopRight.BackgroundImage = global::Lignite.Controls.Properties.Resources.RoundedRightTop;
            this.panelTopRight.Location = new System.Drawing.Point(229, 0);
            this.panelTopRight.Name = "panelTopRight";
            this.panelTopRight.Size = new System.Drawing.Size(12, 12);
            this.panelTopRight.TabIndex = 10;
            // 
            // panelTopLeft
            // 
            this.panelTopLeft.BackColor = System.Drawing.Color.White;
            this.panelTopLeft.BackgroundImage = global::Lignite.Controls.Properties.Resources.RoundedLeftTop;
            this.panelTopLeft.Location = new System.Drawing.Point(0, 0);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Size = new System.Drawing.Size(12, 12);
            this.panelTopLeft.TabIndex = 9;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panelBottom.Controls.Add(this.panelBottomRight);
            this.panelBottom.Controls.Add(this.panelBottomLeft);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(3, 428);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(241, 12);
            this.panelBottom.TabIndex = 2;
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottomRight.BackColor = System.Drawing.Color.White;
            this.panelBottomRight.BackgroundImage = global::Lignite.Controls.Properties.Resources.RoundedRightBottom;
            this.panelBottomRight.Location = new System.Drawing.Point(229, 0);
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
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(3, 36);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(241, 392);
            this.panelBody.TabIndex = 3;
            // 
            // CurrentBetsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.labelCurrentBets);
            this.Name = "CurrentBetsView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(247, 443);
            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTopRight;
        private System.Windows.Forms.Panel panelTopLeft;
        private System.Windows.Forms.Panel panelBottomRight;
        private System.Windows.Forms.Panel panelBottomLeft;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Label labelCurrentBets;
    }
}
