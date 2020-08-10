using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestPointGraphGhHelper
    {
        public static PointGraphGH TestObject
        {
            get
            {
                PointGraphGH testObject = new PointGraphGH();
                return testObject;
            }
        }
    }
    public class TestPointGraphGh
    {
        [Theory]
        [InlineData("Point Graph", "Point Graph",
            "Create point graph, if you want to generate Report Part - set Path",
            "Pterodactyl", "Basic Graphs")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestPointGraphGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestPointGraphGhHelper.TestObject.NickName);
            Assert.Equal(description, TestPointGraphGhHelper.TestObject.Description);
            Assert.Equal(category, TestPointGraphGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestPointGraphGhHelper.TestObject.SubCategory);
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
            Assert.Equal(name, TestPointGraphGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestPointGraphGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestPointGraphGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestPointGraphGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestPointGraphGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestPointGraphGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestPointGraphGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestPointGraphGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("d476c66a-0dd5-40a6-a30c-15e69a20ab16");
            Guid actual = TestPointGraphGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
