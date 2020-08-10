using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestLineDataGhHelper
    {
        public static LineDataGH TestObject
        {
            get
            {
                LineDataGH testObject = new LineDataGH();
                return testObject;
            }
        }
    }
    public class TestLineDataGh
    {
        [Theory]
        [InlineData("Line Data", "Line Data",
            "Add line data",
            "Pterodactyl", "Advanced Graph")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestLineDataGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestLineDataGhHelper.TestObject.NickName);
            Assert.Equal(description, TestLineDataGhHelper.TestObject.Description);
            Assert.Equal(category, TestLineDataGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestLineDataGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Color", "Color", "Add color for line data", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestLineDataGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestLineDataGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestLineDataGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestLineDataGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Data Type", "Data Type", "Set data type", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestLineDataGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestLineDataGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestLineDataGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestLineDataGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("2112c4c5-2553-4087-b44d-9d3e054580f0");
            Guid actual = TestLineDataGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.quarternary;
            GH_Exposure actual = TestLineDataGhHelper.TestObject.Exposure;

            Assert.Equal(expected, actual);
        }
    }
}
