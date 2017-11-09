using WpfCheatSheet.Commands;

namespace WpfCheatSheet.ViewModels
{
    class ViewModel1 : ViewModelBase
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        DelegateCommand helloWorldCommand;
        public DelegateCommand HelloWorldCommand
        {
            get
            {
                if (helloWorldCommand == null)
                {
                    helloWorldCommand = new DelegateCommand(() => MessageBox1.Show("Hello, world!"), () => true);
                }

                return helloWorldCommand;
            }
        }
    }
}
