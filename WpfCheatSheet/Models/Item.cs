using System;
using WpfCheatSheet.ViewModels;

namespace WpfCheatSheet.Models
{
    sealed class Item : ViewModelBase
    {
        public Item(string name, bool isActive, string body, string updatedBy, DateTime updatedAt)
        {
            Name = name;
            IsActive = isActive;
            Body = body;
            UpdatedBy = updatedBy;
            UpdatedAt = updatedAt;
        }


        string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        string body;
        public string Body
        {
            get => body;
            set
            {
                body = value;
                NotifyPropertyChanged();
            }
        }

        bool isActive;
        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                NotifyPropertyChanged();
            }
        }

        string updateBy;
        public string UpdatedBy
        {
            get => updateBy;
            set
            {
                updateBy = value;
                NotifyPropertyChanged();
            }
        }

        DateTime updateAt;
        public DateTime UpdatedAt
        {
            get => updateAt;
            set
            {
                updateAt = value;
                NotifyPropertyChanged();
            }
        }
    }
}