using NPOI.XWPF.UserModel;

using NPOI.OpenXmlFormats.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Utils.Word
{
    public static class NPOIWordExtensionMethods
    {
        public static XWPFTableRow CreateCellByBumber(this XWPFTableRow row, int number)
        {
            for (int i = 0; i < number; i++)
            {
                row.CreateCell();
            }
            return row;
        }
        public static XWPFTable AddRowByList(this XWPFTable table, List<string> data)
        {
            CT_Row targetRow = new CT_Row();
            XWPFTableRow mrow = new XWPFTableRow(targetRow, table);
            mrow.CreateCellByBumber(data.Count);
            for (int i = 0; i < data.Count; i++)
            {
                var cell = mrow.GetCell(i);
                var ct=cell.GetCTTc();
                if (ct.tcPr == null)
                {
                    ct.AddNewTcPr();
                }
                var cp=ct.tcPr;
               
                ct.GetPList()[0].AddNewPPr().AddNewJc().val = ST_Jc.left;//单元格内容居中显示
                cp.AddNewVAlign().val=ST_VerticalJc.center;
              
                mrow.GetCell(i).SetCellText(table, data[i]);

            }
            table.AddRow(mrow);
            return table;

        }
        public static XWPFTableCell SetCellText(this XWPFTableCell cell ,XWPFTable table, string setText)
        {
            //table中的文字格式设置 
            CT_P para = new CT_P();
            XWPFParagraph pCell = new XWPFParagraph(para, table.Body);
            pCell.Alignment = ParagraphAlignment.LEFT;//字体居中 
            pCell.VerticalAlignment = TextAlignment.CENTER;//字体居中 

            XWPFRun r1c1 = pCell.CreateRun();
            r1c1.SetText(setText);
            r1c1.FontSize = 12;
            r1c1.FontFamily = "宋体";
            //r1c1.SetTextPosition(20);//设置高度 
            cell.SetParagraph(pCell);
            return cell;
        }

        public static XWPFTable VMerge(this XWPFTable table,int cellPos,int start,int end)
        {

       

            table.Rows[start].GetCell(cellPos).GetCTTc().AddNewTcPr().AddNewVMerge().val = ST_Merge.restart;

            for (int i = start+1; i < end; i++) 
            {
                table.Rows[i].GetCell(cellPos).GetCTTc().AddNewTcPr().AddNewVMerge().val = ST_Merge.@continue;
            }
      
            return table;
        }
   
    }
}
