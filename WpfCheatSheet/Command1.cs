using System;
using System.Windows.Input;

namespace WpfCheatSheet
{
    class Command1 : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;

        public Command1(Action execute, Func<bool> canExecute)
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
    }
}