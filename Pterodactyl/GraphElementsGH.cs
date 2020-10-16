using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylCharts;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class GraphElementsGH : GH_Component
    {
        public GraphElementsGH()
          : base("Graph Elements", "Graph Elements",
              "Add elements of graph",
              "Pterodactyl", "Advanced Graph")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Data", "Graph Data", "Add graph data", GH_ParamAccess.item);
            pManager.AddGenericParameter("Graph Legend", "Graph Legend", "Add graph legend", GH_ParamAccess.item);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Elements", "Graph Elements", "Graph elements", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GraphData graphData = null;
            GraphLegend graphLegend = null;

            DA.GetData(0, ref graphData);
            DA.GetData(1, ref graphLegend);

            GraphElements graphElements = new GraphElements(graphData, graphLegend);

            DA.SetData(0, graphElements);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylGraphElements;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.secondary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("82919916-4afe-4ef7-98a4-7a4b3cb3f518"); }
        }
    }
}