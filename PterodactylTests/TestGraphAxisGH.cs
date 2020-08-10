using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestGraphAxisGhHelper
    {
        public static GraphAxisGH TestObject
        {
            get
            {
                GraphAxisGH testObject = new GraphAxisGH();
                return testObject;
            }
        }
    }
    public class TestGraphAxisGh
    {
        [Theory]
        [InlineData("Graph Axis", "Graph Axis",
            "Add axises for the graph",
            "Pterodactyl", "Advanced Graph")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestGraphAxisGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestGraphAxisGhHelper.TestObject.NickName);
            Assert.Equal(description, TestGraphAxisGhHelper.TestObject.Description);
            Assert.Equal(category, TestGraphAxisGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestGraphAxisGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "X Axis Name", "X Axis Name", "Name of the X axis", GH_ParamAccess.item)]
        [InlineData(1, "Y Axis Name", "Y Axis Name", "Name of the y axis", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphAxisGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestGraphAxisGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestGraphAxisGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestGraphAxisGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Graph Axis", "Graph Axis", "Graph axises", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphAxisGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestGraphAxisGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestGraphAxisGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestGraphAxisGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("db15705d-c783-4c42-aff1-0a0fb4e409f1");
            Guid actual = TestGraphAxisGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.tertiary;
            GH_Exposure actual = TestGraphAxisGhHelper.TestObject.Exposure;

            Assert.Equal(expected, actual);
        }
    }
}
