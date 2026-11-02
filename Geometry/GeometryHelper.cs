using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDAxisTools.Geometry
{
    public static class GeometryHelper
    {
        public static double Distance(
            double x1,
            double y1,
            double x2,
            double y2)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static double Dot(Vector2D a, Vector2D b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public static double Cross(
            double ax,
            double ay,
            double bx,
            double by)
        {
            return ax * by - ay * bx;
        }

        public static Vector2D RotateLeft90(Vector2D v)
        {
            return new Vector2D(-v.Y, v.X);
        }

        public static Vector2D RotateRight90(Vector2D v)
        {
            return new Vector2D(v.Y, -v.X);
        }
    }
}
