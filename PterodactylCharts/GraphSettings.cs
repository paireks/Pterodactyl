using System.Drawing;

namespace PterodactylCharts
{
    public class GraphSettings
    {
        public GraphSettings(string graphTitle, GraphSizes graphSizes, Color graphColor, GraphAxis graphAxis)
        {
            Title = graphTitle;
            GraphColor = graphColor;
            Sizes = graphSizes;
            Axis = graphAxis;
        }

        public override string ToString()
        {
            return "Graph Settings";
        }

        public string Title { get; set; }
        public Color GraphColor { get; set; }
        public GraphSizes Sizes { get; set; }
        public GraphAxis Axis { get; set; }
    }
}
