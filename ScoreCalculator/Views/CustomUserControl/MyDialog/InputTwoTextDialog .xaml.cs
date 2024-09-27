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

namespace ScoreCalculator.Views.CustomUserControl.MyDialog
{
    /// <summary>
    /// InputTextDialog.xaml 的交互逻辑
    /// </summary>
    public partial class InputTwoTextDialog : Window
    {
        public string value;
        public string value2;
        public InputTwoTextDialog(string defaultValue)
        {
            InitializeComponent();
            //this.keyLabel.Content = key;
            if (!string.IsNullOrEmpty(defaultValue))
            {
                this.leftMarginTextBox.Text = defaultValue;
            }
           
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.value=this.leftMarginTextBox.Text;
            this.value2=this.leftMarginTextBox2.Text;
            this.DialogResult = true;


        }
    }
}
