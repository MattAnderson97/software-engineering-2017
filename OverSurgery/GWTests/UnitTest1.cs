using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OverSurgery;

namespace GWTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReturnsError_IfNo_DataEntered()
        {
            // Initializes empty username and password variables.
            string username = "";
            string password = "";

            // Creates an instance of the LoginManager class.
            LoginManager TestLoginManager = new LoginManager();

            // Checks if the method returned the correct error code to the form.
            // Username and password empty.
            Assert.IsTrue(TestLoginManager.CreateUser(username, password) == 2);

            // Only password is empty.
            username = "User";
            Assert.IsTrue(TestLoginManager.CreateUser(username, password) == 2);

            // Only username is empty.
            username = "";
            password = "password";
            Assert.IsTrue(TestLoginManager.CreateUser(username, password) == 2);

        }
    }
}
