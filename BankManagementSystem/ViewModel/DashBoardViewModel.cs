using BankManagementSystem.CommandsandNotify;
using BankManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankManagementSystem.ViewModel
{
    public  class DashBoardViewModel :Notifier
    {

        public ICommand ApplyLoanCommand { get; }

        public ICommand PreviousLoanCommand { get; }

        public ICommand UpdateAccountDetailsCommand { get; }
        public ICommand LogOutCommand { get; }

        private string userNameGlobal;
        public string UserNameGlobal
        {
            get { return userNameGlobal; }  
            set { userNameGlobal = value;Notify(); }
        }

        public DashBoardViewModel()
        {
            UserNameGlobal = GlobalVariable.UserName;
            ApplyLoanCommand = new RelayCommand(ApplyLoan);
            LogOutCommand = new RelayCommand(LogOut);
            PreviousLoanCommand = new RelayCommand(PreviousLoan);
            UpdateAccountDetailsCommand = new RelayCommand(UpdateAccount);
        }

        public void UpdateAccount()
        {
            UpdateUserDetailWindow update = new UpdateUserDetailWindow();
            update.ShowDialog();

        }

        public void ApplyLoan()
        {
            ApplyLoanWindow applyLoanWindow = new ApplyLoanWindow();
            applyLoanWindow.ShowDialog();
        }

        public void PreviousLoan()
        {
            PreviousAppliedLoanWindow previous = new PreviousAppliedLoanWindow();
            previous.ShowDialog();
        }

        public void LogOut() 
        {
            CloseAllWindows();
            MessageBox.Show("Logged Out Sucessfully");
            LoginWindow login = new LoginWindow();
            login.ShowDialog();

        }

        public void CloseAllWindows()
        {

            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
            {
                App.Current.Windows[intCounter].Close();
            }
        }
    }
}
