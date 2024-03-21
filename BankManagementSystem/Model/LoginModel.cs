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

        TextBoxValidation textBoxvalidation;

        public string UserName
        {
            get { return userName; }
            set { userName = value; Notify();
                ClearErrors();
                //bool result = textBoxvalidation.UserNameValidation(value);
                //if (result)
                  //  AddError(nameof(UserName), "Invalid User name,It must not contain any special character except underscore(_)");
            }
        }

        public string PassWord
        {
            get { return password; }
            set
            {
                password = value;
                Notify();
                ClearErrors();
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

        public LoginModel()
        {
            textBoxvalidation= new TextBoxValidation();
        }
    }
}
