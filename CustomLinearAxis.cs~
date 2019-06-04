using System;
using System.Collections.Generic;
using OxyPlot.Axes;

namespace IUPred2aPlotterApp
{
    public class CustomLinearAxis : LinearAxis
    {
        public int MaximumValue { get; set; }

        public CustomLinearAxis() : base()
        {
        }

        public override void GetTickValues(out IList<double> majorLabelValues, out IList<double> majorTickValues, out IList<double> minorTickValues)
        {
            base.GetTickValues(out majorLabelValues, out majorTickValues, out minorTickValues);

            majorTickValues.Add(1);
            majorTickValues.Add(MaximumValue);

            majorLabelValues.Add(1);
            majorLabelValues.Add(MaximumValue);
        }
    }
}
