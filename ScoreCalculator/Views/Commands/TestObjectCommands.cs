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
            DeleteTestObject = new RoutedUICommand("DeleteTestObject", "DeleteTestObject", typeof(TestObjectCommands));

        }
        public static RoutedUICommand AddTestObject { get; }
        public static RoutedUICommand BatchAddTestObject { get; }
        public static RoutedUICommand DeleteTestObject { get; }


    }
}
