using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestCodeBlockGhHelper
    {
        public static CodeBlockGH TestObject
        {
            get
            {
                CodeBlockGH testObject = new CodeBlockGH();
                return testObject;
            }
        }
    }
    public class TestCodeBlockGh
    {
        [Theory]
        [InlineData("Code Block", "Code Block",
            "Creates code block",
            "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestCodeBlockGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestCodeBlockGhHelper.TestObject.NickName);
            Assert.Equal(description, TestCodeBlockGhHelper.TestObject.Description);
            Assert.Equal(category, TestCodeBlockGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestCodeBlockGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Programming Language", "Programming Language", "Programming language that was used in code", GH_ParamAccess.item)]
        [InlineData(1, "Code", "Code", "Code as text", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestCodeBlockGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestCodeBlockGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestCodeBlockGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestCodeBlockGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestCodeBlockGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestCodeBlockGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestCodeBlockGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestCodeBlockGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("05443fa7-a7ec-4471-be39-44fa62faf893");
            Guid actual = TestCodeBlockGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
