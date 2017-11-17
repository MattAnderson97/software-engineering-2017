using System;
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

            // Sets the minimum date to the current date.
            dtpDateAddApptPanel.MinDate = DateTime.Today;
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

        // Main Menu Add Appointment button click event
        private void btnAddApptMainMenuPanel_Click(object sender, EventArgs e)
        {
            // If the add appointment button is clicked the panel will be displayed.
            pnlAddAppointment.Visible = true;

            // Sets the displayed date and minDate to todays date.
            dtpDateAddApptPanel.MinDate = DateTime.Today;
            dtpDateAddApptPanel.Value = DateTime.Today;
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

        // Runs when the back button is clicked.
        private void btnBackAddApptPanel_Click(object sender, EventArgs e)
        {
            // Hides the panel.
            pnlAddAppointment.Visible = false;

            // Resets all data entry fields.
            lblPatientNameAddApptPanel.Visible = false;
            btnAddPatientAddApptPanel.Visible = true;
            patientID = null;
            dtpDateAddApptPanel.Value = DateTime.Today;
            lbxApptTimeAddApptPanel.Items.Clear();
            lbxApptStaffAddApptPanel.Items.Clear();
        }
  
        private void btnAddPatientAddApptPanel_Click(object sender, EventArgs e)
        {
            lblPatientNameAddApptPanel.Text = "";

            // Runs search patient feature...gets a patientID and name back
            patientID = "2";
            patientName = "John Smith";

            // Stores the name of the selected patient.
            lblPatientNameAddApptPanel.Text = patientName;

            // Hides the add patient button.
            btnAddPatientAddApptPanel.Visible = false;

            // Displays the name of the selected patient.
            lblPatientNameAddApptPanel.Visible = true;
        }

        // Runs when the selected date changes.
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
            appointmentTimes = AddAppointment.GetAddAppointmentInstance().GetAppointmentTimes(chosenDate);

            // Iterates through the list items, adding them to the list box.
            for(int i = 0; i < appointmentTimes.Count; i++)
            {
                lbxApptTimeAddApptPanel.Items.Add(appointmentTimes[i]);
            }
        }

        // Runs when a list box item is selected.
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
            staffIDList = AddAppointment.GetAddAppointmentInstance().GetAppointmentStaff(chosenDate, chosenTime);

            // Iterates through the list adding the items to the list box.
            for(int i =0; i < staffIDList.Count/*availableStaff.Count*/; i++)
            {
                // Gets a data set containing a staff member.
                DataSet dsStaffMember = AddAppointment.GetAddAppointmentInstance().GetStaffMemberName(staffIDList[i]);

                // Adds their first name and last name based off their ID to the list box.
                lbxApptStaffAddApptPanel.Items.Add(dsStaffMember.Tables[0].Rows[0]["FirstName"].ToString() + dsStaffMember.Tables[0].Rows[0]["LastName"].ToString() /*availableStaff[i]*/);
            }         
        }

        // Runs when the add button is clicked.
        private void btnAddAddApptPanel_Click(object sender, EventArgs e)
        {
            // Creates a new instance of the appointment info class.
            AppointmentInfo appointmentInfo = new AppointmentInfo();

            // Says there are empty fields.
            bool noEmptyFields = false;

            // Checks if any of the data entry fields are null.
            if (patientID == null)
            {
                MessageBox.Show("No patient selected.", "Error!");
            }
            else if(lbxApptTimeAddApptPanel.SelectedItem == null)
            {
                MessageBox.Show("No time selected", "Error!");
            }
            else if(lbxApptStaffAddApptPanel.SelectedItem == null)
            {
                MessageBox.Show("No staff member selected", "Error!");
            }
            else
            {
                // Says there are no empty data entry fields.
                noEmptyFields = true;
            }

            // If there are no empty data entry fields, the appointment is added to the database.
            if (noEmptyFields == true)
            {
                // Assigns the PatientID.
                appointmentInfo.PatientID = Int32.Parse(patientID);

                // Assigns the chosen date.
                appointmentInfo.Date = dtpDateAddApptPanel.Value.ToShortDateString();

                // Assigns the chosen time.
                appointmentInfo.Time = lbxApptTimeAddApptPanel.SelectedItem.ToString();

                // Gets the index number of the staff member selected.
                int indexNumber = lbxApptStaffAddApptPanel.SelectedIndex;

                // Sets the staffID to the number in the StaffID list at the chosen index.
                staffID = staffIDList[indexNumber];

                // Assigns the StaffID.
                appointmentInfo.StaffID = Int32.Parse(staffID);

                // Inserts the appointment into the database.
                AddAppointment.GetAddAppointmentInstance().AddToDatabase(appointmentInfo);

                // Tells the user the appointment is booked.
                MessageBox.Show("Appointment booked.", "Done!");

                // Hides the panel.
                pnlAddAppointment.Visible = false;

                // Resets all data entry fields.
                lblPatientNameAddApptPanel.Visible = false;
                btnAddPatientAddApptPanel.Visible = true;
                patientID = null;
                dtpDateAddApptPanel.Value = DateTime.Today;
                lbxApptTimeAddApptPanel.Items.Clear();
                lbxApptStaffAddApptPanel.Items.Clear();
            }

            // Resets the date selected.
            dtpDateAddApptPanel.Value = DateTime.Today;
            
        }

        #endregion

        #region ApplicationMenuForm
        private void ApplicationMenu_Load(object sender, EventArgs e)
        {
            DataSet dsDebug = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.selectAll);

            DataTable dtDebug = dsDebug.Tables[0];

            dgvDebug.DataSource = dtDebug;

            DataSet dsDebug2 = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.selectAll2);

            DataTable dtDebug2 = dsDebug2.Tables[0];

            dgvDebug2.DataSource = dtDebug2;
        }





        #endregion


    }
}
