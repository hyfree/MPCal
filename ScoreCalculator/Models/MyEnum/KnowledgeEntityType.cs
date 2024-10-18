using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.MyEnum
{
    public enum KnowledgeEntityType
    {
        Other=0x00,
        /// <summary>
        /// 简单描述
        /// </summary>
        SimpleDescription = 0x01,
        /// <summary>
        /// 问题
        /// </summary>
        Question = 0x02,
        /// <summary>
        /// 建议
        /// </summary>
        Suggestion = 0x03,
        /// <summary>
        /// 记录
        /// </summary>
        Record = 0x04,
        /// <summary>
        /// 风险分析
        /// </summary>
        RiskAnalysis = 0x05
    }
}
