
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;

using ScoreCalculator.Models.Data;
using ScoreCalculator.Models.MyEnum;
using ScoreCalculator.Models.ViewModel;
using ScoreCalculator.Utils.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ScoreCalculator.Models.Word
{
    public class ProblemConfirmationSheet
    {
        public void Export(TableOfScores tableOfScores,string pathCopy)
        {
            var config=MyConfig.GetMyConfig();
            var path = Path.Combine(config.BaseTemplateDir+ "IssuesList.docx");                                                                                                                                                 
            //var pathCopy = "D:\\WangXianQiang\\Work\\12Project\\04密评报告工具\\template\\商用密码应用安全性评估问题确认单Copy.docx";
            if (File.Exists(pathCopy))
            {
                
                File.Delete(pathCopy);

            }

            var fileStream = File.Open(path, FileMode.Open);
            XWPFDocument doc = new XWPFDocument(fileStream);
            var tables = doc.Tables;
            var myTable = tables[0];

          
            AddProblemConfirmationSheetRow(myTable,tableOfScores);
            //var paragraph = doc.CreateParagraph();

            var fileStreamCopy = File.Open(pathCopy, FileMode.OpenOrCreate);
            doc.Write(fileStreamCopy);

            fileStreamCopy.Flush();
            fileStreamCopy.Close();


        }
        public static List<ProblemConfirmationSheetRow> TableOfScoresToList(TableOfScores tableOfScores, SecurityDimensionEnum securityDimensionEnum)
        {
            var ct = tableOfScores.FindCengMian(securityDimensionEnum);
            List<ProblemConfirmationSheetRow> list = new List<ProblemConfirmationSheetRow>();
            foreach (var item in ct.Rules)
            {
                var rowData = ProblemConfirmationSheetRow.PareByZhiBiaoItem(item, ct.CengMian);
                list.Add(rowData);
            }
            return list;
        }
        public static List<ProblemConfirmationSheetRow> AddProblemConfirmationSheetRow(XWPFTable table, TableOfScores tableOfScores)
        {

            List<ProblemConfirmationSheetRow> list = new List<ProblemConfirmationSheetRow>();
            int pos = 1;
            table.RemoveRow(1);//去掉第一行空白的
            AddProblemConfirmationSheetRow(table, ref pos, TableOfScoresToList(tableOfScores, SecurityDimensionEnum.WuLi));
            AddProblemConfirmationSheetRow(table, ref pos, TableOfScoresToList(tableOfScores, SecurityDimensionEnum.WangLuo));
            AddProblemConfirmationSheetRow(table, ref pos, TableOfScoresToList(tableOfScores, SecurityDimensionEnum.SheBei));
            AddProblemConfirmationSheetRow(table, ref pos, TableOfScoresToList(tableOfScores, SecurityDimensionEnum.YingYong));
            AddProblemConfirmationSheetRow(table, ref pos, TableOfScoresToList(tableOfScores, SecurityDimensionEnum.GuanLi));
            AddProblemConfirmationSheetRow(table, ref pos, TableOfScoresToList(tableOfScores, SecurityDimensionEnum.RenYuan));
            AddProblemConfirmationSheetRow(table, ref pos, TableOfScoresToList(tableOfScores, SecurityDimensionEnum.JianShe));
            AddProblemConfirmationSheetRow(table, ref pos, TableOfScoresToList(tableOfScores, SecurityDimensionEnum.YingJi));
            return list;
        }

        public static void AddProblemConfirmationSheetRow(XWPFTable table, ref int pos, List<ProblemConfirmationSheetRow> data)
        {
            int start=pos;
            var rows2=(from x in data
                     where x.WenTiFengXian!=Exposures.None
                     select x).ToList();
            if (rows2==null || rows2.Count==0)
            {
                return;
            }
            foreach (var row in rows2)
            {
                row.No=pos;
                table.AddRowByList(row.RowToList());
                pos++;
            }
            //table.VMerge(1, start, start + rows.Count());
            NPOIUtils.mergeCellVertically(table, 1, start, start + rows2.Count()-1);
        }




    }
}
