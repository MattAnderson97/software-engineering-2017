using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverSurgery
{
    public class Prescription
    {
        #region PROPERTIES

        // medicine name
        private string medicineName;
        public string MedicineName
        {
            get
            {
                return medicineName;
            }

            set
            {
                medicineName = value;
            }
        }

        // lenght of medicine
        private string length;
        public string Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }


        // prescription extention data
        private string extentionDate;
        public string ExtentionDate
        {
            get
            {
                return extentionDate;
            }

            set
            {
                extentionDate = value;
            }
        }


        // medicine notes
        private string note;
        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }
        #endregion
    }
}
