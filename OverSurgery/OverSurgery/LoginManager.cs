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
        /// George
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void CreateUser(string userName, string password)
        {
            string insert = "INSERT INTO Logins (Username, Password) VALUES ('" + userName + "'" + ", '" + password /*EncryptPassword(password)*/ + "')";
            DatabaseConnection.getDatabaseConnectionInstance().getDataSet(insert);
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
