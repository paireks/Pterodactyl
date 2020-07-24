using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylCharts
{
    public class GraphSettings
    {
        public GraphSettings(GraphColors graphColors, Legend legend, GraphSizes graphSizes)
        {
            Colors = graphColors;
            Legend = legend;
            Sizes = graphSizes;
        }

        public GraphColors Colors { get; set; }
        public Legend Legend { get; set; }
        public GraphSizes Sizes { get; set; }
    }
}
