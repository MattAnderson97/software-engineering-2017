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
            pnlManageAppointments.Visible = false;
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
                    manageAppointmentDoctor.Items.Add(staffRows[i][0].ToString().Trim() + " " + staffRows[i][1].ToString().Trim() + " " + staffRows[i][2].ToString().Trim());

                    if (staffRows[i][0].ToString().Trim() == dataRow[4].ToString().Trim())
                    {
                        manageAppointmentDoctor.Text = staffRows[i][0].ToString().Trim() + " " + staffRows[i][1].ToString().Trim() + " " + staffRows[i][2].ToString().Trim();
                    }
                }
            }
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

        #region prescription
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

        #region Staff
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

        
    }
}
