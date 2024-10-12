using HandyControl.Controls;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using NPOI.SS.Formula.Functions;
using NPOI.XSSF.Streaming.Values;

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
using ScoreCalculator.Views.Extensions;
using ScoreCalculator.Views.Windows;

using SixLabors.Fonts.Tables.AdvancedTypographic;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using static NPOI.HSSF.Util.HSSFColor;

namespace ScoreCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MarkingSchemeWindow: IOPWindows
    {
        public MarkingSchemeWindow(ProjectEntity projectEntity)
        {
            this.projectEntity = projectEntity;
            InitializeComponent();
        }

        public TableOfScores tableOfScores;
        public TableOfScores GetTableOfScores()
        {
            return tableOfScores;
        }

        /// <summary>
        /// 选择标签值  SheBei-远程管理通道安全
        /// </summary>
        private string selectTag = "";

        private ProjectEntity projectEntity;

        private ZhiBiaoItem SelectZhiBiaoItem;

        public string Version="base";
        RecordEntryEntity CopyRecordEntryEntity;
        List<RecordEntryEntity> CopyList;
        
        ListCollectionView listView;
        ObservableCollection<string> SubSystemNameList = new ObservableCollection< string> { "ALL" };
        string SubSystemName;

        public string GetVersion()
        {
            return Version;
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
        }

        private void InitDataBinding()
        {

            this.tableOfScores=new TableOfScores(this.projectEntity);
            this.tableOfScores.LoadData(this.projectEntity.Level);
            var list = new RecordEntryServices().Query(projectEntity.Id,"base");
            this.tableOfScores.LoadRecordEntryEntitys(list);
            this.tableOfScores.UpdateScore();
            this.JiSuanBiao.DataContext = tableOfScores;
            this.SubSystemComboBox.ItemsSource= SubSystemNameList;
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

            this.AddCommandBindings(new CommandBinding(TestObjectCommands.BatchAddTestWuLiObject), (sender, e) => {
                var batchAdditionsObjectDialog = new BatchAdditionsObjectDialog(this);
                batchAdditionsObjectDialog.SetWuLi();
                batchAdditionsObjectDialog.Show();
            });
            this.AddCommandBindings(new CommandBinding(TestObjectCommands.BatchAddTestSheBeiObject), (sender, e) => {
                var batchAdditionsObjectDialog = new BatchAdditionsObjectDialog(this);
                batchAdditionsObjectDialog.SetSheBei();
                batchAdditionsObjectDialog.Show();
            });
            this.AddCommandBindings(new CommandBinding(TestObjectCommands.BatchAddTestWangLuoObject), (sender, e) => {
                var batchAdditionsObjectDialog = new BatchAdditionsObjectDialog(this);
                batchAdditionsObjectDialog.SetWangLuo();
                batchAdditionsObjectDialog.Show();
            });
            this.AddCommandBindings(new CommandBinding(TestObjectCommands.BatchAddTestYingYongObject), (sender, e) => {
                var batchAdditionsObjectDialog = new BatchAdditionsObjectDialog(this);
                batchAdditionsObjectDialog.SetYingYong();
                batchAdditionsObjectDialog.Show();
            });

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
                if (item==null)
                {
                    item=this.DataGridUI.SelectedItem as RecordEntryEntity;

                }
                if (item!=null)
                {
                    this.tableOfScores.DeleteItem(item);
                    RefreshView();
                }
                Growl.Success("删除单个测试对象");

            });


            this.AddCommandBindings(new CommandBinding(ProjectCommands.CopyView), (send, e) =>
            {
              this.CopyList=GetViewData();
               
            });
            this.AddCommandBindings(new CommandBinding(ProjectCommands.PasteView), (send, e) =>
            {
                var securityDimensionEnum = GetSelectSecurityDimensionEnum();
                var zhibiaoStr = this.GetZhiBiaoStr();
                foreach (var item in this.CopyList)
                {
   

                    var record = item.Clone();
                    record.ZhiBiao=zhibiaoStr;
                    record.SecurityDimension=securityDimensionEnum.Value;
                    this.tableOfScores.Add(record);

                }
                RefreshView();
              


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
            this.AddCommandBindings(new CommandBinding(RecordEntryCommands.No), (sender, e) =>
            {
                RecordEntryEntity item = this.DataGridUI.SelectedItem as RecordEntryEntity;
                if (item != null)
                {
                    item.D = false;
                    item.A = false;
                    item.K = false;
                    RefreshView();
                    //CommitView();
                }
            });
            this.AddCommandBindings(new CommandBinding(RecordEntryCommands.D), (sender, e) =>
            {
                RecordEntryEntity item = this.DataGridUI.SelectedItem as RecordEntryEntity;
                if (item != null)
                {
                    item.D=true;
                    item.A = false;
                    item.K = false;
                    RefreshView();
                    //CommitView();
                }
            });
            this.AddCommandBindings(new CommandBinding(ProjectCommands.AddSubSystemName), (s, e) =>
            {
                var inputDig=new InputTextDialog("");
                var result = inputDig.ShowDialog();
                if (result!=null&&result.Value)
                {
                    var value=inputDig.value;
                    this.SubSystemNameList.Add(value);

                }

            });
            this.AddCommandBindings(new CommandBinding(ProjectCommands.DeleteSubSystemName), (s, e) =>
            {
                var inputDig = new InputTextDialog("");
                var result = inputDig.ShowDialog();
                if (result != null && result.Value)
                {
                    var value = inputDig.value;
                    this.SubSystemNameList.Remove(value);
                }

            });

            this.AddCommandBindings(new CommandBinding(ProjectCommands.ReplaceSubSystemName), (s, e) =>
            {
                var inputDig = new InputTwoTextDialog("");
                var result = inputDig.ShowDialog();
                if (result != null && result.Value)
                {
                    var value1 = inputDig.value;
                    var value2 = inputDig.value2;

                    this.SubSystemNameList.Remove(value1);
                    this.SubSystemNameList.Add(value2);

                    this.tableOfScores.ChangeSubNameByName(value1,value2);

                }

            });
            this.AddCommandBindings(new CommandBinding(ProjectCommands.ReloadSubSystemName), (s, e) =>
            {
                var sec = GetSecurityDimensionEnum();
                var zhibiaoStr = GetZhiBiaoStr();
                var zhibiaoItem = this.tableOfScores.FindRuleByName(sec.Value, zhibiaoStr);

                foreach (var item in zhibiaoItem.RecordEntryEntitys)
                {
                    if (string.IsNullOrEmpty(item.SubSystemName) || item.SubSystemName == "ALL")
                    {
                        item.SubSystemName = "未命名";

                    }
                    if (string.IsNullOrEmpty(item.TestObjectName) || item.TestObjectName == "ALL")
                    {
                        item.SubSystemName = "未命名";

                    }
                    if (!this.SubSystemNameList.Contains(item.SubSystemName))
                    {
                        this.SubSystemNameList.Add(item.SubSystemName);

                    }

                }
                Growl.Success("重载子系统指示器");

            });


            this.AddCommandBindings(new CommandBinding(RecordEntryCommands.DA), (sender, e) =>
            {
                RecordEntryEntity item = this.DataGridUI.SelectedItem as RecordEntryEntity;
                if (item != null)
                {
                    item.D = true;
                    item.A = true;
                    item.K=false;
                    RefreshView();
                   // CommitView();
                }
            });
            this.AddCommandBindings(new CommandBinding(RecordEntryCommands.DAK), (sender, e) =>
            {
                RecordEntryEntity item = this.DataGridUI.SelectedItem as RecordEntryEntity;
                if (item != null)
                {
                    item.D = true;
                    item.A = true;
                    item.K = true;
                    RefreshView();
                   // CommitView();
                }
            });
            this.AddCommandBindings(new CommandBinding(RecordEntryCommands.CopyContent), (sender, e) =>
            {
                this.CopyRecordEntryEntity=this.DataGridUI.SelectedItem as RecordEntryEntity;

            });
            this.AddCommandBindings(new CommandBinding(RecordEntryCommands.PasteContent), (sender, e) =>
            {
                if (this.CopyRecordEntryEntity!=null)
                {

                    var temp = this.DataGridUI.SelectedItem as RecordEntryEntity;
                    temp.SubSystemName =this.CopyRecordEntryEntity.SubSystemName;
                    temp.Suggest =this.CopyRecordEntryEntity.Suggest;
                    temp.Description = this.CopyRecordEntryEntity.Description;
                    temp.Question = this.CopyRecordEntryEntity.Question;
                    temp.D = this.CopyRecordEntryEntity.D;
                    temp.A = this.CopyRecordEntryEntity.A;
                    temp.K = this.CopyRecordEntryEntity.K;
                    temp.RA = this.CopyRecordEntryEntity.RA;
                    temp.RK = this.CopyRecordEntryEntity.RK;
                    temp.Score = this.CopyRecordEntryEntity.Score;
                    temp.TestStatus = this.CopyRecordEntryEntity.TestStatus;
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
            Growl.Success("重载项目成功");
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
            
            var record = RecordEntryEntity.CreateByZhiBiao(projectEntity.Id, securityDimensionEnum.Value, zhibiaoStr, GetSubSystemName(), this.Version);
            this.tableOfScores.Add(record);
        }
        string GetSubSystemName()
        {
            return this.SubSystemComboBox.SelectedItem as string;
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
            var selectItem = e.Info as SideMenuItem;
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
                    this.listView=new ListCollectionView(zhibiaoItem.RecordEntryEntitys);
                    this.listView.Filter= ListCollectionViewSource_Filter;
                    //this.listView.GroupDescriptions.Add(new PropertyGroupDescription("SubSystemName"));
                    this.DataGridUI.ItemsSource = this.listView;
                    //this.DataGridUI.ItemsSource = zhibiaoItem.RecordEntryEntitys;
                    foreach (var item in zhibiaoItem.RecordEntryEntitys)
                    {
                        if (string.IsNullOrEmpty(item.SubSystemName)  || item.SubSystemName=="ALL")
                        {
                            item.SubSystemName="未命名";

                        }
                        if (string.IsNullOrEmpty(item.TestObjectName) || item.TestObjectName == "ALL")
                        {
                            item.SubSystemName = "未命名";

                        }
                        if (!this.SubSystemNameList.Contains(item.SubSystemName))
                        {
                            this.SubSystemNameList.Add(item.SubSystemName);

                        }

                    }

                    //CollectionViewSource viewSrc = new CollectionViewSource(zhibiaoItem.RecordEntryEntitys);
                    //this.DataGridUI_CollectionViewSource.Source= zhibiaoItem.RecordEntryEntitys;
                   


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
        public List<RecordEntryEntity> GetViewData()
        {
            var sec = GetSecurityDimensionEnum();
            var zhibiaoStr = GetZhiBiaoStr();
            var zhibiaoItem = this.tableOfScores.FindRuleByName(sec.Value, zhibiaoStr);
            var list= zhibiaoItem.RecordEntryEntitys.ToList<RecordEntryEntity>();
            return list;
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
              //DataGridUI_CollectionViewSource.View.Refresh();

                

            }
           
               
            //this.DataGridUI.CommitEdit();
            //this.DataGridUI.CommitEdit(DataGridEditingUnit.Row, true);

        }
        public void CommitView()
        {
            this.DataGridUI.CommitEdit();
            this.DataGridUI.CommitEdit(DataGridEditingUnit.Row, true);
        }

        private void DataGrid_Unloaded(object sender, RoutedEventArgs e)
        {
            var grid = (DataGrid)sender;
            grid.CommitEdit(DataGridEditingUnit.Row, true);
        }
        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            this.listView.GroupDescriptions.Clear();
            RecordEntryEntity recode = e.Item as RecordEntryEntity;
            var subName = GetSubSystemName();
            if (recode != null && recode.SubSystemName != null && !string.IsNullOrEmpty(subName))
            {
                if (subName.Equals("ALL"))
                {
                    e.Accepted = true;
                   
                    return;

                }
                {
                    if (recode.SubSystemName.Equals(subName))
                    {
                        e.Accepted = true;
                        return;
                    }
                    else
                    {
                        e.Accepted = false;
                        return;
                    }
                }
            }
            e.Accepted = true;
            return;

        }
        private bool ListCollectionViewSource_Filter(object sender)
        {

            RecordEntryEntity recode = sender as RecordEntryEntity;
            var subName = GetSubSystemName();
            if (recode != null && recode.SubSystemName != null && !string.IsNullOrEmpty(subName))
            {
                if (subName.Equals("ALL"))
                {
                   
                    return true;

                }
                {
                    if (recode.SubSystemName.Equals(subName))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;

        }





        private void DataGridUI_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            this.tableOfScores.UpdateScore();
            RefreshView();

        }

        private void DataGridUI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item=this.DataGridUI.SelectedItem as RecordEntryEntity;
            if (item!=null)
            {
                EditDetailsWindow editDetailsWindow = new EditDetailsWindow(item);
                editDetailsWindow.ShowDialog();
            }
            else
            {
                var securityDimensionEnum = GetSelectSecurityDimensionEnum();
                var zhibiaoStr = this.GetZhiBiaoStr();
                if (!string.IsNullOrEmpty(zhibiaoStr))
                {
                    var record = RecordEntryEntity.CreateByZhiBiao(projectEntity.Id, securityDimensionEnum.Value, zhibiaoStr, this.Version);
                    this.tableOfScores.Add(record);

                }
              
            }
           

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

        private void SubSystemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshView();

            if (this.listView != null)
            {

                this.listView.Refresh();
            }
        }
    }
}