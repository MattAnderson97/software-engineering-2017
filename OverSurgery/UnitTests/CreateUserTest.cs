using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OverSurgery;

namespace UnitTests
{
    [TestClass]
    public class CreateUserTest
    {
        [TestMethod]
        public void ReturnsErrorMessageCodeIf_UsernameAndPasswordBlank()
        {
            // Sets username and password to empty.
            string username = "";
            string password = "";

            // Asserts if "2" is returned which corresponds to an error message.
            Assert.IsTrue(LoginManager.GetLoginManagerInstance.CreateUser(username, password) == 2);
        }

        [TestMethod]
        public void ReturnsErrorMessageCodeIf_UsernameBlank()
        {
            // Sets username to empty and assigns password.
            string username = "";
            string password = "password";

            // Asserts if "2" is returned which corresponds to an error message.
            Assert.IsTrue(LoginManager.GetLoginManagerInstance.CreateUser(username, password) == 2);
        }

        [TestMethod]
        public void ReturnsErrorMessageCodeIf_PasswordBlank()
        {
            // Assigns username and sets password to empty.
            string username = "username";
            string password = "";

            // Asserts if "2" is returned which corresponds to an error message.
            Assert.IsTrue(LoginManager.GetLoginManagerInstance.CreateUser(username, password) == 2);
        }

        //Code adapted from:
        //Adolphe, R., (2016). Code with the Singleton pattern. [video online] Available at:
        //https://www.lynda.com/C-tutorials/Code-Singleton-pattern/473890/498782-4.html
        [TestMethod]
        public void IsLoginManagerASingleton()
        {
            // Asserts if the instance of LoginManager is the same.
            Assert.AreSame(LoginManager.GetLoginManagerInstance, LoginManager.GetLoginManagerInstance);
        }

    }
}

