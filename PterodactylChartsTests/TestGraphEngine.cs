using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PterodactylCharts;
using Xunit;

namespace UnitTestEngine
{
    public class TestGraphEngineHelper : TheoryData<bool, GraphElements, GraphSettings, string, string>
    {
        static GraphData graphData = new GraphData(new List<List<double>> { new List<double> { 0, 1, 2 }, new List<double> { 1, 2, 5.5 } },
            new List<List<double>> { new List<double> { -2, 0, 4 }, new List<double> { 5, 2, -1 } },
            new List<string> { "First", "Second" },
            new List<DataType> { new DataType(Color.Navy), new DataType(Color.AliceBlue) });
        GraphElements graphElements = new GraphElements(graphData, new GraphLegend("Legend", 0));
        GraphSettings graphSettings = new GraphSettings("Test title", new GraphSizes(200, 200), Color.AliceBlue, new GraphAxis("X", "Y"));
        public TestGraphEngineHelper()
        {
            Add(false, graphElements, graphSettings, @"SampleFolder\Test.png", @"![Test title](SampleFolder\Test.png)");
            Add(false, graphElements, graphSettings, @"SampleFolder\Test", "");
        }
    }
    public class TestGraphEngine
    {
        [Theory]
        [ClassData(typeof(TestGraphEngineHelper))]
        public void CorrectData(bool showGraph, GraphElements graphElements, GraphSettings graphSettings, string path, string expected)
        {
            GraphEngine testObject = new GraphEngine(showGraph, graphElements, graphSettings, path);
            Assert.Equal(showGraph, testObject.ShowGraph);
            Assert.Equal(graphElements, testObject.Elements);
            Assert.Equal(graphSettings, testObject.Settings);
            Assert.Equal(path, testObject.Path);
        }

        [Theory]
        [ClassData(typeof(TestGraphEngineHelper))]
        public void CheckReportCreation(bool showGraph, GraphElements graphElements, GraphSettings graphSettings, string path, string expected)
        {
            GraphEngine testObject = new GraphEngine(showGraph, graphElements, graphSettings, path);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}