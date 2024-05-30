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
    public class TestStatusConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TestStatus status = (TestStatus)value;
            
            return status.GetEnumString();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (string)value;
            switch (status)
            {
                case "符合":
                    return TestStatus.FULL;
                case "不符合":
                    return TestStatus.NOT;
                case "部分符合":
                    return TestStatus.PART;
                case "不适用":
                    return TestStatus.NA;
                default:
                      return TestStatus.NOT;
            }
        }
    }
}
