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
        #endregion

        #region METHODS
        public static AddAppointment GetAddAppointmentInstance()
        {
            if (_instance == null)
                _instance = new AddAppointment();

            return _instance;
        }

        public string CheckAvailableStaff(string apptDate, string apptTime)
        {
            string select = String.Format("SELECT * FROM Appointment WHERE Date = '{0}' AND Time = '{1}'",apptDate, apptTime);
            DataSet dsAppointment = DatabaseConnection.getDatabaseConnectionInstance().getDataSet(select);

            if(dsAppointment.Tables[0].Rows.Count > 0)
            {
                string first = dsAppointment.Tables[0].Rows[0]["StaffId_Fk"].ToString();
                return first;
            }
            else
            {
                return "nothing";
            }
            
            
        }
        #endregion

        #region CONSTRUCTORS
        #endregion
    }
}
