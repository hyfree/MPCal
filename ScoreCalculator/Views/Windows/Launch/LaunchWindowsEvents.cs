using ScoreCalculator.Models.Entity;
using ScoreCalculator.Services;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ScoreCalculator.Views.Windows.Launch
{
    public partial class LaunchWindows
    {

        /// <summary>
        /// 刷新，从数据中获取全部系统信息，并绑定到DataGridUI
        /// </summary>
        public void Refresh()
        {
            ProjectService rojectService = new ProjectService();
            var list = rojectService.QueryAll();
            projectList = new ObservableCollection<ProjectEntity>(rojectService.QueryAll());
            projectList.Clear();
            foreach (var item in list)
            {
                projectList.Add(item);
            }
            DataGridUI.ItemsSource = projectList;

            HandyControl.Controls.Growl.Success("加载项目集合完成");

        }
        /// <summary>
        /// 创建项目
        /// </summary>
        public void CreatProject()
        {
            //以dialog的形式打开AddProjectWindow

            AddProjectWindow addProjectWindow = new AddProjectWindow();
            addProjectWindow.LaunchWindows=this;
            addProjectWindow.ShowDialog();


        }

    }
}
