using BankManagementSystem.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementTest
{
    public class TestData
    {
        private static NewUserDetails userDetail;

        public static NewUserDetails UserDetail
        {
            get
            {
                userDetail = new NewUserDetails()
                {
                    UserName = "test",
                    Password = "test@121",
                    Token = "Logout",
                    Role = 0,
                    Name = "Test",
                    Address = "DC/4",
                    State = "MH",
                    Country = "IN",
                    Email = "test@test.com",
                    PAN = "Gytruio832",
                    ContactNumber = 9879876543,
                    Dob = DateTime.Now.AddYears(-18),
                    AccountType = "Saving"
                };
                return userDetail;
            }
        }

        private static LoanDetail loanDetail;

        public static LoanDetail LoanDetail
        {
            get
            {
                loanDetail = new LoanDetail()
                {
                    LoanId = 1,
                    LoanAmount = 100000,
                    LoanDate = new DateTime(2022, 1, 1),
                    LoanDuration = 6,
                    LoanType = "Car",
                    Comment = "",
                    RateOfInterst = 10,
                    Status = "Pending",
                    UserName = "test"
                }; return loanDetail;
            }
        }

        private static LoginDetail loginDetail;

        public static LoginDetail LoginDetail
        {
            get
            {
                loginDetail = new LoginDetail()
                {
                    UserName = "test",
                    Password = "Test@121"
                };
                return loginDetail;
            }
        }
    }
}
