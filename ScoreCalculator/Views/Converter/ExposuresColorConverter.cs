using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ScoreCalculator.Views.Converter
{
    public class ExposuresColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var exposures = (Exposures)value;
            return exposures.GetExposuresColorString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();

        }
    }
}
