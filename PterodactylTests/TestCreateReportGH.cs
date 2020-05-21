using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestCreateReportGhHelper
    {
        public static CreateReportGH TestObject
        {
            get
            {
                CreateReportGH testObject = new CreateReportGH();
                return testObject;
            }
        }
    }
    public class TestCreateReportGh
    {
        [Theory]
        [InlineData("Create Report", "Create Report",
            "Creates report",
            "Pterodactyl", "Report")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestCreateReportGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestCreateReportGhHelper.TestObject.NickName);
            Assert.Equal(description, TestCreateReportGhHelper.TestObject.Description);
            Assert.Equal(category, TestCreateReportGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestCreateReportGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Report Parts", "Report Parts", "Report parts as list", GH_ParamAccess.list)]
        [InlineData(1, "Title", "Title", "Sets report's title", GH_ParamAccess.item)]
        [InlineData(2, "Table Of Contents", "Table Of Contents", "Creates table of contents if True", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestCreateReportGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestCreateReportGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestCreateReportGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestCreateReportGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report", "Report", "Created report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestCreateReportGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestCreateReportGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestCreateReportGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestCreateReportGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("61d2c8be-586d-4d92-9dcf-5f54bf1a7e3a");
            Guid actual = TestCreateReportGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
