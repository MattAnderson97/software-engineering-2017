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

        // List containing all times where appointments are available to book.
        private List<string> bookedTimeList = new List<string>();

        // List containing all times appointments can be held.
        private List<string> allTimeList = new List<string>();

        private List<string> appointmentTimeList = new List<string>();
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
        /// Finds all appointment records for a particular date.
        /// </summary>
        /// <param name="chosenDate">The chosen date.</param>
        /// <returns></returns>
        public List<string> FindChosenDate(string chosenDate)
        {
            // SQL statement to search for all appointments on a given date.
            string selectAllDate = String.Format("SELECT DISTINCT Time FROM Appointment WHERE Date = '{0}'", chosenDate);

            // Creates a data set for the data retrieved from the database.
            DataSet dsAppointment = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(selectAllDate);

            // Calls GetBookedTimeList method.
            return GetBookedTimesList(dsAppointment, chosenDate);           
        }

        /// <summary>
        /// Gets a list of all times where all appointments for that time are booked.
        /// </summary>
        /// <param name="dsAppointment"></param>
        /// <returns></returns>
        public List<string> GetBookedTimesList(DataSet dsAppointment, string chosenDate)
        {
            // Checks to see if there are no bookings for the given date.
            if(dsAppointment.Tables[0].Rows.Count > 0)
            {
                GetAppointmentTimeList(dsAppointment, chosenDate);

                AddToBookedTimeList(dsAppointment, chosenDate);
            }
            
            return bookedTimeList;
        }

        /// <summary>
        /// Creates a list of all times that have appointments booked.
        /// </summary>
        /// <param name="dsAppointment"></param>
        /// <param name="chosenDate"></param>
        public void GetAppointmentTimeList(DataSet dsAppointment, string chosenDate)
        {
            // Loops through all the data set rows.
            for (int i = 0; i < dsAppointment.Tables[0].Rows.Count; i++)
            {
                // Adds each distinct time to the list.
                appointmentTimeList.Add(dsAppointment.Tables[0].Rows[i]["Time"].ToString());

                Console.WriteLine(dsAppointment.Tables[0].Rows[i]["Time"].ToString());
            }

            Console.WriteLine("appointmnet list length" + appointmentTimeList.Count.ToString());
        }

        /// <summary>
        /// Compares the amount of staff with appointments for a particular time and the amount of overall staff
        /// to determine whether there are appointments available at that particular time.
        /// </summary>
        /// <param name="dsAppointment"></param>
        /// <param name="chosenDate"></param>
        public void AddToBookedTimeList(DataSet dsAppointment, string chosenDate)
        {
            // Loops through all the times in the list.
            for (int j = 0; j < appointmentTimeList.Count; j++)
            {
                string countTimes = String.Format("SELECT * FROM Appointment WHERE Date = '{0}' AND Time = '{1}'", chosenDate, appointmentTimeList[j]);

                string countStaff = String.Format("SELECT * FROM StaffMember");

                // Gets all the appointments at a given time.
                DataSet dsTimesCount = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(countTimes);

                // Gets all the staff members.
                DataSet dsStaffCount = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(countStaff);

                Console.WriteLine(dsTimesCount.Tables[0].Rows.Count);
                Console.WriteLine(dsStaffCount.Tables[0].Rows.Count);

                // If the number of appointments ata given time is equal to the number of staff
                // available for appointments, the time is fully booked and added to the list.
                if(dsTimesCount.Tables[0].Rows.Count >= dsStaffCount.Tables[0].Rows.Count)
                {
                    bookedTimeList.Add(appointmentTimeList[j]);
                }

                PrintTotals();
            }
        }

        /// <summary>
        /// Creates a list containg all possible appointment times.
        /// </summary>
        public void GetAllTimesList()
        {
            // Sets the hour to 7.
            int hour = 7;

            // Iterates through each time 8-5, adding times at 10 min intervals.
            for (int i = 0; i <= 8; i++)
            {
                // Increments the hour.
                hour++;

                // Converts hour to string.
                string stringHour = hour.ToString();

                // Sets the minute to 0.
                int minute = 0;

                // Iterates through each 10 min slot in each hour,
                // adding it to list.
                for (int j = 0; j <= 5; j++)
                {
                    // Converts minute to string.
                    string stringMinute = minute.ToString();

                    // If the minute = 0, adds an extra 0 so two decimal places.
                    if (stringMinute == "0")
                    {
                        stringMinute = stringMinute + "0";
                    }

                    // Concats string to show hour and minute in correct  format and
                    // adds it to list.
                    allTimeList.Add(stringHour + ":" + stringMinute);

                    // Increments the minute by 10.
                    minute = minute + 10;
                }
            }
        }

        public void PrintTotals()
        {
            Console.WriteLine("ALL TIMES LIST");

            foreach(string s in allTimeList)
            {
                
                Console.WriteLine(s);
            }

            Console.WriteLine("BOOKED TIMES LIST");

            foreach(string s in bookedTimeList)
            {
                
                Console.WriteLine(s);
            }
        }

        public void CompareDateList()
        {

        }

        #endregion

        #region CONSTRUCTORS
        public AddAppointment()
        {
            // Gets a list containing all possible appointment times.
            GetAllTimesList();
        }
        #endregion
    }
}
