using System;
using PterodactylEngine;
using PterodactylEngine.MarkdownTools;
using Xunit;

namespace PterodactylEngineTests.MarkdownTools
{
    public class TestStrongHelper : TheoryData<string, string>
    {
        public TestStrongHelper()
        {
            Add("Test test it", "**Test test it**");
            Add("Multiline test" + Environment.NewLine + "Hmm", "**Multiline test" + Environment.NewLine + "Hmm**");
        }
    }

    public class StrongTests
    {
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

