using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestCreateReportHelper : TheoryData<List<string>, string, bool, string>
    {
        public TestCreateReportHelper()
        {
            Add(new List<string>{"Empty"}, "Test title", false,
                "# Test title" + Environment.NewLine + "Empty" + Environment.NewLine);
            Add(new List<string>{"Multiple", "lines"}, "", true,
                "[TOC]" + Environment.NewLine + "Multiple" + Environment.NewLine + "lines"
                + Environment.NewLine);
        }
    }

    public class TestCreateReport
    {
        [Theory]
        [ClassData(typeof(TestCreateReportHelper))]
        public void CorrectData(List<string> reportParts, string title, bool tableOfContents, string reportExpected)
        {
            CreateReport testObject = new CreateReport(reportParts, title, tableOfContents);
            Assert.Equal(reportParts, testObject.ReportParts);
            Assert.Equal(title, testObject.Title);
            Assert.Equal(tableOfContents, testObject.TableOfContents);
        }

        [Theory]
        [ClassData(typeof(TestCreateReportHelper))]
        public void CheckReportCreation(List<string> reportParts, string title, bool tableOfContents, string expected)
        {
            CreateReport testObject = new CreateReport(reportParts, title, tableOfContents);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }

    }
}
