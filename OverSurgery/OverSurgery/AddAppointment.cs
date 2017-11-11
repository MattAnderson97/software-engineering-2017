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
        private static AddAppointment _instance;

        private List<string> dateList = new List<string>();

        private List<string> allDatesList = new List<string>();
        #endregion

        #region METHODS
        public static AddAppointment GetAddAppointmentInstance()
        {
            if (_instance == null)
                _instance = new AddAppointment();

            return _instance;
        }

        public List<string> FindChosenDate(string chosenDate)
        {
            string selectAllDate = String.Format("SELECT * FROM Appointment WHERE Date = '{0}'", chosenDate);
            DataSet dsAppointment = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(selectAllDate);
            return GetDateList(dsAppointment);           
        }

        public List<string> GetDateList(DataSet dsAppointment)
        {
            if(dsAppointment.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsAppointment.Tables[0].Rows.Count; i++)
                {
                    dateList.Add(dsAppointment.Tables[0].Rows[i]["Date"].ToString());
                }
            }
            
            return allDatesList;
        }

        public void CompareDateList()
        {

        }

        #endregion

        #region CONSTRUCTORS
        public AddAppointment()
        {
            int hour = 7;

            for (int i = 0; i <= 8; i++)
            {
                hour++;
                string stringHour = hour.ToString();
                int minute = 0;

                for (int j = 0; j <= 5; j++)
                {
                    string stringMinute = minute.ToString();

                    if (stringMinute == "0")
                    {
                        stringMinute = stringMinute + "0";
                    }

                    allDatesList.Add(stringHour + ":" + stringMinute);

                    minute = minute + 10;
                }
            }
        }
        #endregion
    }
}
