using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.MyEnum
{
    /// <summary>
    /// 风险
    /// </summary>
    public enum Exposures
    {
        /// <summary>
        /// 高风险
        /// </summary>
        [Description("高")]
        High = 0,
        /// <summary>
        /// 中风险
        /// </summary>
        [Description("中")]
        Medium =1,
        /// <summary>
        /// 低风险
        /// </summary>
        [Description("低")]
        Low =2,
        /// <summary>
        /// 无风险
        /// </summary>
        [Description("无")]
        None =3
    }
    public class ExposuresObjectDataProvider
    {
        public List<string> GetValues()
        {

            var values=Enum.GetValues(typeof(Exposures));   
            List<string> result=new List<string>();
            foreach (Exposures item in values)
            {
                result.Add(item.GetEnumString());

            }
            return result;
        }
    }
    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionAttribute : Attribute
    {
        public string description;

        public DescriptionAttribute(string desc)
        {
            description = desc;
        }
    }
    public static class ExposuresExtensionMethods
    {

        public static string GetEnumString(this Exposures exposures)
        {
            switch (exposures)
            {
                case Exposures.High:
                    return "高";
                case Exposures.Medium:
                    return "中";
                case Exposures.Low:
                    return "低";
                case Exposures.None:
                    return "无";
                default:
                    return null;
            }

        }
        public static string GetExposuresColorString(this Exposures exposures)
        {
            switch (exposures)
            {
                case Exposures.High:
                    return "Red";
                case Exposures.Medium:
                    return "Orange";
                case Exposures.Low:
                    return "Blue";
                case Exposures.None:
                    return "Green";
                default:
                    return "Black";
            }

        }
    }
}
