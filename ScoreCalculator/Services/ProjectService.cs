using ScoreCalculator.Models.Data;
using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Services
{
    public class ProjectService
    {

        public CalculationTableData JiSuan(List<RecordEntryEntity> list, SecurityDimensionEnum securityDimensionEnum,SystemLevel systemLevel)
        {
            var data=from x in list
                     where x.SecurityDimension==securityDimensionEnum
                     select x;
            var ct=CalculationTableData.ReadData(securityDimensionEnum,systemLevel);
            foreach (var item in ct.Rules)
            {
             

            }


            return null;

        }

        /// <summary>
        /// 计算指标的测评单元分数
        /// </summary>
        /// <param name="list">记录数据集合</param>
        /// <param name="securityDimensionEnum">所在安全层面</param>
        /// <param name="zhibiaoStr">指标字符串</param>
        /// <returns></returns>
        public double? JiSuanZhiBiao(List<RecordEntryEntity> list, SecurityDimensionEnum securityDimensionEnum,string zhibiaoStr)
        {
            var data=(from x in list
                     where x.SecurityDimension==securityDimensionEnum && x.ZhiBiao.Equals(zhibiaoStr)
                     select x.Score).ToArray();
            if (data.Any())
            {
                var ave = data.Average();
                return ave;
            }
            return null;
           
        }

  


    }
}
