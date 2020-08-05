using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestGraphDataGhHelper
    {
        public static GraphDataGH TestObject
        {
            get
            {
                GraphDataGH testObject = new GraphDataGH();
                return testObject;
            }
        }
    }
    public class TestGraphDataGh
    {
        [Theory]
        [InlineData("Graph Data", "Graph Data",
            "Create data for graph",
            "Pterodactyl", "Advanced Graph")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestGraphDataGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestGraphDataGhHelper.TestObject.NickName);
            Assert.Equal(description, TestGraphDataGhHelper.TestObject.Description);
            Assert.Equal(category, TestGraphDataGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestGraphDataGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "X Values", "X Values", "Values of x as tree of lists." +
                                               " Each tree branch should be a list of x values." +
                                               " Each branch represents new series of data.",
            GH_ParamAccess.tree)]
        [InlineData(1, "Y Values", "Y Values", "Values of y as tree of lists." +
                                               " Each tree branch should be a list of y values." +
                                               " Each branch represents new series of data.",
            GH_ParamAccess.tree)]
        [InlineData(2, "Values Names", "Values Names",
            "List of names of values, each item should match each branch of X and Y Values. It will appear if" +
            " Show Legend == True.", GH_ParamAccess.list)]
        [InlineData(3, "Data Type", "Data Type",
            "Set data type as list, each data type should match each series of data", GH_ParamAccess.list)]

        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphDataGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestGraphDataGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestGraphDataGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestGraphDataGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Graph Data", "Graph Data", "Graph data", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestGraphDataGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestGraphDataGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestGraphDataGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestGraphDataGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("74472dd4-f46e-4dcd-895b-e650f09760c3");
            Guid actual = TestGraphDataGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.tertiary;
            GH_Exposure actual = TestGraphDataGhHelper.TestObject.Exposure;

            Assert.Equal(expected, actual);
        }
    }
}
