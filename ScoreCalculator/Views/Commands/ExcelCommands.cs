using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScoreCalculator.Views.Commands
{
    public  class ExcelCommands
    {
        static ExcelCommands()
        {

            CreateChaJuFenXiExcel = new RoutedUICommand("CreateChaJuFenXiExcel", "CreateChaJuFenXiExcel", typeof(ExcelCommands));

        }
        public static RoutedUICommand CreateChaJuFenXiExcel { get; }

  
    }
}
