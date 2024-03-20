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
        #region private
        private string userName;
        #endregion

        #region public
        public string UserName
        {
            get { return userName; }
            set { userName = value; Notify(); }
        }
        #endregion

        #region Commands
        public ICommand ApplyLoanCommand { get; }

        public ICommand PreviousLoanCommand { get; }

        public ICommand UpdateAccountDetailsCommand { get; }
        public ICommand LogOutCommand { get; }

        #endregion
       

        public DashBoardViewModel()
        {
            userName = GlobalVariable.UserName;
            ApplyLoanCommand = new RelayCommand(ApplyLoan);
            LogOutCommand = new RelayCommand(LogOut);
            PreviousLoanCommand = new RelayCommand(PreviousLoan);
            UpdateAccountDetailsCommand = new RelayCommand(UpdateAccount);
        }

        #region Members
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
        #endregion
    }
}
