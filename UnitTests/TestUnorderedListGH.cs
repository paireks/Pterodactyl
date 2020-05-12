using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestUnorderedListGhHelper
    {
        public static UnorderedListGH TestObject
        {
            get
            {
                UnorderedListGH testObject = new UnorderedListGH();
                return testObject;
            }
        }
    }
    public class TestUnorderedListGh
    {
        [Theory]
        [InlineData("Unordered List", "Unordered List",
            "Add unordered list",
            "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestUnorderedListGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestUnorderedListGhHelper.TestObject.NickName);
            Assert.Equal(description, TestUnorderedListGhHelper.TestObject.Description);
            Assert.Equal(category, TestUnorderedListGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestUnorderedListGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Items", "Items", "Different list items as text list", GH_ParamAccess.list)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestUnorderedListGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestUnorderedListGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestUnorderedListGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestUnorderedListGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestUnorderedListGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestUnorderedListGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestUnorderedListGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestUnorderedListGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("2435071b-dcfa-4b6c-9d1b-cc621c941c15");
            Guid actual = TestUnorderedListGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
