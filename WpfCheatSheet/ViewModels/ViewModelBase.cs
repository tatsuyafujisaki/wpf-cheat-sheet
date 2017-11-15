using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WpfCheatSheet.ViewModels
{
    class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        readonly Dictionary<string, IEnumerable> errors = new Dictionary<string, IEnumerable>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        bool INotifyDataErrorInfo.HasErrors => errors.Any();
        IEnumerable INotifyDataErrorInfo.GetErrors(string propertyName) => errors.ContainsKey(propertyName) ? errors[propertyName] : null;

        protected void NotifyErrorsChanged(string propertyName, string error)
        {
            if (ErrorsChanged == null)
            {
                return;
            }

            if (!errors.ContainsKey(propertyName))
            {
                errors.Add(propertyName, new[] { error });
            }

            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void ErrorIfEmpty(string propertyName, string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                NotifyErrorsChanged(propertyName, "Required");
            }
            else
            {
                errors.Remove(propertyName);
            }
        }
    }
}