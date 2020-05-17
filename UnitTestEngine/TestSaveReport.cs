using System.IO;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestSaveReport
    {
        [Theory]
        [InlineData("Empty")]
        public void CorrectData(string report)
        {
            string path = Path.GetTempPath() + "PterodactylTest.md";
            SaveReport testObject = new SaveReport(report, path);
            Assert.Equal(report, testObject.Report);
            Assert.Equal(path, testObject.Path);
        }

        [Theory]
        [InlineData("Empty", "PterodactylTest1.md")]
        [InlineData("", "PterodactylTest2.md")]
        [InlineData(@"# Test multiple
## Lines", "PterodactylTest3.md")]
        public void CheckSaving(string report, string pathName)
        {
            string path = Path.GetTempPath() + pathName;
            SaveReport testObject = new SaveReport(report, path);
            string actual = File.ReadAllText(path);

            Assert.Equal(report, actual);
        }
    }
}
