using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;
using ScoreCalculator.Models.ViewModel;
using ScoreCalculator.Utils.Word;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.OutputModel.Word.TestPlan
{
    public class TestPlanTemplateWriter
    {

        public void Export(TableOfScores tableOfScores)
        {
            var path = "D:\\WangXianQiang\\Work\\12Project\\04密评报告工具\\template\\测评方案模板2023.docx";
            var pathCopy = "D:\\WangXianQiang\\Work\\12Project\\04密评报告工具\\template\\测评方案模板2023Copy.docx";
            var fileStream = File.Open(path, FileMode.Open);
            XWPFDocument doc = new XWPFDocument(fileStream);
            var tables = doc.Tables;

            Dictionary<string, string> placeHolderDictionary = new Dictionary<string, string>();
            //报告情况
            placeHolderDictionary.Add("{项目编号}", "XX");


            placeHolderDictionary.Add("{系统名称}", tableOfScores.ProjectEntity.ProjectName);
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




            }



            var fileStreamCopy = File.Open(pathCopy, FileMode.OpenOrCreate);
            doc.Write(fileStreamCopy);

            fileStreamCopy.Flush();
            fileStreamCopy.Close();
            Console.WriteLine(tables.Count);

        }
    }
}
