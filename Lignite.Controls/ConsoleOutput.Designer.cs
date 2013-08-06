namespace Lignite.Controls
{
    partial class ConsoleOutput
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.eventController = new Lignite.Controls.EventController();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(672, 24);
            this.panelTop.TabIndex = 0;
            this.panelTop.Visible = false;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.BackColor = System.Drawing.Color.Black;
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutput.ForeColor = System.Drawing.Color.White;
            this.textBoxOutput.Location = new System.Drawing.Point(0, 24);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(672, 240);
            this.textBoxOutput.TabIndex = 1;
            // 
            // eventController
            // 
            this.eventController.DisplayMessage += new Lignite.Controls.Events.DisplayMessageEventHandler(this.InvokeDisplayMessage);
            // 
            // ConsoleOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.panelTop);
            this.Name = "ConsoleOutput";
            this.Size = new System.Drawing.Size(672, 264);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox textBoxOutput;
        private EventController eventController;
    }
}
