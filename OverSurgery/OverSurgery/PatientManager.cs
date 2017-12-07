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

        // Instantiates a read-only object to use as a lock for the singleton.
        private static readonly object _lock = new object();

        // Declares an instance of the patient class.
        private static PatientManager _instance;
        
        // Ensures only one instance of the class can be instantiated.
        public static PatientManager GetPatientManagerInstance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PatientManager();
                    }

                    return _instance;
                }
            }
        }
        #endregion

        #region METHODS

        /// <summary>
        /// Adds patient details to the database if none of the data entry fields are empty.
        /// </summary>
        /// <param name="patientDetails">patientInfo object.</param>
        /// <returns>Bool for whether the details were added or not.</returns>
        public int Register(PatientInfo patientInfo)
        {
            // Puts each variable from the object into an array element.
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

            // Uses a regular expression to make sure the telephone number string only has digits.
            // Code snipped adapted from Dot Net Perls, avaialble at: https://www.dotnetperls.com/regex
            // Accessed 24 November 2017
            Regex telNumRegex = new Regex(@"\d+");
            Match telNumMatch = telNumRegex.Match(patientInfo.TelephoneNumber);

            // If more than 0 of the fields are empty the method returns false and,
            // the form will display an error message. Else, the details are addded
            // to the database.
            if (emptyFields > 0)
            {
                return 2;
            }
            else if (!telNumMatch.Success) //If the string contains invalid characters an error is returned.
            {
                return 3;
            }
            else
            {
                // Calls the InsertToDatabase method.
                InsertToDatabase(patientInfo);
                return 1;
            }
        }

        /// <summary>
        /// Connects to the DatabaseConnection class and tells it to use an
        /// SQL command on the database.
        /// </summary>
        /// <param name="patientDetails">patientInfo object</param>
        public void InsertToDatabase(PatientInfo patientInfo)
        {
            // Inserts patient details into the database.
            DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.RegisterPatient(patientInfo));            
        }
        #endregion

        #region CONSTRUCTORS

        public PatientManager()
        {

        }
        #endregion
    }
}
