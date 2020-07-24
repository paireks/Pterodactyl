using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestCodeBlockHelper : TheoryData<string, string, string>
    {
        public TestCodeBlockHelper()
        {
            Add("python", "print(\"Hey\")", "```python" + Environment.NewLine + "print(\"Hey\")"
                + Environment.NewLine + "```");
            Add("C#", "string testString;" + Environment.NewLine + "testString = \"Hey\"",
                "```C#" + Environment.NewLine + "string testString;"
                + Environment.NewLine + "testString = \"Hey\""
                + Environment.NewLine + "```");
        }
    }

    public class TestCodeBlock
    {
        [Theory]
        [ClassData(typeof(TestCodeBlockHelper))]
        public void CorrectData(string programmingLanguage, string code, string expected)
        {
            CodeBlock testObject = new CodeBlock(programmingLanguage, code);
            Assert.Equal(programmingLanguage, testObject.ProgrammingLanguage);
            Assert.Equal(code, testObject.Code);
        }

        [Theory]
        [ClassData(typeof(TestCodeBlockHelper))]
        public void CheckReportCreation(string programmingLanguage, string code, string expected)
        {
            CodeBlock testObject = new CodeBlock(programmingLanguage, code);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}