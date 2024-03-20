using BankManagementSystem.CommandsandNotify;
using BankManagementSystem.Model;
using BankManagementSystem.Model.Service;
using BankManagementSystem.View;
using BankManagementSystem.View.Admin;
using BankManagementSystem.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankManagementSystem.ViewModel
{
    public class LoginViewModel : Notifier
    {
        private LoginModel loginModel;

        public LoginModel LoginModel
        {
            get
            {
                return loginModel;
            }
            set
            {
                loginModel = value;
                Notify();
            }
        }

        public ICommand LoginCommand { get; }

        public ICommand SignUpCommand { get; }

       

        public LoginViewModel()
        {
            LoginModel = new LoginModel();
            LoginCommand = new RelayCommand(Login);
            SignUpCommand = new RelayCommand(SignUp);
            
        }

        public async void Login()
        {
            //try
            //{
                LoginDetail login = new LoginDetail()
                {
                    UserName = LoginModel.UserName,
                    Password = LoginModel.PassWord
                };
           // GlobalVariable.UserName =  LoginModel.UserName;

            DashBoardWindow win = new DashBoardWindow();
            win.ShowDialog();

                //SignUpHelper signup = new SignUpHelper();
                //var data = await signup.LoginAgent(login);
                //if (data.ToString() == "Login Sucessfully")
                //{
                //    MessageBox.Show("Login Sucessfully");
                //    if (LoginModel.UserName.ToLower() == "admin")
                //    {
                //        AdminDashboardWindow adminDashboard = new AdminDashboardWindow();
                //        adminDashboard.Show();
                //    }
                //    else
                //    {
                        AdminDashboardWindow dash = new AdminDashboardWindow();
                        dash.ShowDialog();
                    //}

               // }
            //    else
            //    {
            //        MessageBox.Show("User name and Password is incorrect");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        public void SignUp()
        {
            var w = Application.Current.Windows[0];
            w.Hide();
            SignupWindow signupWindow = new SignupWindow();
            SignUpViewModel view = new SignUpViewModel();
            view.CloseCommand = new RelayCommand(() => { signupWindow.Close(); }) ;
            signupWindow.DataContext = view;
            signupWindow.ShowDialog();
            w.Show();
        }
    }
}
