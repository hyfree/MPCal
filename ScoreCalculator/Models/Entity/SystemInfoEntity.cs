using ScoreCalculator.Models.MyEnum;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.Entity
{
    /// <summary>
    /// 子系统信息
    /// </summary>
    public class SystemInfoEntity
    {
        public long Id { get; set; }
        /// <summary>
        /// 被测系统名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否子系统
        /// </summary>
        public bool IsSubsystem{ get; set; }
        /// <summary>
        /// 父系统名称
        /// </summary>
        public long ParentSystem { get; set; }
        /// <summary>
        /// 系统简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 被测单位
        /// </summary>
        public long CompanyId { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Provinces { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 得分
        /// </summary>
        public double Score { get; set; }

        public SystemLevel GetSystemLevel()
        {
            switch (Level)
            {
                case 1:
                    return SystemLevel.Level1;
                case 2: return SystemLevel.Level2;
                    case 3: return SystemLevel.Level3;
                    case 4: return SystemLevel.Level4;
                    
            }
            throw new NotImplementedException("Level is Error");
        }

    }
}
