using INDAxisTools.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDAxisTools.Processing
{
    public static class OffsetSelector
    {
        public static void Select(
            double px,
            double py,

            double ix1,
            double iy1,

            double ix2,
            double iy2,

            double nextx,
            double nexty,

            bool left,

            out double x,
            out double y)
        {
            double vx = nextx - px;
            double vy = nexty - py;

            double c1 =
                GeometryHelper.Cross(
                    vx,
                    vy,
                    ix1 - px,
                    iy1 - py);

            double c2 =
                GeometryHelper.Cross(
                    vx,
                    vy,
                    ix2 - px,
                    iy2 - py);

            if (left)
            {
                if (c1 >= 0)
                {
                    x = ix1;
                    y = iy1;
                }
                else
                {
                    x = ix2;
                    y = iy2;
                }
            }
            else
            {
                if (c1 <= 0)
                {
                    x = ix1;
                    y = iy1;
                }
                else
                {
                    x = ix2;
                    y = iy2;
                }
            }
        }
    }
}
