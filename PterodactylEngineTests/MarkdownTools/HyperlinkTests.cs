using PterodactylEngine;
using PterodactylEngine.MarkdownTools;
using Xunit;

namespace PterodactylEngineTests.MarkdownTools
{
    public class TestHyperlinkHelper : TheoryData<string, string, string>
    {
        public TestHyperlinkHelper()
        {
            Add("Hyperlink test", "google.com", "[Hyperlink test](google.com)");
        }
    }

    public class HyperlinkTests
    {
        [Theory]
        [ClassData(typeof(TestHyperlinkHelper))]
        public void CheckReportCreation(string text, string link, string expected)
        {
            Hyperlink testObject = new Hyperlink(text, link);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}

