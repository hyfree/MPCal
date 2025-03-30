using ScoreCalculator.DataBase;
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
            try
            {

                if (string.IsNullOrEmpty(this.Name.Text))
                {
                    MessageBox.Show("项目名称不能为空");
                    return;
                }
                if (string.IsNullOrEmpty(this.ProjectName.Text))
                {
                    MessageBox.Show("被测系统名称不能为空");
                    return;
                }
                var companyInfo=new TestedCompanyInformationEntity()
                {
                    Id= SnowFlakeNetService.FactoryGeInstance().NextId(),
                    CompanyName=this.CompanyName.Text,
                    Address=this.CompanyAddress.Text,
                    PostCode=this.CompanyAddressPostCode.Text,
                    MiMaju=this.MiMaju.Text,
                    ContactPersonName=this.LianXiRenXingMing.Text,
                    ContactPersonDuties=this.LianXiRenZhiWu.Text,
                    ContactPersonDepartment=this.LianXiRenBuMen.Text,
                    ContactPersonOfficePhone=this.LianXiRenDianHua.Text,
                    ContactPersonMobilePhone=this.LianXiRenDianHua.Text,
                    ContactPersonEmail=this.LianXiRenYouXiang.Text,
                };

                var db =  SQLLite3Context.Instance();
                //插入被测公司信息
                db.TestedCompanyInformationEntity.Add(companyInfo);


                //获取界面上的数据
                string name = this.Name.Text;
                string description = this.Description.Text;
                string provinces = this.Provinces.Text;
                string city = this.City.Text;
                int year = int.Parse(this.Year.Text);
                //int level = int.Parse(());
                var level = (SystemLevel)this.ProjectLevelComboBox.SelectedItem;
                if (level != SystemLevel.Level3)
                {
                    MessageBox.Show("请选择级别,仅支持Level3系统");
                    return;
                }
                //将数据保存到数据库
                //1.创建一个SystemEntity对象
                ProjectEntity project = new ProjectEntity() 
                {

                    SystemName = name,
                    ProjectName = this.ProjectName.Text,
                    TestedCompanyInformation=companyInfo,
                    Description = description,
                    Provinces = provinces,
                    City = city,
                    Year = year,
                    Level = (SystemLevel)level
                };
             
                //2.将SystemEntity对象保存到数据库
                ProjectService projectService = new ProjectService();
                projectService.Add(project);
                LaunchWindows.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
          

        }
    }
}
