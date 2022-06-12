using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Collections;

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
            Marker = markers;

            TypeOfData = 1;

            if (Marker > 4 || Marker < 0)
            {
                throw new ArgumentException("Marker can't be larger than 4 or smaller than 0"); 
            }
        }

        // advanced settings
        //point
        public DataType(Color color, int marker, double size)
        {
            DataColor = color;
            Marker = marker;
            MarkerSizes = new double[1] { size };

            TypeOfData = 1;

            if (Marker > 6 || Marker < 0)
            {
                throw new ArgumentException("Marker can't be larger than 6 or smaller than 0");
            }
            if (MarkerSizes[0] > 100 || MarkerSizes[0] < 0.1d)
            {
                throw new ArgumentException("Marker size can't be larger than 50 or smaller than 0.1");
            }
        }
        //line
        public DataType(Color color, int interpolation, int style, double thickness)
        {
            DataColor = color;
            LineInterpolation = interpolation;
            LineStyle = style;
            LineWeight = thickness;

            TypeOfData = 0;

            if (LineInterpolation > 4 || LineInterpolation < 0)
            {
                throw new ArgumentException("Interpolation can't be larger than 4 or smaller than 0");
            }
            if (LineStyle > 4 || LineStyle < 0)
            {
                throw new ArgumentException("Line Style can't be larger than 4 or smaller than 0");
            }
            if (LineWeight > 20.0d || LineWeight < 0.1d)
            {
                throw new ArgumentException("Line thickness can be from 0.1 to 20.0");
            }
        }
        // scatter
        public DataType(Color[] colors, int marker, double[] sizes, double[] values)
        {
            ScatterPalette = colors; // palette
            Marker = marker;
            MarkerSizes = sizes;
            ScatterValues = values;

            TypeOfData = 2;

            if (ScatterPalette.Length > 4096 || ScatterPalette.Length < 1)
                throw new ArgumentException("Palette is should have at least one color or max 4096 unique colors");

            if (Marker > 6 || Marker < 0)
            {
                throw new ArgumentException("Marker style can't be larger than 6 or smaller than 0");
            }
            foreach (var ms in MarkerSizes)
            {
                if (ms > 100 || ms < 0.1d)
                {
                    throw new ArgumentException("Marker sizes can't be larger than 50 or smaller than 0.1");
                }
            }
            foreach (var ms in values)
            {
                if (ms > double.MaxValue || ms < double.MinValue)
                {
                    throw new ArgumentException("S Values must be a double precision number");
                }
            }
            if (MarkerSizes.Length != ScatterValues.Length)
            {
                throw new ArgumentException("Marker sizes and S Values count must be the same");
            }
        }
        // tag 
        public DataType(string[] text, double size, int position)
        {
            AnnotationTexts = text;
            AnnotationTextSize = size;
            AnnotationTextPosition = position;

            TypeOfData = 3;

            if (AnnotationTexts.Length == 0)
            {
                throw new ArgumentException("Annotation array is empty");
            }
            if (AnnotationTextSize > 72d || AnnotationTextSize < 6d)
            {
                throw new ArgumentException("Annotation sizes can't be larger than 72 or smaller than 6pt");
            }
            if (AnnotationTextPosition > 4 || AnnotationTextPosition < 0)
            {
                throw new ArgumentException("Annotation position index out of range");
            }
        }

        public override string ToString()
        {
            string stringRepresentation;
            if (TypeOfData == 0)
            {
                stringRepresentation = "Line Data";
            }
            else if (TypeOfData == 1)
            {
                stringRepresentation = "Point Data";
            }
            else if (TypeOfData == 2)
            {
                stringRepresentation = "Scatter Data";
            }
            else 
            {
                stringRepresentation = "Annotation Data";
            }
            return stringRepresentation;
        }

        public Color DataColor { get; set; }
        public int TypeOfData { get; }
        public int Marker { get; set; }
        public int LineInterpolation { get; set; }
        public int LineStyle { get; set; }
        public double LineWeight { get; set; }
        public double[] ScatterValues { get; set; }
        public Color[] ScatterPalette { get; set; }
        public double[] MarkerSizes { get; set; }
        public string[] AnnotationTexts { get; set; } = new string[1] { "" };
        public double AnnotationTextSize { get; set; }
        public int AnnotationTextPosition { get; set; }
        
    }
}
