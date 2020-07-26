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
            pManager.AddIntegerParameter("Graph Type", "Graph Type",
                "Graph type as int, 0 = line graph, 1 = point graph", GH_ParamAccess.item, 0);
            pManager.AddGenericParameter("Graph Sizes", "Graph Sizes", "Set graph sizes", GH_ParamAccess.item);
            pManager.AddGenericParameter("Graph Colors", "Graph Colors", "Set colors for graph", GH_ParamAccess.item);
            pManager.AddGenericParameter("Graph Axis", "Graph Axis", "Set axises of graph", GH_ParamAccess.item);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Settings", "Graph Settings", "Graph settings", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            int graphType = 0;
            GraphSizes graphSizes = null;
            GraphColors graphColors = null;
            GraphAxis graphAxis = null;

            DA.GetData(0, ref graphType);
            DA.GetData(1, ref graphSizes);
            DA.GetData(2, ref graphColors);
            DA.GetData(3, ref graphAxis);

            GraphSettings graphSettings = new GraphSettings(graphType, graphSizes, graphColors, graphAxis);

            DA.SetData(0, graphSettings);
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
            get { return new Guid("4bd1c3e3-4664-4f73-a42b-e4c01c30935b"); }
        }
    }
}