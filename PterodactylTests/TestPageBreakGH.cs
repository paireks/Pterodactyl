using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestPageBreakGhHelper
    {
        public static PageBreakGH TestObject
        {
            get
            {
                PageBreakGH testObject = new PageBreakGH();
                return testObject;
            }
        }
    }
    public class TestPageBreakGh
    {
        [Theory]
        [InlineData("Page Break", "Page Break",
            "Insert page break, so it will be visible when export to .pdf",
            "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestPageBreakGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestPageBreakGhHelper.TestObject.NickName);
            Assert.Equal(description, TestPageBreakGhHelper.TestObject.Description);
            Assert.Equal(category, TestPageBreakGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestPageBreakGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestPageBreakGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestPageBreakGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestPageBreakGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestPageBreakGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("ba101baf-857e-4968-a05a-94aeb1c4f97e");
            Guid actual = TestPageBreakGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
