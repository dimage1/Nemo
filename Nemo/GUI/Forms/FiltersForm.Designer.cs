namespace Nemo.GUI
{
    partial class FiltersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiltersForm));
            this.FilterSplitContainer = new System.Windows.Forms.SplitContainer();
            this.FilterStripTextBox = new System.Windows.Forms.TextBox();
            this.FiltersToolStrip = new System.Windows.Forms.ToolStrip();
            this.ExpandStripButton = new System.Windows.Forms.ToolStripButton();
            this.CollapseStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.UpdateStripButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteStripButton = new System.Windows.Forms.ToolStripButton();
            this.HelpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.filtersTreeView = new Nemo.GUI.FiltersTreeView();
            this.FilterSplitContainer.Panel1.SuspendLayout();
            this.FilterSplitContainer.Panel2.SuspendLayout();
            this.FilterSplitContainer.SuspendLayout();
            this.FiltersToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilterSplitContainer
            // 
            this.FilterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.FilterSplitContainer.IsSplitterFixed = true;
            this.FilterSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.FilterSplitContainer.Name = "FilterSplitContainer";
            this.FilterSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // FilterSplitContainer.Panel1
            // 
            this.FilterSplitContainer.Panel1.Controls.Add(this.FilterStripTextBox);
            this.FilterSplitContainer.Panel1.Controls.Add(this.FiltersToolStrip);
            this.FilterSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            // 
            // FilterSplitContainer.Panel2
            // 
            this.FilterSplitContainer.Panel2.Controls.Add(this.filtersTreeView);
            this.FilterSplitContainer.Size = new System.Drawing.Size(336, 405);
            this.FilterSplitContainer.SplitterDistance = 46;
            this.FilterSplitContainer.TabIndex = 1;
            // 
            // FilterStripTextBox
            // 
            this.FilterStripTextBox.BackColor = System.Drawing.Color.White;
            this.FilterStripTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FilterStripTextBox.ForeColor = System.Drawing.Color.Black;
            this.FilterStripTextBox.Location = new System.Drawing.Point(2, 26);
            this.FilterStripTextBox.Name = "FilterStripTextBox";
            this.FilterStripTextBox.Size = new System.Drawing.Size(334, 20);
            this.FilterStripTextBox.TabIndex = 1;
            // 
            // FiltersToolStrip
            // 
            this.FiltersToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.FiltersToolStrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FiltersToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExpandStripButton,
            this.CollapseStripButton,
            this.toolStripSeparator1,
            this.AddToolStripButton,
            this.UpdateStripButton,
            this.DeleteStripButton,
            this.HelpToolStripButton});
            this.FiltersToolStrip.Location = new System.Drawing.Point(2, 0);
            this.FiltersToolStrip.Name = "FiltersToolStrip";
            this.FiltersToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.FiltersToolStrip.Size = new System.Drawing.Size(334, 25);
            this.FiltersToolStrip.TabIndex = 0;
            this.FiltersToolStrip.Text = "FiltersToolStrip";
            // 
            // ExpandStripButton
            // 
            this.ExpandStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExpandStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ExpandStripButton.Image")));
            this.ExpandStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExpandStripButton.Name = "ExpandStripButton";
            this.ExpandStripButton.Size = new System.Drawing.Size(23, 22);
            this.ExpandStripButton.ToolTipText = "Expand All";
            this.ExpandStripButton.Click += new System.EventHandler(this.ExpandStripButton_Click);
            // 
            // CollapseStripButton
            // 
            this.CollapseStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CollapseStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CollapseStripButton.Image")));
            this.CollapseStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CollapseStripButton.Name = "CollapseStripButton";
            this.CollapseStripButton.Size = new System.Drawing.Size(23, 22);
            this.CollapseStripButton.ToolTipText = "Collapse All";
            this.CollapseStripButton.Click += new System.EventHandler(this.CollapseStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // AddToolStripButton
            // 
            this.AddToolStripButton.AutoToolTip = false;
            this.AddToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddToolStripButton.Image")));
            this.AddToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddToolStripButton.Name = "AddToolStripButton";
            this.AddToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.AddToolStripButton.Text = "Add";
            this.AddToolStripButton.ToolTipText = "Add custom filter";
            this.AddToolStripButton.Click += new System.EventHandler(this.AddToolStripButton_Click);
            // 
            // UpdateStripButton
            // 
            this.UpdateStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UpdateStripButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateStripButton.Image")));
            this.UpdateStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateStripButton.Name = "UpdateStripButton";
            this.UpdateStripButton.Size = new System.Drawing.Size(23, 22);
            this.UpdateStripButton.Text = "Update";
            this.UpdateStripButton.ToolTipText = "Update custom filter";
            this.UpdateStripButton.Click += new System.EventHandler(this.UpdateStripButton_Click);
            // 
            // DeleteStripButton
            // 
            this.DeleteStripButton.AutoToolTip = false;
            this.DeleteStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteStripButton.Image")));
            this.DeleteStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteStripButton.Name = "DeleteStripButton";
            this.DeleteStripButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteStripButton.Text = "Delete";
            this.DeleteStripButton.ToolTipText = "Delete custom filter";
            this.DeleteStripButton.Click += new System.EventHandler(this.DeleteStripButton_Click);
            // 
            // HelpToolStripButton
            // 
            this.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HelpToolStripButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HelpToolStripButton.Name = "HelpToolStripButton";
            this.HelpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.HelpToolStripButton.Text = "?";
            this.HelpToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HelpToolStripButton.ToolTipText = "Show custom filters help";
            this.HelpToolStripButton.Click += new System.EventHandler(this.HelpToolStripButton_Click);
            // 
            // filtersTreeView
            // 
            this.filtersTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtersTreeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.filtersTreeView.Location = new System.Drawing.Point(0, 0);
            this.filtersTreeView.Name = "filtersTreeView";
            this.filtersTreeView.Size = new System.Drawing.Size(336, 355);
            this.filtersTreeView.TabIndex = 0;
            this.filtersTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.filtersTreeView_NodeMouseClick);
            this.filtersTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filtersTreeView_KeyDown);
            // 
            // FiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 405);
            this.CloseButton = false;
            this.Controls.Add(this.FilterSplitContainer);
            this.HideOnClose = true;
            this.Name = "FiltersForm";
            this.Opacity = 0.5;
            this.TabText = "Filters";
            this.Text = "Filters";
            this.FilterSplitContainer.Panel1.ResumeLayout(false);
            this.FilterSplitContainer.Panel1.PerformLayout();
            this.FilterSplitContainer.Panel2.ResumeLayout(false);
            this.FilterSplitContainer.ResumeLayout(false);
            this.FiltersToolStrip.ResumeLayout(false);
            this.FiltersToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nemo.GUI.FiltersTreeView filtersTreeView;
        private System.Windows.Forms.SplitContainer FilterSplitContainer;
        private System.Windows.Forms.ToolStrip FiltersToolStrip;
        private System.Windows.Forms.ToolStripButton ExpandStripButton;
        private System.Windows.Forms.ToolStripButton CollapseStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton AddToolStripButton;
        private System.Windows.Forms.ToolStripButton HelpToolStripButton;
        private System.Windows.Forms.ToolStripButton DeleteStripButton;
        private System.Windows.Forms.ToolStripButton UpdateStripButton;
        private System.Windows.Forms.TextBox FilterStripTextBox;
    }
}