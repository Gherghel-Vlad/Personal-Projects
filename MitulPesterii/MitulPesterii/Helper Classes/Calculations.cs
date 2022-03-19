using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitulPesterii
{
    public static class Calculations
    {
        public static double ContentFrameWidthFormula()
        {
            double n, offset;

            // Calculating from how far does it have to come the animations
            n = (double)8 / 10;
            offset = MainWindowSize.MainWindowWidth * n;

            return offset;
        }


    }
}
