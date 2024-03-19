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
        private UpdateUserDetailWindow updateUserDetailsVm;
        private ICommand createAccountCommand;


        [SetUp]
        public void Setup()
        {
            updateUserDetailsVm = new UpdateUserDetailWindow();

        }

        //[Test]
        //public void UpdateUserDetail_Dash_LoanDate_Test()
        //{
        //    updateUserDetailsVm.UpdateUserDetail.DOB = "02-02-2020";
        //    updateUserDetailsVm.UpdateDetails();

        //    Assert.IsNotNull(updateUserDetailsVm.UpdateUserDetail.DOB);
        //}

        //[Test]
        //public void UpdateUserDetail_Shlash_LoanDate_Test()
        //{
        //    updateUserDetailsVm.UpdateUserDetail.DOB = "02/02/2020";
        //    updateUserDetailsVm.UpdateDetails();

        //    Assert.IsNotNull(updateUserDetailsVm.UpdateUserDetail.DOB);
        //}

        //[Test]
        //public void UpdateUserDetail_Error_Test()
        //{
        //    updateUserDetailsVm.UpdateUserDetail.UserName = "@#";
        //    updateUserDetailsVm.UpdateUserDetail.Password = "test";
        //    updateUserDetailsVm.UpdateUserDetail.Email = "wrong";
        //    updateUserDetailsVm.UpdateUserDetail.PAN = "098";
        //    updateUserDetailsVm.UpdateUserDetail.ContactNumber = "989";
        //    updateUserDetailsVm.UpdateUserDetail.DOB = DateTime.Now.ToString("dd/MM/yyyy");
            

        //    Assert.IsTrue(updateUserDetailsVm.UpdateUserDetail.PropertyErrors.Any());
        //}


        //[Test]
        //public void UpdateUserDetail_UserName_Empty_Errors_Test()
        //{
        //    updateUserDetailsVm.UpdateUserDetail.UserName = "";
        //    updateUserDetailsVm.UpdateDetails();

        //    Assert.IsNotNull(updateUserDetailsVm.UpdateUserDetail.UserName);
        //}

        //[Test]
        //public void UpdateUserDetail_UserName_Errors_Test()
        //{
        //    updateUserDetailsVm.UpdateUserDetail.UserName = "Tes67%*";
        //    updateUserDetailsVm.UpdateDetails();

        //    Assert.IsNotNull(updateUserDetailsVm.UpdateUserDetail.UserName);
        //}

        //[Test]
        //public void UpdateUserDetail_PassWord_Errors_Test()
        //{
        //    updateUserDetailsVm.UpdateUserDetail.Password = "T67%*";
        //    updateUserDetailsVm.UpdateDetails();

        //    Assert.IsNotNull(updateUserDetailsVm.UpdateUserDetail.Password);
        //}


        //[Test]
        //public void SignUpModel_EmailId_Errors_Test()
        //{
        //    updateUserDetailsVm.UpdateUserDetail.Email = "T67%*";
        //    updateUserDetailsVm.UpdateDetails();

        //    Assert.IsNotNull(updateUserDetailsVm.UpdateUserDetail.Email);
        //}

        //[Test]
        //public void UpdateUserDetail_PAN_Errors_Test()
        //{
        //    updateUserDetailsVm.UpdateUserDetail.PAN = "098*";
        //    updateUserDetailsVm.UpdateDetails();

        //    Assert.IsNotNull(updateUserDetailsVm.UpdateUserDetail.PAN);
        //}

        //[Test]
        //public void UpdateUserDetail_Contact_Errors_Test()
        //{
        //    updateUserDetailsVm.UpdateUserDetail.ContactNumber = "098*";
        //    updateUserDetailsVm.UpdateDetails();

        //    Assert.IsNotNull(updateUserDetailsVm.UpdateUserDetail.ContactNumber);
        //}

        //[Test]
        //public void UpdateUserDetail_Age_Errors_Test()
        //{
        //    updateUserDetailsVm.UpdateUserDetail.DOB = DateTime.Now.ToString("dd/MM/yyyy"); ;
        //    updateUserDetailsVm.UpdateDetails();

        //    Assert.IsNotNull(updateUserDetailsVm.UpdateUserDetail.DOB);
        //}
    }
}
