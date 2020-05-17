using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestHorizontalLineGhHelper
    {
        public static HorizontalLineGH TestObject
        {
            get
            {
                HorizontalLineGH testObject = new HorizontalLineGH();
                return testObject;
            }
        }
    }
    public class TestHorizontalLineGh
    {
        [Theory]
        [InlineData("Horizontal Line", "Horizontal Line",
              "Add horizontal line",
              "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestHorizontalLineGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestHorizontalLineGhHelper.TestObject.NickName);
            Assert.Equal(description, TestHorizontalLineGhHelper.TestObject.Description);
            Assert.Equal(category, TestHorizontalLineGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestHorizontalLineGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestHorizontalLineGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestHorizontalLineGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestHorizontalLineGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestHorizontalLineGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("db6a6683-e51e-4a89-bb5e-3cdea64bda4e");
            Guid actual = TestHorizontalLineGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
