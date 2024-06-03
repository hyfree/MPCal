using ScoreCalculator.Models.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScoreCalculator.Views.Windows
{
    /// <summary>
    /// EditDetailsWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditDetailsWindow : Window
    {
        public EditDetailsWindow(RecordEntryEntity RecordEntryEntity)
        {
            InitializeComponent();
            this.MyRecordEntryEntity = RecordEntryEntity;
            this.DataContext = MyRecordEntryEntity;

        }
        public RecordEntryEntity MyRecordEntryEntity ;

        private void Window_Initialized(object sender, EventArgs e)
        {
           
          //  this.TabControlUI.DataContext = this.RecordEntryEntity;

        }
    }
}
