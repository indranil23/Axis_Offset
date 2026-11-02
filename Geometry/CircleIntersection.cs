using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDAxisTools.Geometry
{
    public static class CircleIntersection
    {
        public static bool Solve(
            double x0, double y0, double r0,
            double x1, double y1, double r1,
            out double ix1, out double iy1,
            out double ix2, out double iy2)
        {
            ix1 = iy1 = ix2 = iy2 = 0.0;

            double dx = x1 - x0;
            double dy = y1 - y0;

            double d = Math.Sqrt(dx * dx + dy * dy);

            // Too far apart
            if (d > r0 + r1)
                return false;

            // One circle inside the other
            if (d < Math.Abs(r0 - r1))
                return false;

            // Coincident circles
            if (d == 0.0)
                return false;

            double a = (r0 * r0 - r1 * r1 + d * d) / (2.0 * d);

            double h2 = r0 * r0 - a * a;

            if (h2 < 0.0)
                h2 = 0.0;

            double h = Math.Sqrt(h2);

            double xm = x0 + a * dx / d;
            double ym = y0 + a * dy / d;

            double rx = -dy * (h / d);
            double ry = dx * (h / d);

            ix1 = xm + rx;
            iy1 = ym + ry;

            ix2 = xm - rx;
            iy2 = ym - ry;

            return true;
        }
        public static double Cross(
            double ax,
            double ay,
            double bx,
            double by)
        {
            return ax * by - ay * bx;
        }
    }
}
