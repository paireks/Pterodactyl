using System;
using Grasshopper.Kernel;
using PterodactylCharts;

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
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Title", "Title", "Set title of a legend", GH_ParamAccess.item, "Legend");
            pManager.AddIntegerParameter("Position", "Position",
                "Legend Position as integer from 0 to 11. " +
                "0-2 = Top positions, " +
                "3-5 = Bottom positions, " +
                "6-8 = Left positions, " +
                "9-11 = Right positions.",
                GH_ParamAccess.item,
                0);
            pManager.AddIntegerParameter("Placement", "Placement", "Legend Position as integer 0 = Inside,  1 = Outside", GH_ParamAccess.item, 0);
            pManager.AddIntegerParameter("Orientation", "Orientation", "Legend Orientation as integer 0 = Vertical,  1 = Horizontal", GH_ParamAccess.item, 1);
            pManager.AddNumberParameter("Text size", "Text size", "Text size", GH_ParamAccess.item, 12);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Legend", "Graph Legend", "Created legend", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string title = string.Empty;
            int position = 0;
            int place = 0;
            int orient = 0;
            double size = 1;

            DA.GetData(0, ref title);
            DA.GetData(1, ref position);
            DA.GetData(2, ref place);
            DA.GetData(3, ref orient);
            DA.GetData(4, ref size);

            GraphLegend legend = new GraphLegend(title, position, place, orient, size);

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