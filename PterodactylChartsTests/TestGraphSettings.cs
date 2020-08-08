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
            Add("Title example", new GraphSizes(200, 200), Color.Aqua, new GraphAxis("X", "Y"), "Graph Settings");
        }
    }
    public class TestGraphSettings
    {
        [Theory]
        [ClassData(typeof(TestGraphSettingsHelper))]
        public void CorrectData(string graphTitle, GraphSizes graphSizes, Color graphColor, GraphAxis graphAxis, string toString)
        {
            GraphSettings testObject = new GraphSettings(graphTitle, graphSizes, graphColor, graphAxis);
            Assert.Equal(graphTitle, testObject.Title);
            Assert.Equal(graphSizes, testObject.Sizes);
            Assert.Equal(graphColor, testObject.GraphColor);
            Assert.Equal(graphAxis, testObject.Axis);
            Assert.Equal(toString, testObject.ToString());
        }
    }
}