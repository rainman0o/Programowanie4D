using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egzamin2024_06MauiApp.Converters
{
    internal class CubesImages : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value == null || value is not int)
                return Binding.DoNothing;

            switch ((int)value)
            {
                case 0:
                    return "question.jpg";
                case 1:
                    return "k1.jpg";
                case 2:
                    return "k2.jpg";
                case 3:
                    return "k3.jpg";
                case 4:
                    return "k4.jpg";
                case 5:
                    return "k5.jpg";
                case 6:
                    return "k6.jpg";
                default:
                    return Binding.DoNothing;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
