using System;
using System.Globalization;
using System.Windows.Data;

namespace UI.Components
{
    public class PasswordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new string('*', ((string)value).Length);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
