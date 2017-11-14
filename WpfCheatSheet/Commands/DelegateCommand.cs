using System;
using System.Windows.Input;

namespace WpfCheatSheet.Commands
{
    class DelegateCommand : ICommand
    {
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => canExecute == null || canExecute(parameter);
        public void Execute(object parameter) => execute(parameter);

        readonly Action<object> execute;
        readonly Func<object, bool> canExecute;
    }
}