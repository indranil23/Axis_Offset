using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDAxisTools.Geometry
{
    public class Vector2D
    {
        public double X;
        public double Y;

        public Vector2D()
        {
        }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public double LengthSquared()
        {
            return X * X + Y * Y;
        }

        public void Normalize()
        {
            double len = Length();

            if (len == 0.0)
                return;

            X /= len;
            Y /= len;
        }

        public Vector2D Clone()
        {
            return new Vector2D(X, Y);
        }
    }
}
