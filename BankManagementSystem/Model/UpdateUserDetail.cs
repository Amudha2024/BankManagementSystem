using BankManagementSystem.CommandsandNotify;
using BankManagementSystem.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Model
{
    public class UpdateUserDetail : Notifier
    {
        #region private propoerties

        TextBoxValidation textBoxValidation;
        private string name;
        private string userName;
        private string email;
        private string password;
        private string contactNumber;
        private string pan;
        private string address;
        private string accountType;
        private string dob;
        private string state;
        private string country;

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
                userName = value; Notify();
                ClearErrors();
                bool result = textBoxValidation.UserNameValidation(value);
                if (result)
                    AddError(nameof(UserName), "Invalid User name,It must not contain any special character except underscore(_)");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value; Notify();
                ClearErrors();
                bool result = textBoxValidation.PasswordValidation(value);
                if (result)
                    AddError(nameof(Password), "Password must be in between 8-20 and must have 1 caps,1 small and 1 special character");
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
                if (result)
                    AddError(nameof(UserName), "Invalid Mail ID");
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
            set
            {
                country = value; Notify();
                ClearErrors();
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
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
            set
            {
                pan = value; Notify();
                ClearErrors();
                bool result = textBoxValidation.PanValidation(value);
                if (result)
                    AddError(nameof(UserName), "InValid PAN Number,1st digit should not be 0 and must have 10 digits.");


            }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set
            {
                contactNumber = value; Notify();
                bool result = textBoxValidation.ContactNoValidation(value);
                if (result)
                    AddError(nameof(UserName), "InValid PAN Number,1st digit should not be 0 and must have 10 digits.");

            }
        }

        public string DOB
        {
            get { return dob; }
            set
            {
                dob = value; Notify();
                bool result = textBoxValidation.AgeGreaterThan18(value);
                if (result)
                    AddError(nameof(UserName), "No Future Date Please and Age > 18");
            }
        }

        #endregion

        public UpdateUserDetail()
        {
            textBoxValidation = new TextBoxValidation();
        }
    }
}
