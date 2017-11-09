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

        DelegateCommand dc;
        public DelegateCommand Dc
        {
            get
            {
                if (dc == null)
                {
                    dc = new DelegateCommand(() => name = "John Doe", () => true);
                }

                return dc;
            }
        }
    }
}
