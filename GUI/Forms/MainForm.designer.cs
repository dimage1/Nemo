namespace Nemo.GUI
{
	partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.SaveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.loadToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CleanToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fromToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.emptyToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AutoRefreshStripButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshTimeStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.InfoStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FlowsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PacketsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BytesStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomFiltersContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFlowsDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menu.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.CustomFiltersContextMenuStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.Control;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.captureToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(964, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.CleanToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.loadFileToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.loadFileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::Nemo.Properties.Resources.saveHS;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = global::Nemo.Properties.Resources.openHS;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // CleanToolStripMenuItem
            // 
            this.CleanToolStripMenuItem.Image = global::Nemo.Properties.Resources.DeleteHS;
            this.CleanToolStripMenuItem.Name = "CleanToolStripMenuItem";
            this.CleanToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.CleanToolStripMenuItem.Text = "Clean";
            this.CleanToolStripMenuItem.Click += new System.EventHandler(this.CleanToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(109, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Nemo.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // captureToolStripMenuItem
            // 
            this.captureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartStopToolStripMenuItem});
            this.captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            this.captureToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.captureToolStripMenuItem.Text = "Capture";
            // 
            // StartStopToolStripMenuItem
            // 
            this.StartStopToolStripMenuItem.Name = "StartStopToolStripMenuItem";
            this.StartStopToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.StartStopToolStripMenuItem.Text = "Start";
            this.StartStopToolStripMenuItem.Click += new System.EventHandler(this.StartStopToolStripMenuItem_Click_1);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtersToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.filtersToolStripMenuItem.Text = "Filters";
            this.filtersToolStripMenuItem.Click += new System.EventHandler(this.filtersToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripButton,
            this.loadToolStripButton,
            this.CleanToolStripButton,
            this.toolStripSeparator1,
            this.fromToolStripLabel,
            this.toolStripLabel1,
            this.toToolStripLabel,
            this.emptyToolStripLabel1,
            this.refreshToolStripButton,
            this.AutoRefreshStripButton,
            this.RefreshTimeStripTextBox});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(964, 25);
            this.toolStrip.TabIndex = 15;
            this.toolStrip.Text = "toolStrip1";
            // 
            // SaveToolStripButton
            // 
            this.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolStripButton.Image = global::Nemo.Properties.Resources.saveHS;
            this.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripButton.Name = "SaveToolStripButton";
            this.SaveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.SaveToolStripButton.ToolTipText = "Save flows DB";
            this.SaveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
            // 
            // loadToolStripButton
            // 
            this.loadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadToolStripButton.Image = global::Nemo.Properties.Resources.openHS;
            this.loadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadToolStripButton.Name = "loadToolStripButton";
            this.loadToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.loadToolStripButton.ToolTipText = "Load flows DB or dump files";
            this.loadToolStripButton.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // CleanToolStripButton
            // 
            this.CleanToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CleanToolStripButton.Image = global::Nemo.Properties.Resources.DeleteHS;
            this.CleanToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CleanToolStripButton.Name = "CleanToolStripButton";
            this.CleanToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.CleanToolStripButton.Text = "Clean";
            this.CleanToolStripButton.ToolTipText = "Clean loaded flows";
            this.CleanToolStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // fromToolStripLabel
            // 
            this.fromToolStripLabel.Name = "fromToolStripLabel";
            this.fromToolStripLabel.Size = new System.Drawing.Size(33, 22);
            this.fromToolStripLabel.Text = "From:";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Enabled = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(127, 22);
            this.toolStripLabel1.Text = "                                        ";
            // 
            // toToolStripLabel
            // 
            this.toToolStripLabel.Name = "toToolStripLabel";
            this.toToolStripLabel.Size = new System.Drawing.Size(23, 22);
            this.toToolStripLabel.Text = "To:";
            // 
            // emptyToolStripLabel1
            // 
            this.emptyToolStripLabel1.Enabled = false;
            this.emptyToolStripLabel1.Name = "emptyToolStripLabel1";
            this.emptyToolStripLabel1.Size = new System.Drawing.Size(127, 22);
            this.emptyToolStripLabel1.Text = "                                        ";
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.AutoSize = false;
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::Nemo.Properties.Resources.refresh;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(20, 22);
            this.refreshToolStripButton.Text = "Refresh";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // AutoRefreshStripButton
            // 
            this.AutoRefreshStripButton.AutoSize = false;
            this.AutoRefreshStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AutoRefreshStripButton.Image = global::Nemo.Properties.Resources.auto_refresh;
            this.AutoRefreshStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AutoRefreshStripButton.Name = "AutoRefreshStripButton";
            this.AutoRefreshStripButton.Size = new System.Drawing.Size(20, 22);
            this.AutoRefreshStripButton.Text = "AutoRefreshStripButton";
            this.AutoRefreshStripButton.ToolTipText = "Auto Refresh";
            this.AutoRefreshStripButton.Click += new System.EventHandler(this.AutoRefreshStripButton_Click);
            // 
            // RefreshTimeStripTextBox
            // 
            this.RefreshTimeStripTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.RefreshTimeStripTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RefreshTimeStripTextBox.Name = "RefreshTimeStripTextBox";
            this.RefreshTimeStripTextBox.Size = new System.Drawing.Size(50, 25);
            this.RefreshTimeStripTextBox.Text = "15";
            this.RefreshTimeStripTextBox.MouseEnter += new System.EventHandler(this.RefreshTimeStripTextBox_MouseEnter);
            this.RefreshTimeStripTextBox.MouseLeave += new System.EventHandler(this.RefreshTimeStripTextBox_MouseLeave);
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDateTimePicker.Location = new System.Drawing.Point(107, 26);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(128, 20);
            this.fromDateTimePicker.TabIndex = 16;
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDateTimePicker.Location = new System.Drawing.Point(258, 26);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(130, 20);
            this.toDateTimePicker.TabIndex = 17;
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.AllowDrop = true;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockLeftPortion = 0.3;
            this.dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel.Location = new System.Drawing.Point(0, 0);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(964, 652);
            this.dockPanel.TabIndex = 18;
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoStatusLabel,
            this.FlowsStatusLabel,
            this.PacketsStatusLabel,
            this.BytesStatusLabel});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 0);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainStatusStrip.ShowItemToolTips = true;
            this.MainStatusStrip.Size = new System.Drawing.Size(964, 25);
            this.MainStatusStrip.TabIndex = 22;
            this.MainStatusStrip.Text = "MainStatusStrip";
            // 
            // InfoStatusLabel
            // 
            this.InfoStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.InfoStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.InfoStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.InfoStatusLabel.Name = "InfoStatusLabel";
            this.InfoStatusLabel.Size = new System.Drawing.Size(229, 20);
            this.InfoStatusLabel.Spring = true;
            this.InfoStatusLabel.Text = "...";
            this.InfoStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FlowsStatusLabel
            // 
            this.FlowsStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.FlowsStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.FlowsStatusLabel.Name = "FlowsStatusLabel";
            this.FlowsStatusLabel.Size = new System.Drawing.Size(229, 20);
            this.FlowsStatusLabel.Spring = true;
            this.FlowsStatusLabel.Text = "Flows: 0";
            this.FlowsStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FlowsStatusLabel.ToolTipText = "New flows created";
            // 
            // PacketsStatusLabel
            // 
            this.PacketsStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.PacketsStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.PacketsStatusLabel.Name = "PacketsStatusLabel";
            this.PacketsStatusLabel.Size = new System.Drawing.Size(229, 20);
            this.PacketsStatusLabel.Spring = true;
            this.PacketsStatusLabel.Text = "Packets: 0";
            this.PacketsStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PacketsStatusLabel.ToolTipText = "New packets loaded";
            // 
            // BytesStatusLabel
            // 
            this.BytesStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.BytesStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.BytesStatusLabel.Name = "BytesStatusLabel";
            this.BytesStatusLabel.Size = new System.Drawing.Size(229, 20);
            this.BytesStatusLabel.Spring = true;
            this.BytesStatusLabel.Text = "KBytes: 0";
            this.BytesStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BytesStatusLabel.ToolTipText = "New kbytes loaded";
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "NEMO files (*.pcap, *.cap, *.xml)|*.pcap;*.cap;*.xml|All files(*.*)|*.*";
            this.openFileDialog.Multiselect = true;
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 5000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem.Text = "Remove";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // notifyToolStripMenuItem
            // 
            this.notifyToolStripMenuItem.Name = "notifyToolStripMenuItem";
            this.notifyToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.notifyToolStripMenuItem.Text = "Notify?";
            this.notifyToolStripMenuItem.Click += new System.EventHandler(this.notifyToolStripMenuItem_Click);
            // 
            // CustomFiltersContextMenuStrip
            // 
            this.CustomFiltersContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem});
            this.CustomFiltersContextMenuStrip.Name = "CustomFiltersContextMenuStrip";
            this.CustomFiltersContextMenuStrip.Size = new System.Drawing.Size(118, 70);
            this.CustomFiltersContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.CustomFiltersContextMenuStrip_Opening);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // saveFlowsDialog
            // 
            this.saveFlowsDialog.Filter = "XML files (*.xml)|*.xml|All files(*.*)|*.*";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dockPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MainStatusStrip);
            this.splitContainer1.Size = new System.Drawing.Size(964, 681);
            this.splitContainer1.SplitterDistance = 652;
            this.splitContainer1.TabIndex = 24;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(964, 730);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toDateTimePicker);
            this.Controls.Add(this.fromDateTimePicker);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Nemo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.CustomFiltersContextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton SaveToolStripButton;
        private System.Windows.Forms.ToolStripButton loadToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel fromToolStripLabel;
        private System.Windows.Forms.ToolStripLabel toToolStripLabel;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel InfoStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel FlowsStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel PacketsStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel BytesStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartStopToolStripMenuItem;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripButton CleanToolStripButton;
        private System.Windows.Forms.ToolStripLabel emptyToolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem CleanToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton AutoRefreshStripButton;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CustomFiltersContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox RefreshTimeStripTextBox;
        private System.Windows.Forms.SaveFileDialog saveFlowsDialog;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
	}
}

