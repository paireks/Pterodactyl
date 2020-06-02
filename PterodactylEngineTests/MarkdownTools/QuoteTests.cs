using System;
using PterodactylEngine;
using PterodactylEngine.MarkdownTools;
using Xunit;

namespace PterodactylEngineTests.MarkdownTools
{
    public class TestQuoteHelper : TheoryData<string, string>
    {
        public TestQuoteHelper()
        {
            Add("Test test it", "> Test test it");
            Add("Multiline test" + Environment.NewLine + "Hmm", "> Multiline test" + Environment.NewLine + "Hmm");
        }
    }

    public class QuoteTests
    {
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

