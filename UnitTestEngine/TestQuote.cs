using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestQuoteHelper : TheoryData<string, string>
    {
        public TestQuoteHelper()
        {
            Add("Test test it", "> Test test it");
            Add("Multiline test" + Environment.NewLine + "Hmm", "> Multiline test" + Environment.NewLine + "Hmm");
        }
    }

    public class TestQuote
    {
        [Theory]
        [ClassData(typeof(TestQuoteHelper))]
        public void CorrectData(string text, string expected)
        {
            Quote testObject = new Quote(text);
            Assert.Equal(text, testObject.Text);
        }

        [Theory]
        [ClassData(typeof(TestQuoteHelper))]
        public void CheckReportCreation(string text, string expected)
        {
            Quote testObject = new Quote(text);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}

