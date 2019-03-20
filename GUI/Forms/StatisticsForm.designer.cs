namespace Nemo.GUI
{
    partial class StatisticsForm
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
            this.MapPanel = new System.Windows.Forms.Panel();
            this.StatGrid = new System.Windows.Forms.PropertyGrid();
            this.MapPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapPanel
            // 
            this.MapPanel.BackColor = System.Drawing.Color.White;
            this.MapPanel.Controls.Add(this.StatGrid);
            this.MapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPanel.Location = new System.Drawing.Point(0, 0);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(636, 526);
            this.MapPanel.TabIndex = 4;
            // 
            // StatGrid
            // 
            this.StatGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatGrid.Location = new System.Drawing.Point(0, 0);
            this.StatGrid.Name = "StatGrid";
            this.StatGrid.Size = new System.Drawing.Size(636, 526);
            this.StatGrid.TabIndex = 1;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 526);
            this.CloseButton = false;
            this.Controls.Add(this.MapPanel);
            this.HideOnClose = true;
            this.Name = "StatisticsForm";
            this.TabText = "Statistics";
            this.Text = "Statistics";
            this.MapPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MapPanel;
        private System.Windows.Forms.PropertyGrid StatGrid;
    }
}