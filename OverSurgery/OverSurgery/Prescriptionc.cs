using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace OverSurgery

{
    #region Prescriptionc
    public sealed class Prescriptionc
    {
        #region Singleton

        static Prescriptionc instance = null;
        static readonly object myLock = new object();



        public static Prescriptionc Instance
        {
            get
            {
                lock (myLock)
                {
                    if (instance == null)
                    {
                        instance = new Prescriptionc();

                    }
                }
                return instance;
            }


        }

        #endregion

        #region Attributes
        private Patient activePatient;



        #endregion

        #region Properties
        public Patient ActivePatient
        {
            get { return activePatient; }
            set
            {
                activePatient = value;
                //PrescriptionInfor.UpdateActivePatientLabels();
                Prescriptionc.Instance.UpdatePrescriptionsDataGrid();

            }

        }


        #endregion

        #region Update Methods
        public void UpdatePrescriptionsDataGrid()//will add soon sam
        {
            if (ActivePatient != null)
            {
                //prescriptionsform.PrescriptionsGrid.DataSource = LoadPrescriptions().Tables[0];
            }
            else
            {
                //prescriptionsform.PrescriptionsGrid.DataSource = LoadPrescriptions().Tables[0];
            }

        }
        #endregion

        #region GetDataset Methods
        public DataSet LoadMedNameAndNotes(string medID)
        {

            string sql = @"SELECT MedName, Notes  FROM Meds WHERE Id = '" + medID + "'";

            return DatabaseConnection.getDatabaseConnectionInstance().getDataSet(sql);
        }


        //public Dataser needed for string name ...

        public DataSet LoadPrescriptions(string id)
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM PatientsMeds WHERE PatientID = '" + id + "' ";

            ds = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(sql);
            return ds;
        }

        public DataSet LoadPrescriptions()
        {
            DataSet ds = new DataSet();
            string sql = @"SELECT * FROM  PatientsMeds ";

            ds = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(sql);
            return ds;
        }
        public void ExtendPrescrption(string medID, string patientID, string extendDate)
        {

            DataSet ds = new DataSet();
            string sql = @"UPDATE PatientsMeds SET ExtentionDate = '" + extendDate + "' WHERE MedId = '" + medID + "' AND PatientID = '" + patientID + "'";

            ds = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(sql);

        }

        public void DeleteExtention(string medID, string patientId)
        {
            DataSet ds = new DataSet();
            string sql = @"UPDATE PatientsMeds SET ExtentionDate = NULL WHERE MedId = '" + medID + "' AND PatientID = '" + patientId + "'";


            ds = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(sql);
        }
        #endregion
    }
    #endregion
}
