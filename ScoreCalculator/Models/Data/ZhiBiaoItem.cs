using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.Data
{
    /// <summary>
    /// 指标项
    /// </summary>
    public class ZhiBiaoItem
    {
        /// <summary>
        /// 测试对象
        /// </summary>
        public string TestObject { get; set; } = "未定义测试对象";
        
        /// <summary>
        /// 指标要求
        /// </summary>
        public string ZhiBiaoYaoQiu { get; set; } = "未定义指标要求";
        /// <summary>
        /// 指标权重
        /// </summary>
        public double ZhiBiaoQuanZhong { get;set; }
        /// <summary>
        /// 高风险判定指引的指标
        /// </summary>
        public bool HighRisk { get; set; }=false;
        /// <summary>
        /// 单元得分 后计算
        /// </summary>
        public double Score { get;set;}
        /// <summary>
        /// 丢分 后计算
        /// </summary>
        public double LoseScore { get;set;}

        public ObservableCollection<RecordEntryEntity> RecordEntryEntitys { get; set; }=new ObservableCollection<RecordEntryEntity>();


        /// <summary>
        /// 测试状态
        /// </summary>
        public TestStatus TestStatus { get; set; }

        /// <summary>
        /// 风险等级
        /// </summary>
        public Exposures Exposures { get; set; }=Exposures.None;

        public void UpdateScore(SystemLevel level)
        {
            foreach (var item in RecordEntryEntitys)
            {
                item.UpDate(level);

            }
            if (this.RecordEntryEntitys.Any())
            {
                //计算指标平均分
                this.Score = JiSuanZhiBiaoAverage();
            }
            else
            {
             
            }
            //计算风险
            JiSuanFengXian();
            //计算测评状态
            JiSuanZhuangTai();


        }

        /// <summary>
        /// 计算分数，比如身份鉴别的平均分
        /// </summary>
        /// <param name="list"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public double JiSuanZhiBiaoAverage()
        {
            var data2 = (from x in RecordEntryEntitys
                        where x.TestStatus!=TestStatus.NA
                         select x.Score).ToArray();
            if (data2.Any())
            {
                var ave = data2.Average();
                return ave;
            }
            return 0;

        }
       /// <summary>
       /// 计算指标风险
       /// </summary>
        public void JiSuanFengXian()
        {
            int high = 0;
            int zhong = 0;
            int di = 0;

            foreach (var item in RecordEntryEntitys)
            {
                if (item.Exposures==Exposures.High)
                {
                    this.Exposures=Exposures.High;
                }
                if (item.Exposures==Exposures.Medium && this.Exposures != Exposures.High)
                {
                    this.Exposures = Exposures.Medium;

                }
                if (item.Exposures==Exposures.Low)
                {
                    if (this.Exposures==Exposures.None)
                    {
                        this.Exposures=Exposures.Low;
                        continue;
                    }

                }


            }
            if (this.HighRisk==false&& this.Exposures==Exposures.High)
            {
                this.Exposures = Exposures.Medium;
            }
            if (this.HighRisk==false)
            {
                foreach (var item in this.RecordEntryEntitys)
                {
                    if (item.Exposures==Exposures.High)
                    {
                        item.Exposures = Exposures.Medium;

                    }

                }
            }

        }

        public void JiSuanZhuangTai()
        {

          var fuHe=this.RecordEntryEntitys.Count(b=>b.TestStatus==TestStatus.FULL);
          var buFenFuHe=this.RecordEntryEntitys.Count(b=>b.TestStatus==TestStatus.PART);
          var buFuHe=this.RecordEntryEntitys.Count(b=>b.TestStatus==TestStatus.NOT);
          var buShiYong=this.RecordEntryEntitys.Count(b=>b.TestStatus==TestStatus.NA);
            if (fuHe>0 && buFenFuHe==0 && buFenFuHe==0 )
            {
                this.TestStatus = TestStatus.FULL;
                return;
            }
            if (buFuHe > 0 && buFenFuHe==0 && fuHe==0)
            {
                this.TestStatus = TestStatus.NOT;
                return;

            }
            if (fuHe==0&& buFenFuHe==0&& buFuHe==0)
            {
                this.TestStatus = TestStatus.NA;
                return;
            }
            this.TestStatus=TestStatus.PART;

        }
        /// <summary>
        /// Question合并
        /// </summary>
        /// <returns></returns>
        public string QuestionMerge()
        {
            StringBuilder sb=new StringBuilder();
            foreach (var item in this.RecordEntryEntitys)
            {
                if (item.Exposures!=Exposures.None)
                {
                    sb.Append($"{item.TestObjectName}{item.Question};");
                }
            }
            return sb.ToString();

        }


        public int GetCounterByTestStatus(TestStatus testStatus)
        {
            return this.RecordEntryEntitys.Count(b => b.TestStatus == testStatus);
        }
        public int GetCounterByExposures(Exposures exposures)
        {
            return this.RecordEntryEntitys.Count(b => b.Exposures == exposures);
        }
    }
}
