using HandyControl.Controls;

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
        public ObservableCollection<SystemInfoEntity> SystemInfoEntityList;//管理制度
        public LaunchWindows()
        {
            InitializeComponent();
            InitCommandBindings();
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
            var project = e.Parameter as SystemInfoEntity;
            if (project != null)
            {
                SystemInfoService systemInfoService = new SystemInfoService();

                systemInfoService.Delete(project);
            }
            this.Refresh();

        }

        private void OnOpenMarkingScheme(object sender, ExecutedRoutedEventArgs e)
        {
           var project=e.Parameter as SystemInfoEntity;
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
            SystemInfoService systemInfoService = new SystemInfoService();
            var list = systemInfoService.QueryAll();
            SystemInfoEntityList = new ObservableCollection<SystemInfoEntity>(systemInfoService.QueryAll());
            SystemInfoEntityList.Clear();
            foreach (var item in list)
            {
                SystemInfoEntityList.Add(item);
            }
            DataGridUI.ItemsSource = SystemInfoEntityList;

            HandyControl.Controls.Growl.Success("加载项目集合完成");
        }

        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow=new AboutWindow();
            aboutWindow.Show();
        }
    }
}
