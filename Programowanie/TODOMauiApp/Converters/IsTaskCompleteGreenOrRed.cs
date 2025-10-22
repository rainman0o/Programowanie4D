using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOMauiApp.Converters
{
    internal class IsTaskCompleteGreenOrRedColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null
                || value is not bool)
                    return Binding.DoNothing;

            bool isChecked = (bool)value;

            if (isChecked)
                return Colors.Green;
            else
                return Colors.Red;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
