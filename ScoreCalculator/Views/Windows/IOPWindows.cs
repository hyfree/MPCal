using ScoreCalculator.Models.Entity;
using ScoreCalculator.Models.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Views.Windows
{
    public interface IOPWindows
    {
        string GetVersion();
        ProjectEntity GetProjecInfo();
        TableOfScores GetTableOfScores();
        void RefreshView();
    }
}
