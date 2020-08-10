using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestFlowchartGhHelper
    {
        public static FlowchartGH TestObject
        {
            get
            {
                FlowchartGH testObject = new FlowchartGH();
                return testObject;
            }
        }
    }
    public class TestFlowchartGh
    {
        [Theory]
        [InlineData("Flowchart", "Flowchart",
            "Add flowchart",
            "Pterodactyl", "Tools")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestFlowchartGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestFlowchartGhHelper.TestObject.NickName);
            Assert.Equal(description, TestFlowchartGhHelper.TestObject.Description);
            Assert.Equal(category, TestFlowchartGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestFlowchartGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Direction", "Direction",
            "Set direction, True = from left to right, False = from top to bottom", GH_ParamAccess.item)]
        [InlineData(1, "Last Nodes", "Last Nodes", "Add last node / nodes of a flowchart as list", GH_ParamAccess.list)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestFlowchartGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestFlowchartGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestFlowchartGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestFlowchartGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestFlowchartGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestFlowchartGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestFlowchartGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestFlowchartGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("b40a0ebe-dfe8-4586-82a6-cc95395fc9ef");
            Guid actual = TestFlowchartGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.secondary;
            GH_Exposure actual = TestFlowchartGhHelper.TestObject.Exposure;
            Assert.Equal(expected, actual);
        }
    }
}
