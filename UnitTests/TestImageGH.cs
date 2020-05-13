using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestImageGhHelper
    {
        public static ImageGH TestObject
        {
            get
            {
                ImageGH testObject = new ImageGH();
                return testObject;
            }
        }
    }
    public class TestImageGh
    {
        [Theory]
        [InlineData("Image", "Image",
            "Add image from given directory",
              "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestImageGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestImageGhHelper.TestObject.NickName);
            Assert.Equal(description, TestImageGhHelper.TestObject.Description);
            Assert.Equal(category, TestImageGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestImageGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Title", "Title", "Image title", GH_ParamAccess.item)]
        [InlineData(1, "Path", "Path", "Local path to image", GH_ParamAccess.item)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestImageGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestImageGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestImageGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestImageGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestImageGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestImageGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestImageGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestImageGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("e91741eb-da38-434b-941d-faa8f6ecf389");
            Guid actual = TestImageGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
