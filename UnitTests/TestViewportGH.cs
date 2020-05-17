using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestViewportGhHelper
    {
        public static ViewportGH TestObject
        {
            get
            {
                ViewportGH testObject = new ViewportGH();
                return testObject;
            }
        }
    }
    public class TestViewportGh
    {
        [Theory]
        [InlineData("Viewport", "Viewport",
              "Capture selected Rhino viewport and insert to report as image",
              "Pterodactyl", "Parts")]
        public void TestViewport(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestViewportGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestViewportGhHelper.TestObject.NickName);
            Assert.Equal(description, TestViewportGhHelper.TestObject.Description);
            Assert.Equal(category, TestViewportGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestViewportGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Title", "Title", "Title image", GH_ParamAccess.item)]
        [InlineData(1, "Viewport Name", "Viewport Name", "Name of the viewport", GH_ParamAccess.item)]
        [InlineData(2, "Path", "Path", "Directory where image of your viewport will be saved. Should end up with .png", GH_ParamAccess.item)]
        [InlineData(3, "Draw Axes", "Draw Axes", "Boolean, true = draw axes", GH_ParamAccess.item)]
        [InlineData(4, "Draw Grid", "Draw Grid", "Boolean, true = draw grid", GH_ParamAccess.item)]
        [InlineData(5, "Draw Grid Axes", "Draw Grid Axes", "Boolean, true = draw grid axes", GH_ParamAccess.item)]
        [InlineData(6, "Transparent Background", "Transparent Background", "Boolean, true = transparent background", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestViewportGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestViewportGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestViewportGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestViewportGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestViewportGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestViewportGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestViewportGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestViewportGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("8b413c79-f96e-4fad-9cd9-80f7d9989f8a");
            Guid actual = TestViewportGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestExposure()
        {
            GH_Exposure expected = GH_Exposure.quarternary;
            GH_Exposure actual = TestViewportGhHelper.TestObject.Exposure;

            Assert.Equal(expected, actual);
        }
    }
}
