﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylCharts;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class GraphLegendGH : GH_Component
    {
        public GraphLegendGH()
          : base("Graph Legend", "Graph Legend",
              "Create legend for graph",
              "Pterodactyl", "Advanced Graph")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Title", "Title", "Set title of a legend", GH_ParamAccess.item, "Legend");
            pManager.AddIntegerParameter("Position", "Position",
                "Legend Position as integer from 0 to 11. 0-2 = Top positions, 3-5 = Bottom positions, 6-8 = Left positions," +
                "9-11 = Right positions, 12 = Outside graph",
                GH_ParamAccess.item,
                0);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Legend", "Graph Legend", "Created legend", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string title = string.Empty;
            int position = 0;

            DA.GetData(0, ref title);
            DA.GetData(1, ref position);

            GraphLegend legend = new GraphLegend(title, position);

            DA.SetData(0, legend);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylGraphLegend;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.tertiary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("b40a0ebe-dfe8-4586-82a6-cc95395fc9ee"); }
        }
    }
}