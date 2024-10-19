using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScoreCalculator.Views.Commands
{
    public class KnowledgeCommand
    {
        static KnowledgeCommand()
        {
            //var inputOpenNewTab = new InputGestureCollection();
            //inputOpenNewTab.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));


            Delete = new RoutedUICommand("Delete", "Delete", typeof(KnowledgeCommand));
            BulkDelete = new RoutedUICommand("BulkDelete", "BulkDelete", typeof(KnowledgeCommand));
            Add = new RoutedUICommand("Add", "Add", typeof(KnowledgeCommand));
            BulkAdd = new RoutedUICommand("BulkAdd", "BulkAdd", typeof(KnowledgeCommand));
            EditDetails = new RoutedUICommand("EditDetails", "EditDetails", typeof(KnowledgeCommand));
            No = new RoutedUICommand("No", "No", typeof(KnowledgeCommand));
            D = new RoutedUICommand("D", "D", typeof(KnowledgeCommand));
            DA = new RoutedUICommand("DA", "DA", typeof(KnowledgeCommand));
            DAK = new RoutedUICommand("DAK", "DAK", typeof(KnowledgeCommand));
            CopyContent = new RoutedUICommand("CopyContent", "CopyContent", typeof(KnowledgeCommand));
            UseContent = new RoutedUICommand("UseContent", "UseContent", typeof(KnowledgeCommand));
            PasteContent = new RoutedUICommand("PasteContent", "PasteContent", typeof(KnowledgeCommand));
        }

        public static RoutedUICommand Add { get; }
        public static RoutedUICommand BulkAdd { get; }
        public static RoutedUICommand Delete { get; }
        public static RoutedUICommand BulkDelete { get; }
        public static RoutedUICommand EditDetails { get; }
        public static RoutedUICommand No { get; }
        public static RoutedUICommand D { get; }
        public static RoutedUICommand DA { get; }
        public static RoutedUICommand DAK { get; }
        public static RoutedUICommand CopyContent { get; }
        public static RoutedUICommand UseContent { get; }

        public static RoutedUICommand PasteContent { get; }
    }
}
