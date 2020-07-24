using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylCharts;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class GraphSettingsGH : GH_Component
    {
        public GraphSettingsGH()
          : base("Graph Settings", "Graph Settings",
              "Create graph settings",
              "Pterodactyl", "Advanced Graphs")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Sizes", "Graph Sizes", "Set graph sizes", GH_ParamAccess.item);
            pManager.AddGenericParameter("Graph Colors", "Graph Colors", "Set colors for graph", GH_ParamAccess.item);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Settings", "Graph Settings", "Graph settings", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GraphSizes graphSizes = null;
            GraphColors graphColors = null;

            DA.GetData(0, ref graphSizes);
            DA.GetData(1, ref graphColors);

            GraphSettings graphSettings = new GraphSettings(graphSizes, graphColors);

            DA.SetData(0, graphSettings);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("4bd1c3e3-4664-4f73-a42b-e4c01c30935b"); }
        }
    }
}