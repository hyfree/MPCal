using ScoreCalculator.Models.Entity;

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
    public partial class BatchAdditionsObjectDialog : Window
    {
        MarkingSchemeWindow markingSchemeWindow;
        public BatchAdditionsObjectDialog(MarkingSchemeWindow markingSchemeWindow)
        {
            InitializeComponent();
            this.markingSchemeWindow = markingSchemeWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var name=this.MyNameTextBox.Text;
            if (string.IsNullOrEmpty(name))
            {
                name = "未命名测试对象";

            }
            if (this.wuli_SheFenJianBie.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name,markingSchemeWindow.GetSystemInfo().Id,Models.MyEnum.SecurityDimensionEnum.WuLi, "身份鉴别"));
            }
            if (this.wuli_DianZiMenJinJiLu.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.WuLi, "电子门禁记录数据存储完整性"));
            }
            if (this.wuli_ShiPinJianKongJiLu.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.WuLi, "视频监控记录数据存储完整性"));
            }


            if (this.wangluo_SheFenJianBie.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.WangLuo, "身份鉴别"));
            }
            if (this.wangluo_WangZhengXing.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.WangLuo, "通信数据完整性"));
            }

            if (this.wangluo_JiMiXing.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.WangLuo, "通信过程中重要数据的机密性"));
            }
            if (this.wangluo_FangWenKongZhi.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.WangLuo, "网络边界访问控制信息的完整性"));
            }
            if (this.shebei_ShenFenJianBie.IsChecked.Value)
            {

                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.SheBei, "身份鉴别"));
            }
            if (this.shebei_YuanChengGuanLiTongDao.IsChecked.Value)
            {

                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.SheBei, "远程管理通道安全"));
            }
            if (this.shebei_FangWenKongZhi.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.SheBei, "系统资源访问控制信息完整性"));
            }
            if (this.shebei_RiZhi.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.SheBei, "日志记录完整性"));
            }
            if (this.shebei_ZhongYaoKeZhiXingChengXu.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.SheBei, "重要可执行程序完整性、重要可执行程序来源真实性"));
            }
            if (this.yingyong_ShenFenJianBie.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingYong, "YingYong-身份鉴别"));
            }

            if (this.yingyong_ChuanShuJiMiXing.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingYong, "重要数据传输机密性"));
            }
            if (this.yingyong_ChuanShuWanZhengXIng.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingYong, "重要数据传输完整性"));
            }

            if (this.yingyong_CunChuJiMiXing.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingYong, "重要数据存储机密性"));
            }
            if (this.yingyong_CunChuWanZhengXing.IsChecked.Value)
            {
                markingSchemeWindow.tableOfScores.Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetSystemInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingYong, "重要数据存储完整性"));
            }

            this.markingSchemeWindow.tableOfScores.UpdateScore();
            this.markingSchemeWindow.RefreshView();

        }
    }
}
