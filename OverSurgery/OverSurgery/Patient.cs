using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverSurgery
{
    class Patient
    {
        #region PROPERTIES
        // Declares an instance of the patient class.
        public static Patient _instance;

        public struct patientInfo
        {
            public string firstName;
            public string lastName;
            public string telephoneNumber;
            public string dateOfBirth;
            public string gender;         
            public string address;
        }
        #endregion

        #region METHODS

        /// <summary>
        /// Creates an instance of the Patient class.
        /// </summary>
        /// <returns>Instance of the Patient class.</returns>
        public static Patient GetPatientInstance()
        {
            if (_instance == null)
                _instance = new Patient();
            return _instance;
        }

        #endregion

        /// <summary>
        /// Adds patient details to the database if none of the data entry fields are empty.
        /// </summary>
        /// <param name="patientDetails">patient Details struct</param>
        /// <returns>Bool for whether the details were added or not.</returns>
        public bool Register(patientInfo patientDetails)
        {
            // Puts each variable from the struct into an array element.
            string[] checkEmptyArray = new string[6];
            checkEmptyArray[0] = patientDetails.firstName;
            checkEmptyArray[1] = patientDetails.lastName;
            checkEmptyArray[2] = patientDetails.telephoneNumber;
            checkEmptyArray[3] = patientDetails.dateOfBirth;
            checkEmptyArray[4] = patientDetails.gender;          
            checkEmptyArray[5] = patientDetails.address;

            // Assigns a variable for the number of empty data entry fields.
            int emptyFields = 0;
            
            // Loops through the array elements checking if any of the strings are empty,
            // adding them to the counter variable if they are.
            for(int i =0; i < 5; i++)
            {               
                if(checkEmptyArray[i] == "")
                {
                    emptyFields++;
                }
            }

            // If more than 0 of the fields are empty the method returns false and,
            // the form will display an error message. Else, the details are addded
            // to the database.
            if (emptyFields > 0)
            {
                return false;
            }
            else
            {
                // Calls the InsertToDatabase method.
                InsertToDatabase(patientDetails);
                return true;
            }
        }

        /// <summary>
        /// Connects to the DatabaseConnection class and tells it to use an
        /// SQL command on the database.
        /// </summary>
        /// <param name="patientDetails">patientDetails struct</param>
        public void InsertToDatabase(patientInfo patientDetails)
        {
            // Holds the SQL insert command.
            string insert = String.Format(@"INSERT INTO Patient (FirstName, LastName, TelephoneNumber, DateOfBirth, Gender, Address)
                             VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", patientDetails.firstName, patientDetails.lastName, patientDetails.telephoneNumber,
                             patientDetails.dateOfBirth, patientDetails.gender, patientDetails.address);

            // Gives the SQL command to the data set.
            DatabaseConnection.getDatabaseConnectionInstance().getDataSet(insert);            
        }

        public void SearchByID()
        {

        }

        public void SearchByNameDOB()
        {

        }

        public void SearchByNameAddress()
        {

        }

        public void FindSearchType()
        {

        }
    }
}
