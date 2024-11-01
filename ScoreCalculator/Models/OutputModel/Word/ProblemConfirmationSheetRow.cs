using NPOI.XWPF.UserModel;
using ScoreCalculator.Models.Data;
using ScoreCalculator.Models.MyEnum;
using ScoreCalculator.Models.ViewModel;
using ScoreCalculator.Utils.Word;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.OutputModel.Word
{
    /// <summary>
    /// 问题确认单行
    /// </summary>
    public class ProblemConfirmationSheetRow
    {
        public int No { get; set; }
        /// <summary>
        /// 测评层面
        /// </summary>
        public string CePingCengMian { get; set; }
        /// <summary>
        /// 测评要求
        /// </summary>
        public string CePingYaoQiu { get; set; }
        /// <summary>
        /// 问题描述
        /// </summary>
        public string WenTiMiaoShu { get; set; }
        /// <summary>
        /// 问题风险
        /// </summary>
        public Exposures WenTiFengXian { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string BeiZhu { get; set; }

        public List<string> RowToList()
        {
            var list = new List<string>();
            list.Add(No.ToString());
            list.Add(CePingCengMian.ToString());
            list.Add(CePingYaoQiu.ToString());
            list.Add(WenTiMiaoShu.ToString());
            list.Add(WenTiFengXian.GetEnumString());
            list.Add(BeiZhu.ToString());
            return list;
        }

        public List<string> RowToListIgnoreRight()
        {
            var list = new List<string>();
            list.Add(No.ToString());
            list.Add(CePingCengMian.ToString());
            list.Add(CePingYaoQiu.ToString());
            list.Add(WenTiMiaoShu.ToString());
            list.Add(WenTiFengXian.ToString());
            list.Add(BeiZhu.ToString());
            return list;
        }

        /// <summary>
        /// 转换为问题列表行
        /// </summary>
        /// <param name="zhiBiaoItem"></param>
        /// <param name="cePingCengMian"></param>
        /// <returns></returns>
        public static ProblemConfirmationSheetRow PareByZhiBiaoItem(ZhiBiaoItem zhiBiaoItem, string cePingCengMian)
        {

            var data = new ProblemConfirmationSheetRow();
            data.CePingCengMian = cePingCengMian;
            data.CePingYaoQiu = zhiBiaoItem.ZhiBiaoYaoQiu;
            data.WenTiMiaoShu = zhiBiaoItem.QuestionMerge();
            if (string.IsNullOrEmpty(data.WenTiMiaoShu))
            {
                data.WenTiMiaoShu = "未描述";
            }
            data.WenTiFengXian = zhiBiaoItem.Exposures;
            data.BeiZhu = "";
            return data;
        }

    }
}
