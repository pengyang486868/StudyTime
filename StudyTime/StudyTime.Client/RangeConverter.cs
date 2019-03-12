using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StudyTime.Client
{
    public class RangeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var range = (TimeSpan)value;
            var str = "";
            str += (range.Hours < 10 ? "0" : "") + range.Hours;
            str += " : ";
            str += (range.Minutes < 10 ? "0" : "") + range.Minutes;
            str += " : ";
            str += (range.Seconds < 10 ? "0" : "") + range.Seconds;
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
