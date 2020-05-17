using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestOrderedListHelper : TheoryData<List<string>, string>
    {
        public TestOrderedListHelper()
        {
            Add(new List<string> { "First item", "Second item" },
                "1. First item" + Environment.NewLine + "2. Second item");
            Add(new List<string>(), "");
            Add(new List<string> { "Only one item" }, "1. Only one item");
        }
    }

    public class TestOrderedList
    {
        [Theory]
        [ClassData(typeof(TestOrderedListHelper))]
        public void CorrectData(List<string> text, string expected)
        {
            OrderedList testObject = new OrderedList(text);
            Assert.Equal(text, testObject.Text);
        }

        [Theory]
        [ClassData(typeof(TestOrderedListHelper))]
        public void CheckReportCreation(List<string> text, string expected)
        {
            OrderedList testObject = new OrderedList(text);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}
