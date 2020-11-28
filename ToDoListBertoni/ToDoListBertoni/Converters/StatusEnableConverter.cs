using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ToDoListBertoni.Converters
{
    public class StatusEnableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Models.ToDoStatus)
                return ((Models.ToDoStatus)value) == Models.ToDoStatus.Incomplete;
            throw new ArgumentException("value is not ToDoStatus type");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
