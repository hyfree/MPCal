using ScoreCalculator.Models.Data;
using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;
using ScoreCalculator.Services;
using ScoreCalculator.Views.Windows;

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

namespace ScoreCalculator.Views.CustomUserControl.MyDialog
{
    /// <summary>
    /// BatchAdditionsObjectDialog.xaml 的交互逻辑
    /// </summary>
    public partial class BatchAdditionsKnowledgeDialog : Window
    {
        KnowledgeManagerWindow knowledgeManagerWindow;

        public BatchAdditionsKnowledgeDialog(KnowledgeManagerWindow knowledgeManagerWindow)
        {
            InitializeComponent();
            this.knowledgeManagerWindow = knowledgeManagerWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var name = MyNameTextBox.Text;
            var cengmian = (SecurityDimensionEnum)this.cengmian_comboBox.SelectedItem;
            var testStatus = (TestStatus)this.testStatus_ComboBox.SelectedItem;
            var zhibiao=(string)this.zhibiao_ComboBox.SelectedItem;
            var feature = (string)this.feature_ComboBox.SelectedItem;
            var content=this.ContentBox.Text;
            var tag=this.tagBox.Text;
            var entity = new KnowledgeEntity()
            {
                Id = SnowFlakeNetService.FactoryGeInstance().NextId(),
                Title=name,
                SecurityDimensionEnum = cengmian,
                Feature = feature,
                ZhiBiao = zhibiao,
                Tag = tag,
                TestStatus = testStatus,
                Content = content
            };
            this.knowledgeManagerWindow.AddEntity(entity);

        }
        KnowledgeEntity knowledge;
        public void SetEntity(KnowledgeEntity knowledge)
        {
            this.knowledge = knowledge;
            MyNameTextBox.Text=knowledge.Title;
            cengmian_comboBox.SelectedItem = knowledge.SecurityDimensionEnum;
            testStatus_ComboBox.SelectedItem = knowledge.TestStatus;
            zhibiao_ComboBox.SelectedItem = knowledge.ZhiBiao;
            feature_ComboBox.SelectedItem = knowledge.Feature;
            ContentBox.Text = knowledge.Content;
            tagBox.Text = knowledge.Tag;


        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cengmian = (SecurityDimensionEnum)this.cengmian_comboBox.SelectedItem ;
            var data = CalculationTableData.ReadData(cengmian, SystemLevel.Level3);

            var list = new List<string>();
            this.zhibiao_ComboBox.Items.Clear();
            foreach (var item in data.Rules)
            {
                var zhibiao = item.ZhiBiaoYaoQiu.ToString();
                this.zhibiao_ComboBox.Items.Add(zhibiao);
            }

            var feature_data = FeatureData.GetFeatureData(cengmian);
            this.feature_ComboBox.Items.Clear();
            foreach (var feature in feature_data)
            {
                this.feature_ComboBox.Items.Add(feature);
            }



        }
    }
}
