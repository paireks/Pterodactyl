using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestQuoteGhHelper
    {
        public static QuoteGH TestObject
        {
            get
            {
                QuoteGH testObject = new QuoteGH();
                return testObject;
            }
        }
    }
    public class TestQuoteGh
    {
        [Theory]
        [InlineData("Quote", "Quote",
            "Add quote",
            "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestQuoteGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestQuoteGhHelper.TestObject.NickName);
            Assert.Equal(description, TestQuoteGhHelper.TestObject.Description);
            Assert.Equal(category, TestQuoteGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestQuoteGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Text", "Text", "Quote text", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestQuoteGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestQuoteGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestQuoteGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestQuoteGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestQuoteGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestQuoteGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestQuoteGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestQuoteGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("f5b094d0-d5f2-4f06-8f5d-bae1b39c78c7");
            Guid actual = TestQuoteGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
