using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestEmphasisGhHelper
    {
        public static EmphasisGH TestObject
        {
            get
            {
                EmphasisGH testObject = new EmphasisGH();
                return testObject;
            }
        }
    }
    public class TestEmphasisGh
    {
        [Theory]
        [InlineData("Emphasis", "Emphasis",
              "Format text -> emphasis",
              "Pterodactyl", "Format")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestEmphasisGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestEmphasisGhHelper.TestObject.NickName);
            Assert.Equal(description, TestEmphasisGhHelper.TestObject.Description);
            Assert.Equal(category, TestEmphasisGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestEmphasisGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Text", "Text", "Text to format", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestEmphasisGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestEmphasisGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestEmphasisGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestEmphasisGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestEmphasisGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestEmphasisGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestEmphasisGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestEmphasisGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("92a5c76a-6b8f-40bc-846c-95b6868c924f");
            Guid actual = TestEmphasisGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
