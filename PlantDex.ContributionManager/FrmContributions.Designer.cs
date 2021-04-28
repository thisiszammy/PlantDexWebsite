
namespace PlantDex.ContributionManager
{
    partial class FrmContributions
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
            this.gridContributions = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblScientificName = new System.Windows.Forms.Label();
            this.lblCommonName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.imgPlant = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridContributions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlant)).BeginInit();
            this.SuspendLayout();
            // 
            // gridContributions
            // 
            this.gridContributions.AllowUserToAddRows = false;
            this.gridContributions.AllowUserToDeleteRows = false;
            this.gridContributions.AllowUserToOrderColumns = true;
            this.gridContributions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridContributions.Dock = System.Windows.Forms.DockStyle.Right;
            this.gridContributions.Location = new System.Drawing.Point(243, 0);
            this.gridContributions.Name = "gridContributions";
            this.gridContributions.ReadOnly = true;
            this.gridContributions.Size = new System.Drawing.Size(630, 438);
            this.gridContributions.TabIndex = 0;
            this.gridContributions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridContributions_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scientific Name : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Common Name : ";
            // 
            // txtLocation
            // 
            this.txtLocation.Enabled = false;
            this.txtLocation.Location = new System.Drawing.Point(17, 253);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(209, 101);
            this.txtLocation.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Locations Found : ";
            // 
            // lblScientificName
            // 
            this.lblScientificName.AutoSize = true;
            this.lblScientificName.Location = new System.Drawing.Point(99, 188);
            this.lblScientificName.Name = "lblScientificName";
            this.lblScientificName.Size = new System.Drawing.Size(35, 13);
            this.lblScientificName.TabIndex = 5;
            this.lblScientificName.Text = "label4";
            // 
            // lblCommonName
            // 
            this.lblCommonName.AutoSize = true;
            this.lblCommonName.Location = new System.Drawing.Point(99, 211);
            this.lblCommonName.Name = "lblCommonName";
            this.lblCommonName.Size = new System.Drawing.Size(35, 13);
            this.lblCommonName.TabIndex = 6;
            this.lblCommonName.Text = "label4";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Selected Plant";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgPlant
            // 
            this.imgPlant.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.imgPlant.Location = new System.Drawing.Point(17, 29);
            this.imgPlant.Name = "imgPlant";
            this.imgPlant.Size = new System.Drawing.Size(207, 145);
            this.imgPlant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPlant.TabIndex = 8;
            this.imgPlant.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(17, 376);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 50);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.DarkGreen;
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(127, 376);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(99, 50);
            this.btnApprove.TabIndex = 10;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // FrmContributions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 438);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.imgPlant);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCommonName);
            this.Controls.Add(this.lblScientificName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridContributions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmContributions";
            this.Text = "View Contributions";
            this.Load += new System.EventHandler(this.FrmContributions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridContributions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridContributions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblScientificName;
        private System.Windows.Forms.Label lblCommonName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox imgPlant;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnApprove;
    }
}