﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverSurgery
{
    class GetApptTime
    {
        #region PROPERTIES
        // List containing all times appointments can be held.
        private List<string> allTimeList = new List<string>();

        // List containing all times that have bookings.
        private List<string> appointmentTimeList = new List<string>();

        // List containing all times that are fully booked.
        private List<string> bookedTimeList = new List<string>();

        // List containing all times that can be booked.
        private List<string> possibleTimeList = new List<string>();
        #endregion

        #region METHODS

        /// <summary>
        /// Finds all appointment records for a particular date.
        /// </summary>
        /// <param name="chosenDate">The chosen date.</param>
        /// <returns>List of possible booking times.</returns>
        public List<string> GetPossibleTimesList(string chosenDate)
        {
            // Gets data set of all distinct appointments for a chosen date.
            DataSet dsAppointment = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.SelectAllDates(chosenDate));

            // Calls GetBookedTimeList method.
            GetBookedTimesList(dsAppointment, chosenDate);

            CompareTimeLists();

            return possibleTimeList;
        }

        /// <summary>
        /// Gets a list of all times where all appointments for that time are booked.
        /// </summary>
        /// <param name="dsAppointment"></param>
        /// <returns></returns>
        private void GetBookedTimesList(DataSet dsAppointment, string chosenDate)
        {
            // Checks to see if there are no bookings for the given date.
            if (dsAppointment.Tables[0].Rows.Count > 0)
            {
                GetAppointmentTimeList(dsAppointment, chosenDate);

                AddToBookedTimesList(dsAppointment, chosenDate);
                
            }
            else
            {
                possibleTimeList = allTimeList;
            }
        }

        /// <summary>
        /// Creates a list of all times that have appointments booked.
        /// </summary>
        /// <param name="dsAppointment"></param>
        /// <param name="chosenDate"></param>
        private void GetAppointmentTimeList(DataSet dsAppointment, string chosenDate)
        {
            // Loops through all the data set rows.
            for (int i = 0; i < dsAppointment.Tables[0].Rows.Count; i++)
            {
                // Adds each distinct time to the list.
                appointmentTimeList.Add(dsAppointment.Tables[0].Rows[i]["Time"].ToString());
            }
        }

        /// <summary>
        /// Compares the amount of staff with appointments for a particular time and the amount of overall staff
        /// to determine whether there are appointments available at that particular time.
        /// </summary>
        /// <param name="dsAppointment"></param>
        /// <param name="chosenDate"></param>
        private void AddToBookedTimesList(DataSet dsAppointment, string chosenDate)
        {
            // Loops through all the times in the list.
            for (int j = 0; j < appointmentTimeList.Count; j++)
            {
                // Stores the current value in the list.
                string listValue = appointmentTimeList[j].ToString();

                // Gets all the appointments at a given time.
                DataSet dsTimesCount = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.GetAppointmentsAtGivenTime(chosenDate, listValue));

                // Gets all the staff members.
                DataSet dsStaffCount = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.GetStaffMembers());

                // If the number of appointments ata given time is equal to the number of staff
                // available for appointments, the time is fully booked and added to the list.
                if (dsTimesCount.Tables[0].Rows.Count >= dsStaffCount.Tables[0].Rows.Count)
                {
                    bookedTimeList.Add(appointmentTimeList[j]);
                }
            }         
        }

        /// <summary>
        // Creates a list with only times that are not fully booked.
        /// </summary>
        private void CompareTimeLists()
        {
            // Creates a list with all the times except ones which are fully booked.
            possibleTimeList = allTimeList.Except(bookedTimeList).ToList();
        }

        /// <summary>
        /// Creates a list containg all possible appointment times.
        /// </summary>
        private void GetAllTimesList()
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
        #endregion

        #region CONSTRUCTORS
        public GetApptTime()
        {
            // Gets a list containing all possible appointment times.
            GetAllTimesList();
        }
        #endregion

    }
}
