using ScoreCalculator.Models.MyEnum;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.Entity
{

    public class KnowledgeEntity
    {
        
        public long Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 所属安全层面
        /// </summary>
        public SecurityDimensionEnum SecurityDimensionEnum { get; set; }

        /// <summary>
        /// 特征(协议或对象类型)
        /// </summary>
        /// 
        public string Feature { get;set; }
        /// <summary>
        /// 指标
        /// </summary>
        public string ZhiBiao { get;set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get;set; }

        /// <summary>
        /// 测评状态
        /// </summary>
        public TestStatus TestStatus { get;set; }

        /// <summary>
        /// 知识库内容
        /// </summary>
        public string Content { get;set; }



    }
}
