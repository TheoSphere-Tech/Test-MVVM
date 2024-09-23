using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test_MVVM.Commands
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> executeMethod, Predicate<object> CanExecuteMethod) 
        {
            _Execute = executeMethod;
            _CanExecute = CanExecuteMethod;
        }

        public bool CanExecute(object? parameter)
        {
            return _CanExecute(parameter);
        }

        public void Execute(object? parameter)
        { 
            _Execute(parameter);
        }

        public Action<object> _Execute { get; set; }
        public Predicate<object> _CanExecute { get; set; }

        public event EventHandler? CanExecuteChanged;
    }
}
