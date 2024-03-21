using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BankManagementSystem.Validations
{
    public class TextBoxValidation
    {
        string[] list = new[] { "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "=", "\"" };
       
        public bool NameValidation(string name)
        {
            //)&& name.Length <= 50)
            return (list.Contains(name));
        }
        public bool UserNameValidation(string userName)
        {
            //var fill = userName.Length <= 8 && userName.Length >= 20;
            return  list.Any(userName.Contains);
        }

        public bool PasswordValidation(string password)
        {
            Regex regexpassword = new Regex(@"^.*(?=.{4,})(?=.*[a-zA-Z])(?=.*\d)(?=.*[!&$%&?@ ]).*$");
            return !(password.Length >= 8 &&
                     password.Length <= 15 &&
                     regexpassword.IsMatch(password));
        }

        public bool PanValidation(string Pan)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9\s,]*$");
            var f = regex.IsMatch(Pan) && (Pan.Length == 10);
            var result = !(regex.IsMatch(Pan) && (Pan.Length==10));
            return result;
               
        }

        public bool ContactNoValidation(string Contact)
        {
            Regex reg = new Regex(@"^[0-9\s,]*$");
            return !(Contact.Length == 10 &&
                Contact.All(char.IsDigit) && Contact[0] != '0');
        }

        public bool EmailIDValidation(string emailId)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return !regex.IsMatch(emailId);
        }

        public bool DateValidation(string date)
        {
            if (string.IsNullOrEmpty(date))
                return false;
            string val = date.Contains("-") ? "-" : "/";
            string[] dates = date.Split(" ")[0].Split(val);
            string myDate = dates[1] + "-" + dates[0] + "-" + dates[2];

            DateTime now = DateTime.Now.Date;
            DateTime selectedDate = DateTime.Parse(myDate);
            int res = DateTime.Compare(now, selectedDate);

            if (res < 0)
                return true;
            else
                return false;
        }

        public bool AgeGreaterThan18(string date)
        {
            if (string.IsNullOrEmpty(date))
                return false;
            string val = date.Contains("-") ? "-" : "/";
            string[] dates = date.Split(" ")[0].Split(val);
            string myDate = dates[1] + "-" + dates[0] + "-" + dates[2];

            DateTime now = DateTime.Now.Date;
            DateTime selectedDate = DateTime.Parse(myDate);
            int age = now.Year - selectedDate.Year;

            if (age >= 18)
            {
                return false;
            }
            return true;
        }

        public bool LoanAmountValidation(string loanAmount)
        {
            var value = !(loanAmount.All(char.IsDigit));
            return value;
        }

        public bool RoiValidation(string roi)
        {
            var value = !(roi.All(char.IsDigit)&&(roi.Length==2));
            return value;
        }

        public bool LoanDurationValidation(string loanDuration)
        {
            var value = !(loanDuration.All(char.IsDigit) && (loanDuration.Length == 2));
            return value;
        }
    }
}
