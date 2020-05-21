using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestPieChartHelper : TheoryData<string, List<string>, List<double>, string>
    {
        public TestPieChartHelper()
        {
            Add("Test Title", new List<string> { "First", "Second" }, new List<double> { 1, 2.07 },
                "```mermaid" + Environment.NewLine + "pie title Test Title" + Environment.NewLine +
                "    \"First\" : 1" + Environment.NewLine + "    \"Second\" : 2,07" + Environment.NewLine + "```");
            Add("Test Title", new List<string> { "First" }, new List<double> { 5.1230123 },
                 "```mermaid" + Environment.NewLine + "pie title Test Title" + Environment.NewLine +
                "    \"First\" : 5,1230123" + Environment.NewLine + "```");
        }
    }

    public class TestPieChartExceptionHelper : TheoryData<string, List<string>, List<double>, string>
    {
        public TestPieChartExceptionHelper()
        {
            Add("Test Title", new List<string> { "First" }, new List<double> { 1, 2.07 },
                "Categories list should match values list. Check if both input lists have the same number of elements.");
            Add("Test Title", new List<string> { "First", "Second" }, new List<double> { 1 },
                "Categories list should match values list. Check if both input lists have the same number of elements.");
            Add("Test Title", new List<string> {}, new List<double> { 1, 2.07 },
                "Set categories");
            Add("Test Title", new List<string> {"First", "Second"}, new List<double> {},
                "Set values");
            Add("", new List<string> { "First", "Second" }, new List<double> { 1, 2.07 },
                "Set Pie Chart title");

        }
    }

    public class TestPieChart
    {
        [Theory]
        [ClassData(typeof(TestPieChartHelper))]
        public void CorrectData(string title, List<string> categories, List<double> values, string expected)
        {
            PieChart testObject = new PieChart(title, categories, values);
            Assert.Equal(title, testObject.Title);
            Assert.Equal(categories, testObject.Categories);
            Assert.Equal(values, testObject.Values);
        }

        [Theory]
        [ClassData(typeof(TestPieChartHelper))]
        public void CheckReportCreation(string title, List<string> categories, List<double> values, string expected)
        {
            PieChart testObject = new PieChart(title, categories, values);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(TestPieChartExceptionHelper))]
        public void CheckExceptions(string title, List<string> categories, List<double> values, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new PieChart(title, categories, values));
            Assert.Equal(message, exception.Message);
        }

    }
}
