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
    public class ExposuresComboBoxOptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var exposures = (Exposures)value;
            switch (exposures)
            {
                case Exposures.High:
                    return "高";
                case Exposures.Medium:
                    return "中";
                case Exposures.Low:
                    return "低";
                case Exposures.None:
                    return "无";
            }
            return "高";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str=value as string;
            switch (str)
            {
                case "高":
                    return Exposures.High;
                case "中":
                    return Exposures.Medium;
                case "低":
                    return Exposures.Low;
                case "无":
                    return Exposures.None;
                default:
                    return Exposures.High;
            }

        }
    }
}
