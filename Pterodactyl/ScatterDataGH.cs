using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using PterodactylCharts;

// GradientData Code written by Anton Kerezov

namespace Pterodactyl
{
    public class ScatterDataGH : GH_Component
    {
        public ScatterDataGH()
         : base("Scatter Data", "Scatter Data",
        "Add point sizes and parameters to create gradients that fit in the specified palette",
        "Pterodactyl", "Advanced Graph")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Values", "Values", "Number parameters corresponding to each X&Y value pair. It will determine the color from the Palette range. Palette range goes from min to max.", GH_ParamAccess.list);
            pManager.AddNumberParameter("Sizes", "Sizes", "Marker sizes, should match values.", GH_ParamAccess.list);
            pManager.AddIntegerParameter("Marker", "Marker", "Choose point marker: 0 - None, 1 - Circle, 2 - Square, 3 - Diamond, 4 - Triangle, 5 - Cross, 6 - Plus", GH_ParamAccess.item, 1);
            pManager.AddColourParameter("Color Palette", "Color Palette", "Add a list of colors to create a Palette. Palette range goes from min to max.", GH_ParamAccess.list, new List<Color> { Color.Red, Color.Yellow, Color.Green });
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Data Type", "Data Type", "Set data type", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            List<double> values = new List<double>();
            List<double> sizes = new List<double>();
            int marker = 0;
            List<Color> palette = new List<Color>();

            DA.GetDataList(0, values);
            DA.GetDataList(1, sizes);
            DA.GetData(2, ref marker);
            DA.GetDataList(3, palette);

            DataType dataType = new DataType(values.ToArray(), sizes.ToArray(), marker, palette.ToArray());

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