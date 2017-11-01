using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace OverSurgery
{
    class LoginManager
    {
        #region PROPERTIES
        // Declares instance of the LoginManager class.
        public static LoginManager _instance;
        #endregion

        #region METHODS

        /// <summary>
        /// Creates an instance of the LoginManager class.
        /// </summary>
        /// <returns>Instance of the LoginManager class.</returns>
        public static LoginManager GetLoginManagerInstance()
        {
            if (_instance == null)
                _instance = new LoginManager();
            return _instance;
        }

        /// <summary>
        /// Checks if the supllied user details are valid then adds those details to the database.
        /// </summary>
        /// <param name="userName">User's chosen username.</param>
        /// <param name="password">User's chosen password.</param>
        /// <returns>Number corresponding to error message type.</returns>
        public int CreateUser(string userName, string password)
        {
            // If the details are not blank they will be added to the database.
            if (userName != "" && password != "")
            {
                // If the username is unique the details will be added to the database.
                if(CheckExistingUsername(userName) == true)
                {
                    // SQL statement to be given to the database.
                    string insert = "INSERT INTO Logins (Username, Password) VALUES ('" + userName + "'" + ", '" + password /*EncryptPassword(password)*/ + "')";

                    // Method call to DatabaseConnection class.
                    DatabaseConnection.getDatabaseConnectionInstance().getDataSet(insert);

                    // Returns 1 (User account created successfully).
                    return 1;
                }
                else
                {
                    // Returns 3 (Chosen username already taken).
                    return 3;
                }
                
            }
            else
            {
                // Returns 2 (Username and Password fields left empty).
                return 2;
            }          
        }

        /// <summary>
        /// Checks if a username already exists in the system.
        /// </summary>
        /// <param name="userName">User's chosen username.</param>
        /// <returns>True or false depending if the username was unique.</returns>
        public bool CheckExistingUsername(string userName)
        {
            // SQL statement to find all records in the Logins table with a particular username.
            string checkUsername = "SELECT * FROM Logins WHERE Username='" + userName + "'";

            // Gets a DataSet from the DatabaseConnection class.
            DataSet dsLogins = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(checkUsername);

            // Counts the number of rows in the DataSet.
            int sameUsernames = dsLogins.Tables[0].Rows.Count;

            // If the number of rows is more than 0 the method returns false.
            if (sameUsernames > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Sam
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void Login(string userName, string password)
        {
            if (ValidateCredentials(userName, EncryptPassword(password)))
            {
                // ...
            }
        }

        /// <summary>
        /// Matt
        /// </summary>
        /// <param name="password"></param>
        public string EncryptPassword(string password)
        {
            return "";
        }

        /// <summary>
        /// Tanaka
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateCredentials(string userName, string encryptedPassword)
        {
            // check parameters with stored data in DB
            return true;
        }
        #endregion
    }
}
