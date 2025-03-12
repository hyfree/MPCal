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


        /// <summary>
        /// 系统简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 被测单位
        /// </summary>
        public TestedCompanyInformationEntity TestedCompanyInformation { get; set; }
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
        /// 得分
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// 包含的系统
        /// </summary>
        public List<SystemInfoEntity> SystemInfo { get; set; }

        /// <summary>
        /// 是否为关键基础设施
        /// </summary>
        public bool CriticalInfrastructure { get;set; }
        /// <summary>
        /// 安全保护部门
        /// </summary>
        public string SecurityAndProtectionUnits { get;set; }

        /// <summary>
        /// 级别
        /// </summary>
        public SystemLevel Level { get; set; }

        public int SystemLevel_S { get;set; }
        public int SystemLevel_A { get; set; }
        public int SystemLevel_G { get; set; }
        /// <summary>
        /// 备案证明编号
        /// </summary>
        public string FilingCertificateNo { get; set; }
        /// <summary>
        /// 是否为系统级别一致
        /// </summary>
        public bool IsEquipoiseSystemLevel { get;set; }
        /// <summary>
        /// 系统级别说明
        /// </summary>
        public string SystemLevelDescription { get;set; }
        /// <summary>
        /// 是否定级
        /// </summary>
        public bool IsClassifiedOrNot { get;set; }
        /// <summary>
        /// 网络安全等级评估
        /// </summary>
        public NetworkSecurityLevelAssessmentEnum networkSecurityLevelAssessmentEnum { get; set; }

        public string NetworkSecurityAssessmentOrganization { get; set; }
        public string NetworkSecurityAssessmentDate { get; set; }
        public string NetworkSecurityAssessmentResult { get; set; }
        /// <summary>
        /// 服务范围
        /// </summary>
        public List<FuWuFanWei> fuWuFanWeis { get; set; }
        /// <summary>
        /// 服务领域
        /// </summary>
        public List<FuWuLingYu> fuWuLingYu { get; set; }

        /// <summary>
        /// 服务对象
        /// </summary>
        public FuWuDuiXiang fuWuDuiXiang { get; set; }

        /// <summary>
        /// 服务范围
        /// </summary>
        public List<FuGaiFanWei> FuGaiFanWei { get;set; }
        /// <summary>
        /// 网络性质
        /// </summary>
        public List<WangLuoXingZhi> WangLuoXingZhi { get;set; }


        public string YongHuShuLiang { get; set; }  

        public bool TouRuYunXing { get; set; }

        public string TouRuYunXingShiJian { get; set; }

        public string TouRuYunXingQiangKuang { get; set; }


        public List<XiTongHuLian> XiTongHuLian { get; set; }

        public string XiTongHuLianMingCheng { get; set; }



        public bool IsCloudPlatform { get; set; }

        public YunPingTaiCePing yunPingTaiCePing { get;set; }

        public string YunPingTaiCePingJieGuo { get; set; }

        public string YunPingTaiCePingShiJian { get; set; }
        public string YunPingTaiCePingJieLun { get; set; }


        public MiMaFangAnStatus MiMaFangAnStatus { get; set; }

        public string MiMaFangAnCePingShiJian { get; set; }

        public string MiMaFangAnCePingJieGuo { get; set; }

        public bool MiMaFangAn_ZiXingPingGu { get; set; }



    }
}
