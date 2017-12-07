using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OverSurgery;

namespace UnitTests
{
    [TestClass]
    public class AddAppointmentTest
    {
        [TestMethod]
        public void ReturnsErrorMessageCodeIf_PatientIDLeftEmpty()
        {
            // Creates a new instance of AppointmentInfo
            AppointmentInfo appointmentInfo = new AppointmentInfo();

            // Assigns all fields but PatientID is null.
            appointmentInfo.PatientID = null;
            appointmentInfo.Date = "06/12/2017";
            appointmentInfo.Time = "16:10";
            appointmentInfo.StaffID = "1";

            // Asserts if "1" is returned which corresponds to an error message.
            Assert.IsTrue(AppointmentManager.GetAppointmentManagerInstance.AddAppointment(appointmentInfo) == 1);
        }

        [TestMethod]
        public void ReturnsErrorMessageCodeIf_TimeLeftEmpty()
        {
            // Creates a new instance of AppointmentInfo
            AppointmentInfo appointmentInfo = new AppointmentInfo();

            // Assigns all fields but Time is null.
            appointmentInfo.PatientID = "1";
            appointmentInfo.Date = "06/12/2017";
            appointmentInfo.Time = null;
            appointmentInfo.StaffID = "1";

            // Asserts if "3" is returned which corresponds to an error message.
            Assert.IsTrue(AppointmentManager.GetAppointmentManagerInstance.AddAppointment(appointmentInfo) == 3);
        }

        [TestMethod]
        public void ReturnsErrorMessageCodeIf_StaffIDLeftEmpty()
        {
            // Creates a new instance of AppointmentInfo
            AppointmentInfo appointmentInfo = new AppointmentInfo();

            // Assigns all fields as null.
            appointmentInfo.PatientID = "1";
            appointmentInfo.Date = "06/12/2017";
            appointmentInfo.Time = "16:10";
            appointmentInfo.StaffID = null;

            // Asserts if "4" is returned which corresponds to an error message.
            Assert.IsTrue(AppointmentManager.GetAppointmentManagerInstance.AddAppointment(appointmentInfo) == 4);
        }

        [TestMethod]
        public void IsPatientManagerASingleton()
        {
            // Asserts if the instance of AppointmentManager is the same.
            Assert.AreSame(AppointmentManager.GetAppointmentManagerInstance, AppointmentManager.GetAppointmentManagerInstance);
        }
    }
}
