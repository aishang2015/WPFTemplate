using System;
using System.Windows.Input;

namespace WPFTemplate.Commands
{
    public class BaseCommand : ICommand
    {
        private Func<object, bool> _canExecute;

        private Action<object> _execute;

        public BaseCommand(Action<object> execute) : this(execute, null)
        {
        }

        public BaseCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
            => _canExecute == null ? true : _canExecute(parameter);

        public void Execute(object parameter)
        {
            if (_execute != null && CanExecute(parameter))
            {
                _execute(parameter);
            }
        }
    }
    public class BaseCommand<T> : ICommand where T : class
    {
        private Func<T, bool> _canExecute;

        private Action<T> _execute;

        public BaseCommand(Action<T> execute) : this(execute, null)
        {
        }

        public BaseCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
            => _canExecute == null ? true : _canExecute(parameter as T);

        public void Execute(object parameter)
        {
            if (_execute != null && CanExecute(parameter))
            {
                _execute(parameter as T);
            }
        }
    }
}
