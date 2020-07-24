using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylCharts;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class GraphSizesGH : GH_Component
    {
        public GraphSizesGH()
          : base("Graph Sizes", "Graph Sizes",
              "Set sizes of graph",
              "Pterodactyl", "Advanced Graphs")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("Width", "Width", "Set width", GH_ParamAccess.item, 600);
            pManager.AddIntegerParameter("Height", "Height", "Set height", GH_ParamAccess.item, 400);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Sizes", "Graph Sizes", "Size of graph", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            int width = 0;
            int height = 0;

            DA.GetData(0, ref width);
            DA.GetData(1, ref height);

            GraphSizes graphSizes = new GraphSizes(width, height);

            DA.SetData(0, graphSizes);
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
            get { return new Guid("d677815c-993d-43f9-abae-4538b4c327a6"); }
        }
    }
}