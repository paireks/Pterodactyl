using System;
using System.Drawing;
using PterodactylCharts.Enums;

namespace PterodactylCharts
{
    public class DataType
    {
        #region Line

        public DataType(Color color)
        {
            DataColor = color;
            TypeOfData = TypeOfData.Line;
        }
        
        public DataType(Color color, int interpolation, int lineStyle, double lineWeight)
        {
            DataColor = color;
            LineInterpolation = interpolation;
            LineStyle = lineStyle;
            LineWeight = lineWeight;

            TypeOfData = TypeOfData.Line;

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

        #endregion

        #region Point

        public DataType(Color color, int marker)
        {
            DataColor = color;
            Marker = marker;

            TypeOfData = TypeOfData.Point;

            if (Marker > 4 || Marker < 0)
            {
                throw new ArgumentException("Marker can't be larger than 4 or smaller than 0");
            }
        }
        
        public DataType(Color color, int marker, double markerSize)
        {
            DataColor = color;
            Marker = marker;
            MarkerSizes = new [] { markerSize };

            TypeOfData = TypeOfData.Point;

            if (Marker > 6 || Marker < 0)
            {
                throw new ArgumentException("Marker can't be larger than 6 or smaller than 0");
            }
            if (MarkerSizes[0] > 100 || MarkerSizes[0] < 0.1d)
            {
                throw new ArgumentException("Marker size can't be larger than 100 or smaller than 0.1");
            }
        }

        #endregion

        #region Scatter

        public DataType(double[] scatterValues, double[] markerSizes, int marker, Color[] colors)
        {
            ScatterPalette = colors;
            Marker = marker;
            MarkerSizes = markerSizes;
            ScatterValues = scatterValues;

            TypeOfData = TypeOfData.Scatter;

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
                    throw new ArgumentException("Marker sizes can't be larger than 100 or smaller than 0.1");
                }
            }
            foreach (var ms in scatterValues)
            {
                if (ms > double.MaxValue || ms < double.MinValue)
                {
                    throw new ArgumentException("Scatter Values must be a double precision number");
                }
            }
            if (MarkerSizes.Length != ScatterValues.Length)
            {
                throw new ArgumentException("Marker sizes and Scatter Values count must be the same");
            }
        }

        #endregion

        #region Annotation

        public DataType(string[] annotationTexts, double annotationTextSize, int annotationTextPosition)
        {
            AnnotationTexts = annotationTexts;
            AnnotationTextSize = annotationTextSize;
            AnnotationTextPosition = annotationTextPosition;

            TypeOfData = TypeOfData.Annotation;

            if (AnnotationTexts.Length == 0)
            {
                throw new ArgumentException("Annotation array is empty");
            }
            if (AnnotationTextSize > 72d || AnnotationTextSize < 6d)
            {
                throw new ArgumentException("Annotation sizes can't be larger than 72 or smaller than 6");
            }
            if (AnnotationTextPosition > 4 || AnnotationTextPosition < 0)
            {
                throw new ArgumentException("Annotation position index out of range");
            }
        }

        #endregion

        public override string ToString()
        {
            string stringRepresentation;
            switch (TypeOfData)
            {
                case TypeOfData.Line:
                    stringRepresentation = "Line Data";
                    break;
                case TypeOfData.Point:
                    stringRepresentation = "Point Data";
                    break;
                case TypeOfData.Scatter:
                    stringRepresentation = "Scatter Data";
                    break;
                default:
                    stringRepresentation = "Annotation Data";
                    break;
            }
            return stringRepresentation;
        }

        public Color DataColor { get; }
        public TypeOfData TypeOfData { get; }
        public int Marker { get; }
        public int LineInterpolation { get; }
        public int LineStyle { get; }
        public double LineWeight { get; }
        public double[] ScatterValues { get; }
        public Color[] ScatterPalette { get; }
        public double[] MarkerSizes { get; }
        public string[] AnnotationTexts { get; } = { "" };
        public double AnnotationTextSize { get; }
        public int AnnotationTextPosition { get; }

    }
}
