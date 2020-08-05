using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestFlowchartNode_StartNodeHelper : TheoryData<string, int, string>
    {
        public TestFlowchartNode_StartNodeHelper()
        {
            Add("Test", 0, "Test");
            Add("Space text", 0, "Space_text");
        }
    }
    public class TestFlowchartNode_StartNode
    {
        [Theory]
        [ClassData(typeof(TestFlowchartNode_StartNodeHelper))]
        public void CorrectData(string text, int shape, string expectedText)
        {
            FlowchartNode testObject = new FlowchartNode(text, shape);
            Assert.Equal(expectedText, testObject.Text);
            Assert.Equal(shape, testObject.Shape);
        }
    }
}