namespace WpfCheatSheet
{
    class ViewModel1 : ViewModelBase
    {
        public ViewModel1()
        {
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private Command1 command1;

        public Command1 Command1
        {
            get
            {
                if (command1 == null)
                {
                    command1 = new Command1(() => name = "John Doe", () => true);
                }

                return command1;
            }
        }
    }
}
