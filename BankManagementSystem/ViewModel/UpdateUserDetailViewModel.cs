using BankManagementSystem.CommandsandNotify;
using BankManagementSystem.Model;
using BankManagementSystem.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankManagementSystem.ViewModel
{
    public class UpdateUserDetailViewModel : Notifier
    {
        #region private Members

        private string warning;

        private UpdateUserDetail updateUserDetail;

        private SignUpHelper signUpModel;

        #endregion

        #region public Members
        public UpdateUserDetail UpdateUserDetail
        {
            get { return updateUserDetail; }
            set { updateUserDetail = value; Notify(); }
        }

        public string Warning
        {
            get { return warning; }
            set { warning = value; Notify(); }
        }

        public ICommand UpdateUserDetailCommand { get; }

        #endregion

        public UpdateUserDetailViewModel()
        {  
            if (!DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                signUpModel = new SignUpHelper();
                UpdateUserDetail = new UpdateUserDetail();
                UpdateUserDetail.UserName = "Amudha";
                GetUserDetails();
                UpdateUserDetailCommand = new RelayCommand(UdpateDetails);
            }
        }

        #region Methods
        private async void GetUserDetails()
        {

            var getUser = await signUpModel.GetUserDetail(updateUserDetail.UserName);
            if (getUser != null)
            {
                updateUserDetail.Name = getUser.Name;
                updateUserDetail.Email = getUser.Email;
                updateUserDetail.Address = getUser.Address;
                updateUserDetail.ContactNumber = getUser.ContactNumber;
                updateUserDetail.Country = getUser.Country;
                updateUserDetail.AccountType= getUser.AccountType;
                updateUserDetail.PAN = getUser.PAN;
                updateUserDetail.State = getUser.State;
                updateUserDetail.DOB= getUser.DOB;
            }
        }

        private async void UdpateDetails()
        {
            var updatedValue = await signUpModel.UpdateUserDetail(updateUserDetail);
            if(updatedValue != null)
            {
                MessageBox.Show("User Details are Updated");
            }
        }

        #endregion
    }
}
