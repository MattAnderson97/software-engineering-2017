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
    public partial class prescriptionsform : Form
    {
        public prescriptionsform()
        {
            InitializeComponent();
        }
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
        private void prescriptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}