using BankManagementSystem.CommandsandNotify;
using BankManagementSystem.Model.Service;
using BankManagementSystem.View;
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
    public class UpdateUserDetailsTest
    {
        private UpdateUserDetailViewModel updateUserDetailsVm;
        private ICommand createAccountCommand;

        [SetUp]
        public void Setup()
        {
            updateUserDetailsVm = new UpdateUserDetailViewModel();
        }

        [Test]
        public void UpdateUserDetail_Error_Test()
        {
            updateUserDetailsVm.UpdateUserDetail.UserName = "@#";
            updateUserDetailsVm.UpdateUserDetail.Password = "test";
            updateUserDetailsVm.UpdateUserDetail.Email = "wrong";
            updateUserDetailsVm.UpdateUserDetail.PAN = "098";
            updateUserDetailsVm.UpdateUserDetail.ContactNumber = "989";
            updateUserDetailsVm.UpdateUserDetail.DOB = DateTime.Now.ToString("dd/MM/yyyy");
            Assert.IsTrue(updateUserDetailsVm.UpdateUserDetail.PropertyErrors.Any());
        }
    }
}
