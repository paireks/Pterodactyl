using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestFlowchartNode_CombinationsHelper : TheoryData<string, List<FlowchartNode>, int, List<string>>
    {
        public TestFlowchartNode_CombinationsHelper()
        {
            Add("First", null, 0, new List<string>());
            Add("Second", new List<FlowchartNode>
            {
                new FlowchartNode("First", null, 0)
            },
            0, new List<string>{"First --> Second"});
            Add("Second", new List<FlowchartNode>
            {
                new FlowchartNode("First", null, 0)
            },
            1, new List<string> { "First --> Second(Second)" });
            Add("Second", new List<FlowchartNode>
            {
                new FlowchartNode("First", null, 3)
            },
            1, new List<string> { "First[[First]] --> Second(Second)" });
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
            Add("Fourth", new List<FlowchartNode>
                {
                    new FlowchartNode("Third", new List<FlowchartNode>
                        {new FlowchartNode("Second", new List<FlowchartNode>
                            {new FlowchartNode("First", null, 0)}, 0)}, 0)
                },
                0, new List<string> { "First --> Second", "Second --> Third", "Third --> Fourth" });
            Add("Third", new List<FlowchartNode>
                {
                    new FlowchartNode("Second", new List<FlowchartNode>
                        {new FlowchartNode("First", null, 0)}, 0),
                    new FlowchartNode("First", null, 0)
                },
                0, new List<string> { "First --> Second", "Second --> Third", "First --> Third" });
            Add("Fourth", new List<FlowchartNode> //Diamond example
            {
                new FlowchartNode("Third1", new List<FlowchartNode>
                {new FlowchartNode("Second", new List<FlowchartNode>
                    {new FlowchartNode("First", null, 0)}, 0)}, 0),
                new FlowchartNode("Third2", new List<FlowchartNode>
                {new FlowchartNode("Second", new List<FlowchartNode>
                    {new FlowchartNode("First", null, 0)}, 0)}, 0)
            },
                0, new List<string> { "First --> Second", "Second --> Third1", "Third1 --> Fourth", "Second --> Third2", "Third2 --> Fourth" });
        }
    }
    public class TestFlowchartNode_Combinations
    {
        [Theory]
        [ClassData(typeof(TestFlowchartNode_CombinationsHelper))]
        public void CheckReportCreation(string text, List<FlowchartNode> inputNodes, int shape, List<string> flowchartPart)
        {
            FlowchartNode testObject = new FlowchartNode(text, inputNodes, shape);
            List<string> actual = testObject.FlowchartReportsPart;

            Assert.Equal(flowchartPart, actual);
        }
    }
}