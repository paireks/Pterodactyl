using System;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestSaveReport
    {
        [Theory]
        [InlineData("Empty", @"C:\Users\EngineerDesign\Desktop\Projekty\Pterodactyl\Tests\TestReport.md", "Empty")]
        public void CorrectData(string report, string path, string expected)
        {
            SaveReport testObject = new SaveReport(report, path);
        }
    }
}
