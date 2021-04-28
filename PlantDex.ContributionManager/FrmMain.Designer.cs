
namespace PlantDex.ContributionManager
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewContributionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDeleteAllVerifiedContributionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteVerifiedSubmissionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewContributionsToolStripMenuItem,
            this.printDeleteAllVerifiedContributionsToolStripMenuItem,
            this.deleteVerifiedSubmissionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(996, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewContributionsToolStripMenuItem
            // 
            this.viewContributionsToolStripMenuItem.Name = "viewContributionsToolStripMenuItem";
            this.viewContributionsToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.viewContributionsToolStripMenuItem.Text = "View Contributions";
            this.viewContributionsToolStripMenuItem.Click += new System.EventHandler(this.viewContributionsToolStripMenuItem_Click);
            // 
            // printDeleteAllVerifiedContributionsToolStripMenuItem
            // 
            this.printDeleteAllVerifiedContributionsToolStripMenuItem.Name = "printDeleteAllVerifiedContributionsToolStripMenuItem";
            this.printDeleteAllVerifiedContributionsToolStripMenuItem.Size = new System.Drawing.Size(238, 20);
            this.printDeleteAllVerifiedContributionsToolStripMenuItem.Text = "Print and Delete All Verified Contributions";
            this.printDeleteAllVerifiedContributionsToolStripMenuItem.Click += new System.EventHandler(this.printDeleteAllVerifiedContributionsToolStripMenuItem_Click);
            // 
            // deleteVerifiedSubmissionsToolStripMenuItem
            // 
            this.deleteVerifiedSubmissionsToolStripMenuItem.Name = "deleteVerifiedSubmissionsToolStripMenuItem";
            this.deleteVerifiedSubmissionsToolStripMenuItem.Size = new System.Drawing.Size(163, 20);
            this.deleteVerifiedSubmissionsToolStripMenuItem.Text = "Delete Verified Submissions";
            this.deleteVerifiedSubmissionsToolStripMenuItem.Click += new System.EventHandler(this.deleteVerifiedSubmissionsToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 647);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "PlantDex Contribution Manager";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewContributionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printDeleteAllVerifiedContributionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteVerifiedSubmissionsToolStripMenuItem;
    }
}

