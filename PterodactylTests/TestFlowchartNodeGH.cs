using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestFlowchartNodeGhHelper
    {
        public static FlowchartNodeGH TestObject
        {
            get
            {
                FlowchartNodeGH testObject = new FlowchartNodeGH();
                return testObject;
            }
        }
    }
    public class TestFlowchartNodeGh
    {
        [Theory]
        [InlineData("Flowchart Node", "Flowchart Node",
            "Add node for flowchart",
            "Pterodactyl", "Tools")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestFlowchartNodeGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestFlowchartNodeGhHelper.TestObject.NickName);
            Assert.Equal(description, TestFlowchartNodeGhHelper.TestObject.Description);
            Assert.Equal(category, TestFlowchartNodeGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestFlowchartNodeGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Text", "Text", "Add text inside node", GH_ParamAccess.item)]
        [InlineData(1, "Node/Link", "Node/Link", "Add inputs (flowchart nodes or links) or leave empty",
            GH_ParamAccess.list)]
        [InlineData(2, "Shape", "Shape",
            "Set shape of the node as int. 0 - rectangle, 1 - round edges, 2 - stadium-shaped," +
            " 3 - subroutine, 4 - cylindrical, 5 - circle, 6 - asymetric, 7 - rhombus, 8 - hexagon",
            GH_ParamAccess.item)]

        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestFlowchartNodeGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestFlowchartNodeGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestFlowchartNodeGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestFlowchartNodeGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Node", "Node", "Node for flowchart", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestFlowchartNodeGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestFlowchartNodeGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestFlowchartNodeGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestFlowchartNodeGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("030544d6-8a19-4793-a224-e61f7c422fdf");
            Guid actual = TestFlowchartNodeGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.secondary;
            GH_Exposure actual = TestFlowchartNodeGhHelper.TestObject.Exposure;
            Assert.Equal(expected, actual);
        }
    }
}
