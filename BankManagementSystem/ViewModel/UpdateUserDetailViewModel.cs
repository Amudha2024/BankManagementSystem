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

        private async void GetUserDetails()
        {

            var d = await signUpModel.GetUserDetail(updateUserDetail.UserName);
            if (d != null)
            {
                updateUserDetail.Name = d.Name;
                updateUserDetail.Email = d.Email;
                updateUserDetail.Address = d.Address;
                updateUserDetail.ContactNumber = d.ContactNumber;
                updateUserDetail.Country = d.Country;
                updateUserDetail.AccountType= d.AccountType;
                updateUserDetail.PAN = d.PAN;
                updateUserDetail.State = d.State;
                updateUserDetail.DOB=d.DOB;
            }
        }

        private async void UdpateDetails()
        {
            var f = await signUpModel.UpdateUserDetail(updateUserDetail);
            if(f!= null)
            {
                MessageBox.Show("User Details are Updated");
            }
        }
    }
}
