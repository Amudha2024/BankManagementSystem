using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.ViewModel.Helpers
{
    public static class Helper
    {
        public const string BASE_URL = "http://localhost:5278/api/Authenticate/";
        public const string BASE_URL_Loan = "http://localhost:5278/api/ApplyLoan/";
        public const string POST_URL = "Register";
        public const string GET_URL = "ApplyLoan/all/{0}";
    }
}
