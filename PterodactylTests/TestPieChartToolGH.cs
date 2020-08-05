using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestPieChartToolGhHelper
    {
        public static PieChartToolGH TestObject
        {
            get
            {
                PieChartToolGH testObject = new PieChartToolGH();
                return testObject;
            }
        }
    }
    public class TestPieChartToolGh
    {
        [Theory]
        [InlineData("Pie Chart", "Pie Chart",
            "Add simple pie chart",
            "Pterodactyl", "Tools")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestPieChartToolGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestPieChartToolGhHelper.TestObject.NickName);
            Assert.Equal(description, TestPieChartToolGhHelper.TestObject.Description);
            Assert.Equal(category, TestPieChartToolGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestPieChartToolGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Title", "Title", "Title of your pie chart", GH_ParamAccess.item)]
        [InlineData(1, "Categories", "Categories", "Categories as text list", GH_ParamAccess.list)]
        [InlineData(2, "Values", "Values", "Values for each category as number list", GH_ParamAccess.list)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestPieChartToolGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestPieChartToolGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestPieChartToolGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestPieChartToolGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestPieChartToolGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestPieChartToolGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestPieChartToolGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestPieChartToolGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("26a43f20-9ede-4f7c-b5dd-95ab3e2a9ad1");
            Guid actual = TestPieChartToolGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
