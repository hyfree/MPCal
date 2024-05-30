using ScoreCalculator.Models.Entity;
using ScoreCalculator.Services;
using ScoreCalculator.Views.Windows.Launch;

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
    /// AddProjectWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddProjectWindow : Window
    {
        public AddProjectWindow()
        {
            InitializeComponent();
        }
        public LaunchWindows LaunchWindows { get;set;}
        //从界面上获取数据，然后保存到数据库
        private void OnSaveProject(object sender, RoutedEventArgs e)
        {
            //获取界面上的数据
            string name = this.Name.Text;
            string description = this.Description.Text;
            string provinces = this.Provinces.Text;
            string city = this.City.Text;
            int year = int.Parse(this.Year.Text);
            int level = int.Parse(this.Level.Text);
            //将数据保存到数据库
            //1.创建一个SystemEntity对象
            SystemInfoEntity systemEntity = new SystemInfoEntity();
            systemEntity.Name = name;
            systemEntity.Description = description;
            systemEntity.Provinces = provinces;
            systemEntity.City = city;
            systemEntity.Year = year;
            systemEntity.Level = level;
            //2.将SystemEntity对象保存到数据库
            SystemInfoService systemService = new SystemInfoService();
            systemService.Add(systemEntity);
            LaunchWindows.Refresh();


        }
    }
}
