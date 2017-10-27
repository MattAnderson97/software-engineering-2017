using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverSurgery
{
    class LoginManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void CreateUser(string userName, string password)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void Login(string userName, string password)
        {
            if (CheckLoginDetails(userName, EncryptPassword(password)))
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
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckLoginDetails(string userName, string encryptedPassword)
        {
            // check parameters with stored data in DB
            return true;
        }
    }
}
