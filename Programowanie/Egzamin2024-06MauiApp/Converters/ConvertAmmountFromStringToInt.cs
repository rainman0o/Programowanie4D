using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egzamin2024_06MauiApp.Converters
{
    internal class ConvertAmmountFromStringToInt : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return ((int)value).ToString();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {

            if (value == null
               || value is not string)
                return Binding.DoNothing;
            
            string strAmmountOfCubes = (string)value;
            if(!int.TryParse(strAmmountOfCubes, out int ammountOfCubes))
                return Binding.DoNothing;

            if (ammountOfCubes < 0 || ammountOfCubes > 10)
                return Binding.DoNothing;

            return ammountOfCubes;
        }
    }
}
