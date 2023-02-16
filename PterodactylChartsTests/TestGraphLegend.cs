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
            Add("Title example", 0, "Graph Legend" + Environment.NewLine + "Title: Title example");
            Add("Title example", 12, "Graph Legend" + Environment.NewLine + "Title: Title example");
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
    
    public class TestGraphLegendAdvancedHelper : TheoryData<string, int, int, int, double, string>
    {
        public TestGraphLegendAdvancedHelper()
        {
            Add("Title example", 0, 0, 0, 5.0, "Graph Legend" + Environment.NewLine + "Title: Title example");
            Add("Title example", 12, 1, 1, 140.0, "Graph Legend" + Environment.NewLine + "Title: Title example");
        }
    }

    public class TestGraphLegendAdvancedExceptionHelper : TheoryData<string, int, int, int, double, string>
    {
        public TestGraphLegendAdvancedExceptionHelper()
        {
            Add("Title example", -1, 0, 0, 5.0, "Position should be between 0 and 12");
            Add("Title example", 13, 0, 0, 5.0, "Position should be between 0 and 12");
            Add("Title example", 0, 2, 0, 5.0, "Placement should be between 0 and 1");
            Add("Title example", 0, -1, 0, 5.0, "Placement should be between 0 and 1");
            Add("Title example", 0, 0, -1, 5.0, "Orientation should be between 0 and 1");
            Add("Title example", 0, 0, 2, 5.0, "Orientation should be between 0 and 1");
            Add("Title example", 0, 0, 0, 4.9, "Text size should be between 5 and 140");
            Add("Title example", 0, 0, 0, 140.1, "Text size should be between 5 and 140");
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
        [Theory]
        [ClassData(typeof(TestGraphLegendAdvancedHelper))]
        public void CorrectDataAdvanced(string title, int position, int placement, int orientation, double textSize, string toString)
        {
            GraphLegend testObject = new GraphLegend(title, position, placement, orientation, textSize);
            Assert.Equal(title, testObject.Title);
            Assert.Equal(position, testObject.Position);
            Assert.Equal(placement, testObject.Placement);
            Assert.Equal(orientation, testObject.Orientation);
            Assert.Equal(textSize, testObject.TextSize);
            Assert.Equal(toString, testObject.ToString());
        }
        [Theory]
        [ClassData(typeof(TestGraphLegendAdvancedExceptionHelper))]
        public void CheckAdvancedExceptions(string title, int position, int placement, int orientation, double textSize, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new GraphLegend(title, position, placement, orientation, textSize));
            Assert.Equal(message, exception.Message);
        }
    }
}