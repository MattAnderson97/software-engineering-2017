namespace Planera_Life
{
    partial class FileExportDialogue
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_SelectDestination = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbx_FileType = new System.Windows.Forms.ComboBox();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Destination = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(6, 454);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(95, 44);
            this.btn_Cancel.TabIndex = 18;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_SelectDestination
            // 
            this.btn_SelectDestination.Location = new System.Drawing.Point(116, 454);
            this.btn_SelectDestination.Name = "btn_SelectDestination";
            this.btn_SelectDestination.Size = new System.Drawing.Size(95, 44);
            this.btn_SelectDestination.TabIndex = 17;
            this.btn_SelectDestination.Text = "Select Destination...";
            this.btn_SelectDestination.UseVisualStyleBackColor = true;
            this.btn_SelectDestination.Click += new System.EventHandler(this.btn_SelectDestination_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(343, 454);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(95, 44);
            this.btn_Print.TabIndex = 16;
            this.btn_Print.Text = "Print Table...";
            this.btn_Print.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(226, 454);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(95, 44);
            this.btn_Save.TabIndex = 15;
            this.btn_Save.Text = "Save Table...";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Export Table as:";
            // 
            // cmbx_FileType
            // 
            this.cmbx_FileType.FormattingEnabled = true;
            this.cmbx_FileType.Items.AddRange(new object[] {
            "CSV file (filename_date.txt)",
            "Access Database File (filename_date.accdb)"});
            this.cmbx_FileType.Location = new System.Drawing.Point(153, 417);
            this.cmbx_FileType.Name = "cmbx_FileType";
            this.cmbx_FileType.Size = new System.Drawing.Size(286, 24);
            this.cmbx_FileType.TabIndex = 13;
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(7, 12);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowTemplate.Height = 24;
            this.DataGridView.Size = new System.Drawing.Size(432, 359);
            this.DataGridView.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Destination:";
            // 
            // txt_Destination
            // 
            this.txt_Destination.Location = new System.Drawing.Point(153, 385);
            this.txt_Destination.Name = "txt_Destination";
            this.txt_Destination.Size = new System.Drawing.Size(285, 22);
            this.txt_Destination.TabIndex = 20;
            // 
            // FileExportDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 502);
            this.Controls.Add(this.txt_Destination);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_SelectDestination);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbx_FileType);
            this.Controls.Add(this.DataGridView);
            this.Name = "FileExportDialogue";
            this.Text = "FileExportDialogue";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_SelectDestination;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbx_FileType;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Destination;
    }
}