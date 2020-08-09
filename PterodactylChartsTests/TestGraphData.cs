using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PterodactylCharts;
using Xunit;

namespace UnitTestEngine
{
    public class TestGraphDataHelper : TheoryData<List<List<double>>, List<List<double>>, List<string>, List<DataType>, string>
    {
        public TestGraphDataHelper()
        {
            Add(new List<List<double>> { new List<double> { 0, 1, 2 }, new List<double> { 1, 2, 5.5 } },
                new List<List<double>> { new List<double> { -2, 0, 4 }, new List<double> { 5, 2, -1 } },
                new List<string> { "First", "Second" },
                new List<DataType> { new DataType(Color.Navy), new DataType(Color.AliceBlue) },
                "Graph Data\r\nSeries of data: 2");
            Add(new List<List<double>> { new List<double> { 0 } },
                new List<List<double>> { new List<double> { -2 } },
                new List<string> { "First" },
                new List<DataType> { new DataType(Color.Navy) },
                "Graph Data\r\nSeries of data: 1");
        }
    }

    public class TestGraphDataExceptionHelper : TheoryData<List<List<double>>, List<List<double>>, List<string>, List<DataType>, string>
    {
        public TestGraphDataExceptionHelper()
        {
            Add(new List<List<double>> { new List<double> { 0, 1, 2 }, new List<double> { 1, 2, 5.5 } },
                new List<List<double>> { new List<double> { -2, 0, 4 } },
                new List<string> { "First", "Second" }, 
                new List<DataType> { new DataType(Color.Navy), new DataType(Color.AliceBlue) },
                "X Values tree should have the same number of branches like Y Values tree");
            Add(new List<List<double>> { new List<double> { 0, 1, 2 }, new List<double> { 1, 2, 5.5 } },
                new List<List<double>> { new List<double> { -2, 4 }, new List<double> { 5, 2, -1 } },
                new List<string> { "First", "Second" },
                new List<DataType> { new DataType(Color.Navy), new DataType(Color.AliceBlue) },
                "Inside each branch of X Values and Y Values trees numbers of elements of lists should match");
            Add(new List<List<double>> { new List<double> { 0, 1, 2 }, new List<double> { 1, 2, 5.5 }, new List<double>{ 4, 5, 6} },
                new List<List<double>> { new List<double> { -2, 4, 0 }, new List<double> { 5, 2, -1 }, new List<double> { 4, 5, 6 } },
                new List<string> { "First", "Second" },
                new List<DataType> { new DataType(Color.Navy), new DataType(Color.AliceBlue) },
                "X Values tree's number of branches != Values Names elements of list");
            Add(new List<List<double>> { new List<double> { 0, 1, 2 }, new List<double> { 1, 2, 5.5 } },
                new List<List<double>> { new List<double> { -2, 0, 4 }, new List<double> { 5, 2, -1 } },
                new List<string> { "First" },
                new List<DataType> { new DataType(Color.Navy), new DataType(Color.AliceBlue) },
                "X Values tree's number of branches != Values Names elements of list");
            Add(new List<List<double>> { new List<double> { 0, 1, 2 }, new List<double> { 1, 2, 5.5 } },
                new List<List<double>> { new List<double> { -2, 0, 4 }, new List<double> { 5, 2, -1 } },
                new List<string> { "First", "Second" },
                new List<DataType> { new DataType(Color.Navy) },
                "X Values tree's number of branches != Data Types elements of list");
        }
    }
    public class TestGraphData
    {
        [Theory]
        [ClassData(typeof(TestGraphDataHelper))]
        public void CorrectData(List<List<double>> xValues,
            List<List<double>> yValues,
            List<string> valuesNames,
            List<DataType> dataTypes, string toString)
        {
            GraphData testObject = new GraphData(xValues, yValues, valuesNames, dataTypes);
            Assert.Equal(xValues, testObject.XValues);
            Assert.Equal(yValues, testObject.YValues);
            Assert.Equal(valuesNames, testObject.ValuesNames);
            Assert.Equal(dataTypes, testObject.DataTypes);
            Assert.Equal(toString, testObject.ToString());
        }
        [Theory]
        [ClassData(typeof(TestGraphDataExceptionHelper))]
        public void CheckExceptions(List<List<double>> xValues,
            List<List<double>> yValues,
            List<string> valuesNames,
            List<DataType> dataTypes, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new GraphData(xValues, yValues, valuesNames, dataTypes));
            Assert.Equal(message, exception.Message);
        }
    }
}