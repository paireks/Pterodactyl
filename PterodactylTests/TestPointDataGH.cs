using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestPointDataGhHelper
    {
        public static PointDataGH TestObject
        {
            get
            {
                PointDataGH testObject = new PointDataGH();
                return testObject;
            }
        }
    }
    public class TestPointDataGh
    {
        [Theory]
        [InlineData("Point Data", "Point Data",
            "Add point data",
            "Pterodactyl", "Advanced Graph")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestPointDataGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestPointDataGhHelper.TestObject.NickName);
            Assert.Equal(description, TestPointDataGhHelper.TestObject.Description);
            Assert.Equal(category, TestPointDataGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestPointDataGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Color", "Color", "Add color for point data", GH_ParamAccess.item)]
        [InlineData(1, "Marker", "Marker",
            "Choose marker as int. 0 - None, 1 - Circle, 2 - Square, 3 - Diamond, 4 - Triangle",
            GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestPointDataGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestPointDataGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestPointDataGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestPointDataGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Data Type", "Data Type", "Set data type", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestPointDataGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestPointDataGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestPointDataGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestPointDataGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("ce4dd50d-6bf6-448f-afdb-9ddeeda515ba");
            Guid actual = TestPointDataGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.quarternary;
            GH_Exposure actual = TestPointDataGhHelper.TestObject.Exposure;

            Assert.Equal(expected, actual);
        }
    }
}
