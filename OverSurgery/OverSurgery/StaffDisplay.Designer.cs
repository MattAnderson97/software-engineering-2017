namespace OverSurgery
{
    partial class StaffFOrm
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
            this.btnStaff_Available = new System.Windows.Forms.Button();
            this.btn_OnDuty = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStaffs = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStaff_Available
            // 
            this.btnStaff_Available.Location = new System.Drawing.Point(81, 268);
            this.btnStaff_Available.Name = "btnStaff_Available";
            this.btnStaff_Available.Size = new System.Drawing.Size(75, 23);
            this.btnStaff_Available.TabIndex = 0;
            this.btnStaff_Available.Text = "Staff Available";
            this.btnStaff_Available.UseVisualStyleBackColor = true;
            this.btnStaff_Available.Click += new System.EventHandler(this.btnStaff_Available_Click);
            // 
            // btn_OnDuty
            // 
            this.btn_OnDuty.Location = new System.Drawing.Point(270, 267);
            this.btn_OnDuty.Name = "btn_OnDuty";
            this.btn_OnDuty.Size = new System.Drawing.Size(75, 23);
            this.btn_OnDuty.TabIndex = 1;
            this.btn_OnDuty.Text = "OnDuty Staff";
            this.btn_OnDuty.UseVisualStyleBackColor = true;
            this.btn_OnDuty.Click += new System.EventHandler(this.btn_OnDuty_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(94, 111);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(240, 150);
            this.dataGridView2.TabIndex = 2;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(416, 146);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(121, 97);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // lblStaffs
            // 
            this.lblStaffs.AutoSize = true;
            this.lblStaffs.Location = new System.Drawing.Point(58, 51);
            this.lblStaffs.Name = "lblStaffs";
            this.lblStaffs.Size = new System.Drawing.Size(34, 13);
            this.lblStaffs.TabIndex = 5;
            this.lblStaffs.Text = "Staffs";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(157, 51);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // StaffFOrm
            // 
            this.ClientSize = new System.Drawing.Size(736, 317);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.lblStaffs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btn_OnDuty);
            this.Controls.Add(this.btnStaff_Available);
            this.Name = "StaffFOrm";
            this.Load += new System.EventHandler(this.StaffFOrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbStaff;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnStaffAvailable;
        private System.Windows.Forms.Button btnOnDuty;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Button btnStaff_Available;
        private System.Windows.Forms.Button btn_OnDuty;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStaffs;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}