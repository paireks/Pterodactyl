using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestUnorderedListHelper : TheoryData<List<string>, string>
    {
        public TestUnorderedListHelper()
        {
            Add(new List<string> { "First item", "Second item" },
                "- First item" + Environment.NewLine + "- Second item");
            Add(new List<string>(), "");
            Add(new List<string> { "Only one item" }, "- Only one item");
        }
    }

    public class TestUnorderedList
    {
        [Theory]
        [ClassData(typeof(TestUnorderedListHelper))]
        public void CorrectData(List<string> text, string expected)
        {
            UnorderedList testObject = new UnorderedList(text);
            Assert.Equal(text, testObject.Text);
        }

        [Theory]
        [ClassData(typeof(TestUnorderedListHelper))]
        public void CheckReportCreation(List<string> text, string expected)
        {
            UnorderedList testObject = new UnorderedList(text);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}
