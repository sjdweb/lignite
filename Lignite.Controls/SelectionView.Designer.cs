using System.Windows.Forms;

namespace Lignite.Controls
{
    partial class SelectionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionView));
            this.btnLay3 = new Lignite.Controls.SelectionView.SelectionPriceButton();
            this.btnLay2 = new Lignite.Controls.SelectionView.SelectionPriceButton();
            this.btnLay1 = new Lignite.Controls.SelectionView.SelectionPriceButton();
            this.btnSPLay = new Lignite.Controls.SelectionView.SelectionPriceButton();
            this.lblSPPrice = new System.Windows.Forms.Label();
            this.btnSPBack = new Lignite.Controls.SelectionView.SelectionPriceButton();
            this.btnBack1 = new Lignite.Controls.SelectionView.SelectionPriceButton();
            this.btnBack2 = new Lignite.Controls.SelectionView.SelectionPriceButton();
            this.btnBack3 = new Lignite.Controls.SelectionView.SelectionPriceButton();
            this.panelAditionalRunnerInfoLeft = new System.Windows.Forms.Panel();
            this.picBoxSilks = new System.Windows.Forms.PictureBox();
            this.panelStallDraw = new System.Windows.Forms.Panel();
            this.lblStallDraw = new System.Windows.Forms.Label();
            this.panelClothNumber = new System.Windows.Forms.Panel();
            this.lblClothNumber = new System.Windows.Forms.Label();
            this.panelShowChart = new System.Windows.Forms.Panel();
            this.lblRunnerName = new System.Windows.Forms.Label();
            this.panelWhatIf = new System.Windows.Forms.Panel();
            this.lblWhatIfRight = new System.Windows.Forms.Label();
            this.lblWhatIfLeft = new System.Windows.Forms.Label();
            this.toolTipMarketThreadControlRunner = new System.Windows.Forms.ToolTip(this.components);
            this.eventController = new Lignite.Controls.EventController();
            this.panelAditionalRunnerInfoLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSilks)).BeginInit();
            this.panelStallDraw.SuspendLayout();
            this.panelClothNumber.SuspendLayout();
            this.panelWhatIf.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLay3
            // 
            this.btnLay3.BackColor = System.Drawing.Color.White;
            this.btnLay3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLay3.BackgroundImage")));
            this.btnLay3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLay3.ButtonDepth = 3;
            this.btnLay3.ButtonType = Betfair.Collections.BetTypeOptions.L;
            this.btnLay3.CurrencySymbol = "";
            this.btnLay3.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLay3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLay3.FlatAppearance.BorderSize = 0;
            this.btnLay3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnLay3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLay3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLay3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLay3.IsActive = false;
            this.btnLay3.IsPrimaryButton = false;
            this.btnLay3.IsSpButton = false;
            this.btnLay3.Location = new System.Drawing.Point(659, 2);
            this.btnLay3.Name = "btnLay3";
            this.btnLay3.PriceItem = ((Betfair.Collections.Price)(resources.GetObject("btnLay3.PriceItem")));
            this.btnLay3.Size = new System.Drawing.Size(55, 35);
            this.btnLay3.TabIndex = 1;
            this.btnLay3.Text = "Price Size";
            this.btnLay3.UseVisualStyleBackColor = true;
            this.btnLay3.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.btnLay3.Click += new System.EventHandler(this.selectionPriceButton_MouseClick);
            this.btnLay3.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // btnLay2
            // 
            this.btnLay2.BackColor = System.Drawing.Color.White;
            this.btnLay2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLay2.BackgroundImage")));
            this.btnLay2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLay2.ButtonDepth = 2;
            this.btnLay2.ButtonType = Betfair.Collections.BetTypeOptions.L;
            this.btnLay2.CurrencySymbol = "";
            this.btnLay2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLay2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLay2.FlatAppearance.BorderSize = 0;
            this.btnLay2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnLay2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLay2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLay2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLay2.IsActive = false;
            this.btnLay2.IsPrimaryButton = false;
            this.btnLay2.IsSpButton = false;
            this.btnLay2.Location = new System.Drawing.Point(604, 2);
            this.btnLay2.Name = "btnLay2";
            this.btnLay2.PriceItem = ((Betfair.Collections.Price)(resources.GetObject("btnLay2.PriceItem")));
            this.btnLay2.Size = new System.Drawing.Size(55, 35);
            this.btnLay2.TabIndex = 2;
            this.btnLay2.Text = "Price Size";
            this.btnLay2.UseVisualStyleBackColor = false;
            this.btnLay2.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.btnLay2.Click += new System.EventHandler(this.selectionPriceButton_MouseClick);
            this.btnLay2.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // btnLay1
            // 
            this.btnLay1.BackColor = System.Drawing.Color.White;
            this.btnLay1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLay1.BackgroundImage")));
            this.btnLay1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLay1.ButtonDepth = 1;
            this.btnLay1.ButtonType = Betfair.Collections.BetTypeOptions.L;
            this.btnLay1.CurrencySymbol = "";
            this.btnLay1.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLay1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLay1.FlatAppearance.BorderSize = 0;
            this.btnLay1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnLay1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLay1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLay1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLay1.IsActive = false;
            this.btnLay1.IsPrimaryButton = true;
            this.btnLay1.IsSpButton = false;
            this.btnLay1.Location = new System.Drawing.Point(549, 2);
            this.btnLay1.Name = "btnLay1";
            this.btnLay1.PriceItem = ((Betfair.Collections.Price)(resources.GetObject("btnLay1.PriceItem")));
            this.btnLay1.Size = new System.Drawing.Size(55, 35);
            this.btnLay1.TabIndex = 3;
            this.btnLay1.Text = "Price Size";
            this.btnLay1.UseVisualStyleBackColor = false;
            this.btnLay1.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.btnLay1.Click += new System.EventHandler(this.selectionPriceButton_MouseClick);
            this.btnLay1.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // btnSPLay
            // 
            this.btnSPLay.BackColor = System.Drawing.Color.White;
            this.btnSPLay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSPLay.BackgroundImage")));
            this.btnSPLay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSPLay.ButtonDepth = 0;
            this.btnSPLay.ButtonType = Betfair.Collections.BetTypeOptions.L;
            this.btnSPLay.CurrencySymbol = "";
            this.btnSPLay.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSPLay.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSPLay.FlatAppearance.BorderSize = 0;
            this.btnSPLay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSPLay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSPLay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSPLay.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSPLay.IsActive = false;
            this.btnSPLay.IsPrimaryButton = true;
            this.btnSPLay.IsSpButton = true;
            this.btnSPLay.Location = new System.Drawing.Point(494, 2);
            this.btnSPLay.Name = "btnSPLay";
            this.btnSPLay.PriceItem = ((Betfair.Collections.Price)(resources.GetObject("btnSPLay.PriceItem")));
            this.btnSPLay.Size = new System.Drawing.Size(55, 35);
            this.btnSPLay.TabIndex = 12;
            this.btnSPLay.Text = "SP";
            this.btnSPLay.UseVisualStyleBackColor = false;
            this.btnSPLay.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.btnSPLay.Click += new System.EventHandler(this.selectionPriceButton_MouseClick);
            this.btnSPLay.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // lblSPPrice
            // 
            this.lblSPPrice.BackColor = System.Drawing.Color.White;
            this.lblSPPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSPPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSPPrice.Location = new System.Drawing.Point(419, 2);
            this.lblSPPrice.Margin = new System.Windows.Forms.Padding(3);
            this.lblSPPrice.Name = "lblSPPrice";
            this.lblSPPrice.Padding = new System.Windows.Forms.Padding(1);
            this.lblSPPrice.Size = new System.Drawing.Size(75, 35);
            this.lblSPPrice.TabIndex = 14;
            this.lblSPPrice.Text = "Near: 28.62\nFar: 13.5";
            this.lblSPPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSPPrice.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.lblSPPrice.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // btnSPBack
            // 
            this.btnSPBack.BackColor = System.Drawing.Color.White;
            this.btnSPBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSPBack.BackgroundImage")));
            this.btnSPBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSPBack.ButtonDepth = 0;
            this.btnSPBack.ButtonType = Betfair.Collections.BetTypeOptions.B;
            this.btnSPBack.CurrencySymbol = "";
            this.btnSPBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSPBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSPBack.FlatAppearance.BorderSize = 0;
            this.btnSPBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSPBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSPBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSPBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSPBack.IsActive = false;
            this.btnSPBack.IsPrimaryButton = true;
            this.btnSPBack.IsSpButton = true;
            this.btnSPBack.Location = new System.Drawing.Point(364, 2);
            this.btnSPBack.Name = "btnSPBack";
            this.btnSPBack.PriceItem = ((Betfair.Collections.Price)(resources.GetObject("btnSPBack.PriceItem")));
            this.btnSPBack.Size = new System.Drawing.Size(55, 35);
            this.btnSPBack.TabIndex = 13;
            this.btnSPBack.Text = "SP";
            this.btnSPBack.UseVisualStyleBackColor = false;
            this.btnSPBack.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.btnSPBack.Click += new System.EventHandler(this.selectionPriceButton_MouseClick);
            this.btnSPBack.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // btnBack1
            // 
            this.btnBack1.BackColor = System.Drawing.Color.White;
            this.btnBack1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack1.BackgroundImage")));
            this.btnBack1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack1.ButtonDepth = 1;
            this.btnBack1.ButtonType = Betfair.Collections.BetTypeOptions.B;
            this.btnBack1.CurrencySymbol = "";
            this.btnBack1.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBack1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBack1.FlatAppearance.BorderSize = 0;
            this.btnBack1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBack1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBack1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack1.IsActive = false;
            this.btnBack1.IsPrimaryButton = true;
            this.btnBack1.IsSpButton = false;
            this.btnBack1.Location = new System.Drawing.Point(309, 2);
            this.btnBack1.Name = "btnBack1";
            this.btnBack1.PriceItem = ((Betfair.Collections.Price)(resources.GetObject("btnBack1.PriceItem")));
            this.btnBack1.Size = new System.Drawing.Size(55, 35);
            this.btnBack1.TabIndex = 4;
            this.btnBack1.Text = "Price\nSize";
            this.btnBack1.UseVisualStyleBackColor = false;
            this.btnBack1.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.btnBack1.Click += new System.EventHandler(this.selectionPriceButton_MouseClick);
            this.btnBack1.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // btnBack2
            // 
            this.btnBack2.BackColor = System.Drawing.Color.White;
            this.btnBack2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack2.BackgroundImage")));
            this.btnBack2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack2.ButtonDepth = 2;
            this.btnBack2.ButtonType = Betfair.Collections.BetTypeOptions.B;
            this.btnBack2.CurrencySymbol = "";
            this.btnBack2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBack2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBack2.FlatAppearance.BorderSize = 0;
            this.btnBack2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBack2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBack2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack2.IsActive = false;
            this.btnBack2.IsPrimaryButton = false;
            this.btnBack2.IsSpButton = false;
            this.btnBack2.Location = new System.Drawing.Point(254, 2);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.PriceItem = ((Betfair.Collections.Price)(resources.GetObject("btnBack2.PriceItem")));
            this.btnBack2.Size = new System.Drawing.Size(55, 35);
            this.btnBack2.TabIndex = 5;
            this.btnBack2.Text = "Price Size";
            this.btnBack2.UseVisualStyleBackColor = false;
            this.btnBack2.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.btnBack2.Click += new System.EventHandler(this.selectionPriceButton_MouseClick);
            this.btnBack2.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // btnBack3
            // 
            this.btnBack3.BackColor = System.Drawing.Color.White;
            this.btnBack3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack3.BackgroundImage")));
            this.btnBack3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack3.ButtonDepth = 3;
            this.btnBack3.ButtonType = Betfair.Collections.BetTypeOptions.B;
            this.btnBack3.CurrencySymbol = "";
            this.btnBack3.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBack3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBack3.FlatAppearance.BorderSize = 0;
            this.btnBack3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBack3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBack3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack3.IsActive = false;
            this.btnBack3.IsPrimaryButton = false;
            this.btnBack3.IsSpButton = false;
            this.btnBack3.Location = new System.Drawing.Point(199, 2);
            this.btnBack3.Name = "btnBack3";
            this.btnBack3.PriceItem = ((Betfair.Collections.Price)(resources.GetObject("btnBack3.PriceItem")));
            this.btnBack3.Size = new System.Drawing.Size(55, 35);
            this.btnBack3.TabIndex = 6;
            this.btnBack3.Text = "Price Size";
            this.btnBack3.UseVisualStyleBackColor = true;
            this.btnBack3.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.btnBack3.Click += new System.EventHandler(this.selectionPriceButton_MouseClick);
            this.btnBack3.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // panelAditionalRunnerInfoLeft
            // 
            this.panelAditionalRunnerInfoLeft.Controls.Add(this.picBoxSilks);
            this.panelAditionalRunnerInfoLeft.Controls.Add(this.panelStallDraw);
            this.panelAditionalRunnerInfoLeft.Controls.Add(this.panelClothNumber);
            this.panelAditionalRunnerInfoLeft.Controls.Add(this.panelShowChart);
            this.panelAditionalRunnerInfoLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAditionalRunnerInfoLeft.Location = new System.Drawing.Point(1, 2);
            this.panelAditionalRunnerInfoLeft.Name = "panelAditionalRunnerInfoLeft";
            this.panelAditionalRunnerInfoLeft.Size = new System.Drawing.Size(92, 35);
            this.panelAditionalRunnerInfoLeft.TabIndex = 15;
            // 
            // picBoxSilks
            // 
            this.picBoxSilks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBoxSilks.Dock = System.Windows.Forms.DockStyle.Left;
            this.picBoxSilks.ErrorImage = global::Lignite.Controls.Properties.Resources.sample_silk;
            this.picBoxSilks.Image = global::Lignite.Controls.Properties.Resources.sample_silk;
            this.picBoxSilks.InitialImage = global::Lignite.Controls.Properties.Resources.sample_silk;
            this.picBoxSilks.Location = new System.Drawing.Point(60, 0);
            this.picBoxSilks.Name = "picBoxSilks";
            this.picBoxSilks.Size = new System.Drawing.Size(30, 35);
            this.picBoxSilks.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxSilks.TabIndex = 20;
            this.picBoxSilks.TabStop = false;
            this.picBoxSilks.Visible = false;
            this.picBoxSilks.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.picBoxSilks.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // panelStallDraw
            // 
            this.panelStallDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelStallDraw.Controls.Add(this.lblStallDraw);
            this.panelStallDraw.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelStallDraw.Location = new System.Drawing.Point(34, 0);
            this.panelStallDraw.Name = "panelStallDraw";
            this.panelStallDraw.Size = new System.Drawing.Size(26, 35);
            this.panelStallDraw.TabIndex = 19;
            this.panelStallDraw.Visible = false;
            // 
            // lblStallDraw
            // 
            this.lblStallDraw.AutoSize = true;
            this.lblStallDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStallDraw.Location = new System.Drawing.Point(-3, 12);
            this.lblStallDraw.Margin = new System.Windows.Forms.Padding(0);
            this.lblStallDraw.Name = "lblStallDraw";
            this.lblStallDraw.Size = new System.Drawing.Size(29, 13);
            this.lblStallDraw.TabIndex = 0;
            this.lblStallDraw.Text = "(16)";
            this.lblStallDraw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTipMarketThreadControlRunner.SetToolTip(this.lblStallDraw, "Stall Draw");
            this.lblStallDraw.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.lblStallDraw.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // panelClothNumber
            // 
            this.panelClothNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelClothNumber.Controls.Add(this.lblClothNumber);
            this.panelClothNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelClothNumber.Location = new System.Drawing.Point(16, 0);
            this.panelClothNumber.Name = "panelClothNumber";
            this.panelClothNumber.Size = new System.Drawing.Size(18, 35);
            this.panelClothNumber.TabIndex = 17;
            this.panelClothNumber.Visible = false;
            // 
            // lblClothNumber
            // 
            this.lblClothNumber.AutoSize = true;
            this.lblClothNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClothNumber.Location = new System.Drawing.Point(-1, 12);
            this.lblClothNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblClothNumber.Name = "lblClothNumber";
            this.lblClothNumber.Size = new System.Drawing.Size(21, 13);
            this.lblClothNumber.TabIndex = 0;
            this.lblClothNumber.Text = "39";
            this.lblClothNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTipMarketThreadControlRunner.SetToolTip(this.lblClothNumber, "Saddlecloth Number");
            this.lblClothNumber.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.lblClothNumber.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // panelShowChart
            // 
            this.panelShowChart.BackgroundImage = global::Lignite.Controls.Properties.Resources.betfair_chart;
            this.panelShowChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelShowChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelShowChart.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelShowChart.Location = new System.Drawing.Point(0, 0);
            this.panelShowChart.Name = "panelShowChart";
            this.panelShowChart.Size = new System.Drawing.Size(16, 35);
            this.panelShowChart.TabIndex = 16;
            this.toolTipMarketThreadControlRunner.SetToolTip(this.panelShowChart, "Click to open the chart in your default web browser");
            this.panelShowChart.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.panelShowChart.Click += new System.EventHandler(this.panelShowChart_Click);
            this.panelShowChart.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // lblRunnerName
            // 
            this.lblRunnerName.BackColor = System.Drawing.Color.Transparent;
            this.lblRunnerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRunnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunnerName.Location = new System.Drawing.Point(93, 2);
            this.lblRunnerName.Name = "lblRunnerName";
            this.lblRunnerName.Size = new System.Drawing.Size(106, 24);
            this.lblRunnerName.TabIndex = 17;
            this.lblRunnerName.Text = "Runner Name";
            this.lblRunnerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRunnerName.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.lblRunnerName.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // panelWhatIf
            // 
            this.panelWhatIf.Controls.Add(this.lblWhatIfRight);
            this.panelWhatIf.Controls.Add(this.lblWhatIfLeft);
            this.panelWhatIf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelWhatIf.Location = new System.Drawing.Point(93, 26);
            this.panelWhatIf.Name = "panelWhatIf";
            this.panelWhatIf.Size = new System.Drawing.Size(106, 11);
            this.panelWhatIf.TabIndex = 16;
            this.panelWhatIf.Visible = false;
            this.panelWhatIf.MouseLeave += new System.EventHandler(this.Controls_MouseLeave);
            this.panelWhatIf.MouseEnter += new System.EventHandler(this.Controls_MouseHover);
            // 
            // lblWhatIfRight
            // 
            this.lblWhatIfRight.AutoSize = true;
            this.lblWhatIfRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblWhatIfRight.ForeColor = System.Drawing.Color.Red;
            this.lblWhatIfRight.Location = new System.Drawing.Point(31, 0);
            this.lblWhatIfRight.Name = "lblWhatIfRight";
            this.lblWhatIfRight.Size = new System.Drawing.Size(43, 13);
            this.lblWhatIfRight.TabIndex = 1;
            this.lblWhatIfRight.Text = "-£49.20";
            // 
            // lblWhatIfLeft
            // 
            this.lblWhatIfLeft.AutoSize = true;
            this.lblWhatIfLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblWhatIfLeft.ForeColor = System.Drawing.Color.Green;
            this.lblWhatIfLeft.Location = new System.Drawing.Point(0, 0);
            this.lblWhatIfLeft.Name = "lblWhatIfLeft";
            this.lblWhatIfLeft.Size = new System.Drawing.Size(31, 13);
            this.lblWhatIfLeft.TabIndex = 0;
            this.lblWhatIfLeft.Text = "£300";
            // 
            // SelectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Lignite.Controls.Properties.Resources.RunnerBackGround;
            this.Controls.Add(this.lblRunnerName);
            this.Controls.Add(this.panelWhatIf);
            this.Controls.Add(this.panelAditionalRunnerInfoLeft);
            this.Controls.Add(this.btnBack3);
            this.Controls.Add(this.btnBack2);
            this.Controls.Add(this.btnBack1);
            this.Controls.Add(this.btnSPBack);
            this.Controls.Add(this.lblSPPrice);
            this.Controls.Add(this.btnSPLay);
            this.Controls.Add(this.btnLay1);
            this.Controls.Add(this.btnLay2);
            this.Controls.Add(this.btnLay3);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.Name = "SelectionView";
            this.Padding = new System.Windows.Forms.Padding(1, 2, 1, 3);
            this.Size = new System.Drawing.Size(715, 40);
            this.panelAditionalRunnerInfoLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSilks)).EndInit();
            this.panelStallDraw.ResumeLayout(false);
            this.panelStallDraw.PerformLayout();
            this.panelClothNumber.ResumeLayout(false);
            this.panelClothNumber.PerformLayout();
            this.panelWhatIf.ResumeLayout(false);
            this.panelWhatIf.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SelectionPriceButton btnLay3;
        private SelectionPriceButton btnLay2;
        private SelectionPriceButton btnLay1;
        private SelectionPriceButton btnSPLay;
        private System.Windows.Forms.Label lblSPPrice;
        private SelectionPriceButton btnSPBack;
        private SelectionPriceButton btnBack1;
        private SelectionPriceButton btnBack2;
        private SelectionPriceButton btnBack3;
        private System.Windows.Forms.Panel panelAditionalRunnerInfoLeft;
        private System.Windows.Forms.Label lblRunnerName;
        private System.Windows.Forms.Panel panelWhatIf;
        private System.Windows.Forms.Label lblWhatIfRight;
        private System.Windows.Forms.Label lblWhatIfLeft;
        private System.Windows.Forms.Panel panelShowChart;
        private System.Windows.Forms.Panel panelClothNumber;
        private System.Windows.Forms.Label lblClothNumber;
        private System.Windows.Forms.ToolTip toolTipMarketThreadControlRunner;
        private System.Windows.Forms.PictureBox picBoxSilks;
        private System.Windows.Forms.Panel panelStallDraw;
        private System.Windows.Forms.Label lblStallDraw;
        private EventController eventController;
    }
}
