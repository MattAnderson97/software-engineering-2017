using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverSurgery
{
    public class PatientInfo
    {
        #region PROPERTIES

        // Patient first name.
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        // Patient last name.
        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
 
            set
            {
                lastName = value;
            }
        }       
        
        // Patient telephone number.
        private string telephoneNumber;
        public string TelephoneNumber
        {
            get
            {
                return telephoneNumber;
            }
            set
            {
                telephoneNumber = value;
            }
        }

        // Patient date of birth.
        private string dateOfBirth;
        public string DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }

            set
            {
                dateOfBirth = value;
            }
        }

        // Patient gender.
        private string gender;
        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        // Patient address.
        private string address;
        public string Address
        {
            get
            {
                return address;
            }
 
            set
            {
                address = value;
            }
        }     
        #endregion
    }
}
