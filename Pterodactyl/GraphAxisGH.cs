using System;
using Grasshopper.Kernel;
using PterodactylCharts;

namespace Pterodactyl
{
    public class GraphAxisGH : GH_Component
    {
        public GraphAxisGH()
          : base("Graph Axis", "Graph Axis",
              "Add axes for the graph",
              "Pterodactyl", "Advanced Graph")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("X Axis Name", "X Axis Name", "Name of the X axis", GH_ParamAccess.item, "x");
            pManager.AddTextParameter("Y Axis Name", "Y Axis Name", "Name of the y axis", GH_ParamAccess.item, "y");
            pManager.AddTextParameter("C Axis Name", "C Axis Name", "Name of the color axis (used in Scatter Data)", GH_ParamAccess.item, "Color range");
            pManager.AddNumberParameter("Axis Padding", "Axis Padding", "Offset distance from X & Y Axis to plot data from 0.00 - 1.00", GH_ParamAccess.item, 0.01);
            pManager.AddNumberParameter("Text size", "Text size", "Text size", GH_ParamAccess.item, 12);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Axis", "Graph Axis", "Graph axes", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string xAxisName = "";
            string yAxisName = "";
            string cAxisName = "";
            double padding = 0;
            double size = 0;

            DA.GetData(0, ref xAxisName);
            DA.GetData(1, ref yAxisName);
             DA.GetData(2, ref cAxisName);
            DA.GetData(3, ref padding);
            DA.GetData(4, ref size);

            GraphAxis graphAxis = new GraphAxis(xAxisName, yAxisName, cAxisName, padding, size);

            DA.SetData(0, graphAxis);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylGraphAxis;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.tertiary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("db15705d-c783-4c42-aff1-0a0fb4e409f1"); }
        }
    }
}