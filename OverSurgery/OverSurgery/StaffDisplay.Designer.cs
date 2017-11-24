namespace OverSurgery
{
    partial class StaffDisplay
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnOnduty = new System.Windows.Forms.Button();
            this.btnStaffAvailable = new System.Windows.Forms.Button();
            this.lblStaff = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(563, 79);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnOnduty
            // 
            this.btnOnduty.Location = new System.Drawing.Point(59, 262);
            this.btnOnduty.Name = "btnOnduty";
            this.btnOnduty.Size = new System.Drawing.Size(132, 25);
            this.btnOnduty.TabIndex = 1;
            this.btnOnduty.Text = "OnDuty Staff";
            this.btnOnduty.UseVisualStyleBackColor = true;
            this.btnOnduty.Click += new System.EventHandler(this.btnOnduty_Click);
            // 
            // btnStaffAvailable
            // 
            this.btnStaffAvailable.Location = new System.Drawing.Point(269, 265);
            this.btnStaffAvailable.Name = "btnStaffAvailable";
            this.btnStaffAvailable.Size = new System.Drawing.Size(166, 21);
            this.btnStaffAvailable.TabIndex = 2;
            this.btnStaffAvailable.Text = "Staff Available";
            this.btnStaffAvailable.UseVisualStyleBackColor = true;
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(36, 26);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(87, 13);
            this.lblStaff.TabIndex = 3;
            this.lblStaff.Text = "Oversurgery staff";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(41, 48);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(136, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(207, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(16, 72);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(554, 75);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // StaffDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 296);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.btnStaffAvailable);
            this.Controls.Add(this.btnOnduty);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StaffDisplay";
            this.Text = "StaffDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOnduty;
        private System.Windows.Forms.Button btnStaffAvailable;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListView listView1;
    }
}