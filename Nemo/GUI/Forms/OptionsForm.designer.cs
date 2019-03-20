namespace Nemo.GUI
{
	partial class OptionsForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Address");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Port");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Service");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Size");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Time");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Custom");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.FiltersClearAllButton = new System.Windows.Forms.Button();
            this.FiletrsSelectAllButton = new System.Windows.Forms.Button();
            this.FiltersTreeView = new System.Windows.Forms.TreeView();
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LocalsDataGrid = new System.Windows.Forms.DataGridView();
            this.LocalHosts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.AliasGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadFlowsButton = new System.Windows.Forms.Button();
            this.AutoDnsButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExamplesButton = new System.Windows.Forms.Button();
            this.ExampleAliasButton = new System.Windows.Forms.Button();
            this.tabOptions.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocalsDataGrid)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AliasGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FiltersClearAllButton
            // 
            this.FiltersClearAllButton.Location = new System.Drawing.Point(3, 12);
            this.FiltersClearAllButton.Name = "FiltersClearAllButton";
            this.FiltersClearAllButton.Size = new System.Drawing.Size(76, 30);
            this.FiltersClearAllButton.TabIndex = 12;
            this.FiltersClearAllButton.Text = "Clear All";
            this.FiltersClearAllButton.UseVisualStyleBackColor = true;
            this.FiltersClearAllButton.Click += new System.EventHandler(this.FiltersClearAllButton_Click);
            // 
            // FiletrsSelectAllButton
            // 
            this.FiletrsSelectAllButton.Location = new System.Drawing.Point(3, 48);
            this.FiletrsSelectAllButton.Name = "FiletrsSelectAllButton";
            this.FiletrsSelectAllButton.Size = new System.Drawing.Size(76, 30);
            this.FiletrsSelectAllButton.TabIndex = 11;
            this.FiletrsSelectAllButton.Text = "Select All";
            this.FiletrsSelectAllButton.UseVisualStyleBackColor = true;
            this.FiletrsSelectAllButton.Click += new System.EventHandler(this.FiletrsSelectAllButton_Click);
            // 
            // FiltersTreeView
            // 
            this.FiltersTreeView.CheckBoxes = true;
            this.FiltersTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiltersTreeView.Location = new System.Drawing.Point(0, 0);
            this.FiltersTreeView.Name = "FiltersTreeView";
            treeNode1.Checked = true;
            treeNode1.Name = "AddressNode";
            treeNode1.Text = "Address";
            treeNode1.ToolTipText = "Results by address(e.g. 10.0.0.1)";
            treeNode2.Checked = true;
            treeNode2.Name = "PortNode";
            treeNode2.Text = "Port";
            treeNode2.ToolTipText = "Results by port(e.g. 110, 5060)";
            treeNode3.Checked = true;
            treeNode3.Name = "ServiceNode";
            treeNode3.Text = "Service";
            treeNode3.ToolTipText = "Results by service(e.g. http, pop, rtp)";
            treeNode4.Checked = true;
            treeNode4.Name = "SizeNode";
            treeNode4.Text = "Size";
            treeNode4.ToolTipText = "Results by flow size(e.g. <1Mb, >10Mb, etc)";
            treeNode5.Checked = true;
            treeNode5.Name = "TimeNode";
            treeNode5.Text = "Time";
            treeNode5.ToolTipText = "Results by time in 1 hour interval";
            treeNode6.Checked = true;
            treeNode6.Name = "CustomNode";
            treeNode6.Text = "Custom";
            treeNode6.ToolTipText = "Results by custom user filters";
            this.FiltersTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.FiltersTreeView.Size = new System.Drawing.Size(361, 298);
            this.FiltersTreeView.TabIndex = 0;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.tabPage1);
            this.tabOptions.Controls.Add(this.tabPage2);
            this.tabOptions.Controls.Add(this.tabPage3);
            this.tabOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOptions.Location = new System.Drawing.Point(0, 0);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(459, 326);
            this.tabOptions.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage1.Size = new System.Drawing.Size(451, 300);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Filters";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(1, 1);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.FiltersTreeView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.FiltersClearAllButton);
            this.splitContainer3.Panel2.Controls.Add(this.FiletrsSelectAllButton);
            this.splitContainer3.Size = new System.Drawing.Size(449, 298);
            this.splitContainer3.SplitterDistance = 361;
            this.splitContainer3.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(451, 300);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Local";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LocalsDataGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ExamplesButton);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(445, 294);
            this.splitContainer1.SplitterDistance = 359;
            this.splitContainer1.TabIndex = 0;
            // 
            // LocalsDataGrid
            // 
            this.LocalsDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.LocalsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocalHosts});
            this.LocalsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocalsDataGrid.Location = new System.Drawing.Point(0, 0);
            this.LocalsDataGrid.Name = "LocalsDataGrid";
            this.LocalsDataGrid.Size = new System.Drawing.Size(359, 294);
            this.LocalsDataGrid.TabIndex = 0;
            // 
            // LocalHosts
            // 
            this.LocalHosts.FillWeight = 200F;
            this.LocalHosts.HeaderText = "Local Hosts";
            this.LocalHosts.MinimumWidth = 200;
            this.LocalHosts.Name = "LocalHosts";
            this.LocalHosts.ToolTipText = "Add hosts to be locals here";
            this.LocalHosts.Width = 300;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 28);
            this.button1.TabIndex = 18;
            this.button1.Text = "Verify";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(451, 300);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Alias";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.AliasGridView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ExampleAliasButton);
            this.splitContainer2.Panel2.Controls.Add(this.LoadFlowsButton);
            this.splitContainer2.Panel2.Controls.Add(this.AutoDnsButton);
            this.splitContainer2.Panel2.Controls.Add(this.button3);
            this.splitContainer2.Size = new System.Drawing.Size(445, 294);
            this.splitContainer2.SplitterDistance = 356;
            this.splitContainer2.TabIndex = 2;
            // 
            // AliasGridView
            // 
            this.AliasGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AliasGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.AliasGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AliasGridView.Location = new System.Drawing.Point(0, 0);
            this.AliasGridView.Name = "AliasGridView";
            this.AliasGridView.Size = new System.Drawing.Size(356, 294);
            this.AliasGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 110F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Ip";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 110;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 200F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Alias";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // LoadFlowsButton
            // 
            this.LoadFlowsButton.Location = new System.Drawing.Point(1, 12);
            this.LoadFlowsButton.Name = "LoadFlowsButton";
            this.LoadFlowsButton.Size = new System.Drawing.Size(81, 28);
            this.LoadFlowsButton.TabIndex = 17;
            this.LoadFlowsButton.Text = "Load Flows";
            this.LoadFlowsButton.UseVisualStyleBackColor = true;
            this.LoadFlowsButton.Click += new System.EventHandler(this.LoadFlowsButton_Click);
            // 
            // AutoDnsButton
            // 
            this.AutoDnsButton.Location = new System.Drawing.Point(1, 46);
            this.AutoDnsButton.Name = "AutoDnsButton";
            this.AutoDnsButton.Size = new System.Drawing.Size(81, 28);
            this.AutoDnsButton.TabIndex = 16;
            this.AutoDnsButton.Text = "Auto(DNS)";
            this.AutoDnsButton.UseVisualStyleBackColor = true;
            this.AutoDnsButton.Click += new System.EventHandler(this.AutoDnsButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1, 80);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 28);
            this.button3.TabIndex = 15;
            this.button3.Text = "Verify";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 326);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(459, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton2.Text = "Cancel";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(26, 22);
            this.toolStripButton1.Text = "OK";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabOptions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 326);
            this.panel1.TabIndex = 17;
            // 
            // ExamplesButton
            // 
            this.ExamplesButton.Location = new System.Drawing.Point(1, 48);
            this.ExamplesButton.Name = "ExamplesButton";
            this.ExamplesButton.Size = new System.Drawing.Size(81, 28);
            this.ExamplesButton.TabIndex = 19;
            this.ExamplesButton.Text = "Examples";
            this.ExamplesButton.UseVisualStyleBackColor = true;
            this.ExamplesButton.Click += new System.EventHandler(this.ExamplesButton_Click);
            // 
            // ExampleAliasButton
            // 
            this.ExampleAliasButton.Location = new System.Drawing.Point(1, 114);
            this.ExampleAliasButton.Name = "ExampleAliasButton";
            this.ExampleAliasButton.Size = new System.Drawing.Size(81, 28);
            this.ExampleAliasButton.TabIndex = 18;
            this.ExampleAliasButton.Text = "Examples";
            this.ExampleAliasButton.UseVisualStyleBackColor = true;
            this.ExampleAliasButton.Click += new System.EventHandler(this.ExampleAliasButton_Click);
            // 
            // OptionsForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 351);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.MinimumSize = new System.Drawing.Size(400, 352);
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.Text = "Options";
            this.tabOptions.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LocalsDataGrid)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AliasGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TreeView FiltersTreeView;
		private System.Windows.Forms.Button FiltersClearAllButton;
        private System.Windows.Forms.Button FiletrsSelectAllButton;
        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView LocalsDataGrid;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView AliasGridView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button LoadFlowsButton;
        private System.Windows.Forms.Button AutoDnsButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalHosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button ExamplesButton;
        private System.Windows.Forms.Button ExampleAliasButton;
	}
}