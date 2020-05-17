using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestEmphasisHelper : TheoryData<string, string>
    {
        public TestEmphasisHelper()
        {
            Add("Test test it", "*Test test it*");
            Add("Multiline test" + Environment.NewLine + "Hmm", "*Multiline test" + Environment.NewLine + "Hmm*");
        }
    }

    public class TestEmphasis
    {
        [Theory]
        [ClassData(typeof(TestEmphasisHelper))]
        public void CorrectData(string text, string expected)
        {
            Emphasis testObject = new Emphasis(text);
            Assert.Equal(text, testObject.Text);
        }

        [Theory]
        [ClassData(typeof(TestEmphasisHelper))]
        public void CheckReportCreation(string text, string expected)
        {
            Emphasis testObject = new Emphasis(text);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}

