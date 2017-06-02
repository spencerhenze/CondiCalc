using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondiCalc_XFP
{
    public class HSHold : Exercise
    {

        public HSHold(double earned)
        {
            PointsEarned = earned;
            PointsPossible = 60;
        }
    }
}
