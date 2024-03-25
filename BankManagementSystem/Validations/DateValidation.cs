using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Validations
{
    public static class DateValidation
    {
        public static bool DateValidationCheck(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return false;
            }
            string val = date.Contains("-") ? "-" : "/";
            string[] dates = date.Split(" ")[0].Split(val);
            string myDate = dates[1] + "-" + dates[0] + "-" + dates[2];
            DateTime now = DateTime.Now.Date;
            DateTime selectedDate = DateTime.Parse(myDate);
            int res = DateTime.Compare(now, selectedDate);

            if (res < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AgeGreaterThan18(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return false;
            }
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

    }
}
