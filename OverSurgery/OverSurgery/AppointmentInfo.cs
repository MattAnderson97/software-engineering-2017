using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverSurgery
{
    public class AppointmentInfo
    {
        #region PROPERTIES

        private string date;
        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        private string time;
        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        private int patientID;
        public int PatientID
        {
            get
            {
                return patientID;
            }

            set
            {
                patientID = value;
            }
        }

        private int staffID;
        public int StaffID
        {
            get
            {
                return staffID;
            }

            set
            {
                staffID = value;
            }
        }


        #endregion
    }
}
