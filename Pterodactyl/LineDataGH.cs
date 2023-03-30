using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using PterodactylCharts;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class LineDataGH : GH_Component
    {
        public LineDataGH()
          : base("Line Data", "Line Data",
              "Add line data",
              "Pterodactyl", "Advanced Graph")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddColourParameter("Color", "Color", "Add color for line data", GH_ParamAccess.item, Color.Black);
            pManager.AddIntegerParameter("Interpolation", "Interpolation", "0 - None\n" +
                "1 - UniformCatmullRomSpline\n" +
                "2 - CatmullRomSpline\n" +
                "3 - CanonicalSpline\n" +
                "4 - ChordalCatmullRomSpline", GH_ParamAccess.item, 0);
            pManager.AddIntegerParameter("Line Style", "Line Style", "0 - Solid, 1 - Dash, 2 - Dot, 3 - DashDot, 4 - DashDashDot", GH_ParamAccess.item, 0);
            pManager.AddNumberParameter("Line Weight", "Line Weight", "A value from 0.1 to 20.0", GH_ParamAccess.item, 2);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Data Type", "Data Type", "Set data type", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Color color = Color.Empty;
            int inter = 0;
            int style = 0;
            double thickness = 1;

            DA.GetData(0, ref color);
            DA.GetData(1, ref inter);
            DA.GetData(2, ref style);
            DA.GetData(3, ref thickness);

            DataType dataType = new DataType(color, inter, style, thickness);

            DA.SetData(0, dataType);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylLineData;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.quarternary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("2112c4c5-2553-4087-b44d-9d3e054580f0"); }
        }
    }
}