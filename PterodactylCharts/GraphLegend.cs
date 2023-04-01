﻿using System;
using System.Text;

namespace PterodactylCharts
{
    public class GraphLegend
    {
        public GraphLegend(string title, int position)
        {
            Title = title;
            Position = position;

            if (Position > 11 || Position < 0)
            {
                throw new ArgumentException("Position should be between 0 and 11");
            }
        }
        
        public GraphLegend(string title, int position, int placement, int orientation, double textSize)
        {
            Title = title;
            Position = position;
            Placement = placement;
            Orientation = orientation;
            TextSize = textSize;


            if (Position > 11 || Position < 0)
            {
                throw new ArgumentException("Position should be between 0 and 11");
            }
            if (Placement > 1 || Placement < 0)
            {
                throw new ArgumentException("Placement should be between 0 and 1");
            }
            if (Orientation > 1 || Orientation < 0)
            {
                throw new ArgumentException("Orientation should be between 0 and 1");
            }
            if (TextSize > 140 || TextSize < 5)
            {
                throw new ArgumentException("Text size should be between 5 and 140");
            }
        }

        public override string ToString()
        {
            StringBuilder stringRepresentation = new StringBuilder();
            stringRepresentation.AppendFormat("Graph Legend{0}Title: {1}", Environment.NewLine, Title);
            return stringRepresentation.ToString();
        }

        public string Title { get; }
        public int Position { get; }
        public int Placement { get; }
        public int Orientation { get; }
        public double TextSize { get; }

    }
}
