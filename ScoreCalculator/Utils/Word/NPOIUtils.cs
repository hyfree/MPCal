using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Utils.Word
{
    public  static class NPOIUtils
    {

        public   static void test()
        {
            string path = @"D:\WangXianQiang\Work\12Project\04密评报告工具\template\level3.docx";
            string pathCopy = @"D:\WangXianQiang\Work\12Project\04密评报告工具\template\level3Copy.docx";
            var fileStream=   File.Open(path,FileMode.Open);
           XWPFDocument doc = new XWPFDocument(fileStream);
           var tables=doc.Tables;
           
            var table = tables[38];
            
            table.Rows[2].GetCell(1).SetText("移动云机房");
            table.Rows[2].GetCell(2).SetText("经过实地查看和访谈运维人员，被测机房使用ID卡鉴别进出人员身份，未使用密码技术实现进出人员的身份鉴别。");
            //table.Rows[2].GetCell(3).SetText("√☑□");
            table.Rows[2].GetCell(3).SetText("√");
            //var run = table.Rows[2].GetCell(3).Paragraphs[0].CreateRun();
            //run.FontFamily = "Wingdings 2";
            //run.SetText(Convert.ToChar(0x0052).ToString());
            
            table.Rows[2].GetCell(4).SetText("×");
            table.Rows[2].GetCell(5).SetText("×");
            table.Rows[2].GetCell(6).SetText("0.0000");
            table.Rows[2].GetCell(7).SetText("0.0000");

            table.Rows[3].GetCell(1).SetText("华为云机房");
            table.Rows[3].GetCell(2).SetText("经过实地查看和访谈运维人员，被测机房使用ID卡鉴别进出人员身份，未使用密码技术实现进出人员的身份鉴别。");
            CT_Row nr = new CT_Row();
            XWPFTableRow mr = new XWPFTableRow(nr, table);//创建行 
            var cell=  mr.CreateCell();//创建单元格
         

            mr.CreateCell();//创建单元格
            mr.CreateCell();//创建单元格
            mr.CreateCell();//创建单元格
            mr.CreateCell();//创建单元格
            mr.CreateCell();//创建单元格
            mr.CreateCell();//创建单元格
            mr.CreateCell();//创建单元格
            table.AddRow(mr,3);

            table.Rows[3].GetCell(1).SetText("阿里云机房");
            table.Rows[3].GetCell(2).SetText("经过实地查看和访谈运维人员，被测机房使用ID卡鉴别进出人员身份，未使用密码技术实现进出人员的身份鉴别。");

            //table.Rows[2].MergeCells(2, 4);//行合并
            
            table.Rows[2].GetCell(0).GetCTTc().tcPr.AddNewVMerge().val = ST_Merge.restart;
            XWPFTableCell rowcell = table.GetRow(0).GetCell(3);
            CT_Tc cttc = table.Rows[3].GetCell(0).GetCTTc();
            if (cttc.tcPr == null)
            {
                cttc.AddNewTcPr();
            }

            table.Rows[3].GetCell(0).GetCTTc().tcPr.AddNewVMerge().val = ST_Merge.@continue;
            table.Rows[4].GetCell(0).GetCTTc().tcPr.AddNewVMerge().val = ST_Merge.@continue;

            //table.Rows[2].GetCell(0).SetText("阿里云机房");
            //table.Rows[2].GetCell(0).SetText("经过实地查看和访谈运维人员，被测机房使用ID卡鉴别进出人员身份，未使用密码技术实现进出人员的身份鉴别。");

            (doc.Paragraphs[16].Body as XWPFDocument).CreateParagraph().CreateRun().SetText("图AA");

            Dictionary<string,string> placeHolderDictionary = new Dictionary<string, string>();
            placeHolderDictionary.Add("{系统名称}", "密评靶场协同办公系统");
            placeHolderDictionary.Add("{综合得分}", "29.5");
           
            placeHolderDictionary.Add("{评估结论}", "不符合");
            placeHolderDictionary.Add("{风险等级}", "高");
            placeHolderDictionary.Add("{高风险数量}", "19");
            placeHolderDictionary.Add("{中风险数量}", "19");
            placeHolderDictionary.Add("{低风险数量}", "19");
            placeHolderDictionary.Add("{符合项数量}", "19");
            placeHolderDictionary.Add("{部分符合项数量}", "19");
            placeHolderDictionary.Add("{不符合项数量}", "19");
            placeHolderDictionary.Add("{不适用项数量}", "19");
         

            //总体评价
            placeHolderDictionary.Add("{物理层符合项数量}", "19");
            placeHolderDictionary.Add("{物理层部分符合项数量}", "19");
            placeHolderDictionary.Add("{物理层不符合项数量}", "19");
            placeHolderDictionary.Add("{物理层不适用项数量}", "19");
            //总体评价-物理层
            placeHolderDictionary.Add("{整体评价物理层}", "19");
            placeHolderDictionary.Add("{整体评价网络层}", "19");
            placeHolderDictionary.Add("{整体评价设备层}", "19");
            placeHolderDictionary.Add("{整体评价应用层}", "19");

            placeHolderDictionary.Add("{整体评价管理制度层}", "19");
            placeHolderDictionary.Add("{整体评价人员管理层}", "19");
            placeHolderDictionary.Add("{整体评价建设运行层}", "19");
            placeHolderDictionary.Add("{整体评价应急处置层}", "19");

            //问题描述

            placeHolderDictionary.Add("{报告编号}", "BGSM12345678");
            placeHolderDictionary.Add("{被测单位名称}", "北京软件开发公司");
            placeHolderDictionary.Add("{被测单位地址}", "北京市海淀区XX大厦");
            placeHolderDictionary.Add("{被测单位邮编}", "10010");
            placeHolderDictionary.Add("{被测单位所属密码管理局}", "北京市国家密码管理局");

            placeHolderDictionary.Add("{被测联系人姓名}", "王某某");
            placeHolderDictionary.Add("{被测联系人职务}", "技术岗位");
            placeHolderDictionary.Add("{被测联系人部门}", "安全技术部");
            placeHolderDictionary.Add("{被测联系人电话}", "12345678");
            placeHolderDictionary.Add("{被测联系人手机}", "12345678");
            placeHolderDictionary.Add("{被测联系人邮箱}", "12345678@qq.com");


            placeHolderDictionary.Add("{密评机构名称}", "中互金认证有限公司");
            placeHolderDictionary.Add("{报告日期}", "2023年10月19日");
            placeHolderDictionary.Add("{报告日期年}", "2023");
            placeHolderDictionary.Add("{报告日期月}", "10");
            placeHolderDictionary.Add("{报告日期日}", "01");

            placeHolderDictionary.Add("{密评周期开始年}", "01");
            placeHolderDictionary.Add("{密评周期开始月}", "01");
            placeHolderDictionary.Add("{密评周期开始日}", "01");

            placeHolderDictionary.Add("{密评准备周期}", "01");
            placeHolderDictionary.Add("{方案编制周期}", "01");
            placeHolderDictionary.Add("{现场测评周期}", "01");
            placeHolderDictionary.Add("{报告编制周期}", "01");

            placeHolderDictionary.Add("{报告分发数量}", "01");
            placeHolderDictionary.Add("{密码局分发数量}", "01");
            placeHolderDictionary.Add("{委托单位分发数量}", "01");
            placeHolderDictionary.Add("{密评机构留存数量}", "01");

            placeHolderDictionary.Add("{承载业务情况}", "01");
            placeHolderDictionary.Add("{网络拓扑描述}", "01");

            placeHolderDictionary.Add("{物理密码应用情况}", "01");
            placeHolderDictionary.Add("{设备密码应用情况}", "01");
            placeHolderDictionary.Add("{网络密码应用情况}", "01");
            placeHolderDictionary.Add("{应用密码应用情况}", "01");

            placeHolderDictionary.Add("{第几次测评}", "01");
            placeHolderDictionary.Add("{上次测评日期}", "01");
            placeHolderDictionary.Add("{上次测评机构}", "01");
            placeHolderDictionary.Add("{上次测评结论}", "01");
            placeHolderDictionary.Add("{上次测评得分}", "01");





            doc.RelpaceTableWord(placeHolderDictionary);
            foreach (var para in doc.Paragraphs)
            {
                foreach (var item in placeHolderDictionary.Keys)
                {
                    if (para.ParagraphText.Contains(item))
                    {
                        para.ReplaceText(item, placeHolderDictionary[item]);
                    }
                }
                
                
               
                if (para.ParagraphText.Contains("{Image01}"))
                {
                    FileStream picFile = new FileStream("C:\\Users\\huany\\Pictures\\水印.png", FileMode.Open, FileAccess.Read);
                
                    para.Runs[0].SetText("");
                    para.CreateRun().AddPicture(picFile, (int)PictureType.PNG, "1", (int)(400.0 * 9525), (int)(300.0 * 9525));
                    para.CreateRun().AddCarriageReturn();
                    para.CreateRun().AppendText("图BB 身份证图片");
                    FileStream picFile2 = new FileStream("C:\\Users\\huany\\Pictures\\水印.png", FileMode.Open, FileAccess.Read);
                    table.Rows[3].GetCell(2).Paragraphs[0].CreateRun().AddPicture(picFile2, (int)PictureType.PNG, "1", (int)(200.0 * 9525), (int)(150.0 * 9525));

                }
            }



            var fileStreamCopy = File.Open(pathCopy, FileMode.OpenOrCreate);
            doc.Write(fileStreamCopy);
          
            fileStreamCopy.Flush();
            fileStreamCopy.Close();
            Console.WriteLine( tables.Count);

        }

        //public static XWPFParagraph SetCellText(XWPFDocument doc, XWPFTable table, string setText)
        //{
        //    //table中的文字格式设置 
        //    CT_P para = new CT_P();
        //    XWPFParagraph pCell = new XWPFParagraph(para, table.Body);
        //    pCell.Alignment = ParagraphAlignment.CENTER;//字体居中 
        //    pCell.VerticalAlignment = TextAlignment.CENTER;//字体居中 

        //    XWPFRun r1c1 = pCell.CreateRun();
        //    r1c1.SetText(setText);
        //    r1c1.FontSize = 12;
        //    r1c1.FontFamily = "宋体";
        //    //r1c1.SetTextPosition(20);//设置高度 
        //    return pCell;
        //}

      

        public static void RelpaceTableWord(this XWPFDocument doc, Dictionary<string, string> map)
        {

            var tables = doc.Tables;
            foreach (var table in tables)
            {

                foreach (var row in table.Rows)
                {

                    foreach (var cell in row.GetTableCells())
                    {
                        foreach (var key in map.Keys)
                        {
                            if (cell.GetText().Contains(key))
                            {
                                cell.Paragraphs[0].ReplaceText(key, map[key]); 
                            }


                        }

                    }

                }


            }


        }
        public    static void mergeCellVertically(XWPFTable table, int col, int fromRow, int toRow)
        {
            for (int rowIndex = fromRow; rowIndex <= toRow; rowIndex++)
            {
                XWPFTableCell cell = table.GetRow(rowIndex).GetCell(col);
                CT_VMerge vmerge = new CT_VMerge();
                if (rowIndex == fromRow)
                {
                    // The first merged cell is set with RESTART merge value
                    vmerge.val = ST_Merge.restart;
                }
                else
                {
                    // Cells which join (merge) the first one, are set with CONTINUE
                    vmerge.val = ST_Merge.@continue;
                    // and the content should be removed
                    for (int i = cell.Paragraphs.Count; i > 0; i--)
                    {
                        cell.RemoveParagraph(0);
                    }
                    cell.AddParagraph();
                }
                // Try getting the TcPr. Not simply setting an new one every time.
                CT_TcPr tcPr = cell.GetCTTc().tcPr;
                if (tcPr == null) tcPr = cell.GetCTTc().AddNewTcPr();
                tcPr.vMerge = vmerge;
            }
        }

        //merging horizontally by setting grid span instead of using CTHMerge
        public static void mergeCellHorizontally(XWPFTable table, int row, int fromCol, int toCol)
        {
            XWPFTableCell cell = table.GetRow(row).GetCell(fromCol);
            // Try getting the TcPr. Not simply setting an new one every time.
            CT_TcPr tcPr = cell.GetCTTc().tcPr;
            if (tcPr == null) tcPr = cell.GetCTTc().AddNewTcPr();
            // The first merged cell has grid span property set
            if (tcPr.gridSpan != null)
            {
                tcPr.gridSpan.val = (toCol - fromCol + 1).ToString();
            }
            else
            {
                tcPr.gridSpan = new CT_DecimalNumber();
                tcPr.gridSpan.val = (toCol - fromCol + 1).ToString();
            }
            // Cells which join (merge) the first one, must be removed
            for (int colIndex = toCol; colIndex > fromCol; colIndex--)
            {
                table.GetRow(row).RemoveCell(colIndex); // use only this for apache poi versions greater than 3
                                                        //table.getRow(row).getCtRow().removeTc(colIndex); // use this for apache poi versions up to 3
                                                        //table.getRow(row).removeCell(colIndex);
            }
        }
    }
}
