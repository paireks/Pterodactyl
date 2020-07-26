using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class FlowchartGH : GH_Component
    {
        public FlowchartGH()
          : base("Flowchart", "Flowchart",
              "Add flowchart",
              "Pterodactyl", "Tools")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Direction", "Direction",
                "Set direction, True = from left to right, False = from top to bottom", GH_ParamAccess.item, true);
            pManager.AddTextParameter("Last Nodes", "Last Nodes", "Add last node / nodes of a flowchart as list", GH_ParamAccess.list);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.secondary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("5c320088-9e10-48a9-beac-44e65dae2120"); }
        }
    }
}