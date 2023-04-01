using System;
using PterodactylCharts;
using PterodactylCharts.Enums;
using Xunit;

namespace UnitTestEngine
{
    public class TestGraphAxisHelper : TheoryData<string, string, string>
    {
        public TestGraphAxisHelper()
        {
            Add("XAxis", "Y Axis Name", "Graph Axis with X and Y");
        }
    }
    
    public class TestGraphAxisWithColorHelper : TheoryData<string, string, double, double, string>
    {
        public TestGraphAxisWithColorHelper()
        {
            Add("XAxis", "Y Axis Name", 0.0, 15.0, "Graph Axis with X and Y and Color");
            Add("X", "Y", 1.0, 100.0, "Graph Axis with X and Y and Color");
        }
    }

    public class TestGraphAxisWithColorExceptionHelper : TheoryData<string, string, double, double, string>
    {
        public TestGraphAxisWithColorExceptionHelper()
        {
            Add("X", "Y", -0.01, 100.0, "Padding is limited from 0.00 to 1.00");
            Add("X", "Y", 1.01, 100.0, "Padding is limited from 0.00 to 1.00");
            Add("X", "Y", 0.0, 4, "Text size must be in range [5-150] pt");
            Add("X", "Y", 0.0, 151, "Text size must be in range [5-150] pt");
        }
    }

    public class TestGraphAxis
    {
        [Theory]
        [ClassData(typeof(TestGraphAxisHelper))]
        public void CorrectData(string xAxisName, string yAxisName, string toString)
        {
            GraphAxis testObject = new GraphAxis(xAxisName, yAxisName);
            Assert.Equal(GraphAxisType.XAndY, testObject.GraphAxisType);
            Assert.Equal(xAxisName, testObject.XAxisName);
            Assert.Equal(yAxisName, testObject.YAxisName);
            Assert.Equal(toString, testObject.ToString());
        }
        
        [Theory]
        [ClassData(typeof(TestGraphAxisWithColorHelper))]
        public void TestGraphAxisWithColor(string xAxisName, string yAxisName, double globalAxisPadding, double textSize, string toString)
        {
            GraphAxis testObject = new GraphAxis(xAxisName, yAxisName, globalAxisPadding, textSize);
            Assert.Equal(GraphAxisType.XAndYAndColor, testObject.GraphAxisType);
            Assert.Equal(xAxisName, testObject.XAxisName);
            Assert.Equal(yAxisName, testObject.YAxisName);
            Assert.Equal(globalAxisPadding, testObject.GlobalAxisPadding);
            Assert.Equal(textSize, testObject.TextSize);
            Assert.Equal(toString, testObject.ToString());
        }

        [Theory]
        [ClassData(typeof(TestGraphAxisWithColorExceptionHelper))]
        public void TestGraphAxisWithColor_ThrowsException(string xAxisName, string yAxisName, double globalAxisPadding, double textSize, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new GraphAxis(xAxisName, yAxisName, globalAxisPadding, textSize));
            Assert.Equal(message, exception.Message);
        }
    }
}