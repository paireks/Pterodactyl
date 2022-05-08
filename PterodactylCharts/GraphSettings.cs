using System.Drawing;
using System;

namespace PterodactylCharts
{
    public class GraphSettings
    {
        public GraphSettings(string graphTitle, double titleSize, GraphSizes graphSizes, Color graphColor, GraphAxis graphAxis, double padding)
        {
            Title = graphTitle;
            TitleSize = titleSize;
            GraphColor = graphColor;
            Sizes = graphSizes;
            Axis = graphAxis;
            Padding = padding;

            if (Padding > 250|| Padding < 0)
            {
                throw new ArgumentException("Padding is limited from 0 to 250");
            }
            if (TitleSize > 140 || TitleSize < 5)
            {
                throw new ArgumentException("Title size is limited from 5 to 140pt");
            }
        }

        public override string ToString()
        {
            return "Graph Settings";
        }

        public string Title { get; set; }
        public Color GraphColor { get; set; }
        public GraphSizes Sizes { get; set; }
        public GraphAxis Axis { get; set; }
        public double Padding { get; set; }
        public double TitleSize { get; set; }
    }
}
