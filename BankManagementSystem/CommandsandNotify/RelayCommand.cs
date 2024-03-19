using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankManagementSystem.CommandsandNotify
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action action;

        private Action<object> act;

        public RelayCommand(Action actCommand)
        {
            this.action = actCommand;
        }

        public RelayCommand( Action<object> act)
        {
            this.act = act;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            action?.Invoke();
            act?.Invoke(parameter);
        }
    }
}
