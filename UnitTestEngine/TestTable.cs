using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestColumnSizesHelper : TheoryData<List<string>, List<int>, string[,], List<int>, string, string>
    {
        public TestColumnSizesHelper()
        {
            Add(new List<string> { "Head 1", "Head 2", "Alol" },
                new List<int> { 0, 1, 2 },
                new string[,] { { "2", "5" }, { "lol", "hrhrhrh" }, { "r", "h" } },
                new List<int> { 6, 7, 4 },
                "| Head 1 | Head 2  | Alol |",
                "| ------ | :-----: | ---: |");

            Add(new List<string> { "", "a"},
                new List<int> { 0, 0 },
                new string[,] { { "", "", "" }, { "a", "a", "a" }, },
                new List<int> { 4, 4 },
                "|      | a    |",
                "| ---- | ---- |");
        }
    }

    public class TestTable
    {
        [Theory]
        [ClassData(typeof(TestColumnSizesHelper))]
        public void CorrectData(List<string> headings, List<int> alignment,
            string[,] dataTree, List<int> columnSizes, string headingReport, string alignmentReport)
        {
            Table testObject = new Table(headings, alignment, dataTree);
            Assert.Equal(headings, testObject.Headings);
            Assert.Equal(alignment, testObject.Alignment);
            Assert.Equal(dataTree, testObject.DataTree);
        }
    }

    public class TestTableMethods
    {
        [Theory]
        [ClassData(typeof(TestColumnSizesHelper))]
        public void TestColumnSizes(List<string> headings, List<int> alignment,
            string[,] dataTree, List<int> expected, string headingReport, string alignmentReport)
        {
            Table testObject = new Table(headings, alignment, dataTree);
            List<int> actual = testObject.ColumnSizes;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(TestColumnSizesHelper))]
        public void TestHeadingReport(List<string> headings, List<int> alignment,
            string[,] dataTree, List<int> columnSizes, string expected, string alignmentReport)
        {
            Table testObject = new Table(headings, alignment, dataTree);
            string actual = testObject.HeadingReport;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(TestColumnSizesHelper))]
        public void TestAlignmentReport(List<string> headings, List<int> alignment,
            string[,] dataTree, List<int> columnSizes, string headingReport, string expected)
        {
            Table testObject = new Table(headings, alignment, dataTree);
            string actual = testObject.AlignmentReport;

            Assert.Equal(expected, actual);
        }

    }
}
