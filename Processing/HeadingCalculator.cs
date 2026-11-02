using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INDAxisTools.Models;

namespace INDAxisTools.Processing
{
    public static class HeadingCalculator
    {
        public static void Calculate(
            List<AxisPoint> pts)
        {
            int last = pts.Count - 1;

            for (int i = 0; i <= last; i++)
            {
                int prev = (i == 0) ? 0 : i - 1;
                int next = (i == last) ? last : i + 1;

                double dx =
                    pts[next].Easting - pts[prev].Easting;

                double dy =
                    pts[next].Northing - pts[prev].Northing;

                double heading =
                    Math.Atan2(dx, dy);

                if (heading < 0.0)
                    heading += 2.0 * Math.PI;

                pts[i].HeadingRad = heading;
                pts[i].HeadingAxisDeg =
                    heading * 180.0 / Math.PI;
            }
        }
    }
}
