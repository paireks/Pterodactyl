using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        public override string ToString()
        {
            string stringRepresentation = string.Empty;
            if (TypeOfData == 0)
            {
                stringRepresentation = "Line Data";
            }
            else if (TypeOfData == 1)
            {
                stringRepresentation = "Point Data";
            }
            return stringRepresentation;
        }

        public Color DataColor { get; set; }
        public int TypeOfData { get; set; }
        public int Markers { get; set; }
    }
}
