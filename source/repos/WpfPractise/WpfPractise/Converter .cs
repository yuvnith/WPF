using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfPractise
{
    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int temp = 0;
            if (value != null)
                int.TryParse(value.ToString(), out temp);

            if (temp > 12 && temp < 20)
                return true;

            return false;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
                if ((bool) value == true)
                    return "teen";
                else
                    return "adult";
            
        }
    }

    
}