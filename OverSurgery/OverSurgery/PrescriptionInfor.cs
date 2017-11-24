using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OverSurgery
{
    public struct Date
    {
        private int year;
        private int month;
        private int day;
        private int raw;


        public int Raw
        {
            get { return raw; }
            set
            {
                raw = value;

            }
        }


        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                this.Refresh();
            }
        }
        public int Month
        {
            get { return month; }
            set
            {
                month = value;
                this.Refresh();
            }
        }
        public int Day
        {
            get { return day; }
            set
            {
                day = value;
                this.Refresh();
            }
        }



        public Date(string time)
        {
            year = DateTime.ParseExact(time.Trim(' '), "yyyy_MM_dd", CultureInfo.InvariantCulture).Year;
            month = DateTime.ParseExact(time.Trim(' '), "yyyy_MM_dd", CultureInfo.InvariantCulture).Month;
            day = DateTime.ParseExact(time.Trim(' '), "yyyy_MM_dd", CultureInfo.InvariantCulture).Day;
            raw = year * 10000 + month * 100 + day;
        }

        private void Refresh()
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);

            if (this.day >= daysInMonth)
            {
                this.day = day - daysInMonth;
                this.month++;
            }
            else if (this.day < 0)
            {
                this.day = day + 365;
                this.month--;
            }
            if (this.month >= 12)
            {
                this.month = month - 12;
                this.year++;
            }
            else if (this.month < 0)
            {
                this.month = month + 12;
                this.year--;
            }
        }

        public override string ToString()
        {
            string result = "";
            if (this.year < 1000)
            {
                if (this.year < 100)
                {
                    if (this.year < 10)
                    {
                        result += "000";
                    }
                    else
                    {
                        result += "00";
                    }
                }
                else
                {
                    result += "0";
                }
            }
            result += year;
            result += "_";

            if (this.month < 10)
            {
                if (this.day < 10)
                {
                    result += String.Format("0{0}_0{1}", this.month, this.day);
                }
                else
                {
                    result += String.Format("0{0}_{1}", this.month, this.day);
                }
            }
            else
            {
                if (this.day < 10)
                {
                    result += String.Format("{0}_0{1}", this.month, this.day);
                }
                else
                {
                    result += String.Format("{0}_{1}", this.month, this.day);
                }
            }

            return result;

        }
    }

    public static class PrescriptionInfor
    {
        public static bool CheckFind(DataSet ds)// checks if a dataset contains specifically 1 row
        {

            if (ds.Tables[0].Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void ConfirmPrescriptionAction(string medID, string patientId, string extendDate)//Asks for confirmation for the extention request by showing the notes
        {
            DataSet ds = Prescriptionc.Instance.LoadMedNameAndNotes(medID);
            string medName = ds.Tables[0].Rows[0][0].ToString();
            string notes = ds.Tables[0].Rows[0][1].ToString();
            string message = "Notes:{0} " + notes + "{0}{0}{0}{0}Confirm and Authorise prescription extention?";
            DialogResult answer = MessageBox.Show(string.Format(message, Environment.NewLine), medName, MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                Prescriptionc.Instance.ExtendPrescrption(medID, patientId, extendDate);
            }
        }
    }
}
