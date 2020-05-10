using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestHeadingHelper : TheoryData<string, int, string>
    {
        public TestHeadingHelper()
        {
            Add("Lol nice heading tho", 1, "# Lol nice heading tho");
            Add("Different level", 2, "## Different level");
            Add("Last level", 6, "###### Last level");
            Add("Multiline check" + Environment.NewLine + "Hmm", 3, "### Multiline check"+ Environment.NewLine + "Hmm");
        }
    }

    public class TestHeading
    {
        [Theory]
        [ClassData(typeof(TestHeadingHelper))]
        public void CorrectData(string text, int level, string expected)
        {
            Heading testObject = new Heading(text, level);
            Assert.Equal(text, testObject.Text);
        }

        [Theory]
        [ClassData(typeof(TestHeadingHelper))]
        public void CheckReportCreation(string text, int level, string expected)
        {
            Heading testObject = new Heading(text, level);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }

    }
}
