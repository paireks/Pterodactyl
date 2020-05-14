using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestOrderedListGhHelper
    {
        public static OrderedListGH TestObject
        {
            get
            {
                OrderedListGH testObject = new OrderedListGH();
                return testObject;
            }
        }
    }
    public class TestOrderedListGh
    {
        [Theory]
        [InlineData("Ordered List", "Ordered List",
            "Add ordered list",
            "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestOrderedListGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestOrderedListGhHelper.TestObject.NickName);
            Assert.Equal(description, TestOrderedListGhHelper.TestObject.Description);
            Assert.Equal(category, TestOrderedListGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestOrderedListGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Items", "Items", "Different list items as text list", GH_ParamAccess.list)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestOrderedListGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestOrderedListGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestOrderedListGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestOrderedListGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestOrderedListGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestOrderedListGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestOrderedListGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestOrderedListGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("16078687-ab1b-4e4e-a71e-1877c40ce5f7");
            Guid actual = TestOrderedListGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.secondary;
            GH_Exposure actual = TestOrderedListGhHelper.TestObject.Exposure;

            Assert.Equal(expected, actual);
        }
    }
}
