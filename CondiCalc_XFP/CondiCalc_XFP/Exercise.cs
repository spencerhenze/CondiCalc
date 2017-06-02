using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondiCalc_XFP
{
    //This abstract class will serve as the framework for the derived classes for the specific exercises.
    public abstract class Exercise
    {
        //Declare the properties that will be accessed
        private double _pointsPossible, _pointsEarned;
        private double _percentage = 0.00;

        //Define Accessors

        public double PointsPossible
        {
            get { return _pointsPossible; }
            set { _pointsPossible = value; }
        }

        public double PointsEarned
        {
            get { return _pointsEarned; }
            set { _pointsEarned = value; }
        }

        //Percentage will be automatically calculated.

        public double Percentage
        {
            get { return (_pointsEarned / _pointsPossible) * 100; }
        }

    }
}
