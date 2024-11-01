using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScoreCalculator.Views.Commands
{
    public class ProjectCommands
    {
        static ProjectCommands()
      {


            ImportProjectData = new RoutedUICommand("ImportProjectData", "ImportProjectData", typeof(ProjectCommands));
            ExportingProjectData = new RoutedUICommand("ExportingProjectData", "ExportingProjectData", typeof(ProjectCommands));
            SaveProjectData = new RoutedUICommand("SaveProjectData", "SaveProjectData", typeof(ProjectCommands));
            ReloadProjectData = new RoutedUICommand("ReloadProjectData", "ReloadProjectData", typeof(ProjectCommands));
            EditingSystemInformation = new RoutedUICommand("EditingSystemInformation", "EditingSystemInformation", typeof(ProjectCommands));
            OpenMarkingScheme = new RoutedUICommand("OpenMarkingScheme", "OpenMarkingScheme", typeof(ProjectCommands));
            OpenQuickTalkWindow = new RoutedUICommand("OpenQuickTalkWindow", "OpenQuickTalkWindow", typeof(ProjectCommands));
            OpenKnowledgeManagerWindow = new RoutedUICommand("OpenKnowledgeManagerWindow", "OpenKnowledgeManagerWindow", typeof(ProjectCommands));
            OpenSubSystemManagerWindow = new RoutedUICommand("OpenSubSystemManagerWindow", "OpenSubSystemManagerWindow", typeof(ProjectCommands));
            DeleteProjectData = new RoutedUICommand("DeleteProjectData", "DeleteProjectData", typeof(ProjectCommands));
            CreatProjectData = new RoutedUICommand("CreatProjectData", "CreatProjectData", typeof(ProjectCommands));
            SingleComputation = new RoutedUICommand("SingleComputation", "SingleComputation", typeof(ProjectCommands));
            TotalComputation = new RoutedUICommand("TotalComputation", "TotalComputation", typeof(ProjectCommands));
            Refresh = new RoutedUICommand("Refresh", "Refresh", typeof(ProjectCommands));
            ExportProblemConfirmationSheet = new RoutedUICommand("ExportProblemConfirmationSheet", "ExportProblemConfirmationSheet", typeof(ProjectCommands));
            ExportProblemConfirmationSheetExcel = new RoutedUICommand("ExportProblemConfirmationSheetExcel", "ExportProblemConfirmationSheetExcel", typeof(ProjectCommands));

            CopyView = new RoutedUICommand("CopyView", "CopyView", typeof(ProjectCommands));
            PasteView = new RoutedUICommand("PasteView", "PasteView", typeof(ProjectCommands));
            AddSubSystemName = new RoutedUICommand("AddSubSystemName", "AddSubSystemName", typeof(ProjectCommands));
            ReplaceSubSystemName = new RoutedUICommand("ReplaceSubSystemName", "ReplaceSubSystemName", typeof(ProjectCommands));
            DeleteSubSystemName = new RoutedUICommand("DeleteSubSystemName", "DeleteSubSystemName", typeof(ProjectCommands));
            ReloadSubSystemName = new RoutedUICommand("ReloadSubSystemName", "ReloadSubSystemName", typeof(ProjectCommands));


        }
        public static RoutedUICommand ImportProjectData { get; }
        public static RoutedUICommand ReloadProjectData { get; }
        public static RoutedUICommand SaveProjectData { get; }
        public static RoutedUICommand CreatProjectData { get; }
        public static RoutedUICommand DeleteProjectData { get; }
        public static RoutedUICommand ExportingProjectData { get; }
        /// <summary>
        /// 编辑系统信息
        /// </summary>
        public static RoutedUICommand EditingSystemInformation { get; }

        public static RoutedUICommand SingleComputation { get; }
        public static RoutedUICommand TotalComputation { get; }
        public static RoutedUICommand Refresh { get; }
        //复制和粘贴视图
        public static RoutedUICommand CopyView { get; }
        public static RoutedUICommand PasteView { get; }


        public static RoutedUICommand AddSubSystemName { get; }
        public static RoutedUICommand ReplaceSubSystemName { get; }
        public static RoutedUICommand DeleteSubSystemName { get; }
        public static RoutedUICommand ReloadSubSystemName { get; }


        /// <summary>
        /// 激活打分表
        /// </summary>
        public static RoutedUICommand OpenMarkingScheme { get; }
        public static RoutedUICommand OpenQuickTalkWindow { get; }
        public static RoutedUICommand OpenSubSystemManagerWindow { get; }
        public static RoutedUICommand OpenKnowledgeManagerWindow { get; }
        public static RoutedUICommand ExportProblemConfirmationSheet { get; }
        public static RoutedUICommand ExportProblemConfirmationSheetExcel { get; }





    }
}
