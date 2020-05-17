using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestStrongHelper : TheoryData<string, string>
    {
        public TestStrongHelper()
        {
            Add("Test test it", "**Test test it**");
            Add("Multiline test" + Environment.NewLine + "Hmm", "**Multiline test" + Environment.NewLine + "Hmm**");
        }
    }

    public class TestStrong
    {
        [Theory]
        [ClassData(typeof(TestStrongHelper))]
        public void CorrectData(string text, string expected)
        {
            Strong testObject = new Strong(text);
            Assert.Equal(text, testObject.Text);
        }

        [Theory]
        [ClassData(typeof(TestStrongHelper))]
        public void CheckReportCreation(string text, string expected)
        {
            Strong testObject = new Strong(text);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}

