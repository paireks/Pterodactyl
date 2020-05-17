using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestTableGhHelper
    {
        public static TableGH TestObject
        {
            get
            {
                TableGH testObject = new TableGH();
                return testObject;
            }
        }
    }
    public class TestTableGh
    {
        [Theory]
        [InlineData("Table", "Table",
              "Insert table",
              "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestTableGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestTableGhHelper.TestObject.NickName);
            Assert.Equal(description, TestTableGhHelper.TestObject.Description);
            Assert.Equal(category, TestTableGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestTableGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Table Headings", "Table Headings", "Headings inside table as text list", GH_ParamAccess.list)]
        [InlineData(1, "Alignment", "Alignment", "Alignment for each column as matching integer list. 0 = left, 1 = center, 2 = right", GH_ParamAccess.list)]
        [InlineData(2, "Data Tree", "Data Tree", "Data as tree. Each branch is treated as one column." +
                " Inside each branch should be a list of text elements, elements represent rows inside that column.", GH_ParamAccess.tree)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestTableGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestTableGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestTableGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestTableGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.list)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestTableGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestTableGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestTableGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestTableGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("a495a759-ad79-446c-9272-644766102a8b");
            Guid actual = TestTableGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
