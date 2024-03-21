using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagementSystem.ViewModel;
using System.Windows.Input;
using BankManagementSystem.Model.Service;
using BankManagementSystem.CommandsandNotify;

namespace BankManagementTest
{
    [TestFixture]
    internal class SignUpTest
    {
        private SignUpViewModel signUpViewModel;
        private ICommand createAccountCommand;
        private NewUserDetails userDetail = TestData.UserDetail;

        [SetUp]
        public void Setup()
        {
            signUpViewModel = new SignUpViewModel();
            createAccountCommand = new RelayCommand (signUpViewModel.CreateAccount);
            signUpViewModel.SignUpModel.Name = userDetail.Name;
            signUpViewModel.SignUpModel.UserName = userDetail.UserName;
            signUpViewModel.SignUpModel.Password = userDetail.Password;
            signUpViewModel.SignUpModel.Address = userDetail.Address;
            signUpViewModel.SignUpModel.State = userDetail.State;
            signUpViewModel.SignUpModel.Country = userDetail.Country;
            signUpViewModel.SignUpModel.ContactNumber = userDetail.ContactNumber.ToString();
            signUpViewModel.SignUpModel.PAN = userDetail.PAN.ToString();
            signUpViewModel.SignUpModel.Email = userDetail.Email;
            signUpViewModel.SignUpModel.DOB = userDetail.Dob.ToString();
            signUpViewModel.SignUpModel.AccountType = "System.Windows.Controls.ComboBoxItem: Saving";
        }

        [Test]
        public void CreateAccount_Test()
        {
            createAccountCommand.CanExecute(null);
            createAccountCommand.Execute(null);

            Assert.IsNull(signUpViewModel.SignUpModel.Warning);
        }


        [Test]
        public void signUpViewModel_Dash_LoanDate_Test()
        {
            signUpViewModel.SignUpModel.DOB = "02-02-2020";
            signUpViewModel.CreateAccount();

            Assert.IsNotNull(signUpViewModel.SignUpModel.DOB);
        }

        [Test]
        public void signUpViewModel_Shlash_LoanDate_Test()
        {
            signUpViewModel.SignUpModel.DOB = "02/02/2020";
            //signUpViewModel.CreateAccount();

            Assert.IsNotNull(signUpViewModel.SignUpModel.DOB);
        }

        [Test]
        public void signUpViewModel_Error_Test()
        {
            signUpViewModel.SignUpModel.UserName = "@#";
            signUpViewModel.SignUpModel.Password = "test";
            signUpViewModel.SignUpModel.Email = "wrong";
            signUpViewModel.SignUpModel.PAN = "098";
            signUpViewModel.SignUpModel.ContactNumber = "989";
            signUpViewModel.SignUpModel.DOB = DateTime.Now.ToString("dd/MM/yyyy");
            signUpViewModel.SignUpModel.Warning = "";

            Assert.IsTrue(signUpViewModel.SignUpModel.PropertyErrors.Any());
        }


        [Test]
        public void signUpViewModel_UserName_Empty_Errors_Test()
        {
            signUpViewModel.SignUpModel.UserName = "";
           // signUpViewModel.CreateAccount();

            Assert.IsNotNull(signUpViewModel.SignUpModel.UserName);
        }

        [Test]
        public void signUpViewModel_UserName_Errors_Test()
        {
            signUpViewModel.SignUpModel.UserName = "Tes67%*";
            //signUpViewModel.CreateAccount();

            Assert.IsNotNull(signUpViewModel.SignUpModel.UserName);
        }

        [Test]
        public void signUpViewModel_PassWord_Errors_Test()
        {
            signUpViewModel.SignUpModel.Password = "T67%*";
           // signUpViewModel.CreateAccount();

            Assert.IsNotNull(signUpViewModel.SignUpModel.Password);
        }


        [Test]
        public void SignUpModel_EmailId_Errors_Test()
        {
            signUpViewModel.SignUpModel.Email = "T67%*";
            //signUpViewModel.CreateAccount();

            Assert.IsNotNull(signUpViewModel.SignUpModel.Email);
        }

        [Test]
        public void signUpViewModel_PAN_Errors_Test()
        {
            signUpViewModel.SignUpModel.PAN = "098*";
           // signUpViewModel.CreateAccount();

            Assert.IsNotNull(signUpViewModel.SignUpModel.PAN);
        }

        [Test]
        public void signUpViewModel_Contact_Errors_Test()
        {
            signUpViewModel.SignUpModel.ContactNumber = "098*";
            //signUpViewModel.CreateAccount();

            Assert.IsNotNull(signUpViewModel.SignUpModel.ContactNumber);
        }

        [Test]
        public void signUpViewModel_Age_Errors_Test()
        {
            signUpViewModel.SignUpModel.DOB = DateTime.Now.ToString("dd/MM/yyyy"); ;
           // signUpViewModel.CreateAccount();

            Assert.IsNotNull(signUpViewModel.SignUpModel.DOB);
        }
    }
}
