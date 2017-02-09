using System;

namespace WpfCheatSheet
{
    class Record
    {
        // If the access modifier is changed from public to internal,
        // this field will not be displayed in DataGrid.ItemsSource.
        public string Name
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public string UpdatedBy
        {
            get;
            set;
        }

        public DateTime UpdatedAt
        {
            get;
            set;
        }

        internal Record(string name, bool isActive, string updatedBy, DateTime updatedAt)
        {
            Name = name;
            IsActive = isActive;
            UpdatedBy = updatedBy;
            UpdatedAt = updatedAt;
        }
    }
}