using ScoreCalculator.Models.MyEnum;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.Entity
{
    /// <summary>
    /// 系统信息
    /// </summary>
    public class SystemInfoEntity: BaseEntity
    {
        

        /// <summary>
        /// 项目id
        /// </summary>
        public long ProjectId { get; set; }
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
        public SystemLevel Level { get; set; }
        /// <summary>
        /// 得分
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// 测试记录
        /// </summary>
        public List<RecordEntryEntity> Records { get; set; }



    }
}
