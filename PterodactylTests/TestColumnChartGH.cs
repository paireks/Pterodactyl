using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestColumnChartGhHelper
    {
        public static ColumnChartGH TestObject
        {
            get
            {
                ColumnChartGH testObject = new ColumnChartGH();
                return testObject;
            }
        }
    }
    public class TestColumnChartGh
    {
        [Theory]
        [InlineData("Column Chart", "Column Chart",
            "Create column chart, if you want to generate Report Part - set Path",
            "Pterodactyl", "Basic Graphs")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestColumnChartGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestColumnChartGhHelper.TestObject.NickName);
            Assert.Equal(description, TestColumnChartGhHelper.TestObject.Description);
            Assert.Equal(category, TestColumnChartGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestColumnChartGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Show Graph", "Show Graph", "True = show graph, False = hide", GH_ParamAccess.item)]
        [InlineData(1, "Title", "Title", "Title of your chart", GH_ParamAccess.item)]
        [InlineData(2, "Values", "Values", "Values for each column as list",
            GH_ParamAccess.list)]
        [InlineData(3, "Bar Names", "Column Names", "Sets column names as list", GH_ParamAccess.list)]
        [InlineData(4, "Text Format", "Text Format", "Set text format", GH_ParamAccess.item)]
        [InlineData(5, "Colors", "Colors", "Sets data colors, each color for each column", GH_ParamAccess.list)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestColumnChartGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestColumnChartGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestColumnChartGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestColumnChartGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestColumnChartGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestColumnChartGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestColumnChartGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestColumnChartGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("5e1546fc-06cc-4442-ba03-5f0a2a2a4ebd");
            Guid actual = TestColumnChartGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
