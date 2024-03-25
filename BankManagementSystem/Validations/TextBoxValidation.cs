using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BankManagementSystem.Validations
{
    public class TextBoxValidation
    {
        string[] list = new[] { "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "=", "\"" };
        Regex regexValue = new Regex(@"^(?=.*\d)(?=.*[!&$%&?@-]).*$");
        public bool NameValidation(string name)
        {
            return (list.Contains(name));
        }
        public bool UserNameValidation(string userName)
        {
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
            var result = !(regex.IsMatch(Pan) && (Pan.Length==10));
            return result;
               
        }

        public bool ContactNoValidation(string Contact)
        {
            return !(Contact.Length == 10 &&
                Contact.All(char.IsDigit) && Contact[0] != '0');
        }

        public bool EmailIDValidation(string emailId)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return !regex.IsMatch(emailId);
        }

        public bool LoanAmountValidation(string loanAmount)
        {
            var value = !(loanAmount.All(char.IsDigit) && regexValue.IsMatch(loanAmount));
            return value;
        }

        public bool RoiValidation(string roi)
        {
            var value = !(roi.All(char.IsDigit)&&(roi.Length==2) && regexValue.IsMatch(roi));
            return value;
        }

        public bool LoanDurationValidation(string loanDuration)
        {
            var value = !(loanDuration.All(char.IsDigit) && (loanDuration.Length == 2) && list.Contains(loanDuration) && !loanDuration.Contains("-"));
            return value;
        }

        public bool Addressvalidation(string address)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9\s,]*$");
            return !(regex.IsMatch(address));
        }

        public bool CountryValidation(string country)
        {
            Regex regex = new Regex(@"^[a-zA-Z\s,]*$");
            return !(regex.IsMatch(country));
        }

        public bool StateValidationValidation(string State)
        {
            Regex regex = new Regex(@"^[a-zA-Z\s,]*$");
            return !(regex.IsMatch(State));
        }
    }
}
