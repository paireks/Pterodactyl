using System;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestImageHelper : TheoryData<string, string, string>
    {
        public TestImageHelper()
        {
            Add("PterodactylImage", @"C:\Users\Pterodactyl.png",
                @"![PterodactylImage](C:\Users\Pterodactyl.png)");
        }
    }
    public class TestImage
    {
        [Theory]
        [ClassData(typeof(TestImageHelper))]
        public void CorrectData(string title, string path, string expected)
        {
            Image testObject = new Image(title, path);
            Assert.Equal(title, testObject.Text);
            Assert.Equal(path, testObject.Path);
        }

        [Theory]
        [ClassData(typeof(TestImageHelper))]
        public void CheckReportCreation(string title, string path, string expected)
        {
            Image testObject = new Image(title, path);
            string actual = testObject.Create();

            Assert.Equal(expected, actual);
        }
    }
}
