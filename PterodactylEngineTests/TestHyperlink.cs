using System;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestHyperlinkHelper : TheoryData<string, string, string>
    {
        public TestHyperlinkHelper()
        {
            Add("Hyperlink test", "google.com", "[Hyperlink test](google.com)");
        }
    }

    public class TestHyperlink
    {
        [Theory]
        [ClassData(typeof(TestHyperlinkHelper))]
        public void CorrectData(string text, string link, string expected)
        {
            Hyperlink testObject = new Hyperlink(text, link);
            Assert.Equal(text, testObject.Text);
            Assert.Equal(link, testObject.Link);
        }

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

