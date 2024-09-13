using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;
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
            ProjectEntity project = new ProjectEntity();
            project.Name = name;
            project.Description = description;
            project.Provinces = provinces;
            project.City = city;
            project.Year = year;
            project.Level = (SystemLevel)level;
            //2.将SystemEntity对象保存到数据库
            ProjectService projectService = new ProjectService();
            projectService.Add(project);
            LaunchWindows.Refresh();


        }
    }
}
