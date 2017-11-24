namespace OverSurgery
{
    partial class prescriptionsform
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
            this.prescriptions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.prescriptions)).BeginInit();
            this.SuspendLayout();
            // 
            // prescriptions
            // 
            this.prescriptions.AllowUserToOrderColumns = true;
            this.prescriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prescriptions.Location = new System.Drawing.Point(23, 88);
            this.prescriptions.Name = "prescriptions";
            this.prescriptions.Size = new System.Drawing.Size(547, 153);
            this.prescriptions.TabIndex = 0;
            this.prescriptions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.prescriptions_CellContentClick);
            // 
            // prescriptionsform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 261);
            this.Controls.Add(this.prescriptions);
            this.Name = "prescriptionsform";
            this.Text = "prescriptionsform";
            ((System.ComponentModel.ISupportInitialize)(this.prescriptions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView prescriptions;
    }
}