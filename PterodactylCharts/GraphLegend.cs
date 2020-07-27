using System;
using System.Text;

namespace PterodactylCharts
{
    public class GraphLegend
    {
        public GraphLegend(string title, int position)
        {
            Title = title;
            Position = position;
        }

        public override string ToString()
        {
            StringBuilder stringRepresentation = new StringBuilder();
            stringRepresentation.AppendFormat("Graph Legend{0}Title: {1}{0}Position: {2}", Environment.NewLine, Title, Position.ToString());
            return stringRepresentation.ToString();
        }

        public string Title { get; set; }
        public int Position { get; set; }
    }
}
