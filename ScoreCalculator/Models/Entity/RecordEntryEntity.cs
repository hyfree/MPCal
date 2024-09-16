using ScoreCalculator.Models.Data;
using ScoreCalculator.Models.MyEnum;
using ScoreCalculator.Models.ViewModel;
using ScoreCalculator.Services;
using ScoreCalculator.Utils;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.Entity
{
    /// <summary>
    /// 测评记录
    /// </summary>
    public class RecordEntryEntity:ViewModelBase
    {
       
        public long Id { get; set; }
        /// <summary>
        /// 所属项目Id
        /// </summary>
        public long ProjectId { get; set; }

       
        /// <summary>
        /// 系统id
        /// </summary>
        public long SystemId { get; set; }


        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 所属安全层面
        /// </summary>
        public SecurityDimensionEnum SecurityDimension { get; set; }

        /// <summary>
        /// 测评指标
        /// </summary>
        public string ZhiBiao { get; set; }


        /// <summary>
        /// 特征
        /// </summary>
        public string Feature { get; set; } = "";
        /// <summary>
        /// 备注，批注
        /// </summary>
        public string Remark { get; set; } = "";
        /// <summary>
        /// 索引
        /// </summary>

        public string? Index { get; set; }="";
        /// <summary>
        /// 测试对象名称（这里的名称必须在一个系统内是唯一的）
        /// </summary>
  
        public string? TestObjectName { get; set; }
        /// <summary>
        /// 指标要求
        /// </summary>
        public string? ZhiBiaoYaoqQiu { get; set; }
        /// <summary>
        /// 指标权重
        /// </summary>
        public double ZhiBiaoQuanZhong { get; set; }
        /// <summary>
        /// 测评单元得分
        /// </summary>
        public double? CePingDanYuanDeFen { get; set; }
        /// <summary>
        /// 折合分数
        /// </summary>
        public double? ZheHeFenShu { get; set; }
    

        /// <summary>
        /// 被某个对象弥补
        /// </summary>
    

        public bool? EnabledAutomatic { get; set; }=true;



        [Category("B评分情况")]
        public bool D { get; set; }
        [Category("B评分情况")]
        public bool A { get; set; }
        [Category("B评分情况")]
        public bool K { get; set; }
        /// <summary>
        /// 密钥管理弥补
        /// </summary>
        [Category("B评分情况")]

        public bool NK { get; set; } = true;


        [Category("B评分情况")]
        public AlgorithmicStrength RA { get; set; }

        [Category("B评分情况")]
        public CryptographicModuleLevel RK { get; set; }


        [Category("B评分情况")]
        private double _Score;
        public double Score
        {
            get { return _Score; }
            set { SetProperty(ref _Score, value); }
        }


        /// <summary>
        /// 测试状态
        /// </summary>
        //[Category("B评分情况")]
        private TestStatus _TestStatus;
        public TestStatus TestStatus
        {
            get { return _TestStatus; }
            set { SetProperty(ref _TestStatus, value); }
        }


        /// <summary>
        /// 风险等级
        /// </summary>
        //[Category("B评分情况")]
        private Exposures _Exposures;
        public Exposures Exposures
        {
            get { return _Exposures; }
            set { SetProperty(ref _Exposures, value); }
        }


        //==============详情栏==================

        /// <summary>
        /// 测评现状
        /// </summary>
        public string? _Description ;
  
        public string? Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }
        /// <summary>
        /// 问题描述
        /// </summary>
        public string? _Question ;
        public string? Question
        {
            get { return _Question; }
            set { SetProperty(ref _Question, value); }
        }

        /// <summary>
        /// 建议
        /// </summary>
        public string? _Suggest ;
        public string? Suggest
        {
            get { return _Suggest; }
            set { SetProperty(ref _Suggest, value); }
        }


        public RecordEntryEntity() { }

        public void UpDate(SystemLevel level)
        {
            if (!EnabledAutomatic!.Value)
            {
                return;

            }
            var temp=1d;
            var ra = GetRa();
            var rk = GetRk(level);

            if (this.D&&this.A&&this.K)
            {
                temp=1;
            }
            else if (this.D && !this.A && this.K)
            {
                temp = 0.5d * ra;
            }
            else if (this.D &&  this.A && !this.K)
            {
                temp = 0.5D * rk;

            }
            else if (this.D && !this.A && !this.K)
            {
                temp = 0.25 * ra * rk;

            }
            else
            {
                temp = 0;
            }
            this.Score = temp;

            if (this.D)
            {
                this.TestStatus=TestStatus.PART;

            }
            if (this.D && this.A && this.K)
            {
                this.TestStatus = TestStatus.FULL;
                this.Exposures= Exposures.None;

            }
            if (!this.D)
            {
                this.TestStatus = TestStatus.NOT;
            }



        }


        public void Automatic()
        {

        }

        public double GetRa()
        {
            switch (this.RA)
            {
                case AlgorithmicStrength.High:
                    return 1;
                  
                case AlgorithmicStrength.Medium:
                    return 0.5d;
                   
                case AlgorithmicStrength.Low:
                    return 0.2;
                default:
                    return 0;
            }
        }

        public double GetRk(SystemLevel level)
        {
            if (!this.NK)
            {
                return 1;
            }
            if (level==SystemLevel.Level1 || level==SystemLevel.Level2)
            {
              
                return 1;
            }
            if (level==SystemLevel.Level3 && this.RK == CryptographicModuleLevel.One)
            {

                return 1.2;
            }
            if (level == SystemLevel.Level4 && this.RK == CryptographicModuleLevel.Two)
            {

                return 1.5;
            }
            return 1;
        
        }

        public static RecordEntryEntity CreateByZhiBiao(long projectId,SecurityDimensionEnum securityDimensionEnum,string zhiBiao,string version)
        {
            var id = SnowFlakeNetService.FactoryGeInstance().NextId();
           
            return new RecordEntryEntity()
            {
                Id = id,
                ProjectId = projectId,
                TestObjectName = "被测对象名称",
                SecurityDimension = securityDimensionEnum,
                ZhiBiao = zhiBiao,
                Index = id.ToHex(),
                Version = version
            };
        }
        public static RecordEntryEntity CreateByZhiBiao(string Name,long projectId, SecurityDimensionEnum securityDimensionEnum, string zhiBiao,string version)
        {
            var id = SnowFlakeNetService.FactoryGeInstance().NextId();

            return new RecordEntryEntity()
            {
                Id = id,
                ProjectId = projectId,
                TestObjectName = Name,
                SecurityDimension = securityDimensionEnum,
                ZhiBiao = zhiBiao,
                Index = id.ToHex(),
                Version = version
            };
        }


    }


    public enum Gender
    {
        Male,
        Female
    }

}
