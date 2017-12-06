using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OverSurgery;

namespace UnitTests
{
    [TestClass]
    public class RegisterPatientTest
    {
        [TestMethod]
        public void ReturnsErrorMessageCodeIf_FieldsLeftBlank()
        {
            // Initializes a new PatientInfo class.
            PatientInfo patientInfo = new PatientInfo();

            // Assigns all the properties to empty.
            patientInfo.FirstName = "";
            patientInfo.LastName = "";
            patientInfo.TelephoneNumber = "";
            patientInfo.DateOfBirth = "";
            patientInfo.Gender = "";
            patientInfo.Address = "";

            // Asserts if "2" is returned which corresponds to an error message.
            Assert.IsTrue(PatientManager.GetPatientInstance.Register(patientInfo) == 2);
        }

        [TestMethod]
        public void ReturnsErrorMessageCodeIf_FieldsLeftPartiallyBlank()
        {
            // Initializes a new PatientInfo class.
            PatientInfo patientInfo = new PatientInfo();

            // Assigns some properties to empty.
            patientInfo.FirstName = "John";
            patientInfo.LastName = "Smith";
            patientInfo.TelephoneNumber = "";
            patientInfo.DateOfBirth = "";
            patientInfo.Gender = "Male";
            patientInfo.Address = "";

            // Asserts if "2" is returned which corresponds to an error message.
            Assert.IsTrue(PatientManager.GetPatientInstance.Register(patientInfo) == 2);
        }

        [TestMethod]
        public void ReturnsErrorMessageCodeIf_TelephoneNumberInvalid()
        {
            // Initializes a new PatientInfo class.
            PatientInfo patientInfo = new PatientInfo();

            // Assigns all the properties, but with invalid characters for "TelephoneNumber".
            patientInfo.FirstName = "John";
            patientInfo.LastName = "Smith";
            patientInfo.TelephoneNumber = "characters";
            patientInfo.DateOfBirth = "03/04/1964";
            patientInfo.Gender = "Male";
            patientInfo.Address = "12 Town Street";

            // Asserts if "3" is returned which corresponds to an error message.
            Assert.IsTrue(PatientManager.GetPatientInstance.Register(patientInfo) == 3);
        }

        [TestMethod]
        public void IsPatientManagerASingleton()
        {
            // Asserts if the instance of PatientManager is the same.
            Assert.AreSame(PatientManager.GetPatientInstance, PatientManager.GetPatientInstance);
        }

    }
}
