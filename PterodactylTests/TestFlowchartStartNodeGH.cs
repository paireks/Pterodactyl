using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestFlowchartStartNodeGhHelper
    {
        public static FlowchartStartNodeGH TestObject
        {
            get
            {
                FlowchartStartNodeGH testObject = new FlowchartStartNodeGH();
                return testObject;
            }
        }
    }
    public class TestFlowchartStartNodeGh
    {
        [Theory]
        [InlineData("Flowchart Start Node", "Flowchart Start Node",
              "Add starting node for flowchart",
              "Pterodactyl", "Tools")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestFlowchartStartNodeGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestFlowchartStartNodeGhHelper.TestObject.NickName);
            Assert.Equal(description, TestFlowchartStartNodeGhHelper.TestObject.Description);
            Assert.Equal(category, TestFlowchartStartNodeGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestFlowchartStartNodeGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Text", "Text", "Add text inside node", GH_ParamAccess.item)]
        [InlineData(1, "Shape", "Shape",
            "Set shape of the node as int. 0 - rectangle, 1 - round edges, 2 - stadium-shaped," +
            " 3 - subroutine, 4 - cylindrical, 5 - circle, 6 - asymetric, 7 - rhombus, 8 - hexagon",
            GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestFlowchartStartNodeGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestFlowchartStartNodeGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestFlowchartStartNodeGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestFlowchartStartNodeGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Node", "Node", "Node for flowchart", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestFlowchartStartNodeGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestFlowchartStartNodeGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestFlowchartStartNodeGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestFlowchartStartNodeGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("a62feed3-27e8-4f49-b309-160e99384796");
            Guid actual = TestFlowchartStartNodeGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.secondary;
            GH_Exposure actual = TestFlowchartStartNodeGhHelper.TestObject.Exposure;

            Assert.Equal(expected, actual);
        }
    }
}
