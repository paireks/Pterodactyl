using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestDynamicMathBlockHelper : TheoryData<string, List<string>, List<double>, string>
    {
        public TestDynamicMathBlockHelper()
        {
            Add("Test test it",
                new List<string> {"x"}, 
                new List<double> {2.1209},
                "$$" + Environment.NewLine + "Test test it" + Environment.NewLine + "$$");
            Add(@"log_{2}x = 5 \\ sin(<x>)^2 + cos(<x>)^2 = 1",
                new List<string> {"x"},
                new List<double> {2.1209},
                "$$" + Environment.NewLine + @"log_{2}x = 5 \\ sin(2,1209)^2 + cos(2,1209)^2 = 1" + Environment.NewLine + "$$");
            Add(@"<x>, <y>, <z>, <xyz>",
                new List<string> {"x", "y", "z", "xyz"},
                new List<double> {1, 2, 3, 4},
                "$$" + Environment.NewLine + @"1, 2, 3, 4" + Environment.NewLine + "$$");
            Add(@"a < <b <<c> = 10",
                new List<string> { "b", "c"},
                new List<double> { 1, 2 },
                "$$" + Environment.NewLine + @"a < <b <2 = 10" + Environment.NewLine + "$$");
            Add(@"<x>, <y>, <z>, <xyz>",
                new List<string> { "x", "y", "z"},
                new List<double> { 1, 2, 3, 4 },
                "$$" + Environment.NewLine + @"1, 2, 3, <xyz>" + Environment.NewLine + "$$");
            Add(@"<x>, <y>, <z>, <xyz>",
                new List<string> { "x", "y", "z", "xyz"},
                new List<double> { 1, 2, 3 },
                "$$" + Environment.NewLine + @"1, 2, 3, <xyz>" + Environment.NewLine + "$$");
        }
    }

    public class TestDynamicMathBlockExceptionHelper : TheoryData<string, List<string>, List<double>, string>
    {
        public TestDynamicMathBlockExceptionHelper()
        {
            Add("Check",
                new List<string> {},
                new List<double> { 5 },
                "Set Variables' Symbols (at least one). If you don't need to use " +
                "dynamic variables - use Math Block component instead");
        }
    }

    public class TestDynamicMathBlock
    {
        [Theory]
        [ClassData(typeof(TestDynamicMathBlockHelper))]
        public void CorrectData(string text, List<string> variablesSymbols, List<double> variablesValues, string expected)
        {
            DynamicMathBlock testObject = new DynamicMathBlock(text, variablesSymbols, variablesValues);
            Assert.Equal(text, testObject.Text);
        }

        [Theory]
        [ClassData(typeof(TestDynamicMathBlockHelper))]
        public void CheckReportPartCreation(string text, List<string> variablesSymbols, List<double> variablesValues, string expected)
        {
            DynamicMathBlock testObject = new DynamicMathBlock(text, variablesSymbols, variablesValues);
            string actual = testObject.Format();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(TestDynamicMathBlockExceptionHelper))]
        public void CheckExceptions(string text, List<string> variablesSymbols, List<double> variablesValues, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DynamicMathBlock(text, variablesSymbols, variablesValues));
            Assert.Equal(message, exception.Message);
        }
    }
}
