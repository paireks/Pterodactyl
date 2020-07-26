using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylCharts
{
    public class GraphColors
    {
        public GraphColors(List<Color> dataColors, Color backgroundColor)
        {
            DataColors = dataColors;
            BackgroundColor = backgroundColor;
        }

        public override string ToString()
        {
            StringBuilder stringRepresentation = new StringBuilder();
            stringRepresentation.AppendFormat("Graph Colors{0}Data colors: {1}", Environment.NewLine, DataColors.Count);
            return stringRepresentation.ToString();
        }

        public Color BackgroundColor { get; set; }

        public List<Color> DataColors { get; set; }
    }
}
