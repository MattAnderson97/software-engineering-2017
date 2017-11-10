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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet dsPatient = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.selectAll);

            // Get the table to be displayed from the data set.
            DataTable dtPatient = dsPatient.Tables[0];

            // Set the data source for the data grid view.
            dgvPatient.DataSource = dtPatient;
        }
    }
}
