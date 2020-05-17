using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestStrikeGhHelper
    {
        public static StrikeGH TestObject
        {
            get
            {
                StrikeGH testObject = new StrikeGH();
                return testObject;
            }
        }
    }
    public class TestStrikeGh
    {
        [Theory]
        [InlineData("Strike", "Strike",
              "Format text -> strike",
              "Pterodactyl", "Format")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestStrikeGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestStrikeGhHelper.TestObject.NickName);
            Assert.Equal(description, TestStrikeGhHelper.TestObject.Description);
            Assert.Equal(category, TestStrikeGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestStrikeGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Text", "Text", "Text to format", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestStrikeGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestStrikeGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestStrikeGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestStrikeGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestStrikeGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestStrikeGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestStrikeGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestStrikeGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("0e037e2b-b035-4a34-97e5-7c3b95a40dbb");
            Guid actual = TestStrikeGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
