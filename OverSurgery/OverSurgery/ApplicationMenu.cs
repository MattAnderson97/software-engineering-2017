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
        private void dtpDateAddApptPanel_ValueChanged(object sender, EventArgs e)
        {
            string chosenDate = dtpDateAddApptPanel.Value.ToShortDateString();

            List<string> textList = new List<string>();
            textList = AddAppointment.GetAddAppointmentInstance().FindChosenDate(chosenDate);

            tbxTest.Clear();
            
            for(int i = 0; i < textList.Count; i++)
            {
                tbxTest.AppendText(textList[i] + Environment.NewLine);
            }
        }
        #endregion


    }
}
