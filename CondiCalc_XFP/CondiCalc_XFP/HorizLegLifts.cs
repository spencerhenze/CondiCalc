using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondiCalc_XFP
{
    public class HorizLegLifts : Exercise
    {
        public HorizLegLifts(double earned)
        {
            PointsEarned = earned;
            PointsPossible = 20;
        }
    }
}
