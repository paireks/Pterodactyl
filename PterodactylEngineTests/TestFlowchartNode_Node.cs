using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestFlowchartNode_NodeHelper : TheoryData<string, List<FlowchartNode>, int, string>
    {
        public TestFlowchartNode_NodeHelper()
        {
            Add("First", null, 0, "First");
            Add("Second", new List<FlowchartNode>
                {
                    new FlowchartNode("First", null, 0)
                },
                0, "Second");
            Add("Third", new List<FlowchartNode>
                {
                    new FlowchartNode("First", null, 0),
                    new FlowchartNode("Second", null, 0)
                },
                0, "Third");
            Add("Third", new List<FlowchartNode>
                {
                    new FlowchartNode("Second", new List<FlowchartNode>
                        {new FlowchartNode("First", null, 0)}, 0)
                },
                0, "Third");
            Add("First", null, 1, "First");
            Add("Third", new List<FlowchartNode>
                {
                    new FlowchartNode("First", null, 0),
                    new FlowchartNode("Second", null, 0)
                },
                2, "Third");
            Add("Space text", null, 1, "Space_text");
        }
    }
    public class TestFlowchartNode_Node
    {
        [Theory]
        [ClassData(typeof(TestFlowchartNode_NodeHelper))]
        public void CorrectData(string text, List<FlowchartNode> previousNodes, int shape, string expectedText)
        {
            FlowchartNode testObject = new FlowchartNode(text, shape);
            Assert.Equal(expectedText, testObject.Text);
            Assert.Equal(shape, testObject.Shape);
        }

        [Fact]
        public void TestFlowchartNodeToString()
        {
            FlowchartNode testObject = new FlowchartNode("Test", 0);
            Assert.Equal("Flowchart Node: Test", testObject.ToString());
        }
    }
}