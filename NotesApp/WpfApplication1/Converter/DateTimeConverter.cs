using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWindowsWPF.Converter
{
    [System.Windows.Data.ValueConversion(typeof(DateTime), typeof(String))]
    public class DateTimeConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return String.Format("{0}/{1}/{2}", date.Day, date.Month, date.Year);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            DateTime resultDateTime;
            if (DateTime.TryParse(strValue, out resultDateTime))
            {
                return resultDateTime;
            }
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }
}
