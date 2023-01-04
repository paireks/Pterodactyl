using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PterodactylCharts;
using Xunit;

namespace UnitTestEngine
{
    public class TestGraphSizesHelper : TheoryData<int, int, string>
    {
        public TestGraphSizesHelper()
        {
            Add(400, 500, "Graph Sizes\r\nWidth: 400\r\nHeight: 500");
            Add(200, 200, "Graph Sizes\r\nWidth: 200\r\nHeight: 200");
            Add(1000, 1000, "Graph Sizes\r\nWidth: 1000\r\nHeight: 1000");
        }
    }

    public class TestGraphSizesExceptionHelper : TheoryData<int, int, string>
    {
        public TestGraphSizesExceptionHelper()
        {
            Add(-400, 500, "Width and Height values shouldn't be smaller than 200");
            Add(400, 199, "Width and Height values shouldn't be smaller than 200");
            Add(1921, 200, "Width and Height values shouldn't be larger than 1920");
            Add(1000, 1921, "Width and Height values shouldn't be larger than 1920");
        }
    }
    public class TestGraphSizes
    {
        [Theory]
        [ClassData(typeof(TestGraphSizesHelper))]
        public void CorrectData(int width, int height, string toString)
        {
            GraphSizes testObject = new GraphSizes(width, height);
            Assert.Equal(width, testObject.Width);
            Assert.Equal(height, testObject.Height);
            Assert.Equal(toString, testObject.ToString());
        }
        [Theory]
        [ClassData(typeof(TestGraphSizesExceptionHelper))]
        public void CheckExceptions(int width, int height, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new GraphSizes(width, height));
            Assert.Equal(message, exception.Message);
        }
    }
}