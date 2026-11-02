using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDAxisTools.Models
{
    public class AxisPoint
    {
        public double Distance { get; set; }

        public double HeadingAxisDeg { get; set; }

        public double Easting { get; set; }
        public double Northing { get; set; }

        public double TimeUtc { get; set; }
        public double TimeGps { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double EllipsoidHeight { get; set; }

        public double Roll { get; set; }
        public double Pitch { get; set; }

        public double HeadingRad { get; set; }

        public AxisPoint Clone()
        {
            return new AxisPoint
            {
                Distance = Distance,
                HeadingAxisDeg = HeadingAxisDeg,
                Easting = Easting,
                Northing = Northing,
                TimeUtc = TimeUtc,
                TimeGps = TimeGps,
                Latitude = Latitude,
                Longitude = Longitude,
                EllipsoidHeight = EllipsoidHeight,
                Roll = Roll,
                Pitch = Pitch,
                HeadingRad = HeadingRad
            };
        }
    }
}
