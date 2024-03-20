using BankManagementSystem.CommandsandNotify;
using BankManagementSystem.Model;
using BankManagementSystem.Model.Service;
using BankManagementSystem.Validations;
using BankManagementSystem.View;
using BankManagementSystem.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace BankManagementSystem.ViewModel
{
    public class SignUpViewModel : Notifier
    {
        #region Private Members

        private SignUpModel signUpModel;

        private TextBoxValidation textBoxValidation;

        private bool isCheck;

        #endregion

        #region Public Members
        public SignUpModel SignUpModel
        {
            get
            {
                return signUpModel;
            }
            set
            {
                signUpModel = value;
                Notify();
            }
        }

        public bool IsCheck
        {
            get { return isCheck; }
            set { isCheck = value; Notify(); }
        }

        #endregion

        #region Commands
        public ICommand CreateAccountCommand { get; }

        public ICommand IsCheckCommand { get; }

        public ICommand CloseCommand { get; set; }

        #endregion

        public SignUpViewModel()
        {
            SignUpModel = new SignUpModel();
            textBoxValidation = new TextBoxValidation();
            CreateAccountCommand = new RelayCommand(CreateAccount);
            IsCheckCommand = new RelayCommand(AdminLogin);
        }

        public void AdminLogin()
        {
            if (isCheck)
                signUpModel.UserName = "Admin";
            else
                signUpModel.UserName = string.Empty;
           
        }

        public async void CreateAccount(object obj)
        {
            if (Validation())
            {
                try
                {
                    string val = SignUpModel.DOB.Contains("-") ? "-" : "/";
                    string[] dates = signUpModel.DOB.Split(" ")[0].Split(val);
                    string mydate = dates[1] + "/" + dates[0] + "/" + dates[2];

                    //need to map that service value into our values
                    NewUserDetails user = new NewUserDetails()
                    {
                        Name = signUpModel.Name,
                        UserName = signUpModel.UserName,
                        Password = signUpModel.Password,
                        Address = signUpModel.Address,
                        State = signUpModel.State,
                        Country = signUpModel.Country,
                        Email = signUpModel.Email,
                        PAN = signUpModel.PAN,
                        ContactNumber = long.Parse(signUpModel.ContactNumber),
                        Dob = DateTime.Parse(mydate),
                        AccountType = signUpModel.AccountType.Split(":")[1].Trim(),
                    };

                    SignUpHelper helper = new SignUpHelper();
                    var createAccountStatus = await helper.CreateAccount(user);
                    if (createAccountStatus.ToString() == "Register Sucessfully")
                    {
                        MessageBox.Show("Your Account Create Successfully");
                        CloseCommand?.Execute(null);
                    }
                    else if (createAccountStatus.ToString() == "Register Failed")
                    {
                        MessageBox.Show("User Name is Already Exists");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("exception");
                }
            }
        }

        public bool Validation()
        {
            #region Validation:
            CheckForIsNullOrEmpty(nameof(signUpModel.Name), signUpModel.Name);
            CheckForIsNullOrEmpty(nameof(signUpModel.UserName), signUpModel.UserName);
            CheckForIsNullOrEmpty(nameof(signUpModel.Password), signUpModel.Password);
            CheckForIsNullOrEmpty(nameof(signUpModel.Address), signUpModel.Address);
            CheckForIsNullOrEmpty(nameof(signUpModel.State), signUpModel.State);
            CheckForIsNullOrEmpty(nameof(signUpModel.Country), signUpModel.Country);
            CheckForIsNullOrEmpty(nameof(signUpModel.Email), signUpModel.Email);
            CheckForIsNullOrEmpty(nameof(signUpModel.PAN), signUpModel.PAN);
            CheckForIsNullOrEmpty(nameof(signUpModel.ContactNumber), signUpModel.ContactNumber);
            CheckForIsNullOrEmpty(nameof(signUpModel.DOB), signUpModel.DOB);
            signUpModel.Warning = "";

            if (string.IsNullOrEmpty(signUpModel.UserName) || string.IsNullOrEmpty(signUpModel.Password) || string.IsNullOrEmpty(signUpModel.Email) || string.IsNullOrEmpty(signUpModel.PAN) || string.IsNullOrEmpty(signUpModel.ContactNumber) || string.IsNullOrEmpty(signUpModel.DOB))
            {
                signUpModel.Warning = "All Fields are mandatory";
                return false ;
            }

            if (textBoxValidation.UserNameValidation(signUpModel.UserName))
            {
                signUpModel.Warning = " 7 < UserName > 21 and, must not have special character except _";
                return false;
            }

            if (textBoxValidation.PasswordValidation(signUpModel.Password))
            {
                signUpModel.Warning = "Password must be inbetween 8-20 and must have 1 Caps, 1 Small and 1 Special character";
                return false;
            }

            if (textBoxValidation.EmailIDValidation(signUpModel.Email))
            {
                signUpModel.Warning = "Invalid Email ID";
                return false;
            }

            if (textBoxValidation.PanValidation(signUpModel.PAN))
            {
                signUpModel.Warning = "Invalid PAN Number, 1st digit should not be 0 and must have 10 digits.";
                return false;
            }

            if (textBoxValidation.ContactNoValidation(signUpModel.ContactNumber))
            {
                signUpModel.Warning = "Invalid Contact Number, 1st digit should not be 0 and must have 10 digits.";
                return false;
            }

            if (textBoxValidation.AgeGreaterThan18(signUpModel.DOB))
            {
                signUpModel.Warning = "No Future Date Please and Age > 18.";
                return false;
            }
            return true;

            #endregion
        }

    }
}
