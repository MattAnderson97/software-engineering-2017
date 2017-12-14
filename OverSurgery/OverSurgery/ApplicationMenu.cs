using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Globalization;

namespace OverSurgery
{
    public partial class ApplicationMenu : Form
    {
        public ApplicationMenu()
        {
            InitializeComponent();

            // Sets the minimum date to the current date.
            dtpDateAddApptPanel.MinDate = DateTime.Today;

            // Sets the maximum date to the current date.
            dtpDateOfBirth.MaxDate = DateTime.Today;

        }

        #region pnlMainMenu
        // Main Menu Register Patient button click event.
        private void btnRegisterPatientMainMenu_Click(object sender, EventArgs e)
        {
            pnlRegisterPatient.Visible = true;
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
        }

        private void btnPrescriptions_Click(object sender, EventArgs e)
        {
            pnlPrescription.Visible = true;
            datepicker.Value = datepicker.MaxDate;
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
        
        // Main Menu Add Appointment button click event
        private void btnAddApptMainMenuPanel_Click(object sender, EventArgs e)
        {
            // If the add appointment button is clicked the panel will be displayed.
            pnlAddAppointment.Visible = true;

            // Sets the displayed date and minDate to todays date.           
            dtpDateAddApptPanel.MinDate = DateTime.Today;
            dtpDateAddApptPanel.Value = DateTime.Today;

            // Sets the max date to (today's date + 1 month).
            dtpDateAddApptPanel.MaxDate = DateTime.Today.AddMonths(1);
            
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

            if(LoginManager.GetLoginManagerInstance.Login(userName, password) == true)
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
        }

        #endregion

        #region pnlCreateUser
        // Create User panel back button click event.
        private void btnBack_Click(object sender, EventArgs e)
        {
            // If the back button is clicked the Create User panel will be hidden.
            pnlCreateUser.Visible = false;

            // Clears text fields.
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
            switch(LoginManager.GetLoginManagerInstance.CreateUser(userName, password))
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
                    tbxUsername.Text = "";
                    tbxPassword.Text = "";
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
            // Closes panel and resets all data entry fields.
            pnlRegisterPatient.Visible = false;
            tbxFirstName.ResetText();
            tbxLastName.ResetText();
            tbxTelNumRegisterPatientPnl.ResetText();
            dtpDateOfBirth.ResetText();
            cbxGender.ResetText();          
            tbxAddress.ResetText();
        }

        // Register Patient panel register patient button click event.
        private void btnRegisterPatient_Click(object sender, EventArgs e)
        {
            // Assigns patient details to patient info object.
            PatientInfo patientInfo = new PatientInfo();
            patientInfo.FirstName = tbxFirstName.Text;
            patientInfo.LastName = tbxLastName.Text;
            patientInfo.TelephoneNumber = tbxTelNumRegisterPatientPnl.Text;
            patientInfo.DateOfBirth = dtpDateOfBirth.Value.ToShortDateString();
            patientInfo.Gender = cbxGender.Text;
            patientInfo.Address = tbxAddress.Text;

            // Calls the register method in the patient class and gives it the patient info object.
            // Switch displays messages depending on the outcome of running the method.
            switch (PatientManager.GetPatientManagerInstance.Register(patientInfo))
            {
                // Runs if the patient is registered.
                case 1:
                    MessageBox.Show("Patient has been registered.", "Registered!");

                    // Closes panel and resets fields back to empty.
                    pnlRegisterPatient.Visible = false;
                    tbxFirstName.ResetText();
                    tbxLastName.ResetText();
                    tbxTelNumRegisterPatientPnl.ResetText();
                    dtpDateOfBirth.ResetText();
                    cbxGender.ResetText();
                    tbxAddress.ResetText();
                    break;

                // Runs if fields are missing details.
                case 2:
                    MessageBox.Show("Please enter details into all fields.", "Empty fields!");

                    // Resets fields.
                    tbxFirstName.ResetText();
                    tbxLastName.ResetText();
                    tbxTelNumRegisterPatientPnl.ResetText();
                    dtpDateOfBirth.ResetText();
                    cbxGender.ResetText();
                    tbxAddress.ResetText();
                    break;

                // Runs if invalid characters are enetered into the telephone number field.
                case 3:
                     MessageBox.Show("Please enter a correct telephone number.", "Invalid telephone number");

                    // Resets fields.
                    tbxFirstName.ResetText();
                    tbxLastName.ResetText();
                    tbxTelNumRegisterPatientPnl.ResetText();
                    dtpDateOfBirth.ResetText();
                    cbxGender.ResetText();
                    tbxAddress.ResetText();
                    break;
            }
        }
        #endregion


        #region pnlAddAppointment       

        // Stores the selected patients ID number.
        private string patientID;

        // Stores the selected patients name.
        private string patientName;

        // Stores the ID number of the selected staff member.
        private string staffID;

        // Creates a list to hold all of the staff members ID's
        // in the order their names are listed.
        private List<string> staffIDList = new List<string>();

        // Add appointment panel back button click event.
        private void btnBackAddApptPanel_Click(object sender, EventArgs e)
        {
            // Hides the panel.
            pnlAddAppointment.Visible = false;

            // Resets all data entry fields.
            lblPatientNameAddApptPanel.Visible = false;
            btnAddPatientAddApptPanel.Visible = true;
            patientID = null;
            dtpDateAddApptPanel.ResetText();
        }
        
        // Add patient button click event.
        private void btnAddPatientAddApptPanel_Click(object sender, EventArgs e)
        {
            lblPatientNameAddApptPanel.Text = "";

            // Runs search patient feature...gets a patientID and name back.
            patientID = "2";
            patientName = "John Smith";

            // Stores the name of the selected patient.
            lblPatientNameAddApptPanel.Text = patientName;

            // Hides the add patient button.
            btnAddPatientAddApptPanel.Visible = false;

            // Displays the name of the selected patient.
            lblPatientNameAddApptPanel.Visible = true;
        }

        // Add appointment panel date time picker value changed event.
        private void dtpDateAddApptPanel_ValueChanged(object sender, EventArgs e)
        {
            // Clears the list boxes.
            lbxApptTimeAddApptPanel.Items.Clear();
            lbxApptStaffAddApptPanel.Items.Clear();

            // Saves the date chosen by the user.
            string chosenDate = dtpDateAddApptPanel.Value.ToShortDateString();

            // Creates a list to store all bookable appointment times 
            // ready for display.
            List<string> appointmentTimes = new List<string>();

            // Gets the list items from the database.
            appointmentTimes = AppointmentManager.GetAppointmentManagerInstance.GetAppointmentTimes(chosenDate);

            // Iterates through the list items, adding them to the list box.
            for(int i = 0; i < appointmentTimes.Count; i++)
            {
                lbxApptTimeAddApptPanel.Items.Add(appointmentTimes[i]);
            }
        }

        // Time list box value changed event.
        private void lbxApptTimeAddApptPanel_SelectedValueChanged(object sender, EventArgs e)
        {
            // Clears the StaffID list.
            staffIDList.Clear();

            // Clears the list box.
            lbxApptStaffAddApptPanel.Items.Clear();
        
            // Saves the date chosen by the user.
            string chosenDate = dtpDateAddApptPanel.Value.ToShortDateString();

            // Saves the time chosen by the user.
            string chosenTime = lbxApptTimeAddApptPanel.GetItemText(lbxApptTimeAddApptPanel.SelectedItem);

            // Gets a list of available staff members.
            staffIDList = AppointmentManager.GetAppointmentManagerInstance.GetAppointmentStaff(chosenDate, chosenTime);

            // Iterates through the list adding the items to the list box.
            for(int i =0; i < staffIDList.Count; i++)
            {
                // Gets a data set containing a staff member.
                DataSet dsStaffMember = AppointmentManager.GetAppointmentManagerInstance.GetStaffMemberName(staffIDList[i]);

                // Adds their first name and last name based off their ID to the list box.
                lbxApptStaffAddApptPanel.Items.Add(dsStaffMember.Tables[0].Rows[0]["FirstName"].ToString().Trim() + " " + dsStaffMember.Tables[0].Rows[0]["LastName"].ToString().Trim());
            }         
        }

        // Add appointment button click event.
        private void btnAddAddApptPanel_Click(object sender, EventArgs e)
        {
            // Creates a new instance of the appointment info class.
            AppointmentInfo appointmentInfo = new AppointmentInfo();

            // Assigns the PatientID.
            appointmentInfo.PatientID = patientID;

            // Assigns the chosen date.
            appointmentInfo.Date = dtpDateAddApptPanel.Value.ToShortDateString();

            // Runs only if a time is selected.
            if(lbxApptTimeAddApptPanel.SelectedItem != null)
            {
                // Assigns the chosen time.
                appointmentInfo.Time = lbxApptTimeAddApptPanel.SelectedItem.ToString();
            }

            // Gets the index number of the staff member selected.
            int indexNumber = lbxApptStaffAddApptPanel.SelectedIndex;

            // Runs only if a staff member is selected.
            if (indexNumber != -1)
            {
                // Sets the staffID to the number in the StaffID list at the chosen index.
                staffID = staffIDList[indexNumber];
            }

            // Assigns the StaffID.
            appointmentInfo.StaffID = staffID;

            // Runs the add appointment method and displays messages based on the result.
            switch (AppointmentManager.GetAppointmentManagerInstance.AddAppointment(appointmentInfo))
            {
                // No patient is selected.
                case 1:
                    MessageBox.Show("No patient selected.", "Error!");
                    break;
                
                // No date is selected.
                case 2:
                    MessageBox.Show("No date selected.", "Error!");
                    break;
                
                // No time is selected.
                case 3:
                    MessageBox.Show("No time selected.", "Error!");
                    break;
                
                // No staff member is selected.
                case 4:
                    MessageBox.Show("No staff member selected.", "Error!");
                    break;
                
                // Appointment is inserted into the database successfully.
                case 5:
                    MessageBox.Show("Appointment booked.", "Done!");

                    // Hides the panel.
                    pnlAddAppointment.Visible = false;

                    // Resets all data entry fields.
                    lblPatientNameAddApptPanel.Visible = false;
                    btnAddPatientAddApptPanel.Visible = true;
                    patientID = null;
                    dtpDateAddApptPanel.ResetText();
                    staffID = null;
                    break;
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

        /// <summary>
        /// Class from https://stackoverflow.com/a/9569546
        /// Submitted by Bas on March 5 2012
        /// Accessed Dec 1 2017
        /// </summary>
        private class Prompt
        {
            public static void ShowDialog(string title, string text)
            {
                Form prompt = new Form();
                prompt.Width = 210;
                prompt.Height = 150;
                prompt.Text = text;
                Label textLabel = new Label() { Left = 50, Top = 20, Text = title };
                Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 70 };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.ShowDialog();
            }
        }

        private void btnBackManageAppointments_Click(object sender, EventArgs e)
        {
            pnlManageAppointments.Visible = false;
        }
        

        private void btnSaveManageAppointments_Click(object sender, EventArgs e)
        {
            try
            {
                int appointmentID = Int32.Parse(manageAppointmentID.Text.Split(' ')[0]);
                string type = manageAppointmentType.Text;
                string date = manageAppointmentDate.Value.Date.ToString("d");
                string time = manageAppointmentTime.Text;
                int doctorID = Int32.Parse(manageAppointmentDoctor.Text.Split(' ')[0]);
                string sql = "UPDATE Appointment " +
                    "SET Type = '" + type + "', " +
                    "Date = '" + date + "', " +
                    "Time = '" + time + "', " +
                    "StaffID_Fk = " + doctorID + " " +
                    "WHERE AppointmentID = " + appointmentID;
                // Console.WriteLine(sql);
                DatabaseConnection.getDatabaseConnectionInstance().getDataSet(sql);
                pnlManageAppointments.Visible = false;
            }
            catch(Exception ex)
            {
                Prompt.ShowDialog("Missing data", "Error");
            }
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

                DataSet dataSet = DatabaseConnection.getDatabaseConnectionInstance().getDataSet("SELECT StaffID, FirstName, LastName FROM StaffMember");
                DataRowCollection staffRows = dataSet.Tables[0].Rows;

                for (int i = 0; i < staffRows.Count; i++)
                {
                    manageAppointmentDoctor.Items.Add(staffRows[i][0].ToString().Trim() + " " + staffRows[i][1].ToString().Trim() + " " + staffRows[i][2].ToString().Trim());

                    if (staffRows[i][0].ToString().Trim() == dataRow[4].ToString().Trim())
                    {
                        manageAppointmentDoctor.Text = staffRows[i][0].ToString().Trim() + " " + staffRows[i][1].ToString().Trim() + " " + staffRows[i][2].ToString().Trim();
                    }
                }
            }
        }

        #endregion

        #region pnlPrescription



        // Extend prescription button selected
        private void btnExtendPrescription_Click(object sender, EventArgs e)
        {
            Prescription prescription = new Prescription();
            prescription.MedicineName = tbxMedicineName.Text;
            prescription.Length = tbxLength.Text;
            prescription.ExtentionDate = datepicker.Value.ToShortDateString();
            prescription.Note = tbxNote.Text;

            //show message when fields are empty and when they are not 
            switch (PrescriptionManager.GetPrescriptionManagerInstance.Extend(prescription))
            {
                // when all detail have been entered correctly
                case 1:
                    MessageBox.Show("Extended Prescription date. (No more extention for 30 days without a doctor's permission))");
                    pnlPrescription.Visible = false; //hides panel
                    //resets fields
                    tbxMedicineName.ResetText();
                    tbxLength.ResetText();
                    datepicker.ResetText();
                    tbxNote.ResetText();
                    break;

                // when details r missing
                case 2:
                    MessageBox.Show("Please check if all details have been entered. FEILDS MISSING!");
                    // Resets fields.
                    tbxMedicineName.ResetText();
                    tbxLength.ResetText();
                    datepicker.ResetText();
                    tbxNote.ResetText();
                    break;


            }

        }
        // selecting back button on prescription panel
        private void btnBackPrescription_Click(object sender, EventArgs e)
        {
            // hides the panel and resets all data entry fields
            pnlPrescription.Visible = false;
            tbxMedicineName.ResetText();
            tbxLength.ResetText();
            datepicker.ResetText();
            tbxNote.ResetText();
        }
        #endregion


        #region ApplicationMenuForm
        private void ApplicationMenu_Load(object sender, EventArgs e)
        {
            
        }





        #endregion


    }
}
