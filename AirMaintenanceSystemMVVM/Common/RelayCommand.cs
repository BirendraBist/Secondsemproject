using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirMaintenanceSystemMVVM.Common
{
    public  class RelayCommand:ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        //Raised when RaiseCanExecuteChanged is Called.

        public event EventHandler CanExecuteChanged;

        //create a new command that can always execute
        public RelayCommand(Action execute) : this(execute, null)
        {
        }
        //create a new command
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();

        }
        public void Execute(object parameter)
        {
            _execute();
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
