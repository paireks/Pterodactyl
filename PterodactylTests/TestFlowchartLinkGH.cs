using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestFlowchartLinkGhHelper
    {
        public static FlowchartLinkGH TestObject
        {
            get
            {
                FlowchartLinkGH testObject = new FlowchartLinkGH();
                return testObject;
            }
        }
    }
    public class TestFlowchartLinkGh
    {
        [Theory]
        [InlineData("Flowchart Link", "Flowchart Link",
            "Add flowchart link between two nodes",
            "Pterodactyl", "Tools")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestFlowchartLinkGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestFlowchartLinkGhHelper.TestObject.NickName);
            Assert.Equal(description, TestFlowchartLinkGhHelper.TestObject.Description);
            Assert.Equal(category, TestFlowchartLinkGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestFlowchartLinkGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Type", "Type", "Type as integer. 0 - normal, 1 - open, 2 - dotted, 3 - thick", GH_ParamAccess.item)]
        [InlineData(1, "Node", "Node", "First node for link", GH_ParamAccess.item)]
        [InlineData(2, "Text", "Text", "Additional text that will be displayed on a link (optional)",
            GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestFlowchartLinkGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestFlowchartLinkGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestFlowchartLinkGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestFlowchartLinkGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Link", "Link", "Flowchart link, connect it with another node", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestFlowchartLinkGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestFlowchartLinkGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestFlowchartLinkGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestFlowchartLinkGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("3de8e971-9c2e-4a73-bc1d-56ebfc0732ac");
            Guid actual = TestFlowchartLinkGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.secondary;
            GH_Exposure actual = TestFlowchartLinkGhHelper.TestObject.Exposure;

            Assert.Equal(expected, actual);
        }
    }
}
