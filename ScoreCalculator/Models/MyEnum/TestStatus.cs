/// <summary>
/// 测评结论
/// </summary>
/// 
namespace ScoreCalculator.Models.MyEnum
{
    public enum TestStatus
    {
        /// <summary>
        /// 符合
        /// </summary>
        FULL,
        /// <summary>
        /// 不符合
        /// </summary>
        NOT,
        /// <summary>
        /// 部分符合
        /// </summary>
        PART,
        /// <summary>
        /// 不适用
        /// </summary>
        NA
    }
    public static class ETestStatusExtensionMethods
    {

        public static string GetEnumString(this TestStatus status)
        {
            switch (status)
            {
                case TestStatus.FULL:
                    return "符合";
                
                case TestStatus.NOT:
                    return "不符合";
                case TestStatus.PART:
                    return "部分符合";
                case TestStatus.NA:
                    return "不适用";
                default:
                    return "无效值";
            }

        }
        public static string GetTestStatusColorString(this TestStatus status)
        {
            switch (status)
            {
                case TestStatus.FULL:
                    return "Green";
                   
                case TestStatus.NOT:
                    return "Red";
                    
                case TestStatus.PART:
                    return "Orange";
                case TestStatus.NA:
                    return "Black";
                default:
                    return "Black";
            }

        

        }
    }

}
