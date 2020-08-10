using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestGraphSettingsGhHelper
    {
        public static GraphSettingsGH TestObject
        {
            get
            {
                GraphSettingsGH testObject = new GraphSettingsGH();
                return testObject;
            }
        }
    }
    public class TestGraphSettingsGh
    {
        [Theory]
        [InlineData("Graph Settings", "Graph Settings",
            "Create graph settings",
            "Pterodactyl", "Advanced Graph")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestGraphSettingsGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestGraphSettingsGhHelper.TestObject.NickName);
            Assert.Equal(description, TestGraphSettingsGhHelper.TestObject.Description);
            Assert.Equal(category, TestGraphSettingsGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestGraphSettingsGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Title", "Title", "Set title for a graph", GH_ParamAccess.item)]
        [InlineData(1, "Graph Sizes", "Graph Sizes", "Set graph sizes", GH_ParamAccess.item)]
        [InlineData(2, "Color", "Color", "Set background color for graph", GH_ParamAccess.item)]
        [InlineData(3, "Graph Axis", "Graph Axis", "Set axises of graph", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphSettingsGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestGraphSettingsGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestGraphSettingsGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestGraphSettingsGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Graph Settings", "Graph Settings", "Graph settings", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphSettingsGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestGraphSettingsGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestGraphSettingsGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestGraphSettingsGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("4bd1c3e3-4664-4f73-a42b-e4c01c30935b");
            Guid actual = TestGraphSettingsGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.secondary;
            GH_Exposure actual = TestGraphSettingsGhHelper.TestObject.Exposure;

            Assert.Equal(expected, actual);
        }
    }
}
