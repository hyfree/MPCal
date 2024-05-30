using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.Entity
{

    public class TestSystem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TagId { get; set; }
        public string Tag { get; set; }
        public string OriginalTag { get; set; }
        public string Path { get; set; }
        public string OriginalPath { get; set; }

        public TestSystem()
        {

        }
        public TestSystem(string tag, string path)
        {
            Tag = tag.ToLower();
            OriginalTag = tag;
            Path = path.ToLower();
            OriginalPath = path;
        }
        //a是字符串，返回其中字符的个数


    }
}
