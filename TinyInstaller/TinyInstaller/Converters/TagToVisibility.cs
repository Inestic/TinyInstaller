using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TinyInstaller.Converters
{
    internal class TagToVisibility : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var vmTag = values[0];
            var elementTag = values[1];
            return $"{vmTag}" == $"{elementTag}" ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}