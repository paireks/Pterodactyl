using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestLineGraphGhHelper
    {
        public static LineGraphGH TestObject
        {
            get
            {
                LineGraphGH testObject = new LineGraphGH();
                return testObject;
            }
        }
    }
    public class TestLineGraphGh
    {
        [Theory]
        [InlineData("Line Graph", "Line Graph",
            "Create line graph, if you want to generate Report Part - set Path",
            "Pterodactyl", "Basic Graphs")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestLineGraphGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestLineGraphGhHelper.TestObject.NickName);
            Assert.Equal(description, TestLineGraphGhHelper.TestObject.Description);
            Assert.Equal(category, TestLineGraphGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestLineGraphGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Show Graph", "Show Graph", "True = show graph, False = hide", GH_ParamAccess.item)]
        [InlineData(1, "Title", "Title", "Title of your graph", GH_ParamAccess.item)]
        [InlineData(2, "X Values", "X Values", "Values of x as list", GH_ParamAccess.list)]
        [InlineData(3, "Y Values", "Y Values", "Values of y as list", GH_ParamAccess.list)]
        [InlineData(4, "X Name", "X Name", "Sets x name", GH_ParamAccess.item)]
        [InlineData(5, "Y Name", "Y Name", "Sets y name", GH_ParamAccess.item)]
        [InlineData(6, "Color", "Color", "Sets data color", GH_ParamAccess.item)]
        [InlineData(7, "Path", "Path", "Set path where graph should be saved as .png file" +
                                       " if you want to save it, and/or if you want to create Report Part. Remember to end " +
                                       "path with .png extension.", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestLineGraphGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestLineGraphGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestLineGraphGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestLineGraphGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestLineGraphGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestLineGraphGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestLineGraphGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestLineGraphGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("d476c66a-0dd5-40a6-a30c-15e69a20ab15");
            Guid actual = TestLineGraphGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
