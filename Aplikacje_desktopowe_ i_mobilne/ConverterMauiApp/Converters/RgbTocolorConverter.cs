using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterMauiApp.Converters
{
    class RgbToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Color color = new Color();

            if (values is not null
                && values.Length == 3
                && values[0] != null
                && values[1] != null
                && values[2] != null)
            {
                float red = (float)(double)values[0] / 255;
                float green = (float)(double)values[1] / 255;
                float blue = (float)(double)values[2] / 255;
                color = new Color(red, green, blue);
            }

            return color;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Color color = (Color)value;
            object[] doubles = new object[3];
            doubles[0] = color.Red * 255.0;
            doubles[1] = color.Green * 255.0;
            doubles[2] = color.Blue * 255.0;
            return doubles;
        }
    }
}
