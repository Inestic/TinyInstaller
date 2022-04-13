using System;
using System.Globalization;
using System.Windows.Data;

namespace TinyInstaller.Converters
{
    internal class IntToAnimation : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (int)value == 0;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}