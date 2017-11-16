using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OverSurgery
{
    class AddAppointment
    {
        #region PROPERTIES
        // Declares an instance of the AddAppointment class.
        private static AddAppointment _instance;
        #endregion

        #region METHODS
        /// <summary>
        /// Creates an instance of the AddAppointment class.
        /// </summary>
        /// <returns>Instance of the AddAppointment class.</returns>
        public static AddAppointment GetAddAppointmentInstance()
        {
            if (_instance == null)
                _instance = new AddAppointment();

            return _instance;
        }

        /// <summary>
        /// Returns a list of possible booking times from the GetApptTime class.
        /// </summary>
        /// <param name="chosenDate"></param>
        /// <returns>List of possible booking times.</returns>
        public List<string> GetAppointmentTimes(string chosenDate)
        {
            return GetApptTime.GetGetApptTimeInstance().FindChosenDate(chosenDate);
        }

        /// <summary>
        /// Returns a list of staff members available for an appointment 
        /// at a given time and date.
        /// </summary>
        /// <param name="chosenDate">Chosen date of appointment.</param>
        /// <param name="chosenTime">Chosen time of appointment.</param>
        /// <returns>List containg the names of available staff members.</returns>
        public List<string> GetAppointmentStaff(string chosenDate, string chosenTime)
        {
            // Create an instance of the GetApptStaff class.
            GetApptStaff staffList = new GetApptStaff();

            return staffList.GetAvailableStaffNameList(chosenDate, chosenTime);
        }

        #endregion

        #region CONSTRUCTORS
        #endregion
    }
}
