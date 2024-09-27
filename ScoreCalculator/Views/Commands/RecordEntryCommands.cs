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


            Delete = new RoutedUICommand("Delete", "Delete", typeof(RecordEntryCommands));
            BulkDelete = new RoutedUICommand("BulkDelete", "BulkDelete", typeof(RecordEntryCommands));
            Add = new RoutedUICommand("Add", "Add", typeof(RecordEntryCommands));
            BulkAdd = new RoutedUICommand("BulkAdd", "BulkAdd", typeof(RecordEntryCommands));
            EditDetails = new RoutedUICommand("EditDetails", "EditDetails", typeof(RecordEntryCommands));
            D = new RoutedUICommand("D", "D", typeof(RecordEntryCommands));
            DA = new RoutedUICommand("DA", "DA", typeof(RecordEntryCommands));
            DAK = new RoutedUICommand("DAK", "DAK", typeof(RecordEntryCommands));
            CopyContent = new RoutedUICommand("CopyContent", "CopyContent", typeof(RecordEntryCommands));
            PasteContent = new RoutedUICommand("PasteContent", "PasteContent", typeof(RecordEntryCommands));
           

        }

        public static RoutedUICommand Add { get; }
        public static RoutedUICommand BulkAdd { get; }
        public static RoutedUICommand Delete { get; }
        public static RoutedUICommand BulkDelete { get; }
        public static RoutedUICommand EditDetails { get; }
        public static RoutedUICommand D { get; }
        public static RoutedUICommand DA { get; }
        public static RoutedUICommand DAK { get; }
        public static RoutedUICommand CopyContent { get; }
      
        public static RoutedUICommand PasteContent { get; }

       

    }
}
