using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INDAxisTools.Models;

namespace INDAxisTools.Processing
{
    public static class TangentCalculator
    {
        public static void GetTangent(
            List<AxisPoint> pts,
            int index,
            out double tx,
            out double ty)
        {
            int last = pts.Count - 1;

            int prev = (index == 0) ? 0 : index - 1;
            int next = (index == last) ? last : index + 1;

            tx = pts[next].Easting - pts[prev].Easting;
            ty = pts[next].Northing - pts[prev].Northing;

            double len = Math.Sqrt(tx * tx + ty * ty);

            if (len < 1E-12)
            {
                tx = 0.0;
                ty = 0.0;
                return;
            }

            tx /= len;
            ty /= len;
        }
    }
}
