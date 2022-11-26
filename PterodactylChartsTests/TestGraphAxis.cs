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
    
    public class TestGraphAxisWithColorHelper : TheoryData<string, string, string, double, double, string>
    {
        public TestGraphAxisWithColorHelper()
        {
            Add("XAxis", "Y Axis Name", "Color Axis Name", 0.0, 15.0, "Graph Axis with X and Y and Color");
            Add("X", "Y", "Color", 20.0, 100.0, "Graph Axis with X and Y and Color");
        }
    }

    public class TestGraphAxisWithColorExceptionHelper : TheoryData<string, string, string, double, double, string>
    {
        public TestGraphAxisWithColorExceptionHelper()
        {
            Add("X", "Y", "Color", -1, 100.0, "Padding is limited from 0.00 to 250.00");
            Add("X", "Y", "Color", 251, 100.0, "Padding is limited from 0.00 to 250.00");
            Add("X", "Y", "Color", 20.0, 4, "Text size must be in range [5-150] pt");
            Add("X", "Y", "Color", 20.0, 151, "Text size must be in range [5-150] pt");
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
        public void TestGraphAxisWithColor(string xAxisName, string yAxisName, string colorAxisName, double globalAxisPadding, double textSize, string toString)
        {
            GraphAxis testObject = new GraphAxis(xAxisName, yAxisName, colorAxisName, globalAxisPadding, textSize);
            Assert.Equal(GraphAxisType.XAndYAndColor, testObject.GraphAxisType);
            Assert.Equal(xAxisName, testObject.XAxisName);
            Assert.Equal(yAxisName, testObject.YAxisName);
            Assert.Equal(colorAxisName, testObject.ColorAxisName);
            Assert.Equal(globalAxisPadding, testObject.GlobalAxisPadding);
            Assert.Equal(textSize, testObject.TextSize);
            Assert.Equal(toString, testObject.ToString());
        }

        [Theory]
        [ClassData(typeof(TestGraphAxisWithColorExceptionHelper))]
        public void TestGraphAxisWithColor_ThrowsException(string xAxisName, string yAxisName, string colorAxisName, double globalAxisPadding, double textSize, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new GraphAxis(xAxisName, yAxisName, colorAxisName, globalAxisPadding, textSize));
            Assert.Equal(message, exception.Message);
        }
    }
}