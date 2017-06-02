using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondiCalc_XFP
{
    public class LungeJumps : Exercise
    {
        public LungeJumps(double earned)
        {
            PointsEarned = earned;
            PointsPossible = 40;
        }
    }
}
