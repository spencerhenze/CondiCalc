using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondiCalc_XFP
{
    public class LegLifts : Exercise
    {
        public LegLifts(double earned)
        {
            PointsEarned = earned;
            PointsPossible = 25;
        }
    }
}
