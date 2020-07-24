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

        public int Height { get; set; }

        public int Width { get; set; }
    }
}
