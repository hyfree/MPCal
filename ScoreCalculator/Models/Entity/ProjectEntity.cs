using ScoreCalculator.Models.MyEnum;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.Entity
{
    public class ProjectEntity : BaseEntity
    {
       
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; }


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
        /// 包含的系统
        /// </summary>
        public List<SystemInfoEntity> SystemInfo { get; set; }

    }
}
