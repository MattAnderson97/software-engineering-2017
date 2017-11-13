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
            // SQL statement to give to database.
            string selectAllDate = String.Format("SELECT DISTINCT Time FROM Appointment WHERE Date = '{0}'", chosenDate);

            // Creates a data set for the data retrieved from the database.
            DataSet dsAppointment = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(selectAllDate);
            return GetBookedTimesList(dsAppointment, chosenDate);           
        }

        /// <summary>
        /// Gets a list of all times where all appointments for that time are booked.
        /// </summary>
        /// <param name="dsAppointment"></param>
        /// <returns></returns>
        public List<string> GetBookedTimesList(DataSet dsAppointment, string chosenDate)
        {
            if(dsAppointment.Tables[0].Rows.Count > 0)
            {
                GetAppointmentTimeList(dsAppointment, chosenDate);

                AddToBookedTimeList(dsAppointment, chosenDate);
            }
            
            return bookedTimeList;
        }

        public void GetAppointmentTimeList(DataSet dsAppointment, string chosenDate)
        {
            for (int i = 0; i < dsAppointment.Tables[0].Rows.Count; i++)
            {
                appointmentTimeList.Add(dsAppointment.Tables[0].Rows[i]["Time"].ToString());

                Console.WriteLine(dsAppointment.Tables[0].Rows[i]["Time"].ToString());
            }

            Console.WriteLine("appointmnet list length" + appointmentTimeList.Count.ToString());
        }

        public void AddToBookedTimeList(DataSet dsAppointment, string chosenDate)
        {
            for (int j = 0; j < appointmentTimeList.Count; j++)
            {
                string countTimes = String.Format(@"SELECT COUNT(CASE WHEN Date = '{0}' and Time = '{1}' 
                                                        then 1 else null end) as TimeCount FROM Appointment"
                                                , chosenDate, appointmentTimeList[j]);
                string countStaff = String.Format("SELECT COUNT(StaffID) as NumberOfStaff FROM StaffMember");

                DataSet dsTimesCount = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(countTimes);
                DataSet dsStaffCount = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(countStaff);

                Console.WriteLine(dsTimesCount.Tables[0].Rows[0]["TimeCount"].ToString());
                Console.WriteLine(dsStaffCount.Tables[0].Rows[0]["NumberOfStaff"].ToString());

                if (dsTimesCount.Tables[0].Rows[0]["TimeCount"].Equals(dsStaffCount.Tables[0].Rows[0]["NumberOfStaff"]))
                {
                    bookedTimeList.Add(appointmentTimeList[j]);
                    Console.WriteLine(dsAppointment.Tables[0].Rows[j]["Time"].ToString());
                }

                PrintTotals();
            }
        }

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
