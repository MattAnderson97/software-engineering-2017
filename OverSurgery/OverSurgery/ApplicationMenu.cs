﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverSurgery
{
    public partial class ApplicationMenu : Form
    {
        public ApplicationMenu()
        {
            InitializeComponent();
        }

        #region pnlMainMenu
        // Main Menu Register Patient button click event.
        private void btnRegisterPatientMainMenu_Click(object sender, EventArgs e)
        {
            pnlRegisterPatient.Visible = true;
        }

        // Main Menu settings button click event.
        private void btnSettings_Click(object sender, EventArgs e)
        {
            // If the settings button is clicked the Create User panel will be displayed.
            pnlCreateUser.Visible = true;
        }

        private void manageAppointmentsBtn_Click(object sender, EventArgs e)
        {
            pnlManageAppointments.Visible = true;
        }
        #endregion

        #region pnlLogin
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter a valid user name");
                txtUserName.Focus();
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter a valid password");
                txtPassword.Focus();
            }

            string userName, password;
            userName = txtUserName.Text;
            password = txtPassword.Text;

            if(LoginManager.GetLoginManagerInstance().Login(userName, password) == true)
            {
                pnlLogin.Visible = false;
                pnlMainMenu.Visible = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid username and password.", "Incorrect Login Details!");
                txtUserName.Clear();
                txtPassword.Clear();
            }


            // Not sure what this is doing?
            /*DataSet ds = new DataSet("Logins");
         
            foreach (DataRow dr in ds.Tables["Logins"].Rows)
            {
                if (dr["Username"].ToString() == "Username")
                {
                    if (dr["Password"].ToString() == "Password")
                    {
                        ApplicationLogin myForm1 = new ApplicationLogin();
                        myForm1.Hide();
                        break;
                    }
                }
                else
                    MessageBox.Show("Invalid username or password");
            }*/
        }

        #endregion

        #region pnlCreateUser
        // Create User panel back button click event.
        private void btnBack_Click(object sender, EventArgs e)
        {
            // If the back button is clicked the Create User panel will be hidden.
            pnlCreateUser.Visible = false;
            tbxUsername.Text = "";
            tbxPassword.Text = "";
        }

        // Create user panel create button.
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Gets the user's chosen details from a text box.
            string userName = tbxUsername.Text;
            string password = tbxPassword.Text;
            
            // Switch runs the CreateUser method and displays different messages,
            // depending on the outcome. 
            switch(LoginManager.GetLoginManagerInstance().CreateUser(userName, password))
            {
                // User account created.
                case 1:
                    MessageBox.Show("Account Created!", "Done!");
                    pnlCreateUser.Visible = false;
                    tbxUsername.Text = "";
                    tbxPassword.Text = "";
                    break;
                
                // Username and password fields left blank.
                case 2:
                    MessageBox.Show("Please enter a username and password.", "Error!");
                    break;
                
                // Entered username already exists.
                case 3:
                    MessageBox.Show("Please enter a different username.", "Username already exists!");
                    tbxUsername.Text = "";
                    tbxPassword.Text = "";
                    break;
            }
        }

        #endregion
     
        #region pnlRegisterPatient

        // Register Patient panel back button click event.
        private void btnBackRegisterPatient_Click(object sender, EventArgs e)
        {
            pnlRegisterPatient.Visible = false;
            tbxFirstName.ResetText();
            tbxLastName.ResetText();
            mtbTelephoneNumber.ResetText();
            dtpDateOfBirth.ResetText();
            cbxGender.ResetText();          
            tbxAddress.ResetText();
        }

        // Register Patient panel register patient button click event.
        private void btnRegisterPatient_Click(object sender, EventArgs e)
        {
            // Assigns patient details to patient info struct.
            Patient.patientInfo patientDetails;
            patientDetails.firstName = tbxFirstName.Text;
            patientDetails.lastName = tbxLastName.Text;
            patientDetails.telephoneNumber = mtbTelephoneNumber.Text;
            patientDetails.dateOfBirth = dtpDateOfBirth.Value.ToShortDateString();
            patientDetails.gender = cbxGender.Text;           
            patientDetails.address = tbxAddress.Text;

            // Calls the register method in the patient class and gives it the struct,
            // if none of the data entry fields are empty.
            if(Patient.GetPatientInstance().Register(patientDetails) == false)
            {
                MessageBox.Show("Please enter details into all fields.", "Empty fields!");
            }
            else
            {
                MessageBox.Show("Patient has been registered.", "Registered!");
                tbxFirstName.ResetText();
                tbxLastName.ResetText();
                mtbTelephoneNumber.ResetText();
                dtpDateOfBirth.ResetText();
                cbxGender.ResetText();
                tbxAddress.ResetText();
                pnlRegisterPatient.Hide();
            }
        }


        #endregion

        #region pnlManageAppointments

        class ManageAppointmentsPatientStaffData
        {
            int id;
            string firstName;
            string lastName;

            public ManageAppointmentsPatientStaffData(int id, string firstName, string lastName)
            {
                this.id = id;
                this.firstName = firstName;
                this.lastName = lastName;
            }

            override public String ToString()
            {
                return id + " " + firstName + " " + lastName;
            }

            public int ID
            {
                get
                {
                    return id;
                }
            }

            public string FirstName
            {
                get
                {
                    return firstName;
                }
            }

            public string LastName
            {
                get
                {
                    return lastName;
                }
            }
        }

        private void btnBackManageAppointments_Click(object sender, EventArgs e)
        {
            pnlManageAppointments.Visible = false;
        }

        private void btnSaveManageAppointments_Click(object sender, EventArgs e)
        {

        }

        private void pnlManageAppointments_VisibleChanged(object sender, EventArgs e)
        {

            if (pnlManageAppointments.Visible)
            {
                // get list of patients from DB
                // loop through list
                // add each patient to combobox
                // manageAppointmentPatient.Items.add(patient);

                DataSet data = DatabaseConnection.getDatabaseConnectionInstance().getDataSet("SELECT PatientID, FirstName, LastName FROM Patient");
                DataTable table = data.Tables[0];

                for (int row = 0; row < table.Rows.Count; row++)
                {
                    int id = int.Parse(table.Rows[row][0].ToString().Trim());
                    string firstName = table.Rows[row][1].ToString().Trim();
                    string lastName = table.Rows[row][2].ToString().Trim();

                    // Console.WriteLine(PatientIDs[row] + " " + FirstNames[row] + " " + LastNames[row]);
                    manageAppointmentPatient.Items.Add(new ManageAppointmentsPatientStaffData(id, firstName, lastName));
                }
            }
            else
            {
                manageAppointmentPatient.Items.Clear();
            }
        }

        private DataTable getAppointmentsTable()
        {
            ManageAppointmentsPatientStaffData patientData = (ManageAppointmentsPatientStaffData) manageAppointmentPatient.SelectedItem;
            int patientID = patientData.ID;

            DataSet data = DatabaseConnection.getDatabaseConnectionInstance().getDataSet("SELECT * FROM Appointment WHERE PatientID_Fk = " + patientID);
            DataTable table = data.Tables[0];
            return table;
        }

        private void manageAppointmentPatient_SelectedIndexChanged(object sender, EventArgs args)
        {
            DataTable table = getAppointmentsTable();

            for (int row = 0; row < table.Rows.Count; row++)
            {
                DataRow dataRow = table.Rows[row];
                String appointment = dataRow[0].ToString().Trim() + " " + dataRow[2].ToString().Trim() + " " + dataRow[3].ToString().Trim();
                manageAppointmentID.Items.Add(appointment);
            }
        }

        private void manageAppointmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = getAppointmentsTable();

            for (int row = 0; row < table.Rows.Count; row++)
            {
                DataRow dataRow = table.Rows[row];
                manageAppointmentType.Text = dataRow[1].ToString().Trim();
                manageAppointmentDate.Text = dataRow[2].ToString().Trim();
                manageAppointmentTime.Text = dataRow[3].ToString().Trim();

                DataSet dataSet = DatabaseConnection.getDatabaseConnectionInstance().getDataSet("SELECT StaffID, FirstName, LastName FROM StaffMember WHERE StaffID = " + dataRow[4].ToString().Trim());
                DataRowCollection staffRows = dataSet.Tables[0].Rows;

                for (int i = 0; i < staffRows.Count; i++)
                {
                    if (staffRows[i][0].ToString().Trim() == dataRow[4].ToString().Trim())
                    {
                        manageAppointmentDoctor.Text = staffRows[i][0].ToString().Trim() + " " + staffRows[i][1].ToString().Trim() + " " + staffRows[i][2].ToString().Trim();
                        break;
                    }
                }
            }
        }

        #endregion
    }
}
