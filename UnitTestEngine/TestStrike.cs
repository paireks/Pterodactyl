using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestStrikeHelper : TheoryData<string, string>
    {
        public TestStrikeHelper()
        {
            Add("Test test it", "~~Test test it~~");
            Add("Multiline test" + Environment.NewLine + "Hmm", "~~Multiline test" + Environment.NewLine + "Hmm~~");
        }
    }

    public class TestStrike
    {
        [Theory]
        [ClassData(typeof(TestStrikeHelper))]
        public void CorrectData(string text, string expected)
        {
            Strike testObject = new Strike(text);
            Assert.Equal(text, testObject.Text);
        }

        [Theory]
        [ClassData(typeof(TestStrikeHelper))]
        public void CheckReportCreation(string text, string expected)
        {
            Strike testObject = new Strike(text);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}

