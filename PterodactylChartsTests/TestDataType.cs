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
        [Theory]
        [ClassData(typeof(TestDataTypePointExceptionHelper))]
        public void CheckExceptions(Color color, int markerType, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DataType(color, markerType));
            Assert.Equal(message, exception.Message);
        }
    }
}