using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestMathBlockGhHelper
    {
        public static MathBlockGH TestObject
        {
            get
            {
                MathBlockGH testObject = new MathBlockGH();
                return testObject;
            }
        }
    }
    public class TestMathBlockGh
    {
        [Theory]
        [InlineData("Math Block", "Math Block",
            "Creates math block",
            "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestMathBlockGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestMathBlockGhHelper.TestObject.NickName);
            Assert.Equal(description, TestMathBlockGhHelper.TestObject.Description);
            Assert.Equal(category, TestMathBlockGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestMathBlockGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Text", "Text", "Math text written in TeX-style", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestMathBlockGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestMathBlockGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestMathBlockGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestMathBlockGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestMathBlockGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestMathBlockGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestMathBlockGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestMathBlockGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("2a4c7686-7e6b-4421-b0f3-1210b604247c");
            Guid actual = TestMathBlockGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.tertiary;
            GH_Exposure actual = TestMathBlockGhHelper.TestObject.Exposure;

            Assert.Equal(expected, actual);
        }
    }
}
