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

namespace ScoreCalculator.Views.Windows
{
    /// <summary>
    /// AboutWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            this.about.Text= """"
                商用密码应用安全性测评计算工具
                MPScoreCalculator V0.1
                使用MPScoreCalculator计算分数和洞察系统风险 ！
                开源地址: https://github.com/hyfree/MPCal
                开源协议：GPLv3协议
                问题反馈：https://github.com/hyfree/MPScoreCalculator/issues
                邮箱：wangxianqiangcn@foxmail.com，来信标题请注明MPScoreCalculator
                """";
        }
    }
}
