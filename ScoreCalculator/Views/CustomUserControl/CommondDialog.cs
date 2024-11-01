using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Views.CustomUserControl
{
    public class CommondDialog
    {
        public static string SaveWordFileDialog(string title)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = title;
            dlg.FileName = "商用密码应用安全性评估问题确认单.docx"; // Default file name
            dlg.DefaultExt = ".docx"; // Default file extension
            dlg.Filter = "Text documents|*.docx"; // Filter files by extension
        

            // Process save file dialog box results
            if (dlg.ShowDialog() == true)
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }
        }
        public static string SaveExcelFileDialog(string title)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = title;
            dlg.FileName = "商用密码应用安全性评估问题清单.xlsx"; // Default file name
            dlg.DefaultExt = ".xlsx"; // Default file extension
            dlg.Filter = "Text documents|*.xlsx"; // Filter files by extension


            // Process save file dialog box results
            if (dlg.ShowDialog() == true)
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }
        }
    }
}
