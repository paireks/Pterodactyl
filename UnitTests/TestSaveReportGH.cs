using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestSaveReportGhHelper
    {
        public static SaveReportGH TestObject
        {
            get
            {
                SaveReportGH testObject = new SaveReportGH();
                return testObject;
            }
        }
    }
    public class TestSaveReportGh
    {
        [Theory]
        [InlineData("Save Report", "Save Report",
            "Saves markdown file with your report data",
            "Pterodactyl", "Report")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestSaveReportGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestSaveReportGhHelper.TestObject.NickName);
            Assert.Equal(description, TestSaveReportGhHelper.TestObject.Description);
            Assert.Equal(category, TestSaveReportGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestSaveReportGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Report", "Report", "Report to save", GH_ParamAccess.item)]
        [InlineData(1, "Path", "Path", "Path where your file will be saved, should end up with .md",
            GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestSaveReportGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestSaveReportGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestSaveReportGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestSaveReportGhHelper.TestObject.Params.Input[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("2cfe90c9-bca3-4d6d-9243-d5212107066c");
            Guid actual = TestSaveReportGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
