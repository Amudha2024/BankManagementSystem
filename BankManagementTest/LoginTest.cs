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
    public class LoginTest
    {
        private LoginViewModel loginViewModel;
        private ICommand LoginCommand;
        private ICommand signupCommand;

        [SetUp]
        public void Setup()
        {
            loginViewModel = new LoginViewModel();
            LoginCommand = new RelayCommand(loginViewModel.Login);
            signupCommand = new RelayCommand(loginViewModel.SignUp);
        }

        //[Test]
        //public void SignupWindow_Test()
        //{
        //    // create a thread  
        //    Thread newWindowThread = new Thread(new ThreadStart(() =>
        //    {
        //        // create and show the window
        //        // your code
        //        signupCommand.CanExecute(null);
        //        signupCommand.Execute(null);

        //        // start the Dispatcher processing  
        //        System.Windows.Threading.Dispatcher.Run();
        //    }));

        //    // set the apartment state  
        //    newWindowThread.SetApartmentState(ApartmentState.STA);

        //    // make the thread a background thread  
        //    newWindowThread.IsBackground = true;

        //    // start the thread  
        //    newWindowThread.Start();


        //    Assert.IsNull(loginViewModel.LoginModel.UserName);
        //}

        [Test]
        [TestCase("amudha")]
        [TestCase("123456")]
        public void loginViewModel_UserNameValidation_Pass_Test(string username)
        {
            loginViewModel.LoginModel.UserName = username;
            Assert.AreEqual(username, loginViewModel.LoginModel.UserName);
        }

        [Test]
        [TestCase("amudha%")]
        [TestCase("!@#$%^*")]
        public void loginViewModel_UserNameValidation_Fail_Test(string username)
        {
            loginViewModel.LoginModel.UserName = username;
            Assert.AreEqual(username, loginViewModel.LoginModel.UserName);
        }

        [Test]
        [TestCase("Amudha@15")]
        [TestCase("Amudha&005")]
        public void loginViewModel_PasswordValidation_Pass_Test(string password)
        {
            loginViewModel.LoginModel.PassWord = password;
            Assert.AreEqual(password, loginViewModel.LoginModel.PassWord);
        }

        [Test]
        [TestCase("Amudha@12")]
        [TestCase("Amudha#12")]
        [TestCase("12")]
        [TestCase("&%^&!")]
        public void loginViewModel_PasswordValidation_Fail_Test(string password)
        {
            loginViewModel.LoginModel.PassWord = password;
            Assert.AreEqual(password, loginViewModel.LoginModel.PassWord);
        }

        [Test]
        public void loginViewModelCommand_Test()
        {
            loginViewModel.LoginModel.UserName = "test";
            loginViewModel.LoginModel.PassWord = "Test@121";

            loginViewModel.LoginCommand.CanExecute(null);
            loginViewModel.LoginCommand.Execute(null);

            Assert.IsNull(loginViewModel.LoginModel.Warning);

        }

        [Test]
        public void LoginSecurityQuery_UserName_Fail_Test()
        {
            loginViewModel.LoginModel.PassWord = "Test@121";

            loginViewModel.LoginCommand.CanExecute(null);
            loginViewModel.LoginCommand.Execute(null);

            Assert.IsNull(loginViewModel.LoginModel.UserName);

        }

        [Test]
        public void LoginSecurityQuery_Password_Fail_Test()
        {
            loginViewModel.LoginModel.UserName = "test";

            loginViewModel.LoginCommand.CanExecute(null);
            loginViewModel.LoginCommand.Execute(null);

            Assert.IsNull(loginViewModel.LoginModel.PassWord);

        }

    }
}
