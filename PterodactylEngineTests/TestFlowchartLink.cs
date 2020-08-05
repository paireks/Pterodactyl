using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestFlowchartLinkHelper : TheoryData<int, string, string>
    {
        public TestFlowchartLinkHelper()
        {
            Add(0, "", " --> ");
            Add(1, "", " --- ");
            Add(2, "", " .-> ");
            Add(0, "Test" , " -- Test --> ");
            Add(1, "Test" , " -- Test --- ");
            Add(0, "Space text", " -- Space text --> ");
            Add(0, "Hehe", " -- Hehe --> ");
        }
    }
    public class TestFlowchartLinkExceptionHelper : TheoryData<int, string, string>
    {
        public TestFlowchartLinkExceptionHelper()
        {
            Add(-1, "", "Link type can be only between 0 and 3");
            Add(4, "", "Link type can be only between 0 and 3");
        }
    }
    public class TestFlowchartLink
    {
        [Theory]
        [ClassData(typeof(TestFlowchartLinkHelper))]
        public void CorrectData(int type, string text, string linkTextPart)
        {
            FlowchartLink testObject = new FlowchartLink(type, text);
            Assert.Equal(text, testObject.Text);
            Assert.Equal(type, testObject.LinkType);
        }

        [Theory]
        [ClassData(typeof(TestFlowchartLinkHelper))]
        public void CheckLinkOutText(int type, string text, string linkTextPart)
        {
            FlowchartLink testObject = new FlowchartLink(type, text);
            FlowchartNode nodeToEdit = new FlowchartNode("TestNode", 0);

            Assert.Equal(linkTextPart, testObject.ReturnModifiedNode(nodeToEdit).LinkOutTextPart);
        }

        [Theory]
        [ClassData(typeof(TestFlowchartLinkExceptionHelper))]
        public void CheckExceptions(int type, string text, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new FlowchartLink(type, text));
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void TestFlowchartLinkToString()
        {
            FlowchartLink testObject = new FlowchartLink(0, "");
            Assert.Equal("Flowchart Link", testObject.ToString());
        }
    }
}