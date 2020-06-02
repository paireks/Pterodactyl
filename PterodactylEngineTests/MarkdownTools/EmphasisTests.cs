using System;
using PterodactylEngine;
using PterodactylEngine.MarkdownTools;
using Xunit;

namespace PterodactylEngineTests.MarkdownTools
{
    public class TestEmphasisHelper : TheoryData<string, string>
    {
        public TestEmphasisHelper()
        {
            Add("Test test it", "*Test test it*");
            Add("Multiline test" + Environment.NewLine + "Hmm", "*Multiline test" + Environment.NewLine + "Hmm*");
        }
    }

    public class EmphasisTests
    {
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

