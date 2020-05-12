using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestTaskListHelper : TheoryData<List<string>, List<bool>, string>
    {
        public TestTaskListHelper()
        {
            Add(new List<string> { "Empty", "Closed" }, new List<bool> { false , true },
                "- [ ] Empty" + Environment.NewLine + "- [x] Closed");
            Add(new List<string> (), new List<bool> (), "");
            Add(new List<string> { "Empty" }, new List<bool> { false },
                "- [ ] Empty");
        }
    }

    public class TestTaskListExceptionHelper : TheoryData<List<string>, List<bool>, string>
    {
        public TestTaskListExceptionHelper()
        {
            Add(new List<string> { "Empty" }, new List<bool> { false, true },
                "Text values should match boolean (done) values." +
                "Check if both input lists have the same number of elements.");
            Add(new List<string> { "Empty","Closed" }, new List<bool> { false },
                "Text values should match boolean (done) values." +
                "Check if both input lists have the same number of elements.");
        }
    }

    public class TestTaskList
    {
        [Theory]
        [ClassData(typeof(TestTaskListHelper))]
        public void CorrectData(List<string> text, List<bool> done, string expected)
        {
            TaskList testObject = new TaskList(text, done);
            Assert.Equal(text, testObject.Text);
            Assert.Equal(done, testObject.Done);
        }

        [Theory]
        [ClassData(typeof(TestTaskListHelper))]
        public void CheckReportCreation(List<string> text, List<bool> done, string expected)
        {
            TaskList testObject = new TaskList(text, done);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(TestTaskListExceptionHelper))]
        public void CheckExceptions(List<string> text, List<bool> done, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new TaskList(text, done));
            Assert.Equal(message, exception.Message);
        }

    }
}
