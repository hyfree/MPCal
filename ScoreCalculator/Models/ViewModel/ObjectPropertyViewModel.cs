using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;

namespace ScoreCalculator.Models.ViewModel
{
    public class ObjectPropertyViewModel
    {
        [Category("A测评对象概述")]
        public string 被测对象名称 { get; set; }

       
        [Category("B评分情况")]
        public Exposures 风险等级 { get; set; }

        [Category("B评分情况")]
        public double DAK分数 { get; set; }

        [Category("B评分情况")]
        public double RA { get; set; }

        [Category("B评分情况")]
        public double RK { get; set; }

        [Category("B评分情况")]
        public double 得分 { get; set; }

        [Category("B评分情况")]
        public TestStatus 测评结论 { get; set; }

        [Category("被测系统情况")]
        public string Subsystems { get; set; }




    }
}
