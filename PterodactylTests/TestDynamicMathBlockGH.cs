using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestDynamicMathBlockGhHelper
    {
        public static DynamicMathBlockGH TestObject
        {
            get
            {
                DynamicMathBlockGH testObject = new DynamicMathBlockGH();
                return testObject;
            }
        }
    }
    public class TestDynamicMathBlockGh
    {
        [Theory]
        [InlineData("Dynamic Math Block", "Dynamic Math Block",
            "Creates dynamic math block, that can change variables values automatically.",
            "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestDynamicMathBlockGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestDynamicMathBlockGhHelper.TestObject.NickName);
            Assert.Equal(description, TestDynamicMathBlockGhHelper.TestObject.Description);
            Assert.Equal(category, TestDynamicMathBlockGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestDynamicMathBlockGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Text", "Text", "Math text written in TeX-style. Put dynamic variables in <> brackets. " +
                                       "For example: x - this is static variable, <x> - this is dynamic variable, that will change to given value.",
            GH_ParamAccess.item)]
        [InlineData(1, "Variables Symbols", "Variables Symbols",
            "List of symbols that represent dynamic values.",
            GH_ParamAccess.list)]
        [InlineData(2, "Variables Values", "Variables Values", "Variables' values as list.",
            GH_ParamAccess.list)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestDynamicMathBlockGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestDynamicMathBlockGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestDynamicMathBlockGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestDynamicMathBlockGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestDynamicMathBlockGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestDynamicMathBlockGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestDynamicMathBlockGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestDynamicMathBlockGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("29f4111e-1253-461b-9a66-d12e684fc17b");
            Guid actual = TestDynamicMathBlockGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.tertiary;
            GH_Exposure actual = TestDynamicMathBlockGhHelper.TestObject.Exposure;

            Assert.Equal(expected, actual);
        }
    }
}
