using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.MyEnum
{
    /// <summary>
    /// 网络安全等级评估
    /// </summary>
    public enum NetworkSecurityLevelAssessmentEnum
    {
        /// <summary>
        /// 未评估
        /// </summary>
        NotAssessed = 0,
        /// <summary>
        /// 评估中
        /// </summary>
        Assessing = 1,
        /// <summary>
        /// 评估完成
        /// </summary>
        Assessed = 2
    }
}
