using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OverSurgery
{
    class LoginManager
    {
        /// <summary>
        /// George
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void CreateUser(string userName, string password)
        {

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

            // byte[] salt = GenSalt(saltLength); // Generate a 64 bit salt
            byte[] saltedPassword = Encoding.UTF8.GetBytes(password);//.Concat(salt).ToArray(); // apply salt to password and store as byte array
            byte[] hash = sha512.ComputeHash(saltedPassword); // Get a 64 bit hash of the salted password

            //convert hash to string
            var stringBuilder = new StringBuilder();

            foreach (byte b in hash)
                stringBuilder.Append(b.ToString("x2"));
            string hashedPassword = stringBuilder.ToString();

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
    }
}
