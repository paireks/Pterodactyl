using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylCharts
{
    public class GraphSizes
    {
        public GraphSizes(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            StringBuilder stringRepresentation = new StringBuilder();
            stringRepresentation.AppendFormat("Graph Sizes{0}Width: {1}{0}Height: {2}", Environment.NewLine, Width, Height);
            return stringRepresentation.ToString();
        }

        public int Height { get; set; }

        public int Width { get; set; }
    }
}
