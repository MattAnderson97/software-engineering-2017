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
            this.reasonLbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.createAppointmentGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // patientLbl
            // 
            this.patientLbl.AutoSize = true;
            this.patientLbl.Location = new System.Drawing.Point(45, 50);
            this.patientLbl.Name = "patientLbl";
            this.patientLbl.Size = new System.Drawing.Size(59, 20);
            this.patientLbl.TabIndex = 0;
            this.patientLbl.Text = "Patient";
            // 
            // appointmentTimeLbl
            // 
            this.appointmentTimeLbl.AutoSize = true;
            this.appointmentTimeLbl.Location = new System.Drawing.Point(45, 143);
            this.appointmentTimeLbl.Name = "appointmentTimeLbl";
            this.appointmentTimeLbl.Size = new System.Drawing.Size(43, 20);
            this.appointmentTimeLbl.TabIndex = 2;
            this.appointmentTimeLbl.Text = "Time";
            // 
            // doctorNameLbl
            // 
            this.doctorNameLbl.AutoSize = true;
            this.doctorNameLbl.Location = new System.Drawing.Point(45, 97);
            this.doctorNameLbl.Name = "doctorNameLbl";
            this.doctorNameLbl.Size = new System.Drawing.Size(57, 20);
            this.doctorNameLbl.TabIndex = 3;
            this.doctorNameLbl.Text = "Doctor";
            // 
            // doctorSelectionBox
            // 
            this.doctorSelectionBox.FormattingEnabled = true;
            this.doctorSelectionBox.Location = new System.Drawing.Point(138, 97);
            this.doctorSelectionBox.Name = "doctorSelectionBox";
            this.doctorSelectionBox.Size = new System.Drawing.Size(183, 28);
            this.doctorSelectionBox.TabIndex = 4;
            // 
            // patientSelectionBox
            // 
            this.patientSelectionBox.FormattingEnabled = true;
            this.patientSelectionBox.Location = new System.Drawing.Point(138, 50);
            this.patientSelectionBox.Name = "patientSelectionBox";
            this.patientSelectionBox.Size = new System.Drawing.Size(183, 28);
            this.patientSelectionBox.TabIndex = 5;
            // 
            // availableTimesSelectionBox
            // 
            this.availableTimesSelectionBox.FormattingEnabled = true;
            this.availableTimesSelectionBox.Location = new System.Drawing.Point(138, 143);
            this.availableTimesSelectionBox.Name = "availableTimesSelectionBox";
            this.availableTimesSelectionBox.Size = new System.Drawing.Size(183, 28);
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
            this.createAppointmentGroup.Location = new System.Drawing.Point(24, 13);
            this.createAppointmentGroup.Name = "createAppointmentGroup";
            this.createAppointmentGroup.Size = new System.Drawing.Size(352, 239);
            this.createAppointmentGroup.TabIndex = 7;
            this.createAppointmentGroup.TabStop = false;
            this.createAppointmentGroup.Text = "Create Appointment";
            this.createAppointmentGroup.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // reasonLbl
            // 
            this.reasonLbl.AutoSize = true;
            this.reasonLbl.Location = new System.Drawing.Point(49, 188);
            this.reasonLbl.Name = "reasonLbl";
            this.reasonLbl.Size = new System.Drawing.Size(65, 20);
            this.reasonLbl.TabIndex = 7;
            this.reasonLbl.Text = "Reason";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Location = new System.Drawing.Point(138, 188);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 26);
            this.textBox1.TabIndex = 8;
            // 
            // CreateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 264);
            this.Controls.Add(this.createAppointmentGroup);
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