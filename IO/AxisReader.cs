using INDAxisTools.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace INDAxisTools.IO
{
    public static class AxisReader
    {
        public static List<AxisPoint> Read(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("Input file not found.", fileName);

            List<AxisPoint> points = new List<AxisPoint>();

            CultureInfo culture = CultureInfo.InvariantCulture;

            using (StreamReader sr = new StreamReader(fileName))
            {
                // Read and ignore header
                string header = sr.ReadLine();

                if (string.IsNullOrWhiteSpace(header))
                    throw new Exception("The input file is empty.");

                int lineNumber = 1;

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    lineNumber++;

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split(
                        (char[])null,
                        StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 12)
                    {
                        throw new Exception(
                            string.Format(
                                "Invalid number of columns at line {0}. Expected 12 but found {1}.",
                                lineNumber,
                                parts.Length));
                    }

                    AxisPoint p = new AxisPoint();

                    try
                    {
                        p.Distance = double.Parse(parts[0], culture);
                        p.HeadingAxisDeg = double.Parse(parts[1], culture);

                        p.Easting = double.Parse(parts[2], culture);
                        p.Northing = double.Parse(parts[3], culture);

                        p.TimeUtc = double.Parse(parts[4], culture);
                        p.TimeGps = double.Parse(parts[5], culture);

                        p.Latitude = double.Parse(parts[6], culture);
                        p.Longitude = double.Parse(parts[7], culture);

                        p.EllipsoidHeight = double.Parse(parts[8], culture);

                        p.Roll = double.Parse(parts[9], culture);
                        p.Pitch = double.Parse(parts[10], culture);

                        p.HeadingRad = double.Parse(parts[11], culture);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(
                            string.Format(
                                "Error parsing numeric values at line {0}.",
                                lineNumber),
                            ex);
                    }

                    points.Add(p);
                }
            }

            return points;
        }
    }
}