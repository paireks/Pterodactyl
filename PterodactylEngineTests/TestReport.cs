using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestReportHelper : TheoryData<List<string>, string, bool, bool, string>
    {
        public TestReportHelper()
        {
            Add(new List<string>{"Empty"}, "Test title", false, false,
                "# Test title" + Environment.NewLine + "Empty" + Environment.NewLine);
            Add(new List<string>{"Multiple", "lines"}, "", true, false,
                "[TOC]" + Environment.NewLine + "Multiple" + Environment.NewLine + "lines"
                + Environment.NewLine);
            Add(new List<string>{"Empty"}, "Test title", false, true,
                "# Test title" + Environment.NewLine + Environment.NewLine + "Empty" + Environment.NewLine + Environment.NewLine);
            Add(new List<string>{"Multiple", "lines"}, "", true, true,
                "[TOC]" + Environment.NewLine + Environment.NewLine + "Multiple" + Environment.NewLine + Environment.NewLine + "lines"
                + Environment.NewLine + Environment.NewLine);
        }
    }

    public class TestReport
    {
        [Theory]
        [ClassData(typeof(TestReportHelper))]
        public void CorrectData(List<string> reportParts, string title, bool tableOfContents, bool autoSpacing,
            string expected)
        {
            Report testObject = new Report(reportParts, title, tableOfContents, autoSpacing);
            Assert.Equal(reportParts, testObject.ReportParts);
            Assert.Equal(title, testObject.Title);
            Assert.Equal(tableOfContents, testObject.TableOfContents);
            Assert.Equal(autoSpacing, testObject.AutoSpacing);
        }

        [Theory]
        [ClassData(typeof(TestReportHelper))]
        public void CheckReportCreation(List<string> reportParts, string title, bool tableOfContents, bool autoSpacing,
            string expected)
        {
            Report testObject = new Report(reportParts, title, tableOfContents, autoSpacing);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }

    }
}
