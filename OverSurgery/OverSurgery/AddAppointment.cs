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

        // Instantiates a read-only object to use as a lock for the singleton.
        private static readonly object _lock = new object();

        // Ensures only one instance of the class can be instantiated.
        public static AddAppointment GetAddAppointmentInstance
        {
            get
            {
                lock (_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new AddAppointment();
                    }

                    return _instance;
                }
            }
        }
        #endregion

        #region METHODS

        /// <summary>
        /// Returns a list of possible booking times from the GetApptTime class.
        /// </summary>
        /// <param name="chosenDate"></param>
        /// <returns>List of possible booking times.</returns>
        public List<string> GetAppointmentTimes(string chosenDate)
        {
            // Create an instanec of the GetApptTime class.
            GetApptTime timeList = new GetApptTime();

            return timeList.FindChosenDate(chosenDate);
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

        /// <summary>
        /// Gets the name of a staff member associated with a staff ID, to display on the form.
        /// </summary>
        /// <param name="StaffID">StaffID number.</param>
        /// <returns>Data set containing a staff member.</returns>
        public DataSet GetStaffMemberName(string StaffID)
        {
            // Gets a data set containing a staff member.
            DataSet dsStaffMember = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.GetStaffMemberName(StaffID));
            return dsStaffMember;
        }

        /// <summary>
        /// Adds the appointment info to the database.
        /// </summary>
        /// <param name="appointmentInfo"></param>
        public void AddToDatabase(AppointmentInfo appointmentInfo)
        {
            // Inserts appointment info into the database.
            DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.InsertAppointment(appointmentInfo));
        }       
        #endregion

        #region CONSTRUCTORS

        private AddAppointment()
        {

        }
        #endregion
    }
}
