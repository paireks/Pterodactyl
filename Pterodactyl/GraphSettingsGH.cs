using System;
using System.Collections.Generic;
using System.Drawing;
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
              "Pterodactyl", "Advanced Graph")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            // Please arrange as you see most logical. Now should be fully backwards compatible.
            pManager.AddTextParameter("Title", "Title", "Set title for a graph", GH_ParamAccess.item,"Title");   
            pManager.AddGenericParameter("Graph Sizes", "Graph Sizes", "Set graph sizes", GH_ParamAccess.item);
            pManager.AddColourParameter("Background", "Background", "Set background color for graph", GH_ParamAccess.item, Color.White);
            pManager.AddGenericParameter("Graph Axis", "Graph Axis", "Set axises of graph", GH_ParamAccess.item);
            pManager.AddNumberParameter("Graph Padding", "Graph Padding", " The padding around the graph. Default is 10", GH_ParamAccess.item, 10d);
            pManager.AddNumberParameter("Title Size", "Title Size", " The title size", GH_ParamAccess.item, 16d);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Settings", "Graph Settings", "Graph settings", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string graphTitle = string.Empty;
            GraphSizes graphSizes = null;
            Color graphColor = Color.Empty;
            GraphAxis graphAxis = null;
            double padding = 0;
            double tSize = 0;

            DA.GetData(0, ref graphTitle);            
            DA.GetData(1, ref graphSizes);
            DA.GetData(2, ref graphColor);
            DA.GetData(3, ref graphAxis);
            DA.GetData(4, ref padding);
            DA.GetData(5, ref tSize);

            GraphSettings graphSettings = new GraphSettings(graphTitle, tSize, graphSizes, graphColor, graphAxis, padding);

            DA.SetData(0, graphSettings);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylGraphSettings;
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