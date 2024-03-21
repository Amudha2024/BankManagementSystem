using BankManagementSystem.CommandsandNotify;
using BankManagementSystem.Validations;

namespace BankManagementSystem.Model
{
    public class LoginModel : Notifier
    {
        private string userName;

        private string password;

        private string warning;

        private bool isCheck;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value; Notify();
            }
        }

        public string PassWord
        {
            get { return password; }
            set
            {
                password = value;
                Notify();
            }
        }

        public string Warning
        {
            get { return warning; }
            set { warning = value; Notify(); }
        }

        public bool IsCheck
        {
            get { return isCheck; }
            set
            { 
                isCheck = value;
                if (IsCheck)
                {
                    userName = "Admin";
                    PassWord = "Admin@123";
                }
            }
        }

    }
}
