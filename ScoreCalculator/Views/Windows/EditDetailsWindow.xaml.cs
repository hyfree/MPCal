using NPOI.SS.Formula.Functions;

using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;
using ScoreCalculator.Services;

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
    public partial class EditDetailsWindow : Window
    {
        KnowledgeEntityServices knowledgeEntityServices = new KnowledgeEntityServices();
        ListCollectionView listView;
        public ObservableCollection<KnowledgeEntity> obs { get; set; } = new ObservableCollection<KnowledgeEntity>();


        public EditDetailsWindow(RecordEntryEntity RecordEntryEntity)
        {
            InitializeComponent();
            this.MyRecordEntryEntity = RecordEntryEntity;
            this.DataContext = MyRecordEntryEntity;

        }
        private void Window_Initialized(object sender, EventArgs e)
        {

            //  this.TabControlUI.DataContext = this.RecordEntryEntity;

        }
        public RecordEntryEntity MyRecordEntryEntity ;
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
