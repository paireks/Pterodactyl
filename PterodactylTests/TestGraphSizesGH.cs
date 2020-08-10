using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestGraphSizesGhHelper
    {
        public static GraphSizesGH TestObject
        {
            get
            {
                GraphSizesGH testObject = new GraphSizesGH();
                return testObject;
            }
        }
    }
    public class TestGraphSizesGh
    {
        [Theory]
        [InlineData("Graph Sizes", "Graph Sizes",
            "Set sizes of graph",
            "Pterodactyl", "Advanced Graph")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestGraphSizesGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestGraphSizesGhHelper.TestObject.NickName);
            Assert.Equal(description, TestGraphSizesGhHelper.TestObject.Description);
            Assert.Equal(category, TestGraphSizesGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestGraphSizesGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Width", "Width", "Set width", GH_ParamAccess.item)]
        [InlineData(1, "Height", "Height", "Set height", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphSizesGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestGraphSizesGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestGraphSizesGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestGraphSizesGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Graph Sizes", "Graph Sizes", "Size of graph", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphSizesGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestGraphSizesGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestGraphSizesGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestGraphSizesGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("d677815c-993d-43f9-abae-4538b4c327a6");
            Guid actual = TestGraphSizesGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.tertiary;
            GH_Exposure actual = TestGraphSizesGhHelper.TestObject.Exposure;
            Assert.Equal(expected, actual);
        }
    }
}
