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
        }

        private void btnViewStaff_Click(object sender, EventArgs e)
        {
            pnlStaff.Visible = true;
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
            switch (PatientManager.GetPatientInstance.Register(patientInfo))
            {
                // Runs if the patient is registered.
                case 1:
                MessageBox.Show("Patient has been registered.", "Registered!");
                break;

                // Runs if fields are missing details.
                case 2:
                MessageBox.Show("Please enter details into all fields.", "Empty fields!");
                break;

                // Runs if invalid characters are enetered into the telephone number field.
                case 3:
                MessageBox.Show("Please enter a correct telephone number.", "Invalid telephone number");
                break;
            }

            // Closes panel and resets fields back to empty.
            pnlRegisterPatient.Visible = false;
            tbxFirstName.ResetText();
            tbxLastName.ResetText();
            tbxTelNumRegisterPatientPnl.ResetText();
            dtpDateOfBirth.ResetText();
            cbxGender.ResetText();
            tbxAddress.ResetText();
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
        public DataGridView PrescriptionsGrid
        {
            get { return prescriptions; }
            set { prescriptions = value; }
        }

        private void OnPrescriptionGridDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (row >= 0)
            {
                if (col == 0)//if a med id is being clicked
                {
                    string selectedMedID = prescriptions.Rows[row].Cells[col].Value.ToString();
                }
                else if (col == 1)//if a patient id is clicked
                {
                    string selectedPatId = prescriptions.Rows[row].Cells[col].Value.ToString();
                }

            }
        }
        /// <summary>
        /// This event controls the extentions of prescriptions by 
        /// catching all the changes in the values, foul proofing them
        /// and accepting them or rejecting them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPrescriptionsCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int column = e.ColumnIndex;
            int row = e.RowIndex;
            string medID = prescriptions[column - 6, row].Value.ToString();
            string patientId = prescriptions[column - 5, row].Value.ToString();
            string medName = prescriptions[column - 4, row].Value.ToString();
            string patientName = prescriptions[column - 3, row].Value.ToString();
            string dateFrom = prescriptions[column - 2, row].Value.ToString();
            string originalTo = prescriptions[column - 1, row].Value.ToString();
            string extendDate = prescriptions[column, row].Value.ToString();

            if (prescriptions[column, row].Value.ToString() != "")
            {


                DateTime result;
                bool formatValidity = DateTime.TryParseExact(extendDate, "yyyy_MM_dd", new CultureInfo("en-UK"), DateTimeStyles.None, out result);
                bool dateValidity = false;

                if (formatValidity)
                {
                    dateValidity = Int32.Parse(extendDate.Replace("_", "")) > Int32.Parse((originalTo.Replace("_", ""))) ? true : false;

                    if (dateValidity)
                    {
                        PrescriptionInfor.ConfirmPrescriptionAction(medID, patientId, extendDate);
                        BeginInvoke(new MethodInvoker(Prescriptionc.Instance.UpdatePrescriptionsDataGrid));
                        //UpdatePrescription is being Invoked
                    }
                    else
                    {
                        //else got to thing
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Wrong Input inserted. Please make sure the requested extention is in the specified format. (yyyy_MM_dd)");
                    BeginInvoke(new MethodInvoker(Prescriptionc.Instance.UpdatePrescriptionsDataGrid));
                }
            }
            else
            {
                string message = "Delete extention?";
                DialogResult answer = System.Windows.Forms.MessageBox.Show(message, "Attention", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    Prescriptionc.Instance.DeleteExtention(medID, patientId);
                    BeginInvoke(new MethodInvoker(Prescriptionc.Instance.UpdatePrescriptionsDataGrid));
                }
                else
                {
                    BeginInvoke(new MethodInvoker(Prescriptionc.Instance.UpdatePrescriptionsDataGrid));
                }

            }
        }
        #endregion

        #region pnlStaff
        private void btnBackViewStaffPnl_Click(object sender, EventArgs e)
        {
            pnlStaff.Visible = false;
        }

        private void LoadlistView()
        {

            listView1.Items.Clear(); //clearing list view
            listView1.Columns.Add("Time");//adding list view

            DataSet dsStaffMember = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.SelectStaff);

            //get the table to be displayed from the data set
            DataTable dtStaff = dsStaffMember.Tables[0];

            //load the list view with data
            int max = DatabaseConnection.getDatabaseConnectionInstance().GetIntValue(Constants.countStaff);
            for (int i = 0; i < max; i++)
            {
                listView1.Columns.Add(dtStaff.Rows[i]["FirstName"].ToString(), 120);
            }

            for (int i = 8; i < 24; i++)
            {
                if (i < 10)
                {
                    listView1.Items.Add("0" + i + ":00");
                }
                else
                {
                    listView1.Items.Add(i + ":00");
                }
            }

            for (int index = 0; index < max; index++)
            {
                for (int i = 0; i < 16; i++)
                {
                    listView1.Items[i].SubItems.Add("Available");
                    //property to add colour
                    listView1.Items[i].UseItemStyleForSubItems = false;
                }

            }

        }

        private void AddShiftToListView(string StaffID)
        {

            string Date = dateTimePicker1.Text;

            DataSet dsStaffAvailible = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.SelectShiftQuery(Date));

            //get the table to be displayed from the data set
            DataTable dtStaffAvailible = dsStaffAvailible.Tables[0];

            //find out how many shifts a member of staff has in that specific day
            int shiftAmount = DatabaseConnection.getDatabaseConnectionInstance().GetIntValue(Constants.Countshifts(Date));
            Console.WriteLine("Shift Amount=" + shiftAmount);

            //debug
            Console.WriteLine("Passed Value:" + StaffID);
            for (int i = 0; i < shiftAmount; i++)
            {
                Console.WriteLine("Value from the datatable:" + (dtStaffAvailible.Rows[i]["Staff ID"].ToString()));
                if ((dtStaffAvailible.Rows[i]["Staff ID"].ToString()) == StaffID)
                {
                    //change the subitems value to change the staff member

                    string value = (dtStaffAvailible.Rows[i]["From"].ToString());
                    Console.WriteLine("Row value=" + value);
                    int staffInt = Convert.ToInt32(StaffID);

                    switch (value)
                    {
                        case "08:00:00":
                            listView1.Items[0].SubItems[staffInt].Text = "Working";
                            listView1.Items[4].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "09:00:00":
                            listView1.Items[1].SubItems[staffInt].Text = "Working";
                            listView1.Items[1].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "10:00:00":
                            listView1.Items[2].SubItems[staffInt].Text = "Working";
                            listView1.Items[2].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "11:00:00":
                            listView1.Items[3].SubItems[staffInt].Text = "Working";
                            listView1.Items[3].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "12:00:00":
                            listView1.Items[4].SubItems[staffInt].Text = "Working";
                            listView1.Items[4].SubItems[staffInt].ForeColor = Color.Black;
                            break;
                        case "13:00:00":
                            listView1.Items[5].SubItems[staffInt].Text = "Working";
                            listView1.Items[5].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "14:00:00":
                            listView1.Items[6].SubItems[staffInt].Text = "Working";
                            listView1.Items[6].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "15:00:00":
                            listView1.Items[7].SubItems[staffInt].Text = "Working";
                            listView1.Items[7].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "16:00:00":
                            listView1.Items[8].SubItems[staffInt].Text = "Working";
                            listView1.Items[8].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "17:00:00":
                            listView1.Items[9].SubItems[staffInt].Text = "Working";
                            listView1.Items[9].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "18:00:00":
                            listView1.Items[10].SubItems[staffInt].Text = "Working";
                            listView1.Items[10].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "19:00:00":
                            listView1.Items[11].SubItems[staffInt].Text = "Working";
                            listView1.Items[11].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "20:00:00":
                            listView1.Items[12].SubItems[staffInt].Text = "Working";
                            listView1.Items[12].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "21:00:00":
                            listView1.Items[13].SubItems[staffInt].Text = "Working";
                            listView1.Items[13].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "22:00:00":
                            listView1.Items[14].SubItems[staffInt].Text = "Working";
                            listView1.Items[14].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "23:00:00":
                            listView1.Items[15].SubItems[staffInt].Text = "Working";
                            listView1.Items[15].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        default:
                            Console.WriteLine("No time found");
                            break;
                    }
                }

            }
        }
        private void btnOnduty_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Text;
            DataSet dsStaffMember = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.SelectShiftQuery(date));
            DataTable dtStaffMember = dsStaffMember.Tables[0];
        }

        private void btnStaffAvailable_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Text;
            DataSet dsStaffMember = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.CheckStaffAvailability(date));
            DataTable dtStaffMember = dsStaffMember.Tables[0];
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
