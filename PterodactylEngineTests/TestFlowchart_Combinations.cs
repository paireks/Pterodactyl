using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestFlowchart_CombinationsHelper : TheoryData<bool, List<FlowchartNode>, string>
    {
        public TestFlowchart_CombinationsHelper()
        {
            Add(true, new List<FlowchartNode>{new FlowchartNode("First", null, 0) }, "```mermaid\r\ngraph LR\r\n```");
            Add(true, new List<FlowchartNode>{new FlowchartNode("First", 1) }, "```mermaid\r\ngraph LR\r\n```");
            Add(true, new List<FlowchartNode>
            {
                new FlowchartNode("Second", new List<FlowchartNode>{new FlowchartNode("First", 0)}, 0)
            }, "```mermaid\r\ngraph LR\r\nFirst --> Second\r\n```");
            Add(false, new List<FlowchartNode>
            {
                new FlowchartNode("Second", new List<FlowchartNode>{new FlowchartNode("First", 0)}, 0)
            }, "```mermaid\r\ngraph TD\r\nFirst --> Second\r\n```");
            Add(true, new List<FlowchartNode>
            {
                new FlowchartNode("Third", new List<FlowchartNode>
                {
                    new FlowchartNode("Second", new List<FlowchartNode>
                    {
                        new FlowchartNode("First", 1)
                    }, 0)
                }, 0)
            }, "```mermaid\r\ngraph LR\r\nFirst(First) --> Second\r\nSecond --> Third\r\n```");
            Add(true, new List<FlowchartNode>
            {
                new FlowchartNode("Third", new List<FlowchartNode>
                {
                    new FlowchartNode("First", 0),
                    new FlowchartNode("Second", 0)
                }, 0)
            }, "```mermaid\r\ngraph LR\r\nFirst --> Third\r\nSecond --> Third\r\n```");
            Add(true, new List<FlowchartNode> //Diamond example
            {
                new FlowchartNode("Third1", new List<FlowchartNode>{new FlowchartNode("Second", new List<FlowchartNode>{new FlowchartNode("First", 0)}, 0)}, 0),
                new FlowchartNode("Third2", new List<FlowchartNode>{new FlowchartNode("Second", new List<FlowchartNode>{new FlowchartNode("First", 0)}, 0)}, 0),
            }, "```mermaid\r\ngraph LR\r\nFirst --> Second\r\nSecond --> Third1\r\nSecond --> Third2\r\n```");
        }
    }
    public class TestFlowchart_Combinations
    {
        [Theory]
        [ClassData(typeof(TestFlowchart_CombinationsHelper))]
        public void CheckReportCreation(bool direction, List<FlowchartNode> lastNodes, string expected)
        {
            Flowchart testObject = new Flowchart(direction, lastNodes);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}