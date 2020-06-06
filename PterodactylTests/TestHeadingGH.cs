using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestHeadingGhHelper
    {
        public static HeadingGH TestObject
        {
            get
            {
                HeadingGH testObject = new HeadingGH();
                return testObject;
            }
        }
    }
    public class TestHeadingGh
    {
        [Theory]
        [InlineData("Heading", "Heading",
            "Creates heading",
            "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestHeadingGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestHeadingGhHelper.TestObject.NickName);
            Assert.Equal(description, TestHeadingGhHelper.TestObject.Description);
            Assert.Equal(category, TestHeadingGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestHeadingGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Text", "Text", "Text for the heading", GH_ParamAccess.item)]
        [InlineData(1, "Level", "Level", "Level of the heading as integer. Should be between 1 and 6.", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestHeadingGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestHeadingGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestHeadingGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestHeadingGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestHeadingGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestHeadingGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestHeadingGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestHeadingGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("6d67b19c-bd15-44eb-9524-e0856ff55d1a");
            Guid actual = TestHeadingGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
