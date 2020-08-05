using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestPieChartGhHelper
    {
        public static PieChartGH TestObject
        {
            get
            {
                PieChartGH testObject = new PieChartGH();
                return testObject;
            }
        }
    }
    public class TestPieChartGh
    {
        [Theory]
        [InlineData("Pie Chart", "Pie Chart",
            "Create pie chart, if you want to generate Report Part - set Path",
            "Pterodactyl", "Basic Graphs")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestPieChartGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestPieChartGhHelper.TestObject.NickName);
            Assert.Equal(description, TestPieChartGhHelper.TestObject.Description);
            Assert.Equal(category, TestPieChartGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestPieChartGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Show Graph", "Show Graph", "True = show graph, False = hide", GH_ParamAccess.item)]
        [InlineData(1, "Title", "Title", "Title of your chart", GH_ParamAccess.item)]
        [InlineData(2, "Values", "Values", "Values for each slice as list",
            GH_ParamAccess.list)]
        [InlineData(3, "Slices Names", "Slices Names", "Sets slices names as list", GH_ParamAccess.list)]
        [InlineData(4, "Colors", "Colors", "Sets data colors, each color for each slice", GH_ParamAccess.list)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestPieChartGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestPieChartGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestPieChartGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestPieChartGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestPieChartGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestPieChartGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestPieChartGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestPieChartGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("39dd40f8-cd47-4da4-8716-36d735954ef6");
            Guid actual = TestPieChartGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
