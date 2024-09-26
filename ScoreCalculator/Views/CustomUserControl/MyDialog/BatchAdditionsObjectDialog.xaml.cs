using ScoreCalculator.Models.Entity;
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
    public partial class BatchAdditionsObjectDialog : Window
    {
        IOPWindows markingSchemeWindow;
        public BatchAdditionsObjectDialog(IOPWindows markingSchemeWindow)
        {
            InitializeComponent();
            this.markingSchemeWindow = markingSchemeWindow;
        }

        public void SetWuLi()
        {
            this.wuli_SheFenJianBie.IsChecked = true;
            this.wuli_DianZiMenJinJiLu.IsChecked = true;
            this.wuli_ShiPinJianKongJiLu.IsChecked=true;
        }
        public void SetWangLuo()
        {
            this.wangluo_SheFenJianBie.IsChecked=true;
            this.wangluo_WangZhengXing.IsChecked=true;
            this.wangluo_JiMiXing.IsChecked=true;
            this.wangluo_FangWenKongZhi.IsChecked=true;
        }

        public void SetYingYong()
        {
            this.yingyong_ShenFenJianBie.IsChecked=true ;
            this.yingyong_ChuanShuJiMiXing.IsChecked=true ;
            this.yingyong_ChuanShuWanZhengXIng.IsChecked=true ;
            this.yingyong_CunChuJiMiXing.IsChecked=true ;
            this.yingyong_CunChuWanZhengXing.IsChecked=true ;
        }

        public void SetSheBei()
        {
            this.shebei_ShenFenJianBie.IsChecked=true;
            this.shebei_YuanChengGuanLiTongDao.IsChecked=true;
            this.shebei_FangWenKongZhi.IsChecked=true;
            this.shebei_RiZhi.IsChecked=true;
            this.shebei_ZhongYaoKeZhiXingChengXu.IsChecked=true;
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var name=this.MyNameTextBox.Text;
            var version = markingSchemeWindow.GetVersion();
            if (string.IsNullOrEmpty(name))
            {
                name = "未命名测试对象";

            }
            if (this.wuli_SheFenJianBie.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name,markingSchemeWindow.GetProjecInfo().Id,Models.MyEnum.SecurityDimensionEnum.WuLi, "身份鉴别", version));
            }
            if (this.wuli_DianZiMenJinJiLu.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.WuLi, "电子门禁记录数据存储完整性", version));
            }
            if (this.wuli_ShiPinJianKongJiLu.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.WuLi, "视频监控记录数据存储完整性", version));
            }


            if (this.wangluo_SheFenJianBie.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.WangLuo, "身份鉴别", version));
            }
            if (this.wangluo_WangZhengXing.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.WangLuo, "通信数据完整性", version));
            }

            if (this.wangluo_JiMiXing.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.WangLuo, "通信过程中重要数据的机密性", version));
            }
            if (this.wangluo_FangWenKongZhi.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.WangLuo, "网络边界访问控制信息的完整性", version));
            }


            if (this.shebei_ShenFenJianBie.IsChecked.Value)
            {

                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.SheBei, "身份鉴别", version));
            }
            if (this.shebei_YuanChengGuanLiTongDao.IsChecked.Value)
            {

                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.SheBei, "远程管理通道安全", version));
            }
            if (this.shebei_FangWenKongZhi.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.SheBei, "系统资源访问控制信息完整性", version));
            }
            if (this.shebei_RiZhi.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.SheBei, "日志记录完整性", version));
            }
            if (this.shebei_ZhongYaoKeZhiXingChengXu.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.SheBei, "重要可执行程序完整性、重要可执行程序来源真实性", version));
            }
            if (this.yingyong_ShenFenJianBie.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingYong, "身份鉴别", version));
            }

            if (this.yingyong_ChuanShuJiMiXing.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingYong, "重要数据传输机密性", version));
            }
            if (this.yingyong_ChuanShuWanZhengXIng.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingYong, "重要数据传输完整性", version));
            }

            if (this.yingyong_CunChuJiMiXing.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingYong, "重要数据存储机密性", version));
            }
            if (this.yingyong_CunChuWanZhengXing.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingYong, "重要数据存储完整性", version));
            }
            if (this.zhiDuMian.IsChecked.Value)
            {
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.GuanLi, "具备密码应用安全管理制度", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.GuanLi, "密钥管理规则", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.GuanLi, "建立操作规程", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.GuanLi, "定期修订安全管理制度", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.GuanLi, "明确管理制度发布流程", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.GuanLi, "制度执行过程记录留存", version));

                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.RenYuan, "了解并遵守密码相关法律法规和密码管理制度", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.RenYuan, "建立密码应用岗位责任制度", version));
                markingSchemeWindow. GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.RenYuan, "建立上岗人员培训制度", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.RenYuan, "定期进行安全岗位人员考核", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.RenYuan, "建立关键岗位人员保密制度和调离制度", version));


                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.JianShe, "制定密码应用方案", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.JianShe, "制定密钥安全管理策略", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.JianShe, "制定实施方案", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.JianShe, "投入运行前进行密码应用安全性评估", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.JianShe, "定期开展密码应用安全性评估及攻防对抗演习", version));


                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingJi, "应急策略", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingJi, "事件处置", version));
                markingSchemeWindow.GetTableOfScores().Add(RecordEntryEntity.CreateByZhiBiao(name, markingSchemeWindow.GetProjecInfo().Id, Models.MyEnum.SecurityDimensionEnum.YingJi, "向有关主管部门上报处置情况", version));
            }

            this.markingSchemeWindow.GetTableOfScores().UpdateScore();
            this.markingSchemeWindow.RefreshView();

        }
    }
}
