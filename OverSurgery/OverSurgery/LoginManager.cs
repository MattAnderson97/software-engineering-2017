using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace OverSurgery
{
    public class LoginManager
    {
        #region PROPERTIES

        // Instantiates a read-only object to use as a lock for the singleton.
        private static readonly object _lock = new object();

        // Declares instance of the LoginManager class.
        private static LoginManager _instance;

        // Ensures only one instance of the class can be instantiated.
        public static LoginManager GetLoginManagerInstance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoginManager();
                    }

                    return _instance;
                }
            }
        }
        #endregion

        #region METHODS

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
                    // Encrypts the password.
                    string encryptedPassword = EncryptPassword(password);

                    Console.WriteLine(encryptedPassword);

                    // Inserts the user details into the database.
                    DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.CreateUser(userName, encryptedPassword));

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
            // Finds all records in the Logins table with a particular username.
            DataSet dsLogins = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.CheckExistingUsername(userName));

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
        public bool Login(string userName, string password)
        {//
            if (ValidateCredentials(userName, EncryptPassword(password)) == true)
            {
                /*DataTable dttable = new DataTable();
                string SQL = "SELECT FROM Login where userName ='" + userName + "' AND Password ='" + password + "'";
                SqlDataAdapter Consultantdataadapter = new SqlDataAdapter();
                Consultantdataadapter.Fill(dttable);
                foreach (DataRow myrow in consultanttable.Rows)
                    if (DataTable.Rows.Count > 0)
                    {

                    }*/
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Matt
        /// </summary>
        /// <param name="password"></param>
        public static string EncryptPassword(string password)
        {
            var sha512 = new SHA512CryptoServiceProvider();  // use var for readability with obvious type

            // byte[] salt = GenSalt(saltLength); // Generate a 64 bit salt
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password).ToArray(); // apply salt to password and store as byte array
            byte[] hash = sha512.ComputeHash(passwordBytes); // Get a 64 bit hash of the salted password

            //convert hash to string
            var stringBuilder = new StringBuilder();

            foreach (byte b in hash)
                stringBuilder.Append(b.ToString("x2"));
            string hashedPassword = stringBuilder.ToString();

            Console.WriteLine(hashedPassword.Length);

            return hashedPassword;
        }
        
        /// <summary>
        /// Checks the database to see if the user details are a match.
        /// </summary>
        /// <param name="userName">Given username.</param>
        /// <param name="password">Given password.</param>
        /// <returns>Bool representing whether the user can log in or not.</returns>
        public bool ValidateCredentials(string userName, string encryptedPassword)
       {
            // Checks the database to see whether the username and password supplied by the user 
            // matches a record in the database.
            DataSet dsLogins = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.ValidateCredentials(userName, encryptedPassword));

            // Counts the number of matching logins.
            int matchingLogins = dsLogins.Tables[0].Rows.Count;

            // If the number of matching logins is equal to 1 the user can log in.
            if (matchingLogins == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region CONSTRUCTORS

        public LoginManager()
        {

        }
        #endregion
    }
}
