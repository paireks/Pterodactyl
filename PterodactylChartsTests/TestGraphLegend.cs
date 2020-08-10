using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PterodactylCharts;
using Xunit;

namespace UnitTestEngine
{
    public class TestGraphLegendHelper : TheoryData<string, int, string>
    {
        public TestGraphLegendHelper()
        {
            Add("Title example", 0, "Graph Legend" + Environment.NewLine + "Title: Title example"+ Environment.NewLine + "Position: 0");
            Add("Title example", 12, "Graph Legend" + Environment.NewLine + "Title: Title example"+ Environment.NewLine + "Position: 12");
        }
    }

    public class TestGraphLegendExceptionHelper : TheoryData<string, int, string>
    {
        public TestGraphLegendExceptionHelper()
        {
            Add("Title example", -1, "Position should be between 0 and 12");
            Add("Title example", 13, "Position should be between 0 and 12");
        }
    }
    public class TestGraphLegend
    {
        [Theory]
        [ClassData(typeof(TestGraphLegendHelper))]
        public void CorrectData(string title, int position, string toString)
        {
            GraphLegend testObject = new GraphLegend(title, position);
            Assert.Equal(title, testObject.Title);
            Assert.Equal(position, testObject.Position);
            Assert.Equal(toString, testObject.ToString());
        }
        [Theory]
        [ClassData(typeof(TestGraphLegendExceptionHelper))]
        public void CheckExceptions(string title, int position, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new GraphLegend(title, position));
            Assert.Equal(message, exception.Message);
        }
    }
}