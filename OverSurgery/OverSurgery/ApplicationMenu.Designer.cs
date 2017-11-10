namespace OverSurgery
{
    partial class ApplicationMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.btnRegisterPatientMainMenu = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlCreateUser = new System.Windows.Forms.Panel();
            this.btnBackCreateUser = new System.Windows.Forms.Button();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.pnlRegisterPatient = new System.Windows.Forms.Panel();
            this.btnBackRegisterPatient = new System.Windows.Forms.Button();
            this.btnRegisterPatient = new System.Windows.Forms.Button();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.mtbTelephoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.cbxGender = new System.Windows.Forms.ComboBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblTelephoneNumber = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblRegisterPatient = new System.Windows.Forms.Label();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlMainMenu = new System.Windows.Forms.Panel();
            this.pnlCreateUser.SuspendLayout();
            this.pnlRegisterPatient.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.pnlMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "MAIN MENU";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(114, 277);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(194, 40);
            this.button4.TabIndex = 8;
            this.button4.Text = "APPOINTMENTS";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnRegisterPatientMainMenu
            // 
            this.btnRegisterPatientMainMenu.Location = new System.Drawing.Point(114, 207);
            this.btnRegisterPatientMainMenu.Name = "btnRegisterPatientMainMenu";
            this.btnRegisterPatientMainMenu.Size = new System.Drawing.Size(194, 44);
            this.btnRegisterPatientMainMenu.TabIndex = 7;
            this.btnRegisterPatientMainMenu.Text = "REGISTER PATIENT";
            this.btnRegisterPatientMainMenu.UseVisualStyleBackColor = true;
            this.btnRegisterPatientMainMenu.Click += new System.EventHandler(this.btnRegisterPatientMainMenu_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(114, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 44);
            this.button2.TabIndex = 6;
            this.button2.Text = "VIEW PATIENTS";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "VIEW STAFF";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(336, 322);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 10;
            this.btnSettings.Text = "SETTINGS";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlCreateUser
            // 
            this.pnlCreateUser.Controls.Add(this.btnBackCreateUser);
            this.pnlCreateUser.Controls.Add(this.tbxPassword);
            this.pnlCreateUser.Controls.Add(this.tbxUsername);
            this.pnlCreateUser.Controls.Add(this.btnCreate);
            this.pnlCreateUser.Controls.Add(this.label2);
            this.pnlCreateUser.Controls.Add(this.lblUserName);
            this.pnlCreateUser.Controls.Add(this.lblCreateUser);
            this.pnlCreateUser.Location = new System.Drawing.Point(462, 38);
            this.pnlCreateUser.Name = "pnlCreateUser";
            this.pnlCreateUser.Size = new System.Drawing.Size(437, 357);
            this.pnlCreateUser.TabIndex = 15;
            this.pnlCreateUser.Visible = false;
            // 
            // btnBackCreateUser
            // 
            this.btnBackCreateUser.Location = new System.Drawing.Point(14, 11);
            this.btnBackCreateUser.Name = "btnBackCreateUser";
            this.btnBackCreateUser.Size = new System.Drawing.Size(75, 23);
            this.btnBackCreateUser.TabIndex = 11;
            this.btnBackCreateUser.Text = "BACK";
            this.btnBackCreateUser.UseVisualStyleBackColor = true;
            this.btnBackCreateUser.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(129, 180);
            this.tbxPassword.MaxLength = 10;
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(200, 20);
            this.tbxPassword.TabIndex = 9;
            // 
            // tbxUsername
            // 
            this.tbxUsername.BackColor = System.Drawing.Color.White;
            this.tbxUsername.Location = new System.Drawing.Point(129, 127);
            this.tbxUsername.MaxLength = 10;
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(200, 20);
            this.tbxUsername.TabIndex = 8;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(144, 307);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(166, 30);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "CREATE";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(67, 130);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(58, 13);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "Username:";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateUser.Location = new System.Drawing.Point(138, 11);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(172, 25);
            this.lblCreateUser.TabIndex = 5;
            this.lblCreateUser.Text = "CREATE USER";
            // 
            // pnlRegisterPatient
            // 
            this.pnlRegisterPatient.Controls.Add(this.btnBackRegisterPatient);
            this.pnlRegisterPatient.Controls.Add(this.btnRegisterPatient);
            this.pnlRegisterPatient.Controls.Add(this.tbxAddress);
            this.pnlRegisterPatient.Controls.Add(this.mtbTelephoneNumber);
            this.pnlRegisterPatient.Controls.Add(this.cbxGender);
            this.pnlRegisterPatient.Controls.Add(this.dtpDateOfBirth);
            this.pnlRegisterPatient.Controls.Add(this.tbxLastName);
            this.pnlRegisterPatient.Controls.Add(this.tbxFirstName);
            this.pnlRegisterPatient.Controls.Add(this.lblAddress);
            this.pnlRegisterPatient.Controls.Add(this.lblTelephoneNumber);
            this.pnlRegisterPatient.Controls.Add(this.lblGender);
            this.pnlRegisterPatient.Controls.Add(this.lblDateOfBirth);
            this.pnlRegisterPatient.Controls.Add(this.lblLastName);
            this.pnlRegisterPatient.Controls.Add(this.lblFirstName);
            this.pnlRegisterPatient.Controls.Add(this.lblRegisterPatient);
            this.pnlRegisterPatient.Location = new System.Drawing.Point(951, 38);
            this.pnlRegisterPatient.Name = "pnlRegisterPatient";
            this.pnlRegisterPatient.Size = new System.Drawing.Size(450, 357);
            this.pnlRegisterPatient.TabIndex = 16;
            this.pnlRegisterPatient.Visible = false;
            // 
            // btnBackRegisterPatient
            // 
            this.btnBackRegisterPatient.Location = new System.Drawing.Point(14, 11);
            this.btnBackRegisterPatient.Name = "btnBackRegisterPatient";
            this.btnBackRegisterPatient.Size = new System.Drawing.Size(75, 23);
            this.btnBackRegisterPatient.TabIndex = 12;
            this.btnBackRegisterPatient.Text = "BACK";
            this.btnBackRegisterPatient.UseVisualStyleBackColor = true;
            this.btnBackRegisterPatient.Click += new System.EventHandler(this.btnBackRegisterPatient_Click);
            // 
            // btnRegisterPatient
            // 
            this.btnRegisterPatient.Location = new System.Drawing.Point(148, 316);
            this.btnRegisterPatient.Name = "btnRegisterPatient";
            this.btnRegisterPatient.Size = new System.Drawing.Size(166, 30);
            this.btnRegisterPatient.TabIndex = 12;
            this.btnRegisterPatient.Text = "REGISTER PATIENT";
            this.btnRegisterPatient.UseVisualStyleBackColor = true;
            this.btnRegisterPatient.Click += new System.EventHandler(this.btnRegisterPatient_Click);
            // 
            // tbxAddress
            // 
            this.tbxAddress.BackColor = System.Drawing.Color.White;
            this.tbxAddress.Location = new System.Drawing.Point(147, 244);
            this.tbxAddress.MaxLength = 100;
            this.tbxAddress.Multiline = true;
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(200, 66);
            this.tbxAddress.TabIndex = 24;
            // 
            // mtbTelephoneNumber
            // 
            this.mtbTelephoneNumber.Location = new System.Drawing.Point(147, 210);
            this.mtbTelephoneNumber.Mask = "000000000000000";
            this.mtbTelephoneNumber.Name = "mtbTelephoneNumber";
            this.mtbTelephoneNumber.Size = new System.Drawing.Size(97, 20);
            this.mtbTelephoneNumber.TabIndex = 23;
            this.mtbTelephoneNumber.ValidatingType = typeof(int);
            // 
            // cbxGender
            // 
            this.cbxGender.BackColor = System.Drawing.Color.White;
            this.cbxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGender.FormattingEnabled = true;
            this.cbxGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbxGender.Location = new System.Drawing.Point(147, 178);
            this.cbxGender.Name = "cbxGender";
            this.cbxGender.Size = new System.Drawing.Size(200, 21);
            this.cbxGender.TabIndex = 21;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(148, 146);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1890, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(200, 20);
            this.dtpDateOfBirth.TabIndex = 19;
            this.dtpDateOfBirth.Value = new System.DateTime(2017, 11, 2, 0, 0, 0, 0);
            // 
            // tbxLastName
            // 
            this.tbxLastName.BackColor = System.Drawing.Color.White;
            this.tbxLastName.Location = new System.Drawing.Point(147, 113);
            this.tbxLastName.MaxLength = 15;
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(200, 20);
            this.tbxLastName.TabIndex = 18;
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.BackColor = System.Drawing.Color.White;
            this.tbxFirstName.Location = new System.Drawing.Point(147, 73);
            this.tbxFirstName.MaxLength = 15;
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(200, 20);
            this.tbxFirstName.TabIndex = 12;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(93, 244);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 17;
            this.lblAddress.Text = "Address:";
            // 
            // lblTelephoneNumber
            // 
            this.lblTelephoneNumber.AutoSize = true;
            this.lblTelephoneNumber.Location = new System.Drawing.Point(41, 213);
            this.lblTelephoneNumber.Name = "lblTelephoneNumber";
            this.lblTelephoneNumber.Size = new System.Drawing.Size(101, 13);
            this.lblTelephoneNumber.TabIndex = 16;
            this.lblTelephoneNumber.Text = "Telephone Number:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(96, 181);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 15;
            this.lblGender.Text = "Gender:";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(73, 152);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(69, 13);
            this.lblDateOfBirth.TabIndex = 14;
            this.lblDateOfBirth.Text = "Date of Birth:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(80, 116);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 13;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(81, 76);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 12;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblRegisterPatient
            // 
            this.lblRegisterPatient.AutoSize = true;
            this.lblRegisterPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisterPatient.Location = new System.Drawing.Point(114, 11);
            this.lblRegisterPatient.Name = "lblRegisterPatient";
            this.lblRegisterPatient.Size = new System.Drawing.Size(228, 25);
            this.lblRegisterPatient.TabIndex = 12;
            this.lblRegisterPatient.Text = "REGISTER PATIENT";
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.checkBox1);
            this.pnlLogin.Controls.Add(this.label3);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.txtUserName);
            this.pnlLogin.Controls.Add(this.label4);
            this.pnlLogin.Controls.Add(this.label5);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Location = new System.Drawing.Point(12, 417);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(437, 357);
            this.pnlLogin.TabIndex = 17;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(172, 208);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 17);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Remember Username";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "OverSurgery";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(185, 161);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 21;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(185, 122);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(100, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(100, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "UserName";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(147, 263);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 32);
            this.btnLogin.TabIndex = 16;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnlMainMenu
            // 
            this.pnlMainMenu.Controls.Add(this.label1);
            this.pnlMainMenu.Controls.Add(this.button1);
            this.pnlMainMenu.Controls.Add(this.button2);
            this.pnlMainMenu.Controls.Add(this.btnRegisterPatientMainMenu);
            this.pnlMainMenu.Controls.Add(this.btnSettings);
            this.pnlMainMenu.Controls.Add(this.button4);
            this.pnlMainMenu.Location = new System.Drawing.Point(12, 38);
            this.pnlMainMenu.Name = "pnlMainMenu";
            this.pnlMainMenu.Size = new System.Drawing.Size(437, 357);
            this.pnlMainMenu.TabIndex = 24;
            this.pnlMainMenu.Visible = false;
            // 
            // ApplicationMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1541, 823);
            this.Controls.Add(this.pnlMainMenu);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlRegisterPatient);
            this.Controls.Add(this.pnlCreateUser);
            this.Name = "ApplicationMenu";
            this.Text = "Over Surgery";
            this.pnlCreateUser.ResumeLayout(false);
            this.pnlCreateUser.PerformLayout();
            this.pnlRegisterPatient.ResumeLayout(false);
            this.pnlRegisterPatient.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlMainMenu.ResumeLayout(false);
            this.pnlMainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnRegisterPatientMainMenu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlCreateUser;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.Button btnBackCreateUser;
        private System.Windows.Forms.Panel pnlRegisterPatient;
        private System.Windows.Forms.Label lblRegisterPatient;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblTelephoneNumber;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.ComboBox cbxGender;
        private System.Windows.Forms.MaskedTextBox mtbTelephoneNumber;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Button btnRegisterPatient;
        private System.Windows.Forms.Button btnBackRegisterPatient;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnlMainMenu;
    }
}