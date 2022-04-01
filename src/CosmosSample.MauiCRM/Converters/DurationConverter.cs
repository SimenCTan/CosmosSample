using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosSample.MauiCRM.Converters;

class DurationConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value==null)return null;
        var result=string.Empty;
        if (value is string stringValue)
        {

            if (TimeSpan.TryParse(stringValue, out TimeSpan duration))
            {
                result = $"{duration.TotalMinutes.ToString("N0")} min";
            }
        }
        return result;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}

