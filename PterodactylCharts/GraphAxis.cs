using System;
using System.Text;

namespace PterodactylCharts
{
    public class GraphAxis
    {
        public GraphAxis(string xAxisName, string yAxisName)
        {
            XAxisName = xAxisName;
            YAxisName = yAxisName;
        }
        public GraphAxis(string xAxisName, string yAxisName, string cAxisName, double gPadding)
        {
            XAxisName = xAxisName;
            YAxisName = yAxisName;
            CAxisName = cAxisName;
            GlobalAxisPadding = gPadding;

            if (GlobalAxisPadding > 250 || GlobalAxisPadding < 0)
            {
                throw new ArgumentException("Padding is limited from 0.00 to 1.00");
            }
        }

        public override string ToString()
        {
            StringBuilder stringRepresentation = new StringBuilder();
            stringRepresentation.AppendFormat("Graph Axises{0}X Axis: {1}{0}Y Axis: {2}{0}C Axis: {3}{0}Padding: {4}", Environment.NewLine, XAxisName, YAxisName, CAxisName, GlobalAxisPadding);
            return stringRepresentation.ToString();
        }

        public string XAxisName { get; set; }
        public string YAxisName { get; set; }
        public string CAxisName { get; set; }
        public double GlobalAxisPadding { get; set; }
    }
}
