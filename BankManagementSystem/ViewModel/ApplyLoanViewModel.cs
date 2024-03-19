﻿using BankManagementSystem.CommandsandNotify;
using BankManagementSystem.Model;
using BankManagementSystem.Model.Service;
using BankManagementSystem.Validations;
using BankManagementSystem.View;
using BankManagementSystem.ViewModel.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankManagementSystem.ViewModel
{
    public class ApplyLoanViewModel :Notifier
    {
        private ApplyLoanModel applyLoanModel;

        private SignUpHelper signUpHelper;

        private ObservableCollection<LoanDetail> loanDetails;

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value;Notify(); }
        }
        public ObservableCollection<LoanDetail> LoanDetails
        {
            get { return loanDetails; }
            set { loanDetails = value; Notify(); }
        }

        public ApplyLoanModel ApplyLoanModel
        {
            get { return applyLoanModel; }
            set { applyLoanModel = value;Notify(); }
        }

        public ICommand ApplyLoanCommand { get; }

        public ICommand PreviousAppliedLoanCommand { get; }

        public ICommand CancelLoanCommand { get; }

        //public ApplyLoanViewModel(string UserName)
        //{
        //    UserNameAdmin = userName;
        //}

        public ApplyLoanViewModel()
        {
            userName = GlobalVariable.UserName;
            LoanDetails = new ObservableCollection<LoanDetail>();
            signUpHelper = new SignUpHelper();
            ApplyLoanModel = new ApplyLoanModel();
            ApplyLoanCommand = new RelayCommand(ApplyLoan);
            CancelLoanCommand = new RelayCommand(CancelLoan);
            PreviousAppliedLoanCommand = new RelayCommand(PreviousAppliedLoanWindowOpen);
        }

        public async void ApplyLoan()
        {
            try
            {
                if (LoanValidation())
                {
                    applyLoanModel.Status = "Pending..";
                    LoanDetail loan = new LoanDetail()
                    {
                        LoanId = 1,
                        LoanType = "Home",
                        LoanDate = DateTime.Today,
                        LoanAmount = double.Parse(ApplyLoanModel.LoanAmount),
                        LoanDuration = int.Parse(ApplyLoanModel.LoanDuration),
                        RateOfInterst = float.Parse(ApplyLoanModel.ROI),
                        Status = applyLoanModel.Status,
                    };
                    
                    var result = await signUpHelper.SaveLoanDetail(loan);
                    if (result)
                    {
                        MessageBox.Show("Loan Applied Sucessfully");
                        var loanList = await signUpHelper.GetUserLoan("Amudha");
                        if (loanList != null)
                        {
                            foreach (var item in loanList)
                            {
                                LoanDetails.Add(item);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot apply the loan");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void CancelLoan()
        {
            DashBoardWindow dashWindow = new DashBoardWindow();
            dashWindow.Show();
        }

        public async void PreviousAppliedLoanWindowOpen()
        {
            loanDetails.Clear();
            SignUpHelper sign = new SignUpHelper();
           var  list = await sign.GetUserLoan("Amudha");
            foreach (var item in list)
            {
                loanDetails.Add(item);
            }
        }

        public bool LoanValidation()
        {
            CheckForIsNullOrEmpty(nameof(applyLoanModel.LoanType), applyLoanModel.LoanType);
            CheckForIsNullOrEmpty(nameof(applyLoanModel.LoanAmount), applyLoanModel.LoanAmount);
            CheckForIsNullOrEmpty(nameof(applyLoanModel.ROI), applyLoanModel.ROI);
            CheckForIsNullOrEmpty(nameof(applyLoanModel.LoanDuration), applyLoanModel.LoanDuration);
            CheckForIsNullOrEmpty(nameof(applyLoanModel.LoanDate), applyLoanModel.LoanDate);
            
            if (string.IsNullOrEmpty(applyLoanModel.LoanType) || string.IsNullOrEmpty(applyLoanModel.LoanAmount) || string.IsNullOrEmpty(applyLoanModel.ROI) || string.IsNullOrEmpty(applyLoanModel.LoanDuration) || string.IsNullOrEmpty(applyLoanModel.LoanDate))
            {
                applyLoanModel.Warning = "All Fields are mandatory";
                return false;
            }

            return true;
        }
    }
}