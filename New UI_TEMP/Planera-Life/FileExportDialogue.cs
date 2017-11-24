using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Planera_Life
{
    public partial class FileExportDialogue : Form
    {
        private static DataTable Table;
        public FileExportDialogue()
        {
            InitializeComponent();
            try
            {
                //Set form properties
                this.Text = Table.TableName;
                Table = Program.QueryResults;
                DataGridView.DataSource = Table;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Application Error!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cmbx_FileType.Text)
                {
                    case "CSV file (*.txt)":
                        SaveTableAsCSV();
                        break;

                    case "Access Database File(*.accdb)":
                        SaveTableAsAccessDB();
                        break;
                }
            }

            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Application Error!");
            }
            
            this.Close();
        }

        private void btn_SelectDestination_Click(object sender, EventArgs E)
        {
            switch (cmbx_FileType.Text)
            {
                case "CSV file (*.txt)":
                    try
                    {
                        SaveFileDialog SaveFileDialog = new SaveFileDialog();
                        SaveFileDialog.Filter = "CSV file (*.txt)|*.txt|All files (*.*)|*.*";
                        SaveFileDialog.FilterIndex = 2;
                        SaveFileDialog.RestoreDirectory = true;

                        if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string Directory = "--log=\"" + SaveFileDialog.FileName + "\"";
                            txt_Destination.Text = Directory;
                        }
                    }

                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Application Error!");
                    }

                    break;

                case "Access Database File(*.accdb)":
                    try
                    {
                        SaveFileDialog SaveFileDialog = new SaveFileDialog();
                        SaveFileDialog.Filter = "Access Database File (*.accdb)|*.accdb|All files (*.*)|*.*";
                        SaveFileDialog.FilterIndex = 2;
                        SaveFileDialog.RestoreDirectory = true;

                        if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string Directory = "--log=\"" + SaveFileDialog.FileName + "\"";
                            txt_Destination.Text = Directory;
                        }
                    }

                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Application Error!");
                    }

                    break;
            }
        }

        private void SaveTableAsCSV()
        {
            StreamWriter Writer = new StreamWriter(txt_Destination.Text);
            Table _Table = new Table(Table.TableName, 3);
            string Header = "[INDEX] [TITLE] [VALUE]";
            _Table.Set(Table);

            try
            {
                //Write Header
                Writer.WriteLine(Header);
                for (int i = 0; i <= _Table.Rows.Count; i++)
                {
                    //Add row
                    string Row = _Table.Rows[i][0] + ", " + _Table.Rows[i][1] + ", " + _Table.Rows[i][2];
                    Writer.WriteLine(Row);
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Application Error!");
            }
        }

        private void SaveTableAsAccessDB()
        {

        }

        private void PrintTable()
        {

        }
    }
}
