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

        public override string ToString()
        {
            StringBuilder stringRepresentation = new StringBuilder();
            stringRepresentation.AppendFormat("Graph Axises{0}X Axis: {1}{0}Y Axis: {2}", Environment.NewLine, XAxisName, YAxisName);
            return stringRepresentation.ToString();
        }

        public string XAxisName { get; set; }
        public string YAxisName { get; set; }
    }
}
