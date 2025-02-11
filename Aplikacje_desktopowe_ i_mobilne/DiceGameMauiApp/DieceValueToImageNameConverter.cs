using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameMauiApp
{
    public class DieceValueToImageNameConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return "question.jpg";

            int dieceValue = (int)value;
            if (dieceValue >= 1 && dieceValue <= 6)
                return $"k{dieceValue}.jpg";

            return "question.jpg";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
