﻿using BankManagementSystem.CommandsandNotify;
using System.Windows.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagementSystem.Model.Service;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using BankManagementSystem.ViewModel.Helpers;

namespace BankManagementSystem.ViewModel
{
    public  class AdminDashBoardViewModel :Notifier
    {
        private ObservableCollection<LoanDetail> allLoanDetails;

        private SignUpHelper signUp;

        private string user;

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

        public ICommand ApproveStatusCommand { get; }

        public ICommand RejectCommand { get; }

        public ICommand LogOutCommand { get; }

        public AdminDashBoardViewModel()
        {
            signUp = new SignUpHelper();
            UserNameGlobal = GlobalVariable.UserName;
            AllLoanDetails = new ObservableCollection<LoanDetail>();
            ApproveStatusCommand = new RelayCommand(Approve);
            RejectCommand = new RelayCommand(Reject);
            LogOutCommand = new RelayCommand(Logout);
            LoadLoanDetails();
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
            var d = await signUp.ApproveLoanStatus(loanList);
            AllLoanDetails.Clear();
            var g = await signUp.GetAllUserLoan();
            foreach (var item in g)
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
            var d = await signUp.RejectLoanStatus(loanList);
            AllLoanDetails.Clear();
            var g = await signUp.GetAllUserLoan();
            foreach (var item in g)
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
                //LoanDetail loan = new LoanDetail
                //{
                //   LoanAmount=123,
                //   Status="Pending",
                //   LoanDate=DateTime.Now,
                //   RateOfInterst=2,
                //   LoanType ="Home",
                //   LoanId =1,
                //   LoanDuration=35

                //};
                foreach (var item in result)
                {
                    allLoanDetails.Add(item);
                }
               
                //if (result.Count == 0) MessageBox.Show("No Record Found");
                //else
                //{
                //    foreach (var item in result)
                //    {
                //        AllLoanDetails.Add(item);
                //    }
                //}
            }
            catch (Exception ex)
            {
            }
        }
        public void Logout() 
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