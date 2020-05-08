using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Components;
using Grasshopper.Kernel.Parameters;
using Pterodactyl;
using UnitTestsGH;
using Xunit;

namespace UnitTestsGH
{
    public class TestSaveReportGHHelper
    {
        public static SaveReportGH TestObject
        {
            get
            {
                SaveReportGH testObject = new SaveReportGH();
                return testObject;
            }
        }
    }
    public class TestSaveReportGH
    {
        [Theory]
        [InlineData("Save Report", "Save Report",
            "Saves markdown file with your report data",
            "Pterodactyl", "Tools")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestSaveReportGHHelper.TestObject.Name);
            Assert.Equal(nickname, TestSaveReportGHHelper.TestObject.NickName);
            Assert.Equal(description, TestSaveReportGHHelper.TestObject.Description);
            Assert.Equal(category, TestSaveReportGHHelper.TestObject.Category);
            Assert.Equal(subCategory, TestSaveReportGHHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Report", "Report", "Report to save", GH_ParamAccess.item)]
        [InlineData(1, "Path", "Path", "Path where your file will be saved, should end up with .md",
            GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestSaveReportGHHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestSaveReportGHHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestSaveReportGHHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestSaveReportGHHelper.TestObject.Params.Input[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            System.Guid expected = new Guid("2cfe90c9-bca3-4d6d-9243-d5212107066c");
            System.Guid actual = TestSaveReportGHHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
