using BankManagementSystem.CommandsandNotify;
using BankManagementSystem.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankManagementTest
{
    [TestFixture]
    public class ApplyLoanTest
    {
        private ApplyLoanViewModel applyLoanVM;
       
        private ICommand applyLoanCommand;


        [SetUp]
        public void Setup()
        {
            applyLoanVM = new ApplyLoanViewModel();
            
        }

        [Test]
        public void CreateNewLoan_Test()
        {
            applyLoanCommand = new RelayCommand(applyLoanVM.ApplyLoan);
            applyLoanCommand.CanExecute(null);
            applyLoanCommand.Execute(null);

            Assert.NotNull(applyLoanVM.ApplyLoanModel.ROI);
        }

        [Test]
        public void CreateNewLoan_Error_Test()
        {
            applyLoanVM.ApplyLoanModel.LoanAmount = "test";
            applyLoanVM.ApplyLoanModel.LoanDate = "02/02/2029";
            applyLoanVM.ApplyLoanModel.LoanDuration = "5.0";
            applyLoanVM.ApplyLoanModel.LoanDuration = "0test";
            applyLoanVM.ApplyLoanModel.LoanDuration = "9&";
            applyLoanVM.PropertyErrors.Add("", "");
            Assert.NotNull(applyLoanVM.PropertyErrors.Any());
        }


        [Test]
        public void CreateNewLoan_LoanDuration_Errors_Test()
        {
            applyLoanVM.ApplyLoanModel.LoanDuration = "";
            applyLoanVM.ApplyLoan();

            Assert.IsEmpty(applyLoanVM.ApplyLoanModel.LoanDuration);
        }

        [Test]
        public void CreateNewLoan_LoanDuration_WithValue_Errors_Test()
        {
            applyLoanVM.ApplyLoanModel.LoanDuration = "0.0";
            applyLoanVM.ApplyLoan();

            Assert.IsNotNull(applyLoanVM.ApplyLoanModel.LoanDuration);
        }

        [Test]
        public void CreateNewLoan_LoanAmount_Errors_Test()
        {
            applyLoanVM.ApplyLoanModel.LoanAmount = "test";
            applyLoanVM.ApplyLoan();

            Assert.IsNotNull(applyLoanVM.ApplyLoanModel.LoanAmount);
        }

        [Test]
        public void CreateNewLoan_LoanDate_Errors_Test()
        {
            applyLoanVM.ApplyLoanModel.LoanDate = "02/02/2029";
            applyLoanVM.ApplyLoan();

            Assert.IsNotNull(applyLoanVM.ApplyLoanModel.LoanDate);
        }

        [Test]
        public void CreateNewLoan_Dash_LoanDate_Test()
        {
            applyLoanVM.ApplyLoanModel.LoanDate = "02-02-2020";
            applyLoanVM.ApplyLoan();

            Assert.IsNotNull(applyLoanVM.ApplyLoanModel.LoanDate);
        }

        [Test]
        public void CreateNewLoan_Shlash_LoanDate_Test()
        {
            applyLoanVM.ApplyLoanModel.LoanDate = "02/02/2020";
            applyLoanVM.ApplyLoan();

            Assert.IsNotNull(applyLoanVM.ApplyLoanModel.LoanDate);
        }

    }
}
