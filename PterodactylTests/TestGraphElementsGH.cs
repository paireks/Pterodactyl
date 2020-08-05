using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestGraphElementsGhHelper
    {
        public static GraphElementsGH TestObject
        {
            get
            {
                GraphElementsGH testObject = new GraphElementsGH();
                return testObject;
            }
        }
    }
    public class TestGraphElementsGh
    {
        [Theory]
        [InlineData("Graph Elements", "Graph Elements",
            "Add elements of graph",
            "Pterodactyl", "Advanced Graph")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestGraphElementsGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestGraphElementsGhHelper.TestObject.NickName);
            Assert.Equal(description, TestGraphElementsGhHelper.TestObject.Description);
            Assert.Equal(category, TestGraphElementsGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestGraphElementsGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Graph Data", "Graph Data", "Add graph data", GH_ParamAccess.item)]
        [InlineData(1, "Graph Legend", "Graph Legend", "Add graph legend", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphElementsGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestGraphElementsGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestGraphElementsGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestGraphElementsGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Graph Elements", "Graph Elements", "Graph elements", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphElementsGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestGraphElementsGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestGraphElementsGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestGraphElementsGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("82919916-4afe-4ef7-98a4-7a4b3cb3f518");
            Guid actual = TestGraphElementsGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.secondary;
            GH_Exposure actual = TestGraphElementsGhHelper.TestObject.Exposure;
            Assert.Equal(expected, actual);
        }
    }
}
