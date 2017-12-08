using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverSurgery
{
    class GetApptStaff
    {
        #region PROPERTIES
        // Creates a list to hold all the staff members.
        private List<string> allStaffList = new List<string>();

        // Creates a list to hold all the staff members that have 
        // appointments booked for a given date and time.
        private List<string> bookedStaffList = new List<string>();

        // Creates a list to hold all staff members available for appointments.
        private List<string> availableStaffList = new List<string>();
        #endregion

        #region METHODS

        /// <summary>
        /// Gets a list with the names of available staff members.
        /// </summary>
        /// <param name="chosenDate">Chosen appointment date.</param>
        /// <param name="chosenTime">Chosen appointment time.</param>
        /// <returns>List with names of available staff members.</returns>
        public List<string> GetAvailableStaffList(string chosenDate, string chosenTime)
        {
            // Gets a list of staff with appointments at a given date and time.
            GetBookedStaffList(chosenDate, chosenTime);

            // Compares the list of booked staff with the list of all staff,
            // putting only available staff in a list.
            CompareStaffLists();

            return availableStaffList;
        }

        /// <summary>
        /// Creates a list of staff members who have appointments at a given date and time.
        /// </summary>
        /// <param name="chosenDate">Chosen appointment date.</param>
        /// <param name="chosenTime">Chosen appointment time.</param>
        private void GetBookedStaffList(string chosenDate, string chosenTime)
        {
            // Gets a data set of staff members with appointments at a given date and time.
            DataSet dsBookedStaff = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.GetBookedStaff(chosenDate, chosenTime));

            // Iterates through the rows in the data set, adding the staff id's to the list.
            for(int i = 0; i < dsBookedStaff.Tables[0].Rows.Count; i++)
            {
                bookedStaffList.Add(dsBookedStaff.Tables[0].Rows[i]["StaffID_fk"].ToString());
            }
        }

        /// <summary>
        /// Gets a list of all staff members.
        /// </summary>
        private void GetAllStaffList()
        {
            // Gets a data set of all staff members.
            DataSet dsAllApptStaff = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(Constants.GetAllStaff());

            // Iterates through rows in the data set, adding the staff id's to the list.
            for(int i = 0; i < dsAllApptStaff.Tables[0].Rows.Count; i++)
            {
                allStaffList.Add(dsAllApptStaff.Tables[0].Rows[i]["StaffID"].ToString());
            }
        }

        /// <summary>
        /// Creates a list of staff members who don't have an appointment
        /// at a given date and time.
        /// </summary>
        private void CompareStaffLists()
        {
            availableStaffList = allStaffList.Except(bookedStaffList).ToList();
        }
        #endregion

        #region CONSTRUCTORS
        public GetApptStaff()
        {
            // Gets a list of all staff members.
            GetAllStaffList();
        }

        #endregion
    }
}
