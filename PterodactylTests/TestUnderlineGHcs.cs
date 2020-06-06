using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestUnderlineGhHelper
    {
        public static UnderlineGH TestObject
        {
            get
            {
                UnderlineGH testObject = new UnderlineGH();
                return testObject;
            }
        }
    }
    public class TestUnderlineGh
    {
        [Theory]
        [InlineData("Underline", "Underline",
              "Format text -> underline",
              "Pterodactyl", "Format")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestUnderlineGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestUnderlineGhHelper.TestObject.NickName);
            Assert.Equal(description, TestUnderlineGhHelper.TestObject.Description);
            Assert.Equal(category, TestUnderlineGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestUnderlineGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Text", "Text", "Text to format", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestUnderlineGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestUnderlineGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestUnderlineGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestUnderlineGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestUnderlineGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestUnderlineGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestUnderlineGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestUnderlineGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("1386bcfa-a262-429d-ab64-55b36b18ca2a");
            Guid actual = TestUnderlineGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
