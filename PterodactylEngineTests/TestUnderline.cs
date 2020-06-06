using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestUnderlineHelper : TheoryData<string, string>
    {
        public TestUnderlineHelper()
        {
            Add("Test test it", "<u>Test test it</u>");
            Add("Multiline test" + Environment.NewLine + "Hmm", "<u>Multiline test" + Environment.NewLine + "Hmm</u>");
        }
    }

    public class TestUnderline
    {
        [Theory]
        [ClassData(typeof(TestUnderlineHelper))]
        public void CorrectData(string text, string expected)
        {
            Underline testObject = new Underline(text);
            Assert.Equal(text, testObject.Text);
        }

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

