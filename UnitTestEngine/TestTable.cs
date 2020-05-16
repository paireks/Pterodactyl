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
                new string[,] { { "2", "5" }, { "lol", "hrhr" }, { "rrrr", "hohoho" } },
                new List<string> { "" });
        }

    }

    public class TestMaxStringLengthHelper : TheoryData<List<string>, List<int>, string[,], List<int>>
    {
        public TestMaxStringLengthHelper()
        {
            Add(new List<string> { "Head 1", "Head 2", "A" },
                new List<int> { 0, 0, 0 },
                new string[,] 
                { 
                    { "2", "5" },
                    { "lol", "hrhrhrh" },
                    { "r", "h" } 
                },
                new List<int> { 6, 7, 1 });
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
    }

    public class TestMaxStringLength
    {
        [Theory]
        [ClassData(typeof(TestMaxStringLengthHelper))]
        public void CorrectData(List<string> headings, List<int> alignment, string[,] dataTree, List<int> expected)
        {
            Table testObject = new Table(headings, alignment, dataTree);
            List<int> actual = testObject.MaxStringLength;

            Assert.Equal(expected, actual);
        }
    }
}
