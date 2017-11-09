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
                    string encryptedPassword = EncryptPassword(password);
                    string insert = "INSERT INTO Logins (Username, Password) VALUES ('" + userName + "'" + ", '" + encryptedPassword /*EncryptPassword(password)*/ + "')";

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
        public static string EncryptPassword(string password)
        {
            var sha512 = new SHA512CryptoServiceProvider();  // use var for readability with obvious type
            int saltLength = 64; // 64 bits to match length of sha512

            byte[] salt = GenSalt(saltLength); // Generate a 64 bit salt
            byte[] saltedPassword = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray(); // apply salt to password and store as byte array
            byte[] hash = sha512.ComputeHash(saltedPassword); // Get a 64 bit hash of the salted password

            //convert hash to string
            var stringBuilder = new StringBuilder();

            foreach (byte b in hash)
                stringBuilder.Append(b.ToString("x2"));
            string hashedPassword = stringBuilder.ToString();

            Console.WriteLine(hashedPassword.Length);

            return hashedPassword;
        }

        /// <summary>
        /// Generate a salt of a provided length
        /// salt generation source: https://codereview.stackexchange.com/a/93622
        /// from answer by Heslacher (Jun 15 2015)
        /// accessed 27/10/2017
        /// </summary>
        /// <param name="saltLength"></param>
        /// <returns>salt</returns>
        private static byte[] GenSalt(int saltLength)
        {
            var salt = new byte[saltLength];

            // Cryptographically secure pseudo-random number generator
            using (var csprng = new RNGCryptoServiceProvider())
            {
                csprng.GetNonZeroBytes(salt);
            }

            return salt;
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
