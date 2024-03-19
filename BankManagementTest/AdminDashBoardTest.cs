using BankManagementSystem.Model.Service;
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
    public class AdminDashBoardTest
    {
        private AdminDashBoardViewModel adminDashboardVM;

        [SetUp]
        public void Setup()
        {
            adminDashboardVM = new AdminDashBoardViewModel();
        }

        [Test]
        public void BindableLoanDetails_Test()
        {
            List<LoanDetail> loanList = new List<LoanDetail>();
            loanList.Add(TestData.LoanDetail);
            adminDashboardVM.AllLoanDetails = new System.Collections.ObjectModel.ObservableCollection<LoanDetail>(loanList);

            Assert.IsNotNull(adminDashboardVM.AllLoanDetails);
        }
    }
}
