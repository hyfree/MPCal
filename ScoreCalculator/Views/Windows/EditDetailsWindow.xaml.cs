using NPOI.SS.Formula.Functions;

using ScoreCalculator.Models.Data;
using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;
using ScoreCalculator.Services;
using ScoreCalculator.Views.Commands;
using ScoreCalculator.Views.CustomUserControl.MyDialog;

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

namespace ScoreCalculator.Views.Windows
{
    /// <summary>
    /// EditDetailsWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditDetailsWindow 
    {
        KnowledgeEntityServices knowledgeEntityServices = new KnowledgeEntityServices();
        ListCollectionView listView;
        public ObservableCollection<KnowledgeEntity> obs { get; set; } = new ObservableCollection<KnowledgeEntity>();
        public RecordEntryEntity MyRecordEntryEntity;

        public EditDetailsWindow(RecordEntryEntity RecordEntryEntity)
        {
          
            this.MyRecordEntryEntity = RecordEntryEntity;
            this.DataContext = MyRecordEntryEntity;
            InitializeComponent();
            WindowState=WindowState.Maximized;


        }
        private void Window_Initialized(object sender, EventArgs e)
        {

            //  this.TabControlUI.DataContext = this.RecordEntryEntity;
            InitCommandBindings();
            InitView();
            Load();



        }

        void InitView()
        {
            if (this.MyRecordEntryEntity!=null)
            {
                this.cengmian_comboBox.SelectedItem=this.MyRecordEntryEntity.SecurityDimension;
                this.zhibiao_ComboBox.SelectedItem=this.MyRecordEntryEntity.ZhiBiao;

            }
        }

      
        private void InitCommandBindings()
        {
            this.AddCommandBindings(new CommandBinding(KnowledgeCommand.CopyContent), (sender, e) =>
            {
                var item = this.DataGridUI.SelectedItem as KnowledgeEntity;
                if (item != null)
                {
                    Clipboard.SetDataObject(item.Content);
                }

            });
            this.AddCommandBindings(new CommandBinding(ApplicationCommands.Close), (sender, e) =>
            {

                this.Close();
            });
        }
        public void Load()
        {
            var data = knowledgeEntityServices.GetALL();
            this.obs.Clear();
            foreach (KnowledgeEntity entity in data)
            {
                this.obs.Add(entity);
            }
            this.listView = new ListCollectionView(obs);
            this.listView.Filter = ListCollectionViewSource_Filter;
            this.DataGridUI.ItemsSource = this.listView;
        }
        private void AddCommandBindings(CommandBinding commandBinding, ExecutedRoutedEventHandler executed)
        {
            commandBinding.Executed += executed;
            this.CommandBindings.Add(commandBinding);
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.cengmian_comboBox.SelectedItem == null)
            {
                return;
            }
            var cengmian = (SecurityDimensionEnum)this.cengmian_comboBox.SelectedItem;
            var data = CalculationTableData.ReadData(cengmian, SystemLevel.Level3);
            //var knowledgeEntityType = (KnowledgeEntityType)this.zhibiao_ComboBox.SelectedItem;

            var list = new List<string>();
            this.zhibiao_ComboBox.Items.Clear();
            foreach (var item in data.Rules)
            {
                var zhibiao = item.TestObject.ToString();
                this.zhibiao_ComboBox.Items.Add(zhibiao);
            }

            var feature_data = FeatureData.GetFeatureData(cengmian);
            this.feature_ComboBox.Items.Clear();
            foreach (var feature in feature_data)
            {
                this.feature_ComboBox.Items.Add(feature);
            }

            Load();

        }

        private bool ListCollectionViewSource_Filter(object sender)
        {

            KnowledgeEntity entity = sender as KnowledgeEntity;
            if (this.cengmian_comboBox.SelectedItem == null)
            {
                return true;

            }
            if (this.zhishi_comboBox.SelectedItem != null)
            {
                var knowledgeEntityType = (KnowledgeEntityType)this.zhishi_comboBox.SelectedItem;
                if (entity.KnowledgeEntityType != knowledgeEntityType)
                {
                    return false;
                }
            }


            SecurityDimensionEnum cengmian = (SecurityDimensionEnum)this.cengmian_comboBox.SelectedItem;
            if (entity.SecurityDimensionEnum != cengmian)
            {
                return false;
            }
            var zhibiao = (string)this.zhibiao_ComboBox.SelectedItem;
            if (!string.IsNullOrEmpty(zhibiao))
            {
                if (entity.ZhiBiao != zhibiao)
                {
                    return false;
                }
            }

            var feature = (string)this.feature_ComboBox.SelectedItem;
            if (!string.IsNullOrEmpty(feature))
            {
                if (entity.Feature != feature)
                {
                    return false;
                }
            }

            return true;

        }
       
    }
}
