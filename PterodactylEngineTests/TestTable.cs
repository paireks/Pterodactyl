﻿using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;
using Xunit.Sdk;

namespace UnitTestEngine
{
    public class TestTableHelper : TheoryData<List<string>, List<int>, string[,], List<int>, string, string, List<string>>
    {
        public TestTableHelper()
        {
            Add(new List<string> { "Head 1", "Head 2", "Alol" },
                new List<int> { 0, 1, 2 },
                new string[,] { { "2", "5" }, { "lol", "hrhrhrh" }, { "r", "h" } },
                new List<int> { 6, 7, 4 },
                "| Head 1 | Head 2  | Alol |",
                "| ------ | :-----: | ---: |",
                new List<string>
                {
                "| 2      | lol     | r    |",
                "| 5      | hrhrhrh | h    |"
                });

            Add(new List<string> { "", "a"},
                new List<int> { 0, 0 },
                new string[,] { { "", "", "" }, { "a", "a", "a" }, },
                new List<int> { 4, 4 },
                "|      | a    |",
                "| ---- | ---- |",
                new List<string>
                {
                "|      | a    |",
                "|      | a    |",
                "|      | a    |"
                });
        }
    }

    public class TestTableExceptionHelper : TheoryData<List<string>, List<int>, string[,], string>
    {
        public TestTableExceptionHelper()
        {
            Add(new List<string> { "Example column", "Example 2", "C3", "C4" },
                new List<int> { 0, 2, 1 },
                new string[,] { { "2", "5" }, { "lol", "hrhrhrh rhrhh" }, { "r", "h" }, { "aaaaaaaaaa", "bbbbbbbbb" } },
                "Headings list should match alignment list. " +
                "Check if both input lists have the same number of elements.");
            Add(new List<string> { "Example column", "Example 2", "C3", "C4" },
                new List<int> { 0, 2, 1, 0 },
                new string[,] { { "2", "5" }, { "lol", "hrhrhrh rhrhh" }, { "r", "h" }},
                "Headings list should match number of columns given in data tree. " +
                "Check if both inputs have the same number of elements.");
            Add(new List<string> { "Example column", "Example 2", "C3", "C4" },
                new List<int> { 0, 2, 1, 5 },
                new string[,] { { "2", "5" }, { "lol", "hrhrhrh rhrhh" }, { "r", "h" }, { "aaaaaaaaaa", "bbbbbbbbb" } },
                "Alignment should be an integer between 0 and 2");
        }
    }

    public class TestCreateTableHelper : TheoryData<List<string>, List<int>, string[,], List<string>>
    {
        public TestCreateTableHelper()
        {
            Add(new List<string> {"Example column", "Example 2", "C3", "C4"},
                new List<int> {0, 2, 1, 0},
                new string[,] {{"2", "5"}, {"lol", "hrhrhrh rhrhh"}, {"r", "h"}, {"aaaaaaaaaa", "bbbbbbbbb"}},
                new List<string>
                {
                    "| Example column | Example 2     | C3   | C4         |",
                    "| -------------- | ------------: | :--: | ---------- |",
                    "| 2              | lol           | r    | aaaaaaaaaa |",
                    "| 5              | hrhrhrh rhrhh | h    | bbbbbbbbb  |"
                });
            Add(new List<string> { "One column" },
                new List<int> { 1 },
                new string[,] { { "One", "Two" } },
                new List<string>
                {
                    "| One column |",
                    "| :--------: |",
                    "| One        |",
                    "| Two        |"
                });
            Add(new List<string> { "First column", "Second column" },
                new List<int> { 1, 1 },
                new string[,] { { "One" }, { "Two" } },
                new List<string>
                {
                    "| First column | Second column |",
                    "| :----------: | :-----------: |",
                    "| One          | Two           |",
                });
        }
    }

    public class TestTable
    {
        [Theory]
        [ClassData(typeof(TestTableHelper))]
        public void CorrectData(List<string> headings, List<int> alignment,
            string[,] dataTree, List<int> columnSizes, string headingReport, string alignmentReport,
            List<string> rowsReport)
        {
            Table testObject = new Table(headings, alignment, dataTree);
            Assert.Equal(headings, testObject.Headings);
            Assert.Equal(alignment, testObject.Alignment);
            Assert.Equal(dataTree, testObject.DataTree);
        }
    }

    public class TestTableCreate
    {
        [Theory]
        [ClassData(typeof(TestCreateTableHelper))]
        public void CorrectData(List<string> headings, List<int> alignment, string[,] dataTree, List<string> expected)
        {
            Table testObject = new Table(headings, alignment, dataTree);
            List<string> actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }

    public class TestTableException
    {
        [Theory]
        [ClassData(typeof(TestTableExceptionHelper))]
        public void CheckExceptions(List<string> headings, List<int> alignment, string[,] dataTree, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Table(headings, alignment, dataTree));
            Assert.Equal(message, exception.Message);
        }
    }
}
