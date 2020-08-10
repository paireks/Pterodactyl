using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PterodactylCharts;
using Xunit;

namespace UnitTestEngine
{
    public class TestLineGraphEngineHelper : TheoryData<bool, string, List<double>, List<double>, string, string, Color, string, string>
    {
        public TestLineGraphEngineHelper()
        {
            Add(false, "Test title", new List<double>{0.0, 1.0}, new List<double>{0.0, 1.0}, "x", "y", Color.Black, "", "");
            Add(false, "Test title", new List<double>{0.0}, new List<double>{5.0}, "x", "y", Color.Black, "", "");
            Add(false, "", new List<double> { 0.0, 1.0 }, new List<double> { 0.0, 1.0 }, "x", "y", Color.Black, "", "");
            Add(false, "Test title", new List<double> { 0.0, 1.0 }, new List<double> { 0.0, 1.0 }, "", "y", Color.Black, "", "");
            Add(false, "Test title", new List<double> { 0.0, 1.0 }, new List<double> { 0.0, 1.0 }, "many words", "y", Color.Black, "", "");
            Add(true, "Test title", new List<double> { 0.0, 1.0 }, new List<double> { 0.0, 1.0 }, "x", "y", Color.Black, "", "");
            Add(false, "Test title", new List<double> { 0.0, 1.0 }, new List<double> { 0.0, 1.0 }, "x", "y", Color.Black, @"SampleFolder\Test.png",
                @"![Test title](SampleFolder\Test.png)");
            Add(false, "Test title", new List<double> { 0.0, 1.0 }, new List<double> { 0.0, 1.0 }, "x", "y", Color.FromArgb(red:10, blue:11, green:12, alpha: 14), "", "");
        }
    }
    public class TestLineGraphEngineExceptionHelper : TheoryData<bool, string, List<double>, List<double>, string, string, Color, string, string>
    {
        public TestLineGraphEngineExceptionHelper()
        {
            Add(false, "Test title", new List<double> { 0.0 }, new List<double> { 0.0, 1.0 }, "x", "y", Color.Black, "", 
                "X Values should match Y Values - check if both lists have the same number of elements.");
            Add(false, "Test title", new List<double> { 0.0, 1.0 }, new List<double> { 0.0 }, "x", "y", Color.Black, "",
                "X Values should match Y Values - check if both lists have the same number of elements.");
        }
    }

    public class TestLineGraphEngine
    {
        [Theory]
        [ClassData(typeof(TestLineGraphEngineHelper))]
        public void CorrectData(bool showGraph, string title,
            List<double> xValues, List<double> yValues, string xName,
            string yName, Color color, string path, string expected)
        {
            LineGraphEngine testObject = new LineGraphEngine(showGraph, title, xValues, yValues, xName, yName, color, path);
            Assert.Equal(showGraph, testObject.ShowGraph);
            Assert.Equal(title, testObject.Title);
            Assert.Equal(new List<List<double>>{xValues}, testObject.XValues);
            Assert.Equal(new List<List<double>> { yValues }, testObject.YValues);
            Assert.Equal(xName, testObject.XName);
            Assert.Equal(yName, testObject.YName);
            Assert.Equal(new List<Color>{color}, testObject.Colors);
            Assert.Equal(path, testObject.Path);
        }

        [Theory]
        [ClassData(typeof(TestLineGraphEngineHelper))]
        public void CheckReportCreation(bool showGraph, string title,
            List<double> xValues, List<double> yValues, string xName,
            string yName, Color color, string path, string expected)
        {
            LineGraphEngine testObject = new LineGraphEngine(showGraph, title, xValues, yValues, xName, yName, color, path);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(TestLineGraphEngineExceptionHelper))]
        public void CheckExceptions(bool showGraph, string title,
            List<double> xValues, List<double> yValues, string xName,
            string yName, Color color, string path, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new LineGraphEngine(showGraph, title, xValues, yValues, xName, yName, color, path));
            Assert.Equal(message, exception.Message);
        }
    }
}