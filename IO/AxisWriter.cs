using System.Collections.Generic;
using System.Globalization;
using System.IO;
using INDAxisTools.Models;

namespace INDAxisTools.IO
{
    public static class AxisWriter
    {
        public static void Write(string filename, List<AxisPoint> points)
        {
            CultureInfo culture = CultureInfo.InvariantCulture;

            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(
"distance[m] heading_axis[°] easting[m] northing[m] time_utc[s] time_gps[s] latitude[°] longitude[°] ellipsoid_height[m] roll[rad] pitch[rad] heading[rad]");

                foreach (AxisPoint p in points)
                {
                    sw.WriteLine(
"{0,12:F5} {1,12:F5} {2,15:F5} {3,15:F5} {4,15:F5} {5,15:F5} {6,15:F8} {7,15:F8} {8,12:F5} {9,12:F5} {10,12:F5} {11,12:F5}",

                        p.Distance,
                        p.HeadingAxisDeg,
                        p.Easting,
                        p.Northing,
                        p.TimeUtc,
                        p.TimeGps,
                        p.Latitude,
                        p.Longitude,
                        p.EllipsoidHeight,
                        p.Roll,
                        p.Pitch,
                        p.HeadingRad);
                }
            }
        }
    }
}