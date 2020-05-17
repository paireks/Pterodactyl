using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestMathBlockHelper : TheoryData<string, string>
    {
        public TestMathBlockHelper()
        {
            Add("Test test it", "$$" + Environment.NewLine + "Test test it" + Environment.NewLine + "$$");
            Add(@"log_{2}x = 5 \\ sin(x)^2 + cos(x)^2 = 1",
            "$$" + Environment.NewLine + @"log_{2}x = 5 \\ sin(x)^2 + cos(x)^2 = 1" + Environment.NewLine + "$$");
        }
    }

    public class TestMathBlock
    {
        [Theory]
        [ClassData(typeof(TestMathBlockHelper))]
        public void CorrectData(string text, string expected)
        {
            MathBlock testObject = new MathBlock(text);
            Assert.Equal(text, testObject.Text);
        }

        [Theory]
        [ClassData(typeof(TestMathBlockHelper))]
        public void CheckReportCreation(string text, string expected)
        {
            MathBlock testObject = new MathBlock(text);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }

    }
}
