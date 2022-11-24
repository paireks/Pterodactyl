using System;
using System.Drawing;
using PterodactylCharts;
using PterodactylCharts.Enums;
using Xunit;

namespace UnitTestEngine
{
    public class TestDataTypeLineHelper : TheoryData<Color, string, TypeOfData>
    {
        public TestDataTypeLineHelper()
        {
            Add(Color.Aqua, "Line Data", TypeOfData.Line);
            Add(Color.FromArgb(2, 10,23,12), "Line Data", TypeOfData.Line);
        }
    }
    public class TestDataTypePointHelper : TheoryData<Color, int, string, TypeOfData>
    {
        public TestDataTypePointHelper()
        {
            Add(Color.Aqua, 0, "Point Data", TypeOfData.Point);
            Add(Color.FromArgb(2, 10, 23, 12), 4, "Point Data", TypeOfData.Point);
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
        public void CorrectDataLine(Color color, string toString, TypeOfData typeOfData)
        {
            DataType testObject = new DataType(color);
            Assert.Equal(color, testObject.DataColor);
            Assert.Equal(typeOfData, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
        }
        [Theory]
        [ClassData(typeof(TestDataTypePointHelper))]
        public void CorrectDataPoint(Color color, int markerType, string toString, TypeOfData typeOfData)
        {
            DataType testObject = new DataType(color, markerType);
            Assert.Equal(color, testObject.DataColor);
            Assert.Equal(markerType, testObject.Marker);
            Assert.Equal(typeOfData, testObject.TypeOfData);
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