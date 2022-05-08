using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PterodactylCharts;
using Xunit;

namespace UnitTestEngine
{
    public class TestGraphSettingsHelper : TheoryData<string, GraphSizes, Color, GraphAxis, string>
    {
        public TestGraphSettingsHelper()
        {
            Add("Title example", new GraphSizes(200, 200), Color.Aqua, new GraphAxis("X", "Y","C", 0, 2), "Graph Settings");
        }
    }
    public class TestGraphSettings
    {
        [Theory]
        [ClassData(typeof(TestGraphSettingsHelper))]
        public void CorrectData(string graphTitle,int tSize, GraphSizes graphSizes, Color graphColor, GraphAxis graphAxis,int padding, string toString)
        {
            GraphSettings testObject = new GraphSettings(graphTitle, tSize, graphSizes, graphColor, graphAxis, padding);
            Assert.Equal(graphTitle, testObject.Title);
            Assert.Equal(tSize, testObject.TitleSize);
            Assert.Equal(graphSizes, testObject.Sizes);
            Assert.Equal(graphColor, testObject.GraphColor);
            Assert.Equal(graphAxis, testObject.Axis);
            Assert.Equal(padding, testObject.Padding);
            Assert.Equal(toString, testObject.ToString());
        }
    }
}