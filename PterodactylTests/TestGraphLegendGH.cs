using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestGraphLegendGhHelper
    {
        public static GraphLegendGH TestObject
        {
            get
            {
                GraphLegendGH testObject = new GraphLegendGH();
                return testObject;
            }
        }
    }
    public class TestGraphLegendGh
    {
        [Theory]
        [InlineData("Graph Legend", "Graph Legend",
            "Create legend for graph",
            "Pterodactyl", "Advanced Graph")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestGraphLegendGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestGraphLegendGhHelper.TestObject.NickName);
            Assert.Equal(description, TestGraphLegendGhHelper.TestObject.Description);
            Assert.Equal(category, TestGraphLegendGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestGraphLegendGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Title", "Title", "Set title of a legend", GH_ParamAccess.item)]
        [InlineData(1, "Position", "Position",
            "Legend Position as integer from 0 to 11. 0-2 = Top positions, 3-5 = Bottom positions, 6-8 = Left positions," +
            "9-11 = Right positions, 12 = Outside graph",
            GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphLegendGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestGraphLegendGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestGraphLegendGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestGraphLegendGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Graph Legend", "Graph Legend", "Created legend", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphLegendGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestGraphLegendGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestGraphLegendGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestGraphLegendGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("b40a0ebe-dfe8-4586-82a6-cc95395fc9ee");
            Guid actual = TestGraphLegendGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.tertiary;
            GH_Exposure actual = TestGraphLegendGhHelper.TestObject.Exposure;
            Assert.Equal(expected, actual);
        }
    }
}
