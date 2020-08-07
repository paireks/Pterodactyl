using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PterodactylCharts;
using Xunit;

namespace UnitTestEngine
{
    public class TestColumnChartEngineHelper : TheoryData<bool, string,
        List<double>, List<string>, string, List<Color>, string, string>
    {
        public TestColumnChartEngineHelper()
        {
            Add(false, "Test title", new List<double> { 0.0, 1.0 }, new List<string> { "first", "second" }, "{0:0.00[m]}",
                new List<Color> { Color.Black, Color.White }, "", "");
            Add(false, "Test title", new List<double> { 0.0, 1.0 }, new List<string> { "first", "second" }, "{0:0.00[m]}",
                new List<Color> { Color.FromArgb(0, 0, 4, 0), Color.FromArgb(10, 23, 23, 4) }, "", "");
            Add(false, "Test title", new List<double> { 0.0 }, new List<string> { "first" }, "{0:0.00[m]}",
                new List<Color> { Color.White }, "", "");
            Add(false, "Test title", new List<double> { 0.0 }, new List<string> { "first" }, "{0:0.00[m]}",
                new List<Color> { Color.White }, @"SampleFolder\Test.png",
                @"![Test title](SampleFolder\Test.png)");
            Add(false, "Test title", new List<double> { 0.0 }, new List<string> { "first" }, "{0:0.00[m]}",
                new List<Color> { Color.White }, @"SampleFolder\Test", "");
        }
    }
    public class TestColumnChartEngineExceptionHelper : TheoryData<bool, string,
        List<double>, List<string>, string, List<Color>, string, string>
    {
        public TestColumnChartEngineExceptionHelper()
        {
            Add(false, "Test title", new List<double> { 0.0, 1.0 }, new List<string> { "first" }, "{0:0.00[m]}",
                new List<Color> { Color.Black, Color.White }, "",
                "Values should match Names and Colors - check if each list has the same number of elements.");
            Add(false, "Test title", new List<double> { 0.0, 1.0 }, new List<string> { "first", "second" }, "{0:0.00[m]}",
                new List<Color> { Color.Black }, "",
                "Values should match Names and Colors - check if each list has the same number of elements.");
            Add(false, "Test title", new List<double> { 0.0 }, new List<string> { "first", "second" }, "{0:0.00[m]}",
                new List<Color> { Color.Black, Color.AliceBlue }, "",
                "Values should match Names and Colors - check if each list has the same number of elements.");
        }
    }

    public class TestColumnChartEngine
    {
        [Theory]
        [ClassData(typeof(TestColumnChartEngineHelper))]
        public void CorrectData(bool showGraph, string title,
            List<double> values, List<string> names, string textFormat, List<Color> colors, string path, string expected)
        {
            ColumnChartEngine testObject = new ColumnChartEngine(showGraph, title, values, names, textFormat, colors, path);
            Assert.Equal(showGraph, testObject.ShowGraph);
            Assert.Equal(title, testObject.Title);
            Assert.Equal(values, testObject.Values);
            Assert.Equal(names, testObject.Names);
            Assert.Equal(textFormat, testObject.TextFormat);
            Assert.Equal(colors, testObject.Colors);
            Assert.Equal(path, testObject.Path);
        }

        [Theory]
        [ClassData(typeof(TestColumnChartEngineHelper))]
        public void CheckReportCreation(bool showGraph, string title,
            List<double> values, List<string> names, string textFormat, List<Color> colors, string path, string expected)
        {
            ColumnChartEngine testObject = new ColumnChartEngine(showGraph, title, values, names, textFormat, colors, path);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(TestColumnChartEngineExceptionHelper))]
        public void CheckExceptions(bool showGraph, string title,
            List<double> values, List<string> names, string textFormat, List<Color> colors, string path, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new ColumnChartEngine(showGraph, title, values, names, textFormat, colors, path));
            Assert.Equal(message, exception.Message);
        }
    }
}