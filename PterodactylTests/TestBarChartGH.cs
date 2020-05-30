using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestBarChartGhHelper
    {
        public static BarChartGH TestObject
        {
            get
            {
                BarChartGH testObject = new BarChartGH();
                return testObject;
            }
        }
    }
    public class TestBarChartGh
    {
        [Theory]
        [InlineData("Bar Chart", "Bar Chart",
            "Create bar chart",
            "Pterodactyl", "Basic Graphs")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestBarChartGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestBarChartGhHelper.TestObject.NickName);
            Assert.Equal(description, TestBarChartGhHelper.TestObject.Description);
            Assert.Equal(category, TestBarChartGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestBarChartGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Show Graph", "Show Graph", "True = show graph, False = hide", GH_ParamAccess.item)]
        [InlineData(1, "Title", "Title", "Title of your chart", GH_ParamAccess.item)]
        [InlineData(2, "Values", "Values", "Values for each bar as list", GH_ParamAccess.list)]
        [InlineData(3, "Bar Names", "Bar Names", "Sets bar names as list", GH_ParamAccess.list)]
        [InlineData(4, "Text Format", "Text Format", "Set text format", GH_ParamAccess.item)]
        [InlineData(5, "Colors", "Colors", "Sets data colors, each color for each bar", GH_ParamAccess.list)]
        [InlineData(6, "Path", "Path", "Set path where graph should be saved as .png file" +
                                       " if you want to save it, and/or if you want to create Report Part. Remember to end " +
                                       "path with .png extension.", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestBarChartGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestBarChartGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestBarChartGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestBarChartGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestBarChartGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestBarChartGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestBarChartGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestBarChartGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("eecd2d5e-918e-42ee-b7ab-aee8b49b3ecd");
            Guid actual = TestBarChartGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
