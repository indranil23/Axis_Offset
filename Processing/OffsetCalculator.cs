using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INDAxisTools.Models;

namespace INDAxisTools.Processing
{
    public static class OffsetCalculator
    {
        public static void OffsetPoint(
            AxisPoint input,
            AxisPoint output,
            double tx,
            double ty,
            double offset,
            bool leftSide)
        {
            double nx;
            double ny;

            if (leftSide)
            {
                nx = -ty;
                ny = tx;
            }
            else
            {
                nx = ty;
                ny = -tx;
            }

            output.Easting =
                input.Easting + offset * nx;

            output.Northing =
                input.Northing + offset * ny;
        }
    }
}
