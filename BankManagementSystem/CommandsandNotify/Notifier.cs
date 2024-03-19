using BankManagementSystem.Validations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.CommandsandNotify
{
    public class Notifier : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        TextBoxValidation textBoxValdidation;

        protected void Notify([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private Dictionary<string, string> propertyErrors;

        public Dictionary<string, string> PropertyErrors
        {
            get { return propertyErrors; }
            set { propertyErrors = value; }
        }

        public Notifier()
        {
            propertyErrors = new Dictionary<string, string>();
            textBoxValdidation= new TextBoxValidation();
        }

        public bool HasErrors => propertyErrors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return propertyErrors.GetValueOrDefault(propertyName, "");
        }

        public void AddError( string propertyName, string errorMessage)
        {
            if (!propertyErrors.ContainsKey(propertyName))
            {
                propertyErrors.Add(propertyName, errorMessage);
                Notify();
            }
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertName));
        }

        public void ClearErrors([CallerMemberName] string propertyName= null)
        {
            propertyErrors?.Remove(propertyName);
            Notify();
            OnErrorsChanged(propertyName);
        }

        public void CheckForIsNullOrEmpty(string propertyName, string propertyValue)
        {
            if (string.IsNullOrEmpty(propertyValue))
            {
                ClearErrors(propertyName);
                AddError(propertyName, propertyName + " Field is mandatory.");
            }
        }


    }
}
