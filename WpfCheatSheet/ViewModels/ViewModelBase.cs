using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WpfCheatSheet.ViewModels
{
    class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
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

        protected void ErrorIfEmpty(string s, [CallerMemberName] string propertyName = null)
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

        protected void ErrorIfDirectoryNotFound(string path, [CallerMemberName] string propertyName = null)
        {
            if (Directory.Exists(path))
            {
                errors.Remove(propertyName);
            }
            else
            {
                NotifyErrorsChanged(propertyName, "Directory not found");
            }
        }

        protected void ErrorIfFileNotFound(string path, [CallerMemberName] string propertyName = null)
        {
            if (File.Exists(path))
            {
                errors.Remove(propertyName);
            }
            else
            {
                NotifyErrorsChanged(propertyName, "File not found");
            }
        }
    }
}