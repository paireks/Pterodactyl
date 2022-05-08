using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PterodactylCharts;
using Xunit;

namespace UnitTestEngine
{
    public class TestGraphElementsHelper : TheoryData<GraphData, GraphLegend, string>
    {
        GraphData testData = new GraphData(new List<List<double>>{new List<double>{0, 1, 2}, new List<double>{1, 2, 5.5}}, 
            new List<List<double>> {new List<double>{-2, 0, 4}, new List<double>{5, 2, -1}},
            new List<string>{"First", "Second"},
            new List<DataType>{new DataType(Color.Navy), new DataType(Color.AliceBlue)});
        public TestGraphElementsHelper()
        {
            Add(null, null, "Graph Elements");
           // Add(testData, new GraphLegend("Legend", 2, 1, 1), "Graph Elements") ;
        }
    }
    public class TestGraphElements
    {
        [Theory]
        [ClassData(typeof(TestGraphElementsHelper))]
        public void CorrectData(GraphData graphData, GraphLegend graphLegend, string toString)
        {
            GraphElements testObject = new GraphElements(graphData, graphLegend);
            Assert.Equal(graphData, testObject.Data);
            Assert.Equal(graphLegend, testObject.Legend);
            Assert.Equal(toString, testObject.ToString());
        }
    }
}