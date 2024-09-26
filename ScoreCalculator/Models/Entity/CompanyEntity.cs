using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.Entity
{
    /// <summary>
    /// 被测单位信息
    /// </summary>
    public class CompanyEntity: BaseEntity
    {

       
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Name { get; set; }
    }
}
