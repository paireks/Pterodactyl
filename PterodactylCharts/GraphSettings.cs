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
        public GraphSettings(int graphType, GraphSizes graphSizes, GraphColors graphColors, GraphAxis graphAxis)
        {
            Type = graphType;
            Colors = graphColors;
            Sizes = graphSizes;
            Axis = graphAxis;
        }

        public override string ToString()
        {
            return "Graph Settings";
        }

        public int Type { get; set; }
        public GraphColors Colors { get; set; }
        public GraphSizes Sizes { get; set; }
        public GraphAxis Axis { get; set; }
    }
}
