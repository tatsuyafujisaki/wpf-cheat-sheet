using System;
using System.Globalization;
using System.Windows.Data;
using WpfCheatSheet.Models;

namespace WpfCheatSheet.Converters
{
    class EnumToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (BLT)value == BLT.Bacon;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
