using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScoreCalculator.Views.Commands
{
    internal class CustomCommands
    {
        static CustomCommands()
        {
            //var inputOpenNewTab = new InputGestureCollection();
            //inputOpenNewTab.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));
          

            SelectTestItems = new RoutedUICommand("SelectTestItems", "SelectTestItems", typeof(CustomCommands));
            SelectClass = new RoutedUICommand("SelectClass", "SelectClass", typeof(CustomCommands));

        }

        public static RoutedUICommand OpenNewTab { get; }

        public static RoutedUICommand SelectTestItems { get; }
        public static RoutedUICommand SelectClass { get; }

    }
}
