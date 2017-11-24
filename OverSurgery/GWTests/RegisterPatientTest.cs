using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OverSurgery;

namespace GWTests
{
    [TestClass]
    public class RegisterPatientTest
    {
        /// <summary>
        /// Tests if the "Register" method returns false if no
        /// patient details are entered or there is data missing.
        /// </summary>
        [TestMethod]
        public void ReturnsErrorIfNoDataEntered()
        {
            // Creates an instance of the patient class.
            PatientManager testPatient = new PatientManager();

            // Creates an instance of the patient info struct.
            PatientManager.patientInfo testPatientInfo;

            // Assigns empty values to the struct properties.
            testPatientInfo.firstName = "";
            testPatientInfo.lastName = "";
            testPatientInfo.telephoneNumber = "";
            testPatientInfo.dateOfBirth = "";
            testPatientInfo.gender = "";
            testPatientInfo.address = "";

            // Checks if the "Register" method returns false.
            Assert.IsFalse(testPatient.Register(testPatientInfo));

            // Fills in one of the dat fields.
            testPatientInfo.firstName = "";
            testPatientInfo.lastName = "Test";
            testPatientInfo.telephoneNumber = "";
            testPatientInfo.dateOfBirth = "";
            testPatientInfo.gender = "";
            testPatientInfo.address = "";

            Assert.IsFalse(testPatient.Register(testPatientInfo));
        }

        [TestMethod]
        public void ReturnsErrorIfDataPartiallyEntered()
        {
            // Creates an instance of the patient class.
            PatientManager testPatient = new PatientManager();

            // Creates an instance of the patient info struct.
            PatientManager.patientInfo testPatientInfo;

            // Fills in one of the dat fields.
            testPatientInfo.firstName = "";
            testPatientInfo.lastName = "Test";
            testPatientInfo.telephoneNumber = "";
            testPatientInfo.dateOfBirth = "";
            testPatientInfo.gender = "";
            testPatientInfo.address = "";

            Assert.IsFalse(testPatient.Register(testPatientInfo));
        }
    }
}
