using HandyControl.Controls;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using NPOI.SS.Formula.Functions;

using ScoreCalculator.Models.Data;
using ScoreCalculator.Models.DTO;
using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;
using ScoreCalculator.Models.ViewModel;
using ScoreCalculator.Models.Word;
using ScoreCalculator.Services;
using ScoreCalculator.Utils;
using ScoreCalculator.Utils.Word;
using ScoreCalculator.Views.Commands;
using ScoreCalculator.Views.CustomUserControl;
using ScoreCalculator.Views.CustomUserControl.MyDialog;
using ScoreCalculator.Views.CustomUserControl.MySideMenu;
using ScoreCalculator.Views.ExtendedMethods;
using ScoreCalculator.Views.Extensions;
using ScoreCalculator.Views.Windows;
using ScoreCalculator.Views.Windows.QuickTalk.Pages;

using SixLabors.Fonts.Tables.AdvancedTypographic;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScoreCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class QuickTalkWindow : IOPWindows
    {
       
        public TableOfScores tableOfScores;
        public SideMenuItem selectItem;

        /// <summary>
        /// 选择标签值  SheBei-远程管理通道安全
        /// </summary>
        private string selectTag = "";

        private ProjectEntity projectEntity;

        private ZhiBiaoItem SelectZhiBiaoItem;

        public string Version="base";
        public string GetVersion()
        {
            return Version;
        }
        public TableOfScores GetTableOfScores()
        {
            return tableOfScores;
        }
        /// <summary>
        /// 界面显示数据
        /// </summary>
        public DataViewModel dataViewModel  =new DataViewModel();

        public CengMianViewModel Select_CengMianViewModel = new CengMianViewModel();
        bool auto=true;

        public SecurityDimensionEnum? GetSecurityDimensionEnum()
        {
            if (selectTag==null)
            {
                return null;
            }
            var sp=this.selectTag.Split("-");
            if (sp.Length!=2)
            {
                return null;
            }
            var result= (SecurityDimensionEnum)Enum.Parse(typeof(SecurityDimensionEnum), sp[0]);
            return result;
        }
        public string? GetZhiBiaoStr()
        {
            if (selectTag == null)
            {
                return null;
            }
            var sp = this.selectTag.Split("-");
            if (sp.Length != 2)
            {
                return null;
            }
            var result = sp[1];
            return result;
        }
        public ProjectEntity GetProjecInfo()
        {
            return projectEntity;
        }
        public QuickTalkWindow(ProjectEntity projectEntity)
        {
            this.projectEntity = projectEntity;
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            // 初始化命令绑定
            InitCommandBindings();
            //初始化数据绑定
            InitDataBinding();
            //myCalculationTableDatas = CalculationTableData.ReadAllData(systemInfoEntity.GetSystemLevel());

            //data= CalculationTableData.ReadAllData(systemInfoEntity.GetSystemLevel());
            this.CengMinFenXi.DataContext=dataViewModel;
          
            //var arry= sQLLite3Context.TagTable.Where(b => b.TagId == 1).ToArray();
            // var arry2= sQLLite3Context.TagTable.Where(b => b.Tag == "1").ToArray();
            // NPOIUtils.test();
            this.frmMain.Navigate(new WuLiHuanJingPage());

        }

        private void InitDataBinding()
        {

            this.tableOfScores=new TableOfScores(this.projectEntity);
            this.tableOfScores.LoadData(this.projectEntity.Level);
            var list = new RecordEntryServices().Query(projectEntity.Id,"base");
            this.tableOfScores.LoadRecordEntryEntitys(list);
            this.tableOfScores.UpdateScore();
            this.JiSuanBiao.DataContext = tableOfScores;
            //this.DataGridUI.ItemsSource= this.RecordEntryEntityList;
            Growl.Success("加载项目完成");
        }

        private void InitCommandBindings()
        {
            var SelectTestItemsCommand = new CommandBinding(CustomCommands.SelectTestItems);
            SelectTestItemsCommand.Executed += SelectTestItemsCommand_Executed;
            this.CommandBindings.Add(SelectTestItemsCommand);

            var SelectClassCommand = new CommandBinding(CustomCommands.SelectClass);
            SelectClassCommand.Executed += SelectClassCommand_Executed;
            this.CommandBindings.Add(SelectClassCommand);

            var addTestObjCommmad = new CommandBinding(TestObjectCommands.AddTestObject);
            addTestObjCommmad.Executed += AddTestObjCommmad_Executed;
            this.CommandBindings.Add(addTestObjCommmad);

            var batchAdditionsCommad = new CommandBinding(TestObjectCommands.BatchAddTestObject);
            batchAdditionsCommad.Executed += BatchAdditionsCommad_Executed; ;
            this.CommandBindings.Add(batchAdditionsCommad);

            var saveProjectCommand = new CommandBinding(ProjectCommands.SaveProjectData);
            saveProjectCommand.Executed += SaveProjectCommand_Executed;
            this.CommandBindings.Add(saveProjectCommand);

            var reloadProjectData = new CommandBinding(ProjectCommands.ReloadProjectData);
            reloadProjectData.Executed += ReloadProjectData_Executed;
            this.CommandBindings.Add(reloadProjectData);

            var createChaJuFenXiExcel = new CommandBinding(ExcelCommands.CreateChaJuFenXiExcel);
            createChaJuFenXiExcel.Executed += CreateChaJuFenXiExcel_Executed;
            this.CommandBindings.Add(createChaJuFenXiExcel);

            this.AddCommandBindings(new CommandBinding(ProjectCommands.SingleComputation), (sender, e) => { });
            this.AddCommandBindings(new CommandBinding(ProjectCommands.TotalComputation), (sender, e) => { this.tableOfScores.UpdateScore(); RefreshView(); });
            this.AddCommandBindings(new CommandBinding(ProjectCommands.Refresh), (sender, e) => { this.tableOfScores.UpdateScore(); RefreshView(); });
            this.AddCommandBindings(new CommandBinding(RecordEntryCommands.Delete), (sender, e) =>
            {

                RecordEntryEntity item = e.Parameter as RecordEntryEntity;
                if (item!=null)
                {
                    this.tableOfScores.DeleteItem(item);
                    RefreshView();
                }
                Growl.Success("删除单个测试对象");

            });
            this.AddCommandBindings(new CommandBinding(RecordEntryCommands.BulkDelete), (sender, e) =>
            {
                RecordEntryEntity item = e.Parameter as RecordEntryEntity;
                if (item!=null)
                {
                    this.tableOfScores.BulkDeleteItemByName(item);
                    RefreshView();
                    Growl.Success("批量删除测试对象");
                }
               
            });

            this.AddCommandBindings(new CommandBinding(ProjectCommands.ExportProblemConfirmationSheet), (sender, e) =>
            {
                var path=CommondDialog.SaveWordFileDialog("导出问题确认单");
                if (string.IsNullOrEmpty(path))
                {
                    Growl.Error("保存路径错误");
                    return;
                }
                ProblemConfirmationSheet problemConfirmationSheet = new ProblemConfirmationSheet();
                problemConfirmationSheet.Export(this.tableOfScores,path);
                Growl.Success("导出成功");

            });
            this.AddCommandBindings(new CommandBinding(RecordEntryCommands.EditDetails), (sender, e) => {

                RecordEntryEntity data = e.Parameter as RecordEntryEntity;
                if (data != null)
                {
                    EditDetailsWindow editDetailsWindow = new EditDetailsWindow(data);

                    editDetailsWindow.ShowDialog();
                }
                Growl.Success("编辑成功");
            });
        }
      
       
        private void AddCommandBindings(CommandBinding commandBinding, ExecutedRoutedEventHandler executed)
        {
            commandBinding.Executed += executed;
            this.CommandBindings.Add(commandBinding);
        }

        private void CreateChaJuFenXiExcel_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void ReloadProjectData_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void SaveProjectCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.tableOfScores.SaveData(this.Version);
            Growl.Success("保存成功");
        }

     

        /// <summary>
        /// 批量新增对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatchAdditionsCommad_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var batchAdditionsObjectDialog = new BatchAdditionsObjectDialog(this);
            batchAdditionsObjectDialog.Show();
        }

        /// <summary>
        /// 增加测评对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTestObjCommmad_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var securityDimensionEnum = GetSelectSecurityDimensionEnum();
            var zhibiaoStr = this.GetZhiBiaoStr();
            var record = RecordEntryEntity.CreateByZhiBiao(projectEntity.Id, securityDimensionEnum.Value, zhibiaoStr,this.Version);
            this.tableOfScores.Add(record);
        }

    

        public SecurityDimensionEnum? GetSelectSecurityDimensionEnum()
        {
            var cengMian = selectTag.Split('-')[0];
            var canParse = Enum.TryParse(typeof(SecurityDimensionEnum), cengMian, out var securityDimensionEnumObj);
            var securityDimensionEnum = securityDimensionEnumObj as SecurityDimensionEnum?;
            return securityDimensionEnum;
        }

        private void SelectClassCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SelectTestItemsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private float index = 0;

        /// <summary>
        /// 侧边栏切换不同的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SideMenu_SelectionChanged(object sender, HandyControl.Data.FunctionEventArgs<object> e)
        {
            if (e.Info.GetType()==typeof(MySIdeMenuItemNode))
            {
                this.selectItem = (e.Info as MySIdeMenuItemNode).ParentSideMenuItem;
            }
            else
            {
                this.selectItem = e.Info as SideMenuItem;
            }
           



            if (selectItem == null || selectItem.Tag == null)
            {
                return;
            }
            var oldTag = this.selectTag;
            //SheBei-远程管理通道安全
            selectTag = selectItem.Tag.ToString();
            var sec = GetSecurityDimensionEnum();
            var zhibiaoStr = GetZhiBiaoStr();
            



            if (!selectTag.Equals(oldTag))
            {
                
               
                if (sec!=null)
                {
                    auto=false;
                    

                    var zhibiaoItem = this.tableOfScores.FindRuleByName(sec.Value, zhibiaoStr);
                    this.SelectZhiBiaoItem=zhibiaoItem;
                    this.DataGridUI.ItemsSource = zhibiaoItem.RecordEntryEntitys;
                    
                    if (!string.IsNullOrEmpty(zhibiaoStr))
                    {
                        
                        if (zhibiaoItem!=null)
                        {
                            this.dataViewModel.TestObject = zhibiaoItem.TestObject;
                            this.dataViewModel.ZhiBiaoYaoQiu = zhibiaoItem.ZhiBiaoYaoQiu;
                            this.dataViewModel.ZhiBiaoQuanZhong = zhibiaoItem.ZhiBiaoQuanZhong;
                            this.dataViewModel.Score = zhibiaoItem.Score;
                        }
                        else
                        {
                            this.dataViewModel.TestObject="选择未定义";
                        }
        
                    }
                   
                    auto = true;

                }
               
               
                RefreshView();
            }

        }

        public void RefreshView()
        {
            if (this.SelectZhiBiaoItem!=null)
            {
                this.dataViewModel.Score = this.SelectZhiBiaoItem.Score;
                var sc = GetSelectSecurityDimensionEnum();
                if (sc != null)
                {
                    var cengmian = this.tableOfScores.FindCengMian(sc.Value);
                    this.dataViewModel.CengMianScore = cengmian.Score;
                    this.dataViewModel.CengMianHuanSuanScore = cengmian.Score* cengmian.CengMianQuanZhong;
                    this.dataViewModel.CengMianQuanZhong = cengmian.CengMianQuanZhong;
                    this.dataViewModel.CengMian = sc.ToString();

                }
               
              
            }
         
            //this.DataGridUI.CommitEdit();
            //this.DataGridUI.CommitEdit(DataGridEditingUnit.Row, true);

        }

        private void DataGrid_Unloaded(object sender, RoutedEventArgs e)
        {
            var grid = (DataGrid)sender;
            grid.CommitEdit(DataGridEditingUnit.Row, true);
        }





        private void DataGridUI_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            this.tableOfScores.UpdateScore();
            RefreshView();

        }

        private void DataGridUI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // this.selectItem = sender as SideMenuItem;
            // this.selectItem = sender as SideMenuItem;
            //var dg = sender as DataGrid;
            //Point aP = e.GetPosition(dg);

            //IInputElement obj = dg.InputHitTest(aP);
            //DependencyObject target = obj as DependencyObject;

            //while (target != null)
            //{
            //    if (target is DataGridRow)
            //    {
            //        break;
            //    }
            //    target = VisualTreeHelper.GetParent(target.FindVisualTreeRoot());
            //}

            //if (target == null)
            //{
            //    return;
            //}
         
            //var row=target as DataGridRow;
            //var data=row.DataContext as RecordEntryEntity;
            //EditDetailsWindow editDetailsWindow = new EditDetailsWindow(data);
          
            //editDetailsWindow.ShowDialog();
          
            //if (row.GetIndex() >= 0)
            //{
            //    // get row data
            //}
            //else
            //{
            //    return;
            //}

        }

        private void addTestObj(object sender, RoutedEventArgs e)
        {
           
            var  target=  ContextMenuService.GetPlacementTarget(LogicalTreeHelper.GetParent(sender as MenuItem)) as SideMenu;

            if (this.selectItem != null)
            {
                var parentMenuItem = target;
                var item = new MySIdeMenuItemNode();
                InputTextDialog inputTextDialog = new InputTextDialog( null);
                var resut = inputTextDialog.ShowDialog();
                if (resut != null && resut.Value)
                {
                    item.Header = inputTextDialog.value;
                    item.SetIcon("/Resources/Images/Item.png", 24, 24);
                    item.Tag="";
                    item.ParentSideMenuItem=this.selectItem;
                    this.selectItem.Items.Add(item);
                }

            }
          
           

        }
        private void editTestObj(object sender, RoutedEventArgs e)
        {
            var parentMenuItem = selectItem;
           
            InputTextDialog inputTextDialog = new InputTextDialog( parentMenuItem.Header.ToString());
            var resut = inputTextDialog.ShowDialog();
            if (resut != null && resut.Value)
            {
                parentMenuItem.Header = inputTextDialog.value;
                
            }
        }  
        
        private void delTestObj(object sender, RoutedEventArgs e)
        {

        }

        private void mySideMenu_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
           // this.selectItem=sender as SideMenuItem;
          
        }
    }
}