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

        // Chosen date of the appointment.
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

        // Chosen time of the appointment.
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

        // ID of patient who the appointment is for.
        private string patientID;
        public string PatientID
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

        // ID of staff member appointment is with.
        private string staffID;
        public string StaffID
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
