using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestStrongGhHelper
    {
        public static StrongGH TestObject
        {
            get
            {
                StrongGH testObject = new StrongGH();
                return testObject;
            }
        }
    }
    public class TestStrongGh
    {
        [Theory]
        [InlineData("Strong", "Strong",
              "Format text -> strong",
              "Pterodactyl", "Format")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestStrongGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestStrongGhHelper.TestObject.NickName);
            Assert.Equal(description, TestStrongGhHelper.TestObject.Description);
            Assert.Equal(category, TestStrongGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestStrongGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Text", "Text", "Text to format", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestStrongGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestStrongGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestStrongGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestStrongGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestStrongGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestStrongGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestStrongGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestStrongGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("ba101baf-857e-4968-a05a-94aeb1c4f97d");
            Guid actual = TestStrongGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
