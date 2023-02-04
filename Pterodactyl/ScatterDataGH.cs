using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using PterodactylCharts;
using System.Linq;

// GradientData Code written by Anton Kerezov

namespace Pterodactyl
{
    public class ScatterDataGH : GH_Component
    {
        public ScatterDataGH()
         : base("Scatter Data", "Scatter Data",
        "Add point sizes and parametes to create gradients that fit in the specified palette",
        "Pterodactyl", "Advanced Graph")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddColourParameter("Palette", "Palette", "Add a list of colors to map the Values. Maybe any number from 1 to 4096", GH_ParamAccess.tree, new List<Color> { Color.Black, Color.Orange, Color.Red });
            pManager.AddIntegerParameter("Marker", "Marker", "Choose point marker: 0 - None, 1 - Circle, 2 - Square, 3 - Diamond, 4 - Triangle, 5 - Cross, 6 - Plus", GH_ParamAccess.item, 1);
            pManager.AddNumberParameter("Sizes", "Sizes", "Choose marker sizes 0.1 - 50.0", GH_ParamAccess.tree);
            pManager.AddNumberParameter("Params", "Params", "Number parameters corresponding to each X&Y Value pair\nIt will determine the pair color from the Palette range (Pallete range is [Params min to max]", GH_ParamAccess.tree);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Data Type", "Data Type", "Set data type", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            GH_Structure<Grasshopper.Kernel.Types.GH_Colour> tColour = new GH_Structure<Grasshopper.Kernel.Types.GH_Colour>();
            GH_Structure<Grasshopper.Kernel.Types.GH_Number> tSize = new GH_Structure<Grasshopper.Kernel.Types.GH_Number>();
            GH_Structure<Grasshopper.Kernel.Types.GH_Number> tValues = new GH_Structure<Grasshopper.Kernel.Types.GH_Number>();
            int marker = 0;

            DA.GetDataTree(0, out tColour);
            DA.GetData(1, ref marker);
            DA.GetDataTree(2, out tSize);
            DA.GetDataTree(3, out tValues);

            Color[] palette = tColour.FlattenData().Select(s => s.Value).ToArray();
            double[] sizes = tSize.FlattenData().Select(s => s.Value).ToArray();
            double[] values = tValues.FlattenData().Select(s => s.Value).ToArray();

            DataType dataType = new DataType(palette, marker, sizes, values);

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