using System;
using System.Collections.Concurrent;
using System.Drawing;

namespace PterodactylCharts
{
    public class DataType
    {
        public DataType(Color color)
        {
            DataColor = color;

            TypeOfData = 0;
        }
        public DataType(Color color, int markers)
        {
            DataColor = color;
            Markers = markers;

            TypeOfData = 1;

            if (Markers > 4 || Markers < 0)
            {
                throw new ArgumentException("Marker can't be larger than 4 or smaller than 0"); 
            }
        }
        public override string ToString()
        {
            string stringRepresentation;
            if (TypeOfData == 0)
            {
                stringRepresentation = "Line Data";
            }
            else
            {
                stringRepresentation = "Point Data";
            }
            return stringRepresentation;
        }

        public Color DataColor { get; set; }
        public int TypeOfData { get; }
        public int Markers { get; set; }
    }
}
