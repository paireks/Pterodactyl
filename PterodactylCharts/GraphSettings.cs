using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.Axes;

namespace PterodactylCharts
{
    public class GraphSettings
    {
        public GraphSettings(string graphTitle, int graphType, GraphSizes graphSizes, GraphColors graphColors, GraphAxis graphAxis)
        {
            Title = graphTitle;
            Type = graphType;
            Colors = graphColors;
            Sizes = graphSizes;
            Axis = graphAxis;
        }

        public override string ToString()
        {
            return "Graph Settings";
        }

        public string Title { get; set; }
        public int Type { get; set; }
        public GraphColors Colors { get; set; }
        public GraphSizes Sizes { get; set; }
        public GraphAxis Axis { get; set; }
    }
}
