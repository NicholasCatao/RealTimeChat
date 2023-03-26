using System;
using System.Windows.Input;

namespace LiveChat.MVVM.Core
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canexecute;


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canexecute = null)
        {
            _execute = execute;
            _canexecute = canexecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canexecute == null || _canexecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}

