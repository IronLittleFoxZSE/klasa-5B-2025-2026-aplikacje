using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterMauiApp.Converters
{
    public class GradeToTextGradeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string grade = value as string;
            string returnValue = "Nieprawidłowa dana";
            if (grade != null)
            {
                returnValue = grade switch
                {
                    "1" => "Niedostateczny",
                    "2" => "Dopuszczający",
                    "3" => "Dostateczny",
                    "4" => "Dobry",
                    "5" => "Bardzo dobry",
                    "6" => "Celujący",
                    _ => "Nieprawidłowa ocena",
                };
            }
            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
