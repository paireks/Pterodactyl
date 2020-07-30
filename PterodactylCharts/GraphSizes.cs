using System;
using System.Text;

namespace PterodactylCharts
{
    public class GraphSizes
    {
        public GraphSizes(int width, int height)
        {
            Width = width;
            Height = height;

            if (Width < 200 || Height < 200)
            {
                throw new ArgumentException("Width and Height values shouldn't be smaller than 200");
            }
            if (Width > 1000 || Height > 1000)
            {
                throw new ArgumentException("Width and Height values shouldn't be larger than 1000");
            }
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
