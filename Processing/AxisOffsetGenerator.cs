using INDAxisTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace INDAxisTools.Processing
{
    public static class AxisOffsetGenerator
    {
        public static List<AxisPoint> Generate(
            List<AxisPoint> input,
            double offset,
            bool leftSide)
        {
            List<AxisPoint> output =
                new List<AxisPoint>(input.Count);

            for (int i = 0; i < input.Count; i++)
            {
                output.Add(input[i].Clone());
            }

            for (int i = 0; i < input.Count; i++)
            {
                double tx;
                double ty;

                TangentCalculator.GetTangent(
                    input,
                    i,
                    out tx,
                    out ty);

                OffsetCalculator.OffsetPoint(
                    input[i],
                    output[i],
                    tx,
                    ty,
                    offset,
                    leftSide);
            }

            HeadingCalculator.Calculate(output);

            return output;
        }
    }
}
