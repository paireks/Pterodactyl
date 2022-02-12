using System;
using System.Text;

namespace PterodactylCharts
{
    public class GraphLegend
    {
        public GraphLegend(string title, int position, int placement, int orientation)
        {
            Title = title;
            Position = position;
            Placement = placement;
            Orientation = orientation;

            if (Position > 11 || Position < 0)
            {
                throw new ArgumentException("Position should be between 0 and 11");
            }

            if (Orientation > 1 || Orientation < 0)
            {
                throw new ArgumentException("Orientation should be between 0 and 1");
            }

            if (Placement > 1 || Placement < 0)
            {
                throw new ArgumentException("Placement should be between 0 and 1");
            }
        }

        public override string ToString()
        {
            StringBuilder stringRepresentation = new StringBuilder();
            stringRepresentation.AppendFormat("Graph Legend{0}Title: {1}{0}Position: {2}{0}Orientation: {3}{0}Placement: {4}", Environment.NewLine, Title, Position, Orientation, Placement);
            return stringRepresentation.ToString();
        }

        public string Title { get; set; }
        public int Position { get; set; }
        public int Placement { get; set; }
        public int Orientation { get; set; }

    }
}
