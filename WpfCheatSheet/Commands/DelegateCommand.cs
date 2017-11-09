using System;
using System.Windows.Input;

namespace WpfCheatSheet.Commands
{
    class DelegateCommand : ICommand
    {
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => canExecute();

        public void Execute(object parameter) => execute();

        Action execute;
        Func<bool> canExecute;
    }
}