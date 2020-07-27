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
            "Add simple pie chart",
            "Pterodactyl", "Tools")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestPieChartGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestPieChartGhHelper.TestObject.NickName);
            Assert.Equal(description, TestPieChartGhHelper.TestObject.Description);
            Assert.Equal(category, TestPieChartGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestPieChartGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Title", "Title", "Title of your pie chart", GH_ParamAccess.item)]
        [InlineData(1, "Categories", "Categories", "Categories as text list", GH_ParamAccess.list)]
        [InlineData(2, "Values", "Values", "Values for each category as number list", GH_ParamAccess.list)]
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
            Guid expected = new Guid("26a43f20-9ede-4f7c-b5dd-95ab3e2a9ad1");
            Guid actual = TestPieChartGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
