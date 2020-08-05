using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestGraphGhHelper
    {
        public static GraphGH TestObject
        {
            get
            {
                GraphGH testObject = new GraphGH();
                return testObject;
            }
        }
    }
    public class TestGraphGh
    {
        [Theory]
        [InlineData("Graph", "Graph",
            "Create graph, if you want to generate Report Part - set Path",
            "Pterodactyl", "Advanced Graph")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestGraphGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestGraphGhHelper.TestObject.NickName);
            Assert.Equal(description, TestGraphGhHelper.TestObject.Description);
            Assert.Equal(category, TestGraphGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestGraphGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Show Graph", "Show Graph", "Show graph", GH_ParamAccess.item)]
        [InlineData(1, "Graph Elements", "Graph Elements", "Add graph elements", GH_ParamAccess.item)]
        [InlineData(2, "Graph Settings", "Graph Settings", "Add graph settings", GH_ParamAccess.item)]
        [InlineData(3, "Path", "Path", "Set path where graph should be saved as .png file" +
                                       " if you want to save it, and/or if you want to create Report Part. Remember to end " +
                                       "path with .png extension.", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestGraphGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestGraphGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestGraphGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestGraphGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestGraphGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestGraphGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("32ea2490-6ab7-4090-9de2-e2414d0932c0");
            Guid actual = TestGraphGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
