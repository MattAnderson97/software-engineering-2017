using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverSurgery
{
    class Constants
    {
        #region DEBUG
        public static string selectAll = "SELECT * FROM StaffMember";

        public static string selectAll2 = "SELECT * FROM Appointment";
        #endregion

        #region LoginManager
        /// <summary>
        /// Gets SQL statement to insert chosen username and password to the database.
        /// </summary>
        /// <param name="userName">Chosen username.</param>
        /// <param name="encryptedPassword">Chosen encrypted password.</param>
        /// <returns>SQL statement.</returns>
        public static string CreateUser(string userName, string encryptedPassword)
        {
            return String.Format("INSERT INTO Logins (Username, Password) VALUES ('{0}', '{1}')", userName, encryptedPassword);
        }

        /// <summary>
        /// Gets SQL statement to search for a username already in use.
        /// </summary>
        /// <param name="userName">Chosen username.</param>
        /// <returns>SQL statement.</returns>
        public static string CheckExistingUsername(string userName)
        {
            return String.Format("SELECT * FROM Logins WHERE Username = '{0}'", userName);
        }

        /// <summary>
        /// Get SQL statement to search for matching username and password.
        /// </summary>
        /// <param name="userName">Given username.</param>
        /// <param name="encryptedPassword">Given encrypted password.</param>
        /// <returns>SQL statement.</returns>
        public static string ValidateCredentials(string userName, string encryptedPassword)
        {
            return String.Format("SELECT * FROM Logins WHERE Username = '{0}' AND Password = '{1}'", userName, encryptedPassword);
        }
        #endregion

        #region Patient

        /// <summary>
        /// Inserts patient details into the database.
        /// </summary>
        /// <param name="patientDetails">Struct containg patient details.</param>
        /// <returns>SQL statement.</returns>
        public static string RegisterPatient(Patient.patientInfo patientDetails)
        {
            return String.Format(@"INSERT INTO Patient (FirstName, LastName, TelephoneNumber, DateOfBirth, Gender, Address)
                             VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", patientDetails.firstName, patientDetails.lastName, patientDetails.telephoneNumber,
                             patientDetails.dateOfBirth, patientDetails.gender, patientDetails.address);
        }
        #endregion

        #region GetApptTime
        /// <summary>
        /// Gets SQL statement to search for all appointments on a given date.
        /// </summary>
        /// <param name="chosenDate">Chosen date.</param>
        /// <returns>SQL statement.</returns>
        public static string SelectAllDates(string chosenDate)
        {
            return String.Format("SELECT DISTINCT Time FROM Appointment WHERE Date = '{0}'", chosenDate);
        }

        /// <summary>
        /// Gets SQL Statement to search for all appointments at a given date and time.
        /// </summary>
        /// <param name="chosenDate">Chosen date.</param>
        /// <param name="listValue">Current value in the list.</param>
        /// <returns>SQL statement.</returns>
        public static string GetAppointmentsAtGivenTime(string chosenDate, string listValue)
        {
            return String.Format("SELECT * FROM Appointment WHERE Date = '{0}' AND Time = '{1}'", chosenDate, listValue);
        }

        /// <summary>
        /// Gets SQL statement to search for all staff members.
        /// </summary>
        /// <returns>SQL statement.</returns>
        public static string GetStaffMembers()
        {
            return "SELECT * FROM StaffMember";
        }
        #endregion

        #region GetApptStaff
        /// <summary>
        /// SQL statement to search for all staff members.
        /// </summary>
        /// <returns>SQL statement.</returns>
        public static string GetAllStaff()
        {
            return String.Format("SELECT * FROM StaffMember");
        }

        /// <summary>
        /// SQL statement to get all appointments at a given date and time.
        /// </summary>
        /// <param name="chosenDate">Chosen appointment date.</param>
        /// <param name="chosenTime">Chosen appointment time.</param>
        /// <returns>SQL statement.</returns>
        public static string GetBookedStaff(string chosenDate, string chosenTime)
        {
            return String.Format("SELECT * FROM Appointment WHERE Date = '{0}' AND Time = '{1}'", chosenDate, chosenTime);
        }

        /// <summary>
        /// SQL statement to find a staff member using a staff id.
        /// </summary>
        /// <param name="StaffID">ID number of the staff member.</param>
        /// <returns>SQL statement.</returns>
        public static string GetApptStaffMember(string StaffID)
        {
            return String.Format("SELECT * FROM StaffMember WHERE StaffID = '{0}'", StaffID);
        }
        #endregion

        #region AddAppointment

        public static string GetStaffMemberName(string StaffID)
        {
            return String.Format("SELECT FirstName, LastName FROM StaffMember WHERE StaffID = '{0}'", StaffID);
        }

        public static string InsertAppointment(AppointmentInfo appointmentInfo)
        {
            return String.Format(@"INSERT INTO Appointment (Type, Date, Time, StaffID_Fk, PatientID_Fk) 
                                VALUES ('GP Appointment', '{0}', '{1}', '{2}', '{3}')", appointmentInfo.Date, appointmentInfo.Time, 
                                appointmentInfo.StaffID, appointmentInfo.PatientID);
        }
        #endregion

    }
}
