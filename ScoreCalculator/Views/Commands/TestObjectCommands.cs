using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScoreCalculator.Views.Commands
{
    public class TestObjectCommands
    {
        static TestObjectCommands()
      {


            AddTestObject = new RoutedUICommand("AddTestObject", "AddTestObject", typeof(TestObjectCommands));
            BatchAddTestObject = new RoutedUICommand("BatchAddTestObject", "BatchAddTestObject", typeof(TestObjectCommands));
            BatchAddTestWuLiObject = new RoutedUICommand("BatchAddTestWuLiObject", "BatchAddTestWuLiObject", typeof(TestObjectCommands));
            BatchAddTestSheBeiObject = new RoutedUICommand("BatchAddTestSheBeiObject", "BatchAddTestSheBeiObject", typeof(TestObjectCommands));
            BatchAddTestWangLuoObject = new RoutedUICommand("BatchAddTestWangLuoObject", "BatchAddTestWangLuoObject", typeof(TestObjectCommands));
            BatchAddTestYingYongObject = new RoutedUICommand("BatchAddTestYingYongObject", "BatchAddTestYingYongObject", typeof(TestObjectCommands));
            DeleteTestObject = new RoutedUICommand("DeleteTestObject", "DeleteTestObject", typeof(TestObjectCommands));
            EditDetails = new RoutedUICommand("EditDetails", "EditDetails", typeof(TestObjectCommands));

        }
        public static RoutedUICommand AddTestObject { get; }
        public static RoutedUICommand BatchAddTestObject { get; }
        public static RoutedUICommand BatchAddTestWuLiObject { get; }
        public static RoutedUICommand BatchAddTestSheBeiObject { get; }
        public static RoutedUICommand BatchAddTestWangLuoObject { get; }
        public static RoutedUICommand BatchAddTestYingYongObject { get; }
        public static RoutedUICommand DeleteTestObject { get; }
        public static RoutedUICommand EditDetails { get; }


    }
}
