using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScoreCalculator.Views.Commands
{
    public class RecordEntryCommands
    {
        static RecordEntryCommands()
        {
            //var inputOpenNewTab = new InputGestureCollection();
            //inputOpenNewTab.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));


            Delete = new RoutedUICommand("Delete", "Delete", typeof(CustomCommands));
            BulkDelete = new RoutedUICommand("BulkDelete", "BulkDelete", typeof(CustomCommands));
            Add = new RoutedUICommand("Add", "Add", typeof(CustomCommands));
            BulkAdd = new RoutedUICommand("BulkAdd", "BulkAdd", typeof(CustomCommands));

        }

        public static RoutedUICommand Add { get; }
        public static RoutedUICommand BulkAdd { get; }
        public static RoutedUICommand Delete { get; }
        public static RoutedUICommand BulkDelete { get; }


    }
}
