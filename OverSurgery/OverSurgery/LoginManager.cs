using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool CreateUser(string userName, string password)
        {
            // If the details are not blank they will be added to the database.
            if (userName != "" && password != "")
            {
                // SQL statement to be given to the database.
                string insert = "INSERT INTO Logins (Username, Password) VALUES ('" + userName + "'" + ", '" + password /*EncryptPassword(password)*/ + "')";

                // Method call to DatabaseConnection class.
                DatabaseConnection.getDatabaseConnectionInstance().getDataSet(insert);

                // Returns true if details were successfully added.
                return true;
            }
            else
            {
                // Returns false if details were not successfully added.
                return false;
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
