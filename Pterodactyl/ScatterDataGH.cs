using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using PterodactylCharts;

namespace Pterodactyl
{
    public class ScatterDataGH : GH_Component
    {
        public ScatterDataGH()
         : base("Scatter Data", "Scatter Data",
        "Add point data",
        "Pterodactyl", "Advanced Graph")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddColourParameter("Palette", "Palette", "Add a list of colors to map the Values. Maybe any number from 1 to 4096", GH_ParamAccess.list, new List<Color> {Color.Black, Color.Orange, Color.Red});
            pManager.AddIntegerParameter("Marker", "Marker", "Choose point marker: 0 - None, 1 - Circle, 2 - Square, 3 - Diamond, 4 - Triangle, 5 - Cross, 6 - Plus", GH_ParamAccess.item, 1);
            pManager.AddNumberParameter("Sizes", "Sizes","Choose marker sizes 0.1 - 50.0", GH_ParamAccess.list);
            pManager.AddNumberParameter("C Values", "C Values", "Numbers corresponding to each X&Y Values\nThey will determine point color from the Palette (Pallete range: C Values min to max)", GH_ParamAccess.list);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Data Type", "Data Type", "Set data type", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Color> palette = new List<Color>();
            List<double> sizes = new List<double>();
            List<double> values = new List<double>();
            int marker = 0;

            DA.GetDataList(0, palette);
            DA.GetData(1, ref marker);
            DA.GetDataList(2, sizes);
            DA.GetDataList(3, values);

            DataType dataType = new DataType(palette.ToArray(), marker, sizes.ToArray(), values.ToArray());

            /// have to flatten input if you want output to be also flat
            DA.SetData(0, dataType);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylScatterData;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.quarternary; }
        }
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("5719d58a-3937-4632-b99a-6bde802eb74a"); }
        }
    }
}