using BankManagementSystem.CommandsandNotify;
using System;
using System.Linq;
using BankManagementSystem.Model.Service;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using BankManagementSystem.ViewModel.Helpers;

namespace BankManagementSystem.ViewModel
{
    public  class AdminDashBoardViewModel :Notifier
    {
        #region Private Members
        private ObservableCollection<LoanDetail> allLoanDetails;

        private SignUpHelper signUp;

        private string user;

        #endregion

        #region Public Members
        public string UserNameGlobal
        {
            get { return user; }
            set { user = value; Notify(); }
        }

        public ObservableCollection<LoanDetail> AllLoanDetails
        {
            get { return allLoanDetails; }
            set { allLoanDetails = value; Notify(); }
        }
        #endregion

        #region Commands
        public ICommand ApproveStatusCommand { get; }

        public ICommand RejectCommand { get; }

        public ICommand LogOutCommand { get; }

        public ICommand GetLoanDetailsCommand { get; }

        #endregion

        public AdminDashBoardViewModel()
        {
            signUp = new SignUpHelper();
            UserNameGlobal = GlobalVariable.UserName;
            AllLoanDetails = new ObservableCollection<LoanDetail>();
            ApproveStatusCommand = new RelayCommand(Approve);
            RejectCommand = new RelayCommand(Reject);
            LogOutCommand = new RelayCommand(Logout);
            GetLoanDetailsCommand = new RelayCommand(LoadLoanDetails);
        }

        public async void Approve()
        {
            var loanList = AllLoanDetails.FirstOrDefault(x => x.LoanId == GlobalVariable.LoanID);
            if (loanList == null) return;
            var checkValue = AllLoanDetails.FirstOrDefault(x => x.LoanId == GlobalVariable.LoanID).Status;
            if (checkValue.ToLower() != "Pending") 
            {
                MessageBox.Show("Cant Change the status");
                return;
            }
            var approve = await signUp.ApproveLoanStatus(loanList);
            AllLoanDetails.Clear();
            var list = await signUp.GetAllUserLoan();
            foreach (var item in list)
            {
                AllLoanDetails.Add(item);
            }
        }

        public async void Reject()
        {
            var loanList = AllLoanDetails.FirstOrDefault(x => x.LoanId == GlobalVariable.LoanID);
            if (loanList == null) return;
            var checkValue = AllLoanDetails.FirstOrDefault(x => x.LoanId == GlobalVariable.LoanID).Status;
            if (checkValue.ToLower() != "Pending")
            {
                MessageBox.Show("Cant Change the status");
                return;
            }
            var reject = await signUp.RejectLoanStatus(loanList);
            AllLoanDetails.Clear();
            var list = await signUp.GetAllUserLoan();
            foreach (var item in list)
            {
                AllLoanDetails.Add(item);
            }
        }
    
        public async void LoadLoanDetails()
        {
            try
            {
                SignUpHelper sign = new SignUpHelper();
                var result = await sign.GetAllUserLoan();
                if (result.Count == 0)
                    MessageBox.Show("No Record Found");
                else
                {
                    foreach (var item in result)
                    {
                        AllLoanDetails.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Logout() 
        {
            CloseAllWindows();
            MessageBox.Show("Logged Out Sucessfully");
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
