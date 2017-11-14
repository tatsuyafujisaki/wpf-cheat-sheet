using System.Collections.Generic;
using System.ComponentModel;

namespace WpfCheatSheet.ViewModels
{
    class ViewModelBase : INotifyPropertyChanged
    {
        readonly Dictionary<string, PropertyChangedEventArgs> d = new Dictionary<string, PropertyChangedEventArgs>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            if (!d.ContainsKey(propertyName))
            {
                d.Add(propertyName, new PropertyChangedEventArgs(propertyName));
            }

            PropertyChanged.Invoke(this, d[propertyName]);
        }
    }
}