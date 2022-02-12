using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PterodactylCharts;
using Xunit;

namespace UnitTestEngine
{
    public class TestDataTypeLineHelper : TheoryData<Color, string, int>
    {
        public TestDataTypeLineHelper()
        {
            Add(Color.Aqua, "Line Data", 0);
            Add(Color.FromArgb(2, 10,23,12), "Line Data", 0);
        }
    }
    public class TestDataTypePointHelper : TheoryData<Color, int, string, int>
    {
        public TestDataTypePointHelper()
        {
            Add(Color.Aqua, 0, "Point Data", 1);
            Add(Color.FromArgb(2, 10, 23, 12), 4, "Point Data", 1);
        }
    }

    public class TestDataTypePointExceptionHelper : TheoryData<Color, int, string>
    {
        public TestDataTypePointExceptionHelper()
        {
            Add(Color.Aqua, -1, "Marker can't be larger than 4 or smaller than 0");
            Add(Color.Aqua, 5, "Marker can't be larger than 4 or smaller than 0");
        }
    }

    public class TestDataType
    {
        [Theory]
        [ClassData(typeof(TestDataTypeLineHelper))]
        public void CorrectDataLine(Color color, string toString, int dataType)
        {
            DataType testObject = new DataType(color);
            Assert.Equal(color, testObject.DataColor);
            Assert.Equal(dataType, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
        }
        [Theory]
        [ClassData(typeof(TestDataTypePointHelper))]
        public void CorrectDataPoint(Color color, int markerType, string toString, int dataType)
        {
            DataType testObject = new DataType(color, markerType);
            Assert.Equal(color, testObject.DataColor);
            Assert.Equal(markerType, testObject.Marker);
            Assert.Equal(dataType, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
        }

        // advanced 
        [Theory]
        [ClassData(typeof(TestDataTypePointHelper))]
        public void CorrectDataPoint2(Color color, int markerType, double size, string toString, int dataType)
        {
            DataType testObject = new DataType(color, markerType, size);
            Assert.Equal(color, testObject.DataColor);
            Assert.Equal(markerType, testObject.Marker);
            Assert.Equal(size, testObject.MarkerSizes[0]);
            Assert.Equal(dataType, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
        }
        [Theory]
        [ClassData(typeof(TestDataTypeLineHelper))]
        public void CorrectDataLine2(Color color, int interpolation, int style, double thickness, string toString, int dataType)
        {
            DataType testObject = new DataType(color, interpolation, style, thickness);
            Assert.Equal(color, testObject.DataColor);
            Assert.Equal(interpolation, testObject.LineInterpolation);
            Assert.Equal(style, testObject.LineStyle);
            Assert.Equal(thickness, testObject.LineWeight);
            Assert.Equal(dataType, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
        }
        [Theory]
        [ClassData(typeof(TestDataTypePointHelper))]
        public void CorrectDataScatter(Color[] colors, int marker, double[] sizes, double[] values, string toString, int dataType)
        {
            DataType testObject = new DataType(colors, marker, sizes, values);
            Assert.Equal(colors, testObject.ScatterPalette);
            Assert.Equal(marker, testObject.Marker);
            Assert.Equal(sizes, testObject.MarkerSizes);
            Assert.Equal(values, testObject.ScatterValues);
            Assert.Equal(dataType, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
        }
        [Theory]
        [ClassData(typeof(TestDataTypePointHelper))]
        public void CorrectAnnotation(string[] text, double size, string toString, int dataType)
        {
            DataType testObject = new DataType(text, size);
            Assert.Equal(text, testObject.AnnotationTexts);
            Assert.Equal(size, testObject.AnnotationTextSize);
            Assert.Equal(dataType, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
        }

        [Theory]
        [ClassData(typeof(TestDataTypePointExceptionHelper))]
        public void CheckExceptions(Color color, int markerType, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DataType(color, markerType));
            Assert.Equal(message, exception.Message);
        }
    }
}