using ScoreCalculator.Models.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.ViewModel
{
    public class DataViewModel:ViewModelBase
    {
        /// <summary>
        /// 测试对象
        /// </summary>
        public string _TestObject;
        /// <summary>
        /// 指标要求
        /// </summary>
        public string _ZhiBiaoYaoQiu ;
        /// <summary>
        /// 指标权重
        /// </summary>
        public double _ZhiBiaoQuanZhong;
        /// <summary>
        /// 分数
        /// </summary>
        public double? _Score;
        /// <summary>
        /// 层面分数
        /// </summary>
        private double? _CengMianScore;
        private double? _CengMianHuanSuanScore;
        private double? _CengMianQuanZhong;
        private string? _CengMian;


        public string TestObject
        {
            get { return _TestObject;}
            set { SetProperty(ref _TestObject,value);}
        }
        public string ZhiBiaoYaoQiu
        {
            get { return _ZhiBiaoYaoQiu; }
            set { SetProperty(ref _ZhiBiaoYaoQiu, value); }
        }
        public double ZhiBiaoQuanZhong
        {
            get { return _ZhiBiaoQuanZhong; }
            set { SetProperty(ref _ZhiBiaoQuanZhong, value); }
        }

        public double? Score
        {
            get { return _Score; }
            set { SetProperty(ref _Score, value); }
        }

        public double? CengMianScore
        {
            get { return _CengMianScore; }
            set { SetProperty(ref _CengMianScore, value); }
        }
        public double? CengMianHuanSuanScore
        {
            get { return _CengMianHuanSuanScore; }
            set { SetProperty(ref _CengMianHuanSuanScore, value); }
        }
        public double? CengMianQuanZhong
        {
            get { return _CengMianQuanZhong; }
            set { SetProperty(ref _CengMianQuanZhong, value); }
        }
        public string? CengMian
        {
            get { return _CengMian; }
            set { SetProperty(ref _CengMian, value); }
        }


    }
}
