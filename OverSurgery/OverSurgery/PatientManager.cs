using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OverSurgery
{
    public class PatientManager
    {
        #region PROPERTIES
        // Declares an instance of the patient class.
        public static PatientManager _instance;
        #endregion

        #region METHODS

        /// <summary>
        /// Creates an instance of the Patient class.
        /// </summary>
        /// <returns>Instance of the Patient class.</returns>
        public static PatientManager GetPatientInstance()
        {
            if (_instance == null)
                _instance = new PatientManager();
            return _instance;
        }

        #endregion

        /// <summary>
        /// Adds patient details to the database if none of the data entry fields are empty.
        /// </summary>
        /// <param name="patientDetails">patient Details struct</param>
        /// <returns>Bool for whether the details were added or not.</returns>
        public bool Register(PatientInfo patientInfo)
        {
            // Puts each variable from the struct into an array element.
            string[] checkEmptyArray = new string[6];
            checkEmptyArray[0] = patientInfo.FirstName;
            checkEmptyArray[1] = patientInfo.LastName;
            checkEmptyArray[2] = patientInfo.TelephoneNumber;
            checkEmptyArray[3] = patientInfo.DateOfBirth;
            checkEmptyArray[4] = patientInfo.Gender;
            checkEmptyArray[5] = patientInfo.Address;

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

            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(patientInfo.TelephoneNumber);

            // If more than 0 of the fields are empty the method returns false and,
            // the form will display an error message. Else, the details are addded
            // to the database.
            if (emptyFields > 0 || !match.Success)
            {
                return false;
            }
            else
            {
                // Calls the InsertToDatabase method.
                InsertToDatabase(patientInfo);
                return true;
            }
        }

        /// <summary>
        /// Connects to the DatabaseConnection class and tells it to use an
        /// SQL command on the database.
        /// </summary>
        /// <param name="patientDetails">patientDetails struct</param>
        public void InsertToDatabase(PatientInfo patientInfo)
        {
            // Inserts patient details into the database.
            DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.RegisterPatient(patientInfo));            
        }
    }
}
