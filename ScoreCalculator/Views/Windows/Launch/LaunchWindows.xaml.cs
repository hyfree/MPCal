using HandyControl.Controls;

using ScoreCalculator.DataBase;
using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.ViewModel;
using ScoreCalculator.Services;
using ScoreCalculator.Views.Commands;
using ScoreCalculator.Views.Windows.SubSystemManager;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ScoreCalculator.Views.Windows.Launch
{
    /// <summary>
    /// LaunchWindows.xaml 的交互逻辑
    /// </summary>
    public partial class LaunchWindows 
    {
        public ObservableCollection<ProjectEntity> projectList;//管理制度
        public LaunchWindows()
        {
            InitializeComponent();
            InitCommandBindings();
            using (var db=SQLLite3Context.Instance())
            {
                if (!db.IsExists())
                {
                    db.Database.EnsureCreated();

                }

            }
           LoadAllData();
        }

        private void OnCreatProject(object sender, RoutedEventArgs e)
        {
            CreatProject();
        }
        private void InitCommandBindings()
        {
            var openMarkingSchemeCommand = new CommandBinding(ProjectCommands.OpenMarkingScheme);
            openMarkingSchemeCommand.Executed += OnOpenMarkingScheme;
            this.CommandBindings.Add(openMarkingSchemeCommand);

            var deleteProjectCommnad = new CommandBinding(ProjectCommands.DeleteProjectData);
            deleteProjectCommnad.Executed += DeleteProjectCommnad_Executed;
            this.CommandBindings.Add(deleteProjectCommnad);

            this.AddCommandBindings(new CommandBinding(ProjectCommands.CreatProjectData), CreatProjectCommnad_Executed);
            this.AddCommandBindings(new CommandBinding(ProjectCommands.OpenKnowledgeManagerWindow), (c, e) => { 
                new KnowledgeManagerWindow().Show();
                });
            this.AddCommandBindings(new CommandBinding(ProjectCommands.OpenSubSystemManagerWindow), (c, e) => { 
            
                new SubSystemManagerWindow().Show();
            });
            this.AddCommandBindings(new CommandBinding(ProjectCommands.OpenQuickTalkWindow), (c, e) => {
                var project = e.Parameter as ProjectEntity;
                if (project != null)
                {
                    QuickTalkWindow windows = new QuickTalkWindow(project);
                    windows.Show();
                }

            });
        }

 
        private void AddCommandBindings(CommandBinding commandBinding, ExecutedRoutedEventHandler executed)
        {
            commandBinding.Executed += executed;
            this.CommandBindings.Add(commandBinding);
        }
        private void CreatProjectCommnad_Executed(object sender, ExecutedRoutedEventArgs e)
        {
          this.CreatProject();

        }

        private void DeleteProjectCommnad_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var project = this.DataGridUI.SelectedItem as ProjectEntity;

            if (project != null)
            {
                //SystemInfoService systemInfoService = new SystemInfoService();

                //systemInfoService.Delete(project);

                ProjectService projectService = new ProjectService();
                projectService.Delete(project);
            }
            this.Refresh();

        }
        /// <summary>
        /// 打开汇总打分计算器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenMarkingScheme(object sender, ExecutedRoutedEventArgs e)
        {
           var project= this.DataGridUI.SelectedItem as ProjectEntity;
            if (project != null)
            {
                MarkingSchemeWindow markingSchemeWindow = new MarkingSchemeWindow(project);
                markingSchemeWindow.Show();
            }

        }

        private void OnRefresh(object sender, RoutedEventArgs e)
        {
            this.Refresh();
        }

       
        private void OnDelete(object sender, RoutedEventArgs e)
        {
            SystemInfoService systemInfoService = new SystemInfoService();
           

        }

        private void LoadAllData()
        {
            ProjectService projectService = new ProjectService();
            var list = projectService.QueryAll();
            projectList = new ObservableCollection<ProjectEntity>(projectService.QueryAll());
            projectList.Clear();
            foreach (var item in list)
            {
                projectList.Add(item);
            }
            DataGridUI.ItemsSource = projectList;

            HandyControl.Controls.Growl.Success("加载项目集合完成");
        }

        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow=new AboutWindow();
            aboutWindow.Show();
        }

        private async void EnsureCreatedAsync(object sender, RoutedEventArgs e)
        {
            using (var sqlite= SQLLite3Context.Instance())
            {
              await  sqlite.Database.EnsureCreatedAsync();
            }
            Growl.Success("初始化成功！");
        }
        private async void EnsureDeletedAsync(object sender, RoutedEventArgs e)
        {
            using (var sqlite = SQLLite3Context.Instance())
            {

                await sqlite.Database.EnsureDeletedAsync();
            }
            Growl.Success("销毁成功！");
        }
        private async void CheckDatabaseExists(object sender, RoutedEventArgs e)
        {
            using (var sqlite = SQLLite3Context.Instance())
            {
                var isExist= sqlite.IsExists();
                if (isExist)
                {
                    Growl.Success("数据库存在状态！");
                }
                else
                {
                    Growl.Error("数据库销毁状态！");
                }
            }
           
        }
        /// <summary>
        /// 创建示例数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateExampleData(object sender,RoutedEventArgs e)
        {
            //1.创建一个SystemEntity对象
           ProjectService projectService = new ProjectService();
           projectService.AddTestData();
           this.Refresh();

        }

        private async void Window_LoadedAsync(object sender, RoutedEventArgs e)
        {
            var service=new LicenseServer();
            var dic=await service.CheckLicenseServerAsync();
            if (dic!=null)
            {

                Growl.Success($"已经连接到授权服务器！");
               //this.lis.Text=$"您的省份：{dic.data.prov}，您的城市：{dic.data.city}，您的地区：{dic.data.district}，您的ip：{dic.ip}。";
            }
            else
            {
                Growl.Error("授权服务器不可用，部分功能受限！");

            }

        }
    }
}
