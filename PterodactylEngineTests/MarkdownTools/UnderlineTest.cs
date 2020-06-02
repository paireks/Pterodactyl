using System;
using PterodactylEngine;
using PterodactylEngine.MarkdownTools;
using Xunit;

namespace PterodactylEngineTests.MarkdownTools
{
    public class TestUnderlineHelper : TheoryData<string, string>
    {
        public TestUnderlineHelper()
        {
            Add("Test test it", "<u>Test test it</u>");
            Add("Multiline test" + Environment.NewLine + "Hmm", "<u>Multiline test" + Environment.NewLine + "Hmm</u>");
        }
    }

    public class UnderlineTest
    {
        [Theory]
        [ClassData(typeof(TestUnderlineHelper))]
        public void CheckReportCreation(string text, string expected)
        {
            Underline testObject = new Underline(text);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}

