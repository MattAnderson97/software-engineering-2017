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



        [TestMethod]
        public void IsLoginManagerASingleton()
        {
            // Asserts if the instance of LoginManager is the same.
            Assert.AreSame(LoginManager.GetLoginManagerInstance, LoginManager.GetLoginManagerInstance);
        }

    }
}

