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
        public string ProjectName { get; set; }
        public string SystemName { get; set; }

        /// <summary>
        /// 系统简介
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 被测单位
        /// </summary>
        public TestedCompanyInformationEntity? TestedCompanyInformation { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string? Provinces { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        public int? Year { get; set; }
       
        /// <summary>
        /// 得分
        /// </summary>
        public double? Score { get; set; }
        /// <summary>
        /// 包含的系统
        /// </summary>
        public List<SystemInfoEntity>? SystemInfo { get; set; }

        /// <summary>
        /// 是否为关键基础设施
        /// </summary>
        public bool? CriticalInfrastructure { get;set; }
        /// <summary>
        /// 安全保护部门
        /// </summary>
        public string? SecurityAndProtectionUnits { get;set; }

        /// <summary>
        /// 级别
        /// </summary>
        public SystemLevel Level { get; set; }

        public int? SystemLevel_S { get;set; }
        public int? SystemLevel_A { get; set; }
        public int? SystemLevel_G { get; set; }
        /// <summary>
        /// 备案证明编号
        /// </summary>
        public string? FilingCertificateNo { get; set; }
        /// <summary>
        /// 是否为系统级别一致
        /// </summary>
        public bool IsEquipoiseSystemLevel { get;set; }
        /// <summary>
        /// 系统级别说明
        /// </summary>
        public string? SystemLevelDescription { get;set; }
        /// <summary>
        /// 是否定级
        /// </summary>
        public bool? IsClassifiedOrNot { get;set; }
        /// <summary>
        /// 网络安全等级评估
        /// </summary>
        public NetworkSecurityLevelAssessmentEnum networkSecurityLevelAssessmentEnum { get; set; }


        /// <summary>
        /// 网络安全测评机构
        /// </summary>
        public string? NetworkSecurityAssessmentOrganization { get; set; }
        /// <summary>
        /// 等保测评时间
        /// </summary>
        public string? NetworkSecurityAssessmentDate { get; set; }
        /// <summary>
        ///等保测评结论
        /// </summary>
        public string? NetworkSecurityAssessmentResult { get; set; }
        /// <summary>
        /// 服务范围
        /// </summary>
        public List<FuWuFanWei>? fuWuFanWeis { get; set; }
        /// <summary>
        /// 服务领域
        /// </summary>
        public List<FuWuLingYu>? fuWuLingYu { get; set; }

        /// <summary>
        /// 服务对象
        /// </summary>
        public FuWuDuiXiang? fuWuDuiXiang { get; set; }

        /// <summary>
        /// 服务范围
        /// </summary>
        public List<FuGaiFanWei>? FuGaiFanWei { get;set; }
        /// <summary>
        /// 网络性质
        /// </summary>
        public List<WangLuoXingZhi>? WangLuoXingZhi { get;set; }

        /// <summary>
        /// 用户数量
        /// </summary>
        public string? YongHuShuLiang { get; set; }  

        /// <summary>
        /// 是否投入运行
        /// </summary>
        public bool? IsTouRuYunXing { get; set; }
        /// <summary>
        /// 投入运行时间
        /// </summary>
        public string? TouRuYunXingShiJian { get; set; }
        /// <summary>
        /// 投入运行时间
        /// </summary>
        public string? TouRuYunXingQiangKuang { get; set; }

        /// <summary>
        /// 系统互联情况
        /// </summary>
        public List<XiTongHuLian>? XiTongHuLian { get; set; }

        /// <summary>
        /// 系统互联名称
        /// </summary>
        public string? XiTongHuLianMingCheng { get; set; }


        /// <summary>
        /// 是否依赖云平台
        /// </summary>
        public bool? IsDependenceCloudPlatform { get; set; }
        /// <summary>
        /// 云平台测评情况
        /// </summary>
        public YunPingTaiCePing? yunPingTaiCePing { get;set; }
        /// <summary>
        /// 云平台测评结果
        /// </summary>
        public string? YunPingTaiCePingJieGuo { get; set; }
        /// <summary>
        /// 云平台测评时间
        /// </summary>
        public string? YunPingTaiCePingShiJian { get; set; }
        /// <summary>
        /// 云平台测评结论
        /// </summary>
        public string? YunPingTaiCePingJieLun { get; set; }

        /// <summary>
        /// 密码方案状态
        /// </summary>
        public MiMaFangAnStatus? MiMaFangAnStatus { get; set; }
        /// <summary>
        /// 密码方案时间
        /// </summary>
        public string? MiMaFangAnCePingShiJian { get; set; }
        /// <summary>
        /// 密码方案测评结果
        /// </summary>
        public string? MiMaFangAnCePingJieGuo { get; set; }
        /// <summary>
        /// 密码方案是否自行评估
        /// </summary>
        public bool? MiMaFangAn_ZiXingPingGu { get; set; }
        /// <summary>
        /// 密码方案测评机构
        /// </summary>
        public string? MiMaFangAn_CePingJiGou { get; set; }
    }
}
