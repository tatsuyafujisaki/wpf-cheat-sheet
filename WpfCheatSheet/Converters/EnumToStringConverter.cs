using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using WpfCheatSheet.Models;

namespace WpfCheatSheet.Converters
{
    class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((BLT)value)
            {
                case BLT.Bacon:
                    return "ベーコン";
                case BLT.Lettuce:
                    return "レタス";
                case BLT.Tomato:
                    return "トマト";
                default:
                    throw new InvalidEnumArgumentException(value.ToString());
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "ベーコン":
                    return BLT.Bacon;
                case "レタス":
                    return BLT.Lettuce;
                case "トマト":
                    return BLT.Tomato;
                default:
                    throw new InvalidEnumArgumentException(value.ToString());
            }
        }
    }
}
