using Microsoft.VisualStudio.TestTools.UnitTesting;

using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.MyEnum;
using ScoreCalculator.Models.ViewModel;
using ScoreCalculator.Models.Word;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Utils.Word.Tests
{
    [TestClass()]
    public class ProblemConfirmationSheetTests
    {
        [TestMethod()]
        public void testTest()
        {
           ProblemConfirmationSheet problemConfirmationSheet = new ProblemConfirmationSheet();
            var sys = new SystemInfoEntity();
            sys.Level = 3;
            sys.Name = "测试系统";
            TableOfScores tableOfScores = new TableOfScores(sys);
            tableOfScores.LoadData(SystemLevel.Level3);
           problemConfirmationSheet.Export(tableOfScores);
        }
    }
}