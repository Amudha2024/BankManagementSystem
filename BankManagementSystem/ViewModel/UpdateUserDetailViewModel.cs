using BankManagementSystem.CommandsandNotify;
using BankManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankManagementSystem.ViewModel
{
    public class UpdateUserDetailViewModel : Notifier
    {
        private UpdateUserDetail updateUserDetail;

        public UpdateUserDetail UpdateUserDetail
        {
            get { return updateUserDetail; }
            set { updateUserDetail = value; Notify(); }
        }

        public ICommand UpdateUserDetailCommand { get; }

        public UpdateUserDetailViewModel()
        {
            UpdateUserDetail.UserName = GlobalVariable.UserName;
            UpdateUserDetail = new UpdateUserDetail();
            UpdateUserDetailCommand = new RelayCommand(UpdateDetails);
        }

        public void UpdateDetails()
        {

        }
    }
}
