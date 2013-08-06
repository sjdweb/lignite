namespace Lignite.Console
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startEngineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopEngineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseEngineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainConfigurationFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMenuPathInDisplayNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTheBetfairStartingPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToSystemTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.tsLabelCurrentDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsSplit1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLabelLoggedInAsText = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLabelLoggedInAs = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsSplit3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainerMain = new System.Windows.Forms.ToolStripContainer();
            this.splitContainerMainOverview = new System.Windows.Forms.SplitContainer();
            this.panelMarkets = new System.Windows.Forms.Panel();
            this.marketViewContainer = new Lignite.Controls.MarketViewContainer();
            this.MasterEventController = new Lignite.Controls.EventController();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.MainConsoleOutput = new Lignite.Controls.ConsoleOutput();
            this.currentBetsView1 = new Lignite.Controls.CurrentBetsView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.systemStatusMonitor1 = new Lignite.Controls.SystemStatusMonitor();
            this.toolStripStartStop = new System.Windows.Forms.ToolStrip();
            this.tsButtonStartStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButtonPause = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.ligniteNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nicmShowHideConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.nicmStart = new System.Windows.Forms.ToolStripMenuItem();
            this.nicmStop = new System.Windows.Forms.ToolStripMenuItem();
            this.nicmPause = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.nicmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.toolStripContainerMain.ContentPanel.SuspendLayout();
            this.toolStripContainerMain.TopToolStripPanel.SuspendLayout();
            this.toolStripContainerMain.SuspendLayout();
            this.splitContainerMainOverview.Panel1.SuspendLayout();
            this.splitContainerMainOverview.Panel2.SuspendLayout();
            this.splitContainerMainOverview.SuspendLayout();
            this.panelMarkets.SuspendLayout();
            this.toolStripStartStop.SuspendLayout();
            this.NotifyIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(944, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startEngineToolStripMenuItem,
            this.stopEngineToolStripMenuItem,
            this.pauseEngineToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // startEngineToolStripMenuItem
            // 
            this.startEngineToolStripMenuItem.Image = global::Lignite.Console.Properties.Resources.bullet_triangle_blue;
            this.startEngineToolStripMenuItem.Name = "startEngineToolStripMenuItem";
            this.startEngineToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.startEngineToolStripMenuItem.Text = "Start Engine";
            this.startEngineToolStripMenuItem.Click += new System.EventHandler(this.startEngineToolStripMenuItem_Click);
            // 
            // stopEngineToolStripMenuItem
            // 
            this.stopEngineToolStripMenuItem.Enabled = false;
            this.stopEngineToolStripMenuItem.Image = global::Lignite.Console.Properties.Resources.bullet_square_red;
            this.stopEngineToolStripMenuItem.Name = "stopEngineToolStripMenuItem";
            this.stopEngineToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.stopEngineToolStripMenuItem.Text = "Stop Engine";
            this.stopEngineToolStripMenuItem.Click += new System.EventHandler(this.stopEngineToolStripMenuItem_Click);
            // 
            // pauseEngineToolStripMenuItem
            // 
            this.pauseEngineToolStripMenuItem.Enabled = false;
            this.pauseEngineToolStripMenuItem.Image = global::Lignite.Console.Properties.Resources.pause_blue;
            this.pauseEngineToolStripMenuItem.Name = "pauseEngineToolStripMenuItem";
            this.pauseEngineToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.pauseEngineToolStripMenuItem.Text = "Pause Engine";
            this.pauseEngineToolStripMenuItem.Click += new System.EventHandler(this.pauseEngineToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Lignite.Console.Properties.Resources.close;
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainConfigurationFileToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // mainConfigurationFileToolStripMenuItem
            // 
            this.mainConfigurationFileToolStripMenuItem.Image = global::Lignite.Console.Properties.Resources.edit_file;
            this.mainConfigurationFileToolStripMenuItem.Name = "mainConfigurationFileToolStripMenuItem";
            this.mainConfigurationFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.mainConfigurationFileToolStripMenuItem.Text = "Main &Configuration File";
            this.mainConfigurationFileToolStripMenuItem.Click += new System.EventHandler(this.mainConfigurationFileToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMenuPathInDisplayNameToolStripMenuItem,
            this.showTheBetfairStartingPriceToolStripMenuItem,
            this.minimizeToSystemTrayToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // showMenuPathInDisplayNameToolStripMenuItem
            // 
            this.showMenuPathInDisplayNameToolStripMenuItem.Checked = global::Lignite.Console.Properties.Settings.Default.ShowCompleteMenuPath;
            this.showMenuPathInDisplayNameToolStripMenuItem.CheckOnClick = true;
            this.showMenuPathInDisplayNameToolStripMenuItem.Name = "showMenuPathInDisplayNameToolStripMenuItem";
            this.showMenuPathInDisplayNameToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.showMenuPathInDisplayNameToolStripMenuItem.Text = "Show Menu Path in Display Name";
            this.showMenuPathInDisplayNameToolStripMenuItem.Click += new System.EventHandler(this.showMenuPathInDisplayNameToolStripMenuItem_Click);
            // 
            // showTheBetfairStartingPriceToolStripMenuItem
            // 
            this.showTheBetfairStartingPriceToolStripMenuItem.Checked = global::Lignite.Console.Properties.Settings.Default.ShowBetfairStartingPrices;
            this.showTheBetfairStartingPriceToolStripMenuItem.CheckOnClick = true;
            this.showTheBetfairStartingPriceToolStripMenuItem.Name = "showTheBetfairStartingPriceToolStripMenuItem";
            this.showTheBetfairStartingPriceToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.showTheBetfairStartingPriceToolStripMenuItem.Text = "Show the Betfair Starting Price";
            this.showTheBetfairStartingPriceToolStripMenuItem.Click += new System.EventHandler(this.showTheBetfairStartingPriceToolStripMenuItem_Click);
            // 
            // minimizeToSystemTrayToolStripMenuItem
            // 
            this.minimizeToSystemTrayToolStripMenuItem.Checked = global::Lignite.Console.Properties.Settings.Default.MinimizeToSystemTray;
            this.minimizeToSystemTrayToolStripMenuItem.CheckOnClick = true;
            this.minimizeToSystemTrayToolStripMenuItem.Name = "minimizeToSystemTrayToolStripMenuItem";
            this.minimizeToSystemTrayToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.minimizeToSystemTrayToolStripMenuItem.Text = "Minimize to System Tray";
            this.minimizeToSystemTrayToolStripMenuItem.Click += new System.EventHandler(this.minimizeToSystemTrayToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licenceToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // licenceToolStripMenuItem
            // 
            this.licenceToolStripMenuItem.Name = "licenceToolStripMenuItem";
            this.licenceToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.licenceToolStripMenuItem.Text = "&Licence";
            this.licenceToolStripMenuItem.Click += new System.EventHandler(this.licenceToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabelCurrentDateTime,
            this.tsSplit1,
            this.tsLabelLoggedInAsText,
            this.tsLabelLoggedInAs,
            this.tsSplit3});
            this.statusStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStripMain.Location = new System.Drawing.Point(0, 672);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(944, 18);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // tsLabelCurrentDateTime
            // 
            this.tsLabelCurrentDateTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsLabelCurrentDateTime.ForeColor = System.Drawing.Color.Black;
            this.tsLabelCurrentDateTime.Name = "tsLabelCurrentDateTime";
            this.tsLabelCurrentDateTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tsLabelCurrentDateTime.Size = new System.Drawing.Size(162, 13);
            this.tsLabelCurrentDateTime.Text = "HH:mm:ss - dd MMMM yyyy";
            // 
            // tsSplit1
            // 
            this.tsSplit1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.tsSplit1.Name = "tsSplit1";
            this.tsSplit1.Size = new System.Drawing.Size(11, 13);
            this.tsSplit1.Text = "|";
            // 
            // tsLabelLoggedInAsText
            // 
            this.tsLabelLoggedInAsText.Name = "tsLabelLoggedInAsText";
            this.tsLabelLoggedInAsText.Size = new System.Drawing.Size(71, 13);
            this.tsLabelLoggedInAsText.Text = "Logged in as:";
            // 
            // tsLabelLoggedInAs
            // 
            this.tsLabelLoggedInAs.Name = "tsLabelLoggedInAs";
            this.tsLabelLoggedInAs.Size = new System.Drawing.Size(82, 13);
            this.tsLabelLoggedInAs.Text = "Not logged in...";
            // 
            // tsSplit3
            // 
            this.tsSplit3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.tsSplit3.Name = "tsSplit3";
            this.tsSplit3.Size = new System.Drawing.Size(11, 13);
            this.tsSplit3.Text = "|";
            // 
            // toolStripContainerMain
            // 
            // 
            // toolStripContainerMain.ContentPanel
            // 
            this.toolStripContainerMain.ContentPanel.BackColor = System.Drawing.Color.White;
            this.toolStripContainerMain.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolStripContainerMain.ContentPanel.Controls.Add(this.splitContainerMainOverview);
            this.toolStripContainerMain.ContentPanel.Size = new System.Drawing.Size(944, 623);
            this.toolStripContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainerMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainerMain.Name = "toolStripContainerMain";
            this.toolStripContainerMain.Size = new System.Drawing.Size(944, 648);
            this.toolStripContainerMain.TabIndex = 2;
            this.toolStripContainerMain.Text = "toolStripContainer1";
            // 
            // toolStripContainerMain.TopToolStripPanel
            // 
            this.toolStripContainerMain.TopToolStripPanel.Controls.Add(this.toolStripStartStop);
            // 
            // splitContainerMainOverview
            // 
            this.splitContainerMainOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainOverview.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainOverview.Name = "splitContainerMainOverview";
            // 
            // splitContainerMainOverview.Panel1
            // 
            this.splitContainerMainOverview.Panel1.Controls.Add(this.panelMarkets);
            // 
            // splitContainerMainOverview.Panel2
            // 
            this.splitContainerMainOverview.Panel2.Controls.Add(this.currentBetsView1);
            this.splitContainerMainOverview.Panel2.Controls.Add(this.splitter2);
            this.splitContainerMainOverview.Panel2.Controls.Add(this.systemStatusMonitor1);
            this.splitContainerMainOverview.Size = new System.Drawing.Size(940, 619);
            this.splitContainerMainOverview.SplitterDistance = 705;
            this.splitContainerMainOverview.TabIndex = 1;
            // 
            // panelMarkets
            // 
            this.panelMarkets.AutoScroll = true;
            this.panelMarkets.AutoScrollMinSize = new System.Drawing.Size(580, 0);
            this.panelMarkets.BackColor = System.Drawing.Color.White;
            this.panelMarkets.Controls.Add(this.marketViewContainer);
            this.panelMarkets.Controls.Add(this.splitter1);
            this.panelMarkets.Controls.Add(this.MainConsoleOutput);
            this.panelMarkets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMarkets.Location = new System.Drawing.Point(0, 0);
            this.panelMarkets.Name = "panelMarkets";
            this.panelMarkets.Size = new System.Drawing.Size(705, 619);
            this.panelMarkets.TabIndex = 9;
            // 
            // marketViewContainer
            // 
            this.marketViewContainer.BackColor = System.Drawing.Color.White;
            this.marketViewContainer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("marketViewContainer.BackgroundImage")));
            this.marketViewContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.marketViewContainer.Controller = this.MasterEventController;
            this.marketViewContainer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.marketViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marketViewContainer.ItemsPerPage = 20;
            this.marketViewContainer.Location = new System.Drawing.Point(0, 0);
            this.marketViewContainer.Name = "marketViewContainer";
            this.marketViewContainer.ShowMenuPathInDisplayName = true;
            this.marketViewContainer.ShowStartingPricesIfAvailable = true;
            this.marketViewContainer.Size = new System.Drawing.Size(705, 494);
            this.marketViewContainer.TabIndex = 3;
            // 
            // MasterEventController
            // 
            this.MasterEventController.BroadcastMarketStateRequest += new Lignite.Controls.Events.BroadcastMarketStateRequestEventHandler(this.MasterEventController_BroadcastMarketStateRequest);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.White;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 494);
            this.splitter1.Name = "splitter1";
            this.splitter1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.splitter1.Size = new System.Drawing.Size(705, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // MainConsoleOutput
            // 
            this.MainConsoleOutput.Controller = this.MasterEventController;
            this.MainConsoleOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainConsoleOutput.Location = new System.Drawing.Point(0, 497);
            this.MainConsoleOutput.MaxLines = 50;
            this.MainConsoleOutput.Name = "MainConsoleOutput";
            this.MainConsoleOutput.ShowDate = true;
            this.MainConsoleOutput.Size = new System.Drawing.Size(705, 122);
            this.MainConsoleOutput.TabIndex = 4;
            // 
            // currentBetsView1
            // 
            this.currentBetsView1.BackColor = System.Drawing.Color.White;
            this.currentBetsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentBetsView1.Location = new System.Drawing.Point(0, 0);
            this.currentBetsView1.Name = "currentBetsView1";
            this.currentBetsView1.Padding = new System.Windows.Forms.Padding(3);
            this.currentBetsView1.Size = new System.Drawing.Size(231, 379);
            this.currentBetsView1.TabIndex = 22;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 379);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(231, 3);
            this.splitter2.TabIndex = 21;
            this.splitter2.TabStop = false;
            // 
            // systemStatusMonitor1
            // 
            this.systemStatusMonitor1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.systemStatusMonitor1.BackColor = System.Drawing.Color.Transparent;
            this.systemStatusMonitor1.Controller = this.MasterEventController;
            this.systemStatusMonitor1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.systemStatusMonitor1.FeedUrl = "http://bdp.betfair.com/index.php?option=com_rd_rss&id=2";
            this.systemStatusMonitor1.Location = new System.Drawing.Point(0, 382);
            this.systemStatusMonitor1.Name = "systemStatusMonitor1";
            this.systemStatusMonitor1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.systemStatusMonitor1.RefreshTimerInterval = 300000;
            this.systemStatusMonitor1.Size = new System.Drawing.Size(231, 237);
            this.systemStatusMonitor1.TabIndex = 20;
            // 
            // toolStripStartStop
            // 
            this.toolStripStartStop.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripStartStop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButtonStartStop,
            this.toolStripSeparator1,
            this.tsButtonPause,
            this.toolStripSeparator3});
            this.toolStripStartStop.Location = new System.Drawing.Point(0, 0);
            this.toolStripStartStop.Name = "toolStripStartStop";
            this.toolStripStartStop.Size = new System.Drawing.Size(944, 25);
            this.toolStripStartStop.Stretch = true;
            this.toolStripStartStop.TabIndex = 0;
            // 
            // tsButtonStartStop
            // 
            this.tsButtonStartStop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsButtonStartStop.Image = global::Lignite.Console.Properties.Resources.bullet_triangle_blue;
            this.tsButtonStartStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonStartStop.Name = "tsButtonStartStop";
            this.tsButtonStartStop.Size = new System.Drawing.Size(99, 22);
            this.tsButtonStartStop.Text = "Click to start";
            this.tsButtonStartStop.Click += new System.EventHandler(this.tsButtonStartStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButtonPause
            // 
            this.tsButtonPause.Enabled = false;
            this.tsButtonPause.Image = global::Lignite.Console.Properties.Resources.pause_grey;
            this.tsButtonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonPause.Name = "tsButtonPause";
            this.tsButtonPause.Size = new System.Drawing.Size(56, 22);
            this.tsButtonPause.Text = "Pause";
            this.tsButtonPause.Click += new System.EventHandler(this.pauseEngineToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Interval = 1000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // ligniteNotifyIcon
            // 
            this.ligniteNotifyIcon.ContextMenuStrip = this.NotifyIconContextMenu;
            this.ligniteNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ligniteNotifyIcon.Icon")));
            this.ligniteNotifyIcon.Text = "Lignite";
            this.ligniteNotifyIcon.Visible = true;
            this.ligniteNotifyIcon.DoubleClick += new System.EventHandler(this.ligniteNotifyIcon_DoubleClick);
            // 
            // NotifyIconContextMenu
            // 
            this.NotifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nicmShowHideConsole,
            this.toolStripSeparator4,
            this.nicmStart,
            this.nicmStop,
            this.nicmPause,
            this.toolStripSeparator5,
            this.nicmExit});
            this.NotifyIconContextMenu.Name = "formMainContextMenu";
            this.NotifyIconContextMenu.Size = new System.Drawing.Size(204, 126);
            // 
            // nicmShowHideConsole
            // 
            this.nicmShowHideConsole.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nicmShowHideConsole.Name = "nicmShowHideConsole";
            this.nicmShowHideConsole.Size = new System.Drawing.Size(203, 22);
            this.nicmShowHideConsole.Text = "Show Lignite Console";
            this.nicmShowHideConsole.Click += new System.EventHandler(this.nicmShowHideConsole_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(200, 6);
            // 
            // nicmStart
            // 
            this.nicmStart.Image = global::Lignite.Console.Properties.Resources.bullet_triangle_blue;
            this.nicmStart.Name = "nicmStart";
            this.nicmStart.Size = new System.Drawing.Size(203, 22);
            this.nicmStart.Text = "Start Engine";
            this.nicmStart.Click += new System.EventHandler(this.startEngineToolStripMenuItem_Click);
            // 
            // nicmStop
            // 
            this.nicmStop.Enabled = false;
            this.nicmStop.Image = global::Lignite.Console.Properties.Resources.bullet_square_red;
            this.nicmStop.Name = "nicmStop";
            this.nicmStop.Size = new System.Drawing.Size(203, 22);
            this.nicmStop.Text = "Stop Engine";
            this.nicmStop.Click += new System.EventHandler(this.stopEngineToolStripMenuItem_Click);
            // 
            // nicmPause
            // 
            this.nicmPause.Enabled = false;
            this.nicmPause.Image = global::Lignite.Console.Properties.Resources.pause_blue;
            this.nicmPause.Name = "nicmPause";
            this.nicmPause.Size = new System.Drawing.Size(203, 22);
            this.nicmPause.Text = "Pause Engine";
            this.nicmPause.Click += new System.EventHandler(this.pauseEngineToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(200, 6);
            // 
            // nicmExit
            // 
            this.nicmExit.Image = global::Lignite.Console.Properties.Resources.close;
            this.nicmExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nicmExit.Name = "nicmExit";
            this.nicmExit.Size = new System.Drawing.Size(203, 22);
            this.nicmExit.Text = "E&xit";
            this.nicmExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 690);
            this.Controls.Add(this.toolStripContainerMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = " Lignite for Betfair - Autobet Version 0.0.1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.toolStripContainerMain.ContentPanel.ResumeLayout(false);
            this.toolStripContainerMain.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainerMain.TopToolStripPanel.PerformLayout();
            this.toolStripContainerMain.ResumeLayout(false);
            this.toolStripContainerMain.PerformLayout();
            this.splitContainerMainOverview.Panel1.ResumeLayout(false);
            this.splitContainerMainOverview.Panel2.ResumeLayout(false);
            this.splitContainerMainOverview.ResumeLayout(false);
            this.panelMarkets.ResumeLayout(false);
            this.toolStripStartStop.ResumeLayout(false);
            this.toolStripStartStop.PerformLayout();
            this.NotifyIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripContainer toolStripContainerMain;
        private System.Windows.Forms.ToolStrip toolStripStartStop;
        private System.Windows.Forms.ToolStripButton tsButtonStartStop;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel tsLabelCurrentDateTime;
        private System.Windows.Forms.ToolStripStatusLabel tsSplit1;
        private System.Windows.Forms.SplitContainer splitContainerMainOverview;
        private System.Windows.Forms.Panel panelMarkets;
        private System.Windows.Forms.ToolStripStatusLabel tsLabelLoggedInAsText;
        private System.Windows.Forms.ToolStripStatusLabel tsLabelLoggedInAs;
        private System.Windows.Forms.ToolStripStatusLabel tsSplit3;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenceToolStripMenuItem;
        internal System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.ToolStripMenuItem mainConfigurationFileToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private Lignite.Controls.ConsoleOutput MainConsoleOutput;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMenuPathInDisplayNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startEngineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopEngineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseEngineToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsButtonPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem showTheBetfairStartingPriceToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter2;
        private Lignite.Controls.SystemStatusMonitor systemStatusMonitor1;
        private Lignite.Controls.CurrentBetsView currentBetsView1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToSystemTrayToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon ligniteNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem nicmShowHideConsole;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem nicmStart;
        private System.Windows.Forms.ToolStripMenuItem nicmStop;
        private System.Windows.Forms.ToolStripMenuItem nicmPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem nicmExit;
        private Lignite.Controls.EventController MasterEventController;
        private Lignite.Controls.MarketViewContainer marketViewContainer;

    }
}

