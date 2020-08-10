using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PterodactylCharts;
using Xunit;

namespace UnitTestEngine
{
    public class TestGraphAxisHelper : TheoryData<string, string, string>
    {
        public TestGraphAxisHelper()
        {
            Add("XAxis", "Y Axis Name", "Graph Axises\r\nX Axis: XAxis\r\nY Axis: Y Axis Name");
        }
    }

    public class TestGraphAxis
    {
        [Theory]
        [ClassData(typeof(TestGraphAxisHelper))]
        public void CorrectData(string xAxisName, string yAxisName, string toString)
        {
            GraphAxis testObject = new GraphAxis(xAxisName, yAxisName);
            Assert.Equal(xAxisName, testObject.XAxisName);
            Assert.Equal(yAxisName, testObject.YAxisName);
            Assert.Equal(toString, testObject.ToString());
        }
    }
}