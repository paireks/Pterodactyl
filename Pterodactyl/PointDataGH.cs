using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using PterodactylCharts;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class PointDataGH : GH_Component
    {
        public PointDataGH()
          : base("Point Data", "Point Data",
              "Add point data",
              "Pterodactyl", "Advanced Graph")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddColourParameter("Color", "Color", "Add color for point data", GH_ParamAccess.item,
                Color.Black);
            pManager.AddIntegerParameter("Marker", "Marker",
                "Choose marker as int. 0 - None, 1 - Circle, 2 - Square, 3 - Diamond, 4 - Triangle",
                GH_ParamAccess.item, 1);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Data Type", "Data Type", "Set data type", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Color color = Color.Empty;
            int marker = 0;

            DA.GetData(0, ref color);
            DA.GetData(1, ref marker);

            DataType dataType = new DataType(color, marker);

            DA.SetData(0, dataType);
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
            get { return GH_Exposure.quarternary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("ce4dd50d-6bf6-448f-afdb-9ddeeda515ba"); }
        }
    }
}