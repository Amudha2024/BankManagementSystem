using BankManagementSystem.CommandsandNotify;
using BankManagementSystem.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Model
{
    public class SignUpModel : Notifier
    {
        #region private propoerties

        private TextBoxValidation textBoxValidation;
        private string name;
        private string userName;
        private string email;
        private string password;
        private string contactNumber;
        private string pan;
        private string address;
        private string accountType = "Saving";
        private string dob;
        private string state;
        private string country;
        private string warning;

        #endregion

        #region public Properties
        public string Name
        {
            get { return name; }
            set
            {
                name = value; Notify();
                ClearErrors();
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                Notify();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value; Notify();
                ClearErrors();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value; Notify();
                ClearErrors();
                bool result = textBoxValidation.EmailIDValidation(value);
            }
        }

        public string State
        {
            get { return state; }
            set
            {
                state = value; Notify();
                ClearErrors();
            }
        }

        public string Country
        {
            get { return country; }
            set { country = value; Notify();
                ClearErrors();
            }
        }

        public string Address
        {
            get { return address; }
            set { address = value; 
                Notify();
                ClearErrors();
            }
        }

        public string AccountType
        {
            get { return accountType; }
            set { accountType = value; Notify(); }
        }

        public string PAN
        {
            get { return pan; }
            set { pan = value; Notify();
            }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; Notify();
            }
        }

        public string DOB
        {
            get { return dob; }
            set
            {
                dob = value; Notify();
            }
        }

        public string Warning
        {
            get { return warning; } 
            set { warning = value; Notify();}
        }

        #endregion
        public SignUpModel()
        {
            textBoxValidation = new TextBoxValidation();
        }

    }
}
