using System;
using PterodactylCharts.Enums;

namespace PterodactylCharts
{
    public class GraphAxis
    {
        public GraphAxis(string xAxisName, string yAxisName)
        {
            GraphAxisType = GraphAxisType.XAndY;
            XAxisName = xAxisName;
            YAxisName = yAxisName;
        }
        public GraphAxis(string xAxisName, string yAxisName, string colorAxisName, double globalAxisPadding, double textSize)
        {
            GraphAxisType = GraphAxisType.XAndYAndColor;
            XAxisName = xAxisName;
            YAxisName = yAxisName;
            ColorAxisName = colorAxisName;
            GlobalAxisPadding = globalAxisPadding;
            TextSize = textSize;

            if (GlobalAxisPadding > 250 || GlobalAxisPadding < 0)
            {
                throw new ArgumentException("Padding is limited from 0.00 to 250.00");
            }
            if (TextSize > 150 || TextSize < 5)
            {
                throw new ArgumentException("Text size must be in range [5-150] pt");
            }
        }

        public override string ToString()
        {
            switch (GraphAxisType)
            {
                case GraphAxisType.XAndY:
                    return "Graph Axis with X and Y";
                default:
                    return "Graph Axis with X and Y and Color";
            }
        }

        public string XAxisName { get; }
        public string YAxisName { get; }
        public string ColorAxisName { get; }
        public double GlobalAxisPadding { get; }
        public double TextSize { get; }
        public GraphAxisType GraphAxisType { get; }
    }
}
