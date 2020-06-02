using System;
using PterodactylEngine;
using PterodactylEngine.MarkdownTools;
using Xunit;

namespace PterodactylEngineTests.MarkdownTools
{
    public class TestStrikeHelper : TheoryData<string, string>
    {
        public TestStrikeHelper()
        {
            Add("Test test it", "~~Test test it~~");
            Add("Multiline test" + Environment.NewLine + "Hmm", "~~Multiline test" + Environment.NewLine + "Hmm~~");
        }
    }

    public class StrikeTests
    {
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

