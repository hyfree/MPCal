


using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.Data
{
    public class CalculationTableData
    {
        /// <summary>
        /// 层面权重
        /// </summary>
        public double CengMianQuanZhong { get; set; }
        public string CengMian { get; set; }
        public List<ZhiBiaoItem> Rules { get; set; }
        /// <summary>
        /// 安全层面得分
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// 层面换算分数
        /// </summary>
        public double HuanSuanScore { get; set; }
        /// <summary>
        /// 丢失分数
        /// </summary>
        public double LostScore { get; set; }

        public TestStatus TestStatus { get; set; }


        public static CalculationTableData ReadData(SecurityDimensionEnum securityDimensionEnum,SystemLevel level)
        {
            var cengji = Enum.GetName(securityDimensionEnum);
            var levelStr=Enum.GetName(level);

            var json= File.ReadAllText($"Data/{levelStr}/CalculationTable/{cengji}.json");
            var config=  System.Text.Json.JsonSerializer.Deserialize<CalculationTableData>(json);
            return config;
        }
        public static Dictionary<SecurityDimensionEnum, CalculationTableData> ReadAllData(SystemLevel level)
        {
            Dictionary<SecurityDimensionEnum,CalculationTableData> data=new Dictionary<SecurityDimensionEnum, CalculationTableData> ();
            data.Add(SecurityDimensionEnum.WuLi,ReadData(SecurityDimensionEnum.WuLi, level));
            data.Add(SecurityDimensionEnum.WangLuo,ReadData(SecurityDimensionEnum.WangLuo, level));
            data.Add(SecurityDimensionEnum.SheBei,ReadData(SecurityDimensionEnum.SheBei, level));
            data.Add(SecurityDimensionEnum.YingYong,ReadData(SecurityDimensionEnum.YingYong, level));

            data.Add(SecurityDimensionEnum.GuanLi,ReadData(SecurityDimensionEnum.GuanLi, level));
            data.Add(SecurityDimensionEnum.RenYuan,ReadData(SecurityDimensionEnum.RenYuan, level));
            data.Add(SecurityDimensionEnum.JianShe,ReadData(SecurityDimensionEnum.JianShe, level));
            data.Add(SecurityDimensionEnum.YingJi,ReadData(SecurityDimensionEnum.YingJi, level));

            return data;
        }

        public ZhiBiaoItem? FindByName(string name)
        {
            if (this.Rules.Exists(b=>b.TestObject.Equals(name)))
            {
                return  this.Rules.Where(b=>b.TestObject.Equals(name)).First();

            }
            return null;
        }
        public void Add(RecordEntryEntity recordEntryEntity)
        {
            var rule = this.Rules.Find(b => b.TestObject.Equals(recordEntryEntity.ZhiBiao));
            if (rule == null)
            {
                throw new Exception(" Add(RecordEntryEntity recordEntryEntity) is Error");
            }
            rule.RecordEntryEntitys.Add(recordEntryEntity);
        }
        public ZhiBiaoItem findRuleByName(string name)
        {
            return this.Rules.Find(b => b.TestObject.Equals(name));
        }


        public void UpdateScore(SystemLevel level)
        {
            foreach (var rule in Rules)
            {
                //分别计算每条直白的分数
                rule.UpdateScore(level);
            }
            //计算本层面分数
            CalculateScore();

            var any=this.Rules.Any(b=>b.TestStatus!=TestStatus.NA);
            if (!any)
            {
                this.TestStatus = TestStatus.NA;
            }
            else
            {
                var full = this.Rules.Count(b => b.TestStatus == TestStatus.FULL);
                var part = this.Rules.Count(b => b.TestStatus == TestStatus.PART);
                var not = this.Rules.Count(b => b.TestStatus == TestStatus.NOT);
                if (full > 0 && part == 0 && not == 0)
                {
                    this.TestStatus = TestStatus.FULL;
                }
                if (not > 0)
                {
                    this.TestStatus = TestStatus.NOT;

                }
                else
                {
                    this.TestStatus = TestStatus.PART;
                }
            }
         


        }
        /// <summary>
        /// 计算加权平均数
        /// </summary>
        /// <returns></returns>
        public double SUMPRODUCT()
        {
            double sum = 0;
            double quan=0;
            foreach (var item in this.Rules)
            {
                if (item.RecordEntryEntitys.Any())
                {
                    sum += item.ZhiBiaoQuanZhong * item.Score;
                    quan += item.ZhiBiaoQuanZhong;

                }
            }
            double result= sum/quan;
            return result;
        }
        /// <summary>
        /// 计算本层面分数
        /// </summary>
        public void CalculateScore()
        {
            //计算加权平均数
            var sumproduct=SUMPRODUCT();
    
            this.Score = sumproduct;
            this.HuanSuanScore = sumproduct * CengMianQuanZhong;
            this.LostScore=this.CengMianQuanZhong-Score;
        }
        /// <summary>
        /// 计算项目数量
        /// </summary>
        /// <param name="testStatus"></param>
        /// <returns></returns>
        public int GetCounterByTestStatus(TestStatus testStatus)
        {
            int counter = 0;
            foreach (var item in this.Rules) 
            {
                counter += item.GetCounterByTestStatus(testStatus);
            }
            return counter;
        }
        /// <summary>
        /// 计算风险数量
        /// </summary>
        /// <param name="exposures"></param>
        /// <returns></returns>
        public int GetCounterByExposures(Exposures exposures)
        {
            int counter = 0;
            foreach (var item in this.Rules)
            {
                counter += item.GetCounterByExposures(exposures);
            }
            return counter;
        }

    }
}
