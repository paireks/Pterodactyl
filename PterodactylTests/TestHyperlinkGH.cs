using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestHyperlinkGhHelper
    {
        public static HyperlinkGH TestObject
        {
            get
            {
                HyperlinkGH testObject = new HyperlinkGH();
                return testObject;
            }
        }
    }
    public class TestHyperlinkGh
    {
        [Theory]
        [InlineData("Hyperlink", "Hyperlink",
            "Add hyperlink",
            "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestHyperlinkGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestHyperlinkGhHelper.TestObject.NickName);
            Assert.Equal(description, TestHyperlinkGhHelper.TestObject.Description);
            Assert.Equal(category, TestHyperlinkGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestHyperlinkGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Text", "Text", "Hyperlink text", GH_ParamAccess.item)]
        [InlineData(1, "Link", "Link", "Destination, where hyperlink will move you after click", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestHyperlinkGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestHyperlinkGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestHyperlinkGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestHyperlinkGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestHyperlinkGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestHyperlinkGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestHyperlinkGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestHyperlinkGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("28f4f7cd-060e-4a6a-b63a-88809f31c8a3");
            Guid actual = TestHyperlinkGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
