namespace OverSurgery
{
    partial class CreateAppointment
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
            this.patientLbl = new System.Windows.Forms.Label();
            this.appointmentTimeLbl = new System.Windows.Forms.Label();
            this.doctorNameLbl = new System.Windows.Forms.Label();
            this.doctorSelectionBox = new System.Windows.Forms.ComboBox();
            this.patientSelectionBox = new System.Windows.Forms.ComboBox();
            this.availableTimesSelectionBox = new System.Windows.Forms.ComboBox();
            this.createAppointmentGroup = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.reasonLbl = new System.Windows.Forms.Label();
            this.createAppointmentGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // patientLbl
            // 
            this.patientLbl.AutoSize = true;
            this.patientLbl.Location = new System.Drawing.Point(30, 32);
            this.patientLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.patientLbl.Name = "patientLbl";
            this.patientLbl.Size = new System.Drawing.Size(40, 13);
            this.patientLbl.TabIndex = 0;
            this.patientLbl.Text = "Patient";
            // 
            // appointmentTimeLbl
            // 
            this.appointmentTimeLbl.AutoSize = true;
            this.appointmentTimeLbl.Location = new System.Drawing.Point(30, 93);
            this.appointmentTimeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.appointmentTimeLbl.Name = "appointmentTimeLbl";
            this.appointmentTimeLbl.Size = new System.Drawing.Size(30, 13);
            this.appointmentTimeLbl.TabIndex = 2;
            this.appointmentTimeLbl.Text = "Time";
            // 
            // doctorNameLbl
            // 
            this.doctorNameLbl.AutoSize = true;
            this.doctorNameLbl.Location = new System.Drawing.Point(30, 63);
            this.doctorNameLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.doctorNameLbl.Name = "doctorNameLbl";
            this.doctorNameLbl.Size = new System.Drawing.Size(39, 13);
            this.doctorNameLbl.TabIndex = 3;
            this.doctorNameLbl.Text = "Doctor";
            // 
            // doctorSelectionBox
            // 
            this.doctorSelectionBox.FormattingEnabled = true;
            this.doctorSelectionBox.Location = new System.Drawing.Point(92, 63);
            this.doctorSelectionBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.doctorSelectionBox.Name = "doctorSelectionBox";
            this.doctorSelectionBox.Size = new System.Drawing.Size(123, 21);
            this.doctorSelectionBox.TabIndex = 4;
            // 
            // patientSelectionBox
            // 
            this.patientSelectionBox.FormattingEnabled = true;
            this.patientSelectionBox.Location = new System.Drawing.Point(92, 32);
            this.patientSelectionBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.patientSelectionBox.Name = "patientSelectionBox";
            this.patientSelectionBox.Size = new System.Drawing.Size(123, 21);
            this.patientSelectionBox.TabIndex = 5;
            this.patientSelectionBox.SelectedIndexChanged += new System.EventHandler(this.patientSelectionBox_SelectedIndexChanged);
            // 
            // availableTimesSelectionBox
            // 
            this.availableTimesSelectionBox.FormattingEnabled = true;
            this.availableTimesSelectionBox.Location = new System.Drawing.Point(92, 93);
            this.availableTimesSelectionBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.availableTimesSelectionBox.Name = "availableTimesSelectionBox";
            this.availableTimesSelectionBox.Size = new System.Drawing.Size(123, 21);
            this.availableTimesSelectionBox.TabIndex = 6;
            // 
            // createAppointmentGroup
            // 
            this.createAppointmentGroup.Controls.Add(this.textBox1);
            this.createAppointmentGroup.Controls.Add(this.reasonLbl);
            this.createAppointmentGroup.Controls.Add(this.appointmentTimeLbl);
            this.createAppointmentGroup.Controls.Add(this.availableTimesSelectionBox);
            this.createAppointmentGroup.Controls.Add(this.patientLbl);
            this.createAppointmentGroup.Controls.Add(this.doctorSelectionBox);
            this.createAppointmentGroup.Controls.Add(this.patientSelectionBox);
            this.createAppointmentGroup.Controls.Add(this.doctorNameLbl);
            this.createAppointmentGroup.Location = new System.Drawing.Point(16, 8);
            this.createAppointmentGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createAppointmentGroup.Name = "createAppointmentGroup";
            this.createAppointmentGroup.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createAppointmentGroup.Size = new System.Drawing.Size(235, 155);
            this.createAppointmentGroup.TabIndex = 7;
            this.createAppointmentGroup.TabStop = false;
            this.createAppointmentGroup.Text = "Create Appointment";
            this.createAppointmentGroup.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Location = new System.Drawing.Point(92, 122);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 20);
            this.textBox1.TabIndex = 8;
            // 
            // reasonLbl
            // 
            this.reasonLbl.AutoSize = true;
            this.reasonLbl.Location = new System.Drawing.Point(33, 122);
            this.reasonLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.reasonLbl.Name = "reasonLbl";
            this.reasonLbl.Size = new System.Drawing.Size(44, 13);
            this.reasonLbl.TabIndex = 7;
            this.reasonLbl.Text = "Reason";
            // 
            // CreateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 172);
            this.Controls.Add(this.createAppointmentGroup);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CreateAppointment";
            this.Text = "CreateAppointment";
            this.createAppointmentGroup.ResumeLayout(false);
            this.createAppointmentGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label patientLbl;
        private System.Windows.Forms.Label appointmentTimeLbl;
        private System.Windows.Forms.Label doctorNameLbl;
        private System.Windows.Forms.ComboBox doctorSelectionBox;
        private System.Windows.Forms.ComboBox patientSelectionBox;
        private System.Windows.Forms.ComboBox availableTimesSelectionBox;
        private System.Windows.Forms.GroupBox createAppointmentGroup;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label reasonLbl;
    }
}