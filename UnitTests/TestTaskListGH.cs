using System;
using Grasshopper.Kernel;
using Pterodactyl;
using Xunit;

namespace UnitTestsGH
{
    public class TestTaskListGhHelper
    {
        public static TaskListGH TestObject
        {
            get
            {
                TaskListGH testObject = new TaskListGH();
                return testObject;
            }
        }
    }
    public class TestTaskListGh
    {
        [Theory]
        [InlineData("Task List", "Task List",
            "Add task list",
            "Pterodactyl", "Parts")]
        public void TestName(string name, string nickname, string description, string category, string subCategory)
        {
            Assert.Equal(name, TestTaskListGhHelper.TestObject.Name);
            Assert.Equal(nickname, TestTaskListGhHelper.TestObject.NickName);
            Assert.Equal(description, TestTaskListGhHelper.TestObject.Description);
            Assert.Equal(category, TestTaskListGhHelper.TestObject.Category);
            Assert.Equal(subCategory, TestTaskListGhHelper.TestObject.SubCategory);
        }

        [Theory]
        [InlineData(0, "Tasks", "Tasks", "Different tasks as text list", GH_ParamAccess.list)]
        [InlineData(1, "Done", "Done", "Boolean list. True = done.", GH_ParamAccess.list)]
        public void TestRegisterInputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestTaskListGhHelper.TestObject.Params.Input[id].Name);
            Assert.Equal(nickname, TestTaskListGhHelper.TestObject.Params.Input[id].NickName);
            Assert.Equal(description, TestTaskListGhHelper.TestObject.Params.Input[id].Description);
            Assert.Equal(access, TestTaskListGhHelper.TestObject.Params.Input[id].Access);
        }

        [Theory]
        [InlineData(0, "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item)]
        public void TestRegisterOutputParams(int id, string name, string nickname,
            string description, GH_ParamAccess access)
        {
            Assert.Equal(name, TestTaskListGhHelper.TestObject.Params.Output[id].Name);
            Assert.Equal(nickname, TestTaskListGhHelper.TestObject.Params.Output[id].NickName);
            Assert.Equal(description, TestTaskListGhHelper.TestObject.Params.Output[id].Description);
            Assert.Equal(access, TestTaskListGhHelper.TestObject.Params.Output[id].Access);
        }

        [Fact]
        public void TestGuid()
        {
            Guid expected = new Guid("6d67b19c-bd15-44eb-9524-e0856ff55d1b");
            Guid actual = TestTaskListGhHelper.TestObject.ComponentGuid;

            Assert.Equal(expected, actual);
        }
    }
}
