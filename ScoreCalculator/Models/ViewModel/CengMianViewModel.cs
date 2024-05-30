using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Models.ViewModel
{
    public class CengMianViewModel:ViewModelBase
    {
        public double _Score;
        public double Score
        {
            get { return _Score; }
            set { SetProperty(ref _Score, value); }
        }
        public double _CengMianQuanZHong;
        public double CengMianQuanZHong
        {
            get { return _CengMianQuanZHong; }
            set { SetProperty(ref _CengMianQuanZHong, value); }
        }

    }
}
