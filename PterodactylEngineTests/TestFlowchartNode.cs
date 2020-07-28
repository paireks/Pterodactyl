using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestFlowchartNodeHelper : TheoryData<string, List<FlowchartNode>, int, List<string>>
    {
        public TestFlowchartNodeHelper()
        {
            Add("First", null, 0, new List<string>());
            Add("Second", new List<FlowchartNode>
            {
                new FlowchartNode("First", null, 0)
            },
            0, new List<string>{"First --> Second"});
            Add("Third", new List<FlowchartNode>
            {
                new FlowchartNode("First", null, 0),
                new FlowchartNode("Second", null, 0)
            },
            0, new List<string> { "First --> Third", "Second --> Third" });
            Add("Third", new List<FlowchartNode>
            {
                new FlowchartNode("Second", new List<FlowchartNode>
                    {new FlowchartNode("First", null, 0)}, 0)
            },
            0, new List<string> { "First --> Second", "Second --> Third" });
        }
    }
    public class TestFlowchartNode
    {
        [Theory]
        [ClassData(typeof(TestFlowchartNodeHelper))]
        public void CorrectData(string text, List<FlowchartNode> inputNodes, int shape, List<string> flowchartPart)
        {
            FlowchartNode testObject = new FlowchartNode(text, inputNodes, shape);
            Assert.Equal(text, testObject.Text);
            Assert.Equal(inputNodes, testObject.InputNodes);
            Assert.Equal(shape, testObject.Shape);
        }

        [Theory]
        [ClassData(typeof(TestFlowchartNodeHelper))]
        public void CheckReportCreation(string text, List<FlowchartNode> inputNodes, int shape, List<string> flowchartPart)
        {
            FlowchartNode testObject = new FlowchartNode(text, inputNodes, shape);
            List<string> actual = testObject.FlowchartPart;

            Assert.Equal(flowchartPart, actual);
        }
    }
}