using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace OverSurgery
{
    class AppointmentManager
    {
        #region PROPERTIES
        // Declares an instance of the AddAppointment class.
        private static AppointmentManager _instance;

        // Instantiates a read-only object to use as a lock for the singleton.
        private static readonly object _lock = new object();

        // Ensures only one instance of the class can be instantiated.
        public static AppointmentManager GetAppointmentManagerInstance
        {
            get
            {
                lock (_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new AppointmentManager();
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

            return timeList.GetPossibleTimesList(chosenDate);
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

            return staffList.GetAvailableStaffList(chosenDate, chosenTime);
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
        /// Checks if any of the data fields are invalid then inserts
        /// the appointment into the database.
        /// </summary>
        /// <param name="appointmentInfo">appointmentInfo object</param>
        /// <returns>Integer associated with a particular message.</returns>
        public int AddAppointment(AppointmentInfo appointmentInfo)
        {
            if (appointmentInfo.PatientID == null)
            {
                // No patient selected.
                return 1;
            }
            else if (appointmentInfo.Date == null)
            {
                // No date selected.
                return 2;
            }
            else if (appointmentInfo.Time == null)
            {
                // No time selected.
                return 3;
            }
            else if (appointmentInfo.StaffID == null)
            {
                // No staff member selected.
                return 4;
            }
            else
            {
                InsertToDatabase(appointmentInfo);

                // Appointment inserted into database successfully.
                return 5;
            }
        }

        /// <summary>
        /// Adds the appointment info to the database.
        /// </summary>
        /// <param name="appointmentInfo"></param>
        public void InsertToDatabase(AppointmentInfo appointmentInfo)
        {
            // Inserts appointment info into the database.
            DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.InsertAppointment(appointmentInfo));
        }       
        #endregion

        #region CONSTRUCTORS

        private AppointmentManager()
        {

        }
        #endregion
    }
}
