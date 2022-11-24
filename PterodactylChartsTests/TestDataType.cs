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

    public class TestDataTypeLineAdvancedHelper : TheoryData<Color, int, int, double, string, TypeOfData>
    {
        public TestDataTypeLineAdvancedHelper()
        {
            Add(Color.Aqua, 2, 3, 0.5, "Line Data", TypeOfData.Line);
            Add(Color.Red, 3, 2, 10.2, "Line Data", TypeOfData.Line);
        }
    }

    public class TestDataTypeLineAdvancedHelperExceptions : TheoryData<Color, int, int, double, string>
    {
        public TestDataTypeLineAdvancedHelperExceptions()
        {
            Add(Color.Aqua, -1, 3, 0.5, "Interpolation can't be larger than 4 or smaller than 0");
            Add(Color.Aqua, 5, 3, 0.5, "Interpolation can't be larger than 4 or smaller than 0");
            Add(Color.Aqua, 2, -1, 0.5, "Line Style can't be larger than 4 or smaller than 0");
            Add(Color.Aqua, 2, 5, 0.5, "Line Style can't be larger than 4 or smaller than 0");
            Add(Color.Aqua, 2, 3, 20.1, "Line thickness can be from 0.1 to 20.0");
            Add(Color.Aqua, 2, 3, 0.09, "Line thickness can be from 0.1 to 20.0");
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
    
    public class TestDataTypePointAdvancedHelper : TheoryData<Color, int, double, string, TypeOfData>
    {
        public TestDataTypePointAdvancedHelper()
        {
            Add(Color.Aqua, 0, 0.2, "Point Data", TypeOfData.Point);
            Add(Color.FromArgb(2, 10, 23, 12), 4, 11.5, "Point Data", TypeOfData.Point);
        }
    }
    
    public class TestDataTypePointAdvancedExceptionHelper : TheoryData<Color, int, double, string>
    {
        public TestDataTypePointAdvancedExceptionHelper()
        {
            Add(Color.Aqua, -1, 0.2, "Marker can't be larger than 6 or smaller than 0");
            Add(Color.Aqua, 7, 0.2, "Marker can't be larger than 6 or smaller than 0");
            Add(Color.Aqua, 0, 0.09, "Marker size can't be larger than 100 or smaller than 0.1");
            Add(Color.Aqua, 0, 100.1, "Marker size can't be larger than 100 or smaller than 0.1");
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
        [ClassData(typeof(TestDataTypeLineAdvancedHelper))]
        public void CorrectDataLineAdvance(Color color, int interpolation, int lineStyle, double lineWeight, string toString, TypeOfData typeOfData)
        {
            DataType testObject = new DataType(color, interpolation, lineStyle, lineWeight);
            Assert.Equal(color, testObject.DataColor);
            Assert.Equal(typeOfData, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
            Assert.Equal(interpolation, testObject.LineInterpolation);
            Assert.Equal(lineStyle, testObject.LineStyle);
            Assert.Equal(lineWeight, testObject.LineWeight);
        }
        
        [Theory]
        [ClassData(typeof(TestDataTypeLineAdvancedHelperExceptions))]
        public void DataLineAdvanceExceptions(Color color, int interpolation, int lineStyle, double lineWeight, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DataType(color, interpolation, lineStyle, lineWeight));
            Assert.Equal(message, exception.Message);
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
        
        [Theory]
        [ClassData(typeof(TestDataTypePointAdvancedHelper))]
        public void CorrectDataPointAdvanced(Color color, int markerType, double markerSize, string toString, TypeOfData typeOfData)
        {
            DataType testObject = new DataType(color, markerType, markerSize);
            Assert.Equal(color, testObject.DataColor);
            Assert.Equal(markerType, testObject.Marker);
            Assert.Equal(markerSize, testObject.MarkerSizes[0]);
            Assert.Single(testObject.MarkerSizes);
            Assert.Equal(typeOfData, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
        }
        [Theory]
        [ClassData(typeof(TestDataTypePointAdvancedExceptionHelper))]
        public void DataPointAdvanceExceptions(Color color, int markerType, double markerSize, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DataType(color, markerType, markerSize));
            Assert.Equal(message, exception.Message);
        }
    }
}