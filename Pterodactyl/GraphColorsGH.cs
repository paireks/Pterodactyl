using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using PterodactylCharts;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class GraphColorsGH : GH_Component
    {
        public GraphColorsGH()
          : base("Graph Colors", "Graph Colors",
              "Set colors for graph",
              "Pterodactyl", "Advanced Graphs")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddColourParameter("Data Colors", "Data Colors",
                "Colors for data as list, each color should correspond each group of data", GH_ParamAccess.list, Color.Black);
            pManager.AddColourParameter("Background Color", "Background Color", "Color of the graph's background",
                GH_ParamAccess.item, Color.White);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Colors", "Graph Colors", "Graph colors", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Color> dataColors = new List<Color>();
            Color backgroundColor = new Color();

            DA.GetDataList(0, dataColors);
            DA.GetData(1, ref backgroundColor);

            GraphColors graphColors = new GraphColors(dataColors, backgroundColor);

            DA.SetData(0, graphColors);
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
            get { return new Guid("f3fd88fd-b199-4dbd-95cb-8e0783143814"); }
        }
    }
}