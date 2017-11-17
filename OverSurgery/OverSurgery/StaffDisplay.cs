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
    public partial class StaffsForm : Form
    {
        
        
        
   

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.btnOnduty = new System.Windows.Forms.Button();
            this.btnStaffAvailable = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.listView2 = new System.Windows.Forms.ListView();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblStaffs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOnduty
            // 
            this.btnOnduty.Location = new System.Drawing.Point(73, 295);
            this.btnOnduty.Name = "btnOnduty";
            this.btnOnduty.Size = new System.Drawing.Size(179, 23);
            this.btnOnduty.TabIndex = 0;
            this.btnOnduty.Text = "OnDuty Staff";
            this.btnOnduty.UseVisualStyleBackColor = true;
            this.btnOnduty.Click += new System.EventHandler(this.btnOnduty_Click);
            // 
            // btnStaffAvailable
            // 
            this.btnStaffAvailable.Location = new System.Drawing.Point(291, 295);
            this.btnStaffAvailable.Name = "btnStaffAvailable";
            this.btnStaffAvailable.Size = new System.Drawing.Size(205, 23);
            this.btnStaffAvailable.TabIndex = 1;
            this.btnStaffAvailable.Text = "Staff Available";
            this.btnStaffAvailable.UseVisualStyleBackColor = true;
            this.btnStaffAvailable.Click += new System.EventHandler(this.btnStaffAvailable_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(62, 185);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(583, 104);
            this.dataGridView2.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(171, 56);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(62, 82);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(583, 97);
            this.listView2.TabIndex = 4;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(62, 63);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Date";
            // 
            // lblStaffs
            // 
            this.lblStaffs.AutoSize = true;
            this.lblStaffs.Location = new System.Drawing.Point(73, 13);
            this.lblStaffs.Name = "lblStaffs";
            this.lblStaffs.Size = new System.Drawing.Size(96, 13);
            this.lblStaffs.TabIndex = 6;
            this.lblStaffs.Text = "OverSurgery Staffs";
            // 
            // StaffsForm
            // 
            this.ClientSize = new System.Drawing.Size(657, 330);
            this.Controls.Add(this.lblStaffs);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnStaffAvailable);
            this.Controls.Add(this.btnOnduty);
            this.Name = "StaffsForm";
            this.Text = "Staffs Display";
            this.Load += new System.EventHandler(this.StaffFOrm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //reload the listview
            LoadlistView();

            //Get the number of staff for the loop
            /*int staffNumber = DatabaseConnection.getDatabaseConnectionInstance().GetIntValue(Constants.countStaff);
            for (int i = 0; i < staffNumber; i++)
            {
                string staffID = Convert.ToString(i);
                AddShiftToListView(staffID);
            }*/
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadlistView()
        {

            listView2.Items.Clear(); //clearing list view
            listView2.Columns.Add("Time");//adding list view

            DataSet dsStaffMember = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.SelectStaff);

            //get the table to be displayed from the data set
            DataTable dtStaff = dsStaffMember.Tables[0];

            //load the list view with data
            int max = DatabaseConnection.getDatabaseConnectionInstance().GetIntValue(Constants.countStaff);
            for (int i = 0; i < max; i++)
            {
                listView2.Columns.Add(dtStaff.Rows[i]["FirstName"].ToString(), 120);
            }

            for (int i = 8; i < 24; i++)
            {
                if (i < 10)
                {
                    listView2.Items.Add("0" + i + ":00");
                }
                else
                {
                    listView2.Items.Add(i + ":00");
                }
            }

            for (int index = 0; index < max; index++)
            {
                for (int i = 0; i < 16; i++)
                {
                    listView2.Items[i].SubItems.Add("Available");
                    //property to add colour
                    listView2.Items[i].UseItemStyleForSubItems = false;
                }

            }

        }

        private void AddShiftToListView(string StaffID)
        {

            string Date = dateTimePicker2.Text;

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
                            listView2.Items[0].SubItems[staffInt].Text = "Working";
                            listView2.Items[4].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "09:00:00":
                            listView2.Items[1].SubItems[staffInt].Text = "Working";
                            listView2.Items[1].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "10:00:00":
                            listView2.Items[2].SubItems[staffInt].Text = "Working";
                            listView2.Items[2].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "11:00:00":
                            listView2.Items[3].SubItems[staffInt].Text = "Working";
                            listView2.Items[3].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "12:00:00":
                            listView2.Items[4].SubItems[staffInt].Text = "Working";
                            listView2.Items[4].SubItems[staffInt].ForeColor = Color.Black;
                            break;
                        case "13:00:00":
                            listView2.Items[5].SubItems[staffInt].Text = "Working";
                            listView2.Items[5].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "14:00:00":
                            listView2.Items[6].SubItems[staffInt].Text = "Working";
                            listView2.Items[6].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "15:00:00":
                            listView2.Items[7].SubItems[staffInt].Text = "Working";
                            listView2.Items[7].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "16:00:00":
                            listView2.Items[8].SubItems[staffInt].Text = "Working";
                            listView2.Items[8].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "17:00:00":
                            listView2.Items[9].SubItems[staffInt].Text = "Working";
                            listView2.Items[9].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "18:00:00":
                            listView2.Items[10].SubItems[staffInt].Text = "Working";
                            listView2.Items[10].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "19:00:00":
                            listView2.Items[11].SubItems[staffInt].Text = "Working";
                            listView2.Items[11].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "20:00:00":
                            listView2.Items[12].SubItems[staffInt].Text = "Working";
                            listView2.Items[12].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "21:00:00":
                            listView2.Items[13].SubItems[staffInt].Text = "Working";
                            listView2.Items[13].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "22:00:00":
                            listView2.Items[14].SubItems[staffInt].Text = "Working";
                            listView2.Items[14].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        case "23:00:00":
                            listView2.Items[15].SubItems[staffInt].Text = "Working";
                            listView2.Items[15].SubItems[staffInt].ForeColor = Color.Black;

                            break;
                        default:
                            Console.WriteLine("No time found");
                            break;
                    }
                }

            }
        }

        private void StaffFOrm_Load(object sender, EventArgs e)
        {

        }



        private void StaffFOrm_Load_1(object sender, EventArgs e)
        {
             
        }

        private Button btnOnduty;
        private Button btnStaffAvailable;
        private DataGridView dataGridView2;
        private DateTimePicker dateTimePicker2;
        private ListView listView2;
        private Label lblDate;
        private Label lblStaffs;

        private void btnOnduty_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker2.Text;
            DataSet dsStaffMember = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.SelectShiftQuery(date));
            DataTable dtStaffMember = dsStaffMember.Tables[0];
        }

        private void btnStaffAvailable_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker2.Text;
            DataSet dsStaffMember = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.CheckStaffAvailability(date));
            DataTable dtStaffMember = dsStaffMember.Tables[0];
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
       
     

    

