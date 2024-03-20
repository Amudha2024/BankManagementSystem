using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.ViewModel
{

    public static class GlobalVariable
    {
        #region private

        private static string userName;

        private static string comment;

        private static int londId;
        #endregion

        #region public
        public static string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public static string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public static int LoanID
        {
            get { return londId; }
            set { londId = value; }
        }

        #endregion
    }
}
    

