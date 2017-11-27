using System;
using System.Globalization;
using System.Windows.Data;
using WpfCheatSheet.Common;

namespace WpfCheatSheet.Converters
{
    sealed class UncConverter : IValueConverter
    {
        // Null-check is to prevent the designer from throwing an exception.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value == null ? null : Io.GetUnc((string)value);

        // Null-check is to prevent the designer from throwing an exception.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value == null ? null : Io.GetUnc((string)value);
    }
}