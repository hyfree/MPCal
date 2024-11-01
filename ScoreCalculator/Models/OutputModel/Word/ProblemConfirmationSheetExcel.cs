using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;

using ScoreCalculator.Models.Data;
using ScoreCalculator.Models.MyEnum;
using ScoreCalculator.Models.ViewModel;
using ScoreCalculator.Utils.Word;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ScoreCalculator.Models.OutputModel.Word
{
    /// <summary>
    /// 问题确认单
    /// </summary>
    public class ProblemConfirmationSheetExcel
    {
        public void ExportExcel(TableOfScores tableOfScores, string pathCopy)
        {
            //创建一个excel文件(工作簿)
            XSSFWorkbook workbook = new XSSFWorkbook();
            //在其中创建一张表
           
            AddProblemConfirmationSheetRow(workbook, tableOfScores);
            //开发一个文件流,准备写入数据
            FileStream stream = new FileStream(pathCopy, FileMode.Create);
            //写入Excel信息
            workbook.Write(stream);
            //关闭流
            stream.Close();
        }

     

        public void AddProblemConfirmationSheetRow(XSSFWorkbook workbook, TableOfScores tableOfScores)
        {

            ISheet sheet = workbook.CreateSheet("sheetOne");
            //List<ProblemConfirmationSheetRow> list = new List<ProblemConfirmationSheetRow>();
            int rowIndex = 0;
            //table.RemoveRow(1);//去掉第一行空白的
            IRow title = sheet.CreateRow(rowIndex);

            title.CreateCell(0).SetCellValue("测评层面");
            title.CreateCell(1).SetCellValue("测评要求");
            title.CreateCell(2).SetCellValue("问题编号");
            title.CreateCell(3).SetCellValue("测评对象");
            title.CreateCell(4).SetCellValue("系统现状");
            title.CreateCell(5).SetCellValue("问题描述");
            title.CreateCell(6).SetCellValue("风险等级");
            title.CreateCell(7).SetCellValue("整改建议");
            sheet.SetColumnWidth(0, 5000);
            sheet.SetColumnWidth(1, 5000);
            sheet.SetColumnWidth(2, 3000);
            sheet.SetColumnWidth(3, 3000);
            sheet.SetColumnWidth(4, 5000);
            sheet.SetColumnWidth(5, 5000);
            sheet.SetColumnWidth(6, 3000);
            sheet.SetColumnWidth(7, 5000);
            //rowIndex++;
           
            var SecList = new List<SecurityDimensionEnum>()
            {   SecurityDimensionEnum.WuLi,
                SecurityDimensionEnum.WangLuo,
                SecurityDimensionEnum.SheBei,
                SecurityDimensionEnum.YingYong,
                SecurityDimensionEnum.GuanLi,
                SecurityDimensionEnum.RenYuan,
                SecurityDimensionEnum.JianShe,
                SecurityDimensionEnum.YingJi,
            };
            var style = GetStyle(workbook);

            foreach (var sec in SecList)
            {
                var tableData = tableOfScores.FindCengMian(sec);
                if (tableData != null)
                {
                    int tableIndex = rowIndex;
                    foreach (var rule in tableData.Rules)
                    {

                        int rule_index = rowIndex;
                        foreach (var item in rule.RecordEntryEntitys)
                        {
                            rowIndex++;
                            IRow row = sheet.CreateRow(rowIndex);
                            
                            row.CreateCell(0).SetCellValue(tableData.CengMian);
                           
                            row.CreateCell(1).SetCellValue(rule.ZhiBiaoYaoQiu);
                            row.CreateCell(2).SetCellValue(rowIndex);
                            row.CreateCell(3).SetCellValue(item.TestObjectName);
                            row.CreateCell(4).SetCellValue(item.Description);
                            row.CreateCell(5).SetCellValue(item.Question);
                            row.CreateCell(6).SetCellValue(item.Exposures.GetEnumString());
                            row.CreateCell(7).SetCellValue(item.Suggest);

                            row.GetCell(0).CellStyle = style;
                            row.GetCell(1).CellStyle = style;
                            row.GetCell(2).CellStyle = style;
                            row.GetCell(3).CellStyle = style;
                            row.GetCell(4).CellStyle = style;
                            row.GetCell(5).CellStyle = style;
                            row.GetCell(6).CellStyle = style;
                            row.GetCell(7).CellStyle = style;
                        }

                        //合并单元格，如果要合并的单元格中都有数据，只会保留左上角的
                        //CellRangeAddress(0, 2, 0, 0)，合并0-2行，0-0列的单元格
                        if (rule_index!= rowIndex  && (rowIndex- rule_index) >1)
                        {
                            CellRangeAddress region_CePingYaoQiu = new CellRangeAddress(rule_index+1, rowIndex, 1, 1);
                            sheet.AddMergedRegion(region_CePingYaoQiu);
                        }
                       
                    }


                    //合并单元格，如果要合并的单元格中都有数据，只会保留左上角的
                    //CellRangeAddress(0, 2, 0, 0)，合并0-2行，0-0列的单元格
                    if (tableIndex != rowIndex && (rowIndex - tableIndex) > 1)
                    {
                        CellRangeAddress region_CengMian = new CellRangeAddress(tableIndex + 1, rowIndex, 0, 0);
                        sheet.AddMergedRegion(region_CengMian);
                    }
                }
               


            }
        }

        public ICellStyle GetStyle(IWorkbook wb)
        {
            ICellStyle style2 = wb.CreateCellStyle();//样式
            IFont font1 = wb.CreateFont();//字体
            font1.FontName = "楷体";
            //font1.Color = HSSFColor.Red.Index;//字体颜色
            font1.Boldweight = (short)FontBoldWeight.Normal;//字体加粗样式
            style2.SetFont(font1);//样式里的字体设置具体的字体样式
                                  //设置背景色
            //style2.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
           // style2.FillPattern = FillPattern.SolidForeground;
           // style2.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
            style2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;//文字水平对齐方式
            style2.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//文字垂直对齐方式

            style2.WrapText = true;
            //HSSFCellStyle cs_Content = (HSSFCellStyle)wb.CreateCellStyle(); //创建列头样式
            //cs_Content.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center; //水平居中
            //cs_Content.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center; //垂直居中

            //cs_Content.WrapText = true;

            return style2;
        }
    }
}