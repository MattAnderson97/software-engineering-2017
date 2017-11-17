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

        public static string SelectStaff = "SELECT * FROM StaffMember";
        public static string SelectStaffName = "SELECT Staff FROM StaffMember";
        public static String countStaff = "SELECT COUNT(StaffID) FROM StaffMember";
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

        #region Staff
        public static String GetStaffID(string FirstName, string LastName) //need working 
        {
            string StaffID = "SELECT StaffID FROM StaffMember WHERE FirstName='" + FirstName + "'";
            return StaffID;
        }
        public static String SpecificStaffMember(string StaffID, string date, string time)
        {
            Console.WriteLine(date + time);
            string selectStaffMember = "SELECT * FROM Shift WHERE StaffID='" + StaffID + "' AND StartDate='" + date + "' AND StartTime='" + time + "'";
            return selectStaffMember;
        }
        
        public static String SelectShiftQuery(string userInput)
        {
            string SelectShiftDate = "SELECT Shift.StaffID AS [Staff ID], StaffMember.FirstName AS [Name], StartTime AS [From], EndTime AS [To] FROM Shift INNER JOIN StaffMember ON Shift.StaffID = StaffMember.StaffID WHERE StartDate= '" + userInput + "'";
            return SelectShiftDate;
        }

        public static String CheckFreeQuery(string userInput)
        {
            string SelectShiftDate = "SELECT Shift.StaffID AS [Staff ID] , StaffMember.FirstName AS [Name], StaffMember.role AS [Role] FROM Shift INNER JOIN StaffMember ON Shift.StaffID = StaffMember.StaffID WHERE NOT Shift.StartDate= '" + userInput + "'";
            return SelectShiftDate;
        }

        public static String CheckStaffAvailability(string userInput)
        {
            string SelectAvailability = "SELECT StaffMember.StaffID AS [Staff ID], StaffMember.FirstName AS [Name], Shift.StartDate AS [Date], Shift.StartTime AS [From], Shift.EndTime AS [To] FROM StaffMember INNER JOIN Shift ON StaffMember.StaffID = StaffMember.StaffID WHERE Shift.StartDate= '" + userInput + "'";
            return SelectAvailability;
        }
        
        public static String AddShift(string StartDate, string StartTime, string EndTime, int StaffID, string AppointmentID)
        {
            string addShift = $"INSERT INTO Shift (startDate, startTime, endTime, staffID, appointmentID) VALUES('{StartDate} ', '{StartTime}', '{EndTime} ', '{StaffID}', '{AppointmentID}')";
            return addShift;
        }

        /*public static String DeleteShift(string AppointmentID)
        {
            string deleteShift = "DELETE FROM shift WHERE appointmentID = '" + AppointmentID + "'";
            return deleteShift;
        }*/
        
        public static String UpdateShift(string StartDate, string StartTime, string EndTime, int StaffID, string AppointmentID)
        {
            string updateShift = $"UPDATE shift SET startDate = '" + StartDate + "', startTime = '" + StartTime + "', EndTime = '" + EndTime + "', staffID = '" + StaffID + "' WHERE appointmentID ='" + AppointmentID + "'";
            return updateShift;
        }

        //count how many shifts a member of staff has in a specific day
        public static String Countshifts(string Date)
        {
            string countShifts = "SELECT COUNT(StaffID) FROM Shift WHERE StartDate= '" + Date + "'";
            return countShifts;
        }
        #endregion


    }
}
