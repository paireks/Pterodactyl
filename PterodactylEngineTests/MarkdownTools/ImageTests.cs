using PterodactylEngine;
using PterodactylEngine.MarkdownTools;
using Xunit;

namespace PterodactylEngineTests.MarkdownTools
{
    public class TestImageHelper : TheoryData<string, string, string>
    {
        public TestImageHelper()
        {
            Add("PterodactylImage", @"C:\Users\Pterodactyl.png",
                @"![PterodactylImage](C:\Users\Pterodactyl.png)");
        }
    }
    public class ImageTests
    {
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
