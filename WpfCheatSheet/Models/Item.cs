using System;

namespace WpfCheatSheet.Models
{
    public sealed class Item
    {
        public Item(string name, bool isActive, string updatedBy, DateTime updatedAt)
        {
            Name = name;
            IsActive = isActive;
            UpdatedBy = updatedBy;
            UpdatedAt = updatedAt;
        }

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
    }
}