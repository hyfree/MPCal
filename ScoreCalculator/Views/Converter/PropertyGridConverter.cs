using ScoreCalculator.Models.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ScoreCalculator.Views.Converter
{
    public class PropertyGridConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selectItem = value as RecordEntryEntity;
            //if (selectItem != null)
            //{
            //    var propertyItem = new PropertyGridDemoModel()
            //    {
            //        被测对象名称 = selectItem.TestObjectName,
            //        DAK=selectItem.DAK,
            //        RA=selectItem.RA,
            //        RK=selectItem.RK
                   
            //    };
            //    return propertyItem;
            //}
            return null;
           
        
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
