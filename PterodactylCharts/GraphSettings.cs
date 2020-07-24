using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylCharts
{
    public class GraphSettings
    {
        public GraphSettings(GraphSizes graphSizes, GraphColors graphColors)
        {
            Colors = graphColors;
            Sizes = graphSizes;
        }

        public override string ToString()
        {
            return "Graph Settings";
        }

        public GraphColors Colors { get; set; }
        public GraphSizes Sizes { get; set; }
    }
}
