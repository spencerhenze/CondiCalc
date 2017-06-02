using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondiCalc_XFP
{
    public class Rope : Exercise
    {
        public Rope(double earned)
        {
            PointsEarned = earned;
            PointsPossible = 100;
        }
    }
}
