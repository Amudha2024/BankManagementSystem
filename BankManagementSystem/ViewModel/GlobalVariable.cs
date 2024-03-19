using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.ViewModel
{

    public static class GlobalVariable
    {
        private static string username;

        public static string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private static string comment;

        public static string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        private static int londId;

        public static int LoanID
        {
            get { return londId; }
            set { londId = value; }
        }
    }
}
    

