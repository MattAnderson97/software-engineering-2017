using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OverSurgery
{
    public class PrescriptionManager
    {

        #region PROPERTIES
        // Declares an instance of the prescription class
        private static PrescriptionManager _instance;
        // Instantiates a read-only object to use as a lock for the singleton.
        private static readonly object _lock = new object();
        // Ensures one instance of the class can be instantiated.
        public static PrescriptionManager GetPrescriptionManagerInstance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PrescriptionManager();
                    }

                    return _instance;
                }
            }
        }
        public PrescriptionManager()
        {

        }
        #endregion

        #region METHODS

        /// <summary>
        /// adds tot he database details when none of the fields are empty
        /// </summary>
        /// <param name="extendPrescriptionDetails">prescription object.</param>
        /// <returns>Bool</returns>
        public int Extend(Prescription prescription)
        {
            // insert each of the variable from the object into an array element
            string[] checkEmptyArray = new string[4];
            checkEmptyArray[0] = prescription.MedicineName;
            checkEmptyArray[1] = prescription.Length;
            checkEmptyArray[2] = prescription.ExtentionDate;
            checkEmptyArray[3] = prescription.Note;

            // Assigns a variable for the number of empty data entry fields.
            int emptyFields = 0;

            for (int i = 0; i < 3; i++)//check for empty string
            {
                if (checkEmptyArray[i] == "")
                {
                    emptyFields++;
                }
            }

            if (emptyFields > 0)//if fields are empty it returm erroe message if not enter details to database
            {
                return 2;
            }
            else
            {
                InsertToDatabase(prescription);//inserts to database
                return 1;
            }
        }
        //insert entered detaits into database 
        private void InsertToDatabase(Prescription prescription)
        {
            
            DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.ExtendPrescription(prescription));
        }
        #endregion


    }
}

