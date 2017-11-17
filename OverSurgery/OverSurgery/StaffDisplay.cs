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
    public partial class StaffFOrm : Form
    {
        private Button btnOnDuty;
        private Button btnStaffAvailible;
        private Label lblStaff;
        private Label lblDate;
        private DataGridView dataGridView1;
        private ListView listView1;
        private DateTimePicker dateTimePicker1;

        public StaffFOrm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeComponent()
        {

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
                            listView1.Items[4].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "09:00:00":
                            listView1.Items[1].SubItems[staffInt].Text = "Working";
                            listView1.Items[1].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "10:00:00":
                            listView1.Items[2].SubItems[staffInt].Text = "Working";
                            listView1.Items[2].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "11:00:00":
                            listView1.Items[3].SubItems[staffInt].Text = "Working";
                            listView1.Items[3].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "12:00:00":
                            listView1.Items[4].SubItems[staffInt].Text = "Working";
                            listView1.Items[4].SubItems[staffInt].ForeColor = Color.Green;
                            break;
                        case "13:00:00":
                            listView1.Items[5].SubItems[staffInt].Text = "Working";
                            listView1.Items[5].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "14:00:00":
                            listView1.Items[6].SubItems[staffInt].Text = "Working";
                            listView1.Items[6].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "15:00:00":
                            listView1.Items[7].SubItems[staffInt].Text = "Working";
                            listView1.Items[7].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "16:00:00":
                            listView1.Items[8].SubItems[staffInt].Text = "Working";
                            listView1.Items[8].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "17:00:00":
                            listView1.Items[9].SubItems[staffInt].Text = "Working";
                            listView1.Items[9].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "18:00:00":
                            listView1.Items[10].SubItems[staffInt].Text = "Working";
                            listView1.Items[10].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "19:00:00":
                            listView1.Items[11].SubItems[staffInt].Text = "Working";
                            listView1.Items[11].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "20:00:00":
                            listView1.Items[12].SubItems[staffInt].Text = "Working";
                            listView1.Items[12].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "21:00:00":
                            listView1.Items[13].SubItems[staffInt].Text = "Working";
                            listView1.Items[13].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "22:00:00":
                            listView1.Items[14].SubItems[staffInt].Text = "Working";
                            listView1.Items[14].SubItems[staffInt].ForeColor = Color.Green;

                            break;
                        case "23:00:00":
                            listView1.Items[15].SubItems[staffInt].Text = "Working";
                            listView1.Items[15].SubItems[staffInt].ForeColor = Color.Green;

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

        private void btnStaff_Available_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Text;
            DataSet dsStaffMember = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.CheckStaffAvailability(date));
            DataTable dtStaffMember = dsStaffMember.Tables[0];
        }

        private void btn_OnDuty_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Text;
            DataSet dsStaffMember = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.SelectShiftQuery(date));
            DataTable dtStaffMember = dsStaffMember.Tables[0];
        }
    }
}
       
     

    

