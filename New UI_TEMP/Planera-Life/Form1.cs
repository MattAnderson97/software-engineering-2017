using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planera_Life
{
    public partial class Form1 : Form
    {
        private static FileDelegate FileHandler;
        private static event FileDelegate QuerySubmited;

        public Form1()
        {
            InitializeComponent();
        }

        private void pnl_Display_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lst_DatabaseTables.Items.Add("...");
            lst_DatabaseQueries.Items.Add("...");
            lst_Users.Items.Add("...");

            Program.Tables = new List<DataTable>();

            DataTable _EmptyTable = new DataTable("Empty Table");
            Program.Tables = new List<DataTable>();
            Program.Tables.Add(_EmptyTable);

            Query _EmptyQuery = new Query("Empty Query", "...");
            Program.Queries = new List<Query>();
            Program.Queries.Add(_EmptyQuery);

            User Admin = new User();
            Program.Users = new List<User>();
            Program.Users.Add(Admin);
        }

        private void btn_NewQuery_Click(object sender, EventArgs e)
        {

            try
            {
                NewQueryDialogueBox QueryEditor = new NewQueryDialogueBox();
                QueryEditor.Show();
            }

            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Application Error!");
            }
     
        }

        private void btn_EditQuery_Click(object sender, EventArgs e)
        {
            NewQueryDialogueBox QueryEditor = new NewQueryDialogueBox();
            QueryEditor.ShowDialog();
        }

        private void btn_SubmitQuery_Click(object sender, EventArgs e)
        {
            if (lst_DatabaseQueries!=null)
            {
                try
                {
                    Session SubmitQuery = new Session();
                    DataTable Results = new DataTable();
                    
                    //Submit query
                    Results = SubmitQuery.ExecuteQuery(Program.Queries[lst_DatabaseQueries.SelectedIndex]);

                    //Update results
                    Tables.SelectedIndex = 4;
                    dgv_QueryResults.DataSource = Results;
                    Program.QueryResults = Results;
                }

                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "Application Error!");
                }
            }
        }

        private void printResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_PrintQuery_Click(object sender, EventArgs e)
        {
            try
            {
                FileExportDialogue FileExport = new FileExportDialogue();

                if (FileExport.ShowDialog() != DialogResult.Cancel)
                {
                    //If successful
                    TabControl.SelectedIndex = 2;
                }

                else
                {
                    //if cancelled

                }
            }

            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Application Error!");
            }
        }

        private void Tab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Sync()
        {
            try
            {

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Application Error!");
            }
            //Update list of Tables
            lst_DatabaseTables.Items.Clear();
            foreach (DataTable Table in Program.Tables)
            {
                lst_DatabaseTables.Items.Add(Table.TableName);
            }

            //Update list of queries
            lst_DatabaseQueries.Items.Clear();
            foreach (Query Query in Program.Queries)
            {
                lst_DatabaseQueries.Items.Add(Query.Title);
            }

            //Update list of users
            lst_Users.Items.Clear();
            foreach (User User in Program.Users)
            {
                lst_DatabaseQueries.Items.Add(User.Name);
            }
        }
    }
}
