using System;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestHeadingHelper : TheoryData<string, int, string>
    {
        public TestHeadingHelper()
        {
            Add("Lol nice heading tho", 1, "# Lol nice heading tho");
            Add("Different level", 2, "## Different level");
            Add("Last level", 6, "###### Last level");
            Add("Multiline check" + Environment.NewLine + "Hmm", 3, "### Multiline check"+ Environment.NewLine + "Hmm");
        }
    }
    public class TestHeadingExceptionHelper : TheoryData<string, int, string>
    {
        public TestHeadingExceptionHelper()
        {
            Add("Lol nice heading tho", 0, "Level should be an integer between 1 and 6");
            Add("Lol nice heading tho", 7, "Level should be an integer between 1 and 6");
        }
    }

    public class TestHeading
    {
        [Theory]
        [ClassData(typeof(TestHeadingHelper))]
        public void CorrectData(string text, int level, string expected)
        {
            Heading testObject = new Heading(text, level);
            Assert.Equal(text, testObject.Text);
            Assert.Equal(level, testObject.Level);
        }

        [Theory]
        [ClassData(typeof(TestHeadingHelper))]
        public void CheckReportCreation(string text, int level, string expected)
        {
            Heading testObject = new Heading(text, level);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(TestHeadingExceptionHelper))]
        public void CheckExceptions(string text, int level, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Heading(text, level));
            Assert.Equal(message, exception.Message);
        }

    }
}
