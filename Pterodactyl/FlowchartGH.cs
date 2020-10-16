using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylEngine;
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
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Direction", "Direction",
                "Set direction, True = from left to right, False = from top to bottom", GH_ParamAccess.item, true);
            pManager.AddGenericParameter("Last Nodes", "Last Nodes", "Add last node / nodes of a flowchart as list", GH_ParamAccess.list);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool direction = true;
            List<FlowchartNode> lastNodes = new List<FlowchartNode>();

            DA.GetData(0, ref direction);
            DA.GetDataList(1, lastNodes);

            Flowchart flowchart = new Flowchart(direction, lastNodes);
            string reportPart = flowchart.Create();

            DA.SetData(0, reportPart);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylFlowchart;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.secondary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("b40a0ebe-dfe8-4586-82a6-cc95395fc9ef"); }
        }
    }
}