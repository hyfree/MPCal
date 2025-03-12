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
    public class TestedCompanyInformationEntity: BaseEntity
    {

       
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 单位地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// 所属省部密码管理部门
        /// </summary>
        public string MiMaju { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string ContactPersonName { get; set; }
        /// <summary>
        /// 联系人职务
        /// </summary>
        public string ContactPersonDuties { get; set; }
        /// <summary>
        /// 联系人部门
        /// </summary>
        public string ContactPersonDepartment { get; set; }
        /// <summary>
        /// 联系人办公电话
        /// </summary>
        public string ContactPersonOfficePhone { get; set; }
        /// <summary>
        /// 联系人移动电话
        /// </summary>
        public string ContactPersonMobilePhone { get; set; }
        /// <summary>
        /// 联系人移动电话
        /// </summary>
        public string ContactPersonEmail { get; set; }



    }
}
