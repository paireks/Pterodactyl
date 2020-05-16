using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestTableHelper : TheoryData<List<string>, List<int>, string[,], List<string>>
    {
        public TestTableHelper()
        {
            Add(new List<string> { "Head 1", "Head 2", "Head 3" },
                new List<int> { 0, 0, 0 },
                new string[,] { { "2", "5" }, { "lol", "hrhr" } },
                new List<string> { "Head" });
        }
    }

    public class TestTable
    {
        [Theory]
        [ClassData(typeof(TestTableHelper))]
        public void CorrectData(List<string> headings, List<int> alignment, string[,] dataTree, List<string> expected)
        {
            Table testObject = new Table(headings, alignment, dataTree);
            Assert.Equal(headings, testObject.Headings);
            Assert.Equal(alignment, testObject.Alignment);
            Assert.Equal(dataTree, testObject.DataTree);
        }

        [Theory]
        [ClassData(typeof(TestTableHelper))]
        public void CheckReportCreation(List<string> headings, List<int> alignment, Grasshopper.DataTree<string> dataTree, List<string> expected)
        {
            Table testObject = new Table(headings, alignment, dataTree);
            List<string> actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}
