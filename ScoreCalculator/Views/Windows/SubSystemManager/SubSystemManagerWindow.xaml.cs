﻿using ScoreCalculator.Views.CustomUserControl.MyDialog;

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

namespace ScoreCalculator.Views.Windows.SubSystemManager
{
    /// <summary>
    /// KnowledgeManagerWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SubSystemManagerWindow : Window
    {
        public SubSystemManagerWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dig = new BatchAdditionsKnowledgeDialog();
            dig.ShowDialog();
        }
    }
}