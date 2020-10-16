using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using PterodactylEngine;

namespace Pterodactyl
{
    public class TaskListGH : GH_Component
    {
        public TaskListGH()
          : base("Task List", "Task List",
              "Add task list",
              "Pterodactyl", "Parts")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Tasks", "Tasks", "Different tasks as text list",
                  GH_ParamAccess.list, new List<string> { "Try Task List component",
                  "Write your own task"});
            pManager.AddBooleanParameter("Done", "Done", "Boolean list. True = done.",
                  GH_ParamAccess.list, new List<bool> { true, false });
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<string> text = new List<string>();
            List<bool> done = new List<bool>();

            DA.GetDataList(0, text);
            DA.GetDataList(1, done);

            string report;
            TaskList taskObject = new TaskList(text, done);
            report = taskObject.Create();

            DA.SetData(0, report);
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.secondary; }
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylTaskList;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("6d67b19c-bd15-44eb-9524-e0856ff55d1b"); }
        }
    }
}