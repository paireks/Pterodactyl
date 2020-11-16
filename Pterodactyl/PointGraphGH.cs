using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using PterodactylCharts;
using System.Windows.Forms;
using PterodactylEngine;

namespace Pterodactyl
{
    public class PointGraphGH : GH_Component
    {
        public PointGraphGH()
          : base("Point Graph", "Point Graph",
              "Create point graph, if you want to generate Report Part - set Path",
              "Pterodactyl", "Basic Graphs")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Title", "Title", "Title of your graph", GH_ParamAccess.item, "Awesomeness of Pterodactyl plugin");
            pManager.AddNumberParameter("X Values", "X Values", "Values of x as list",
                                        GH_ParamAccess.list, new List<double> { 0.0, 0.5, 1.0, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5 });
            pManager.AddNumberParameter("Y Values", "Y Values", "Values of y as list",
                GH_ParamAccess.list, new List<double> { 1, 1.414214, 2, 2.828427, 4, 5.656854, 8, 11.313708, 16, 22.627417 });
            pManager.AddTextParameter("X Name", "X Name", "Sets x name", GH_ParamAccess.item, "Time");
            pManager.AddTextParameter("Y Name", "Y Name", "Sets y name", GH_ParamAccess.item, "Awesomeness");
            pManager.AddColourParameter("Color", "Color", "Sets data color", GH_ParamAccess.item, Color.FromArgb(0,0,0));
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new PterodactylGrasshopperBitmapParam(), "Report Part", "Report Part", "Created part of the report (Markdown text with referenced Image)", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string title = "";
            List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();
            string xName = "";
            string yName = "";
            Color color = new Color();

            DA.GetData(0, ref title);
            DA.GetDataList(1, xValues);
            DA.GetDataList(2, yValues);
            DA.GetData(3, ref xName);
            DA.GetData(4, ref yName);
            DA.GetData(5, ref color);

            PointGraph graphObject = new PointGraph();
            dialogImage = graphObject;
            PterodactylGrasshopperBitmapGoo GH_bmp = new PterodactylGrasshopperBitmapGoo();
            graphObject.PointGraphData(true, title, xValues, yValues, xName, yName, color, GH_bmp.ReferenceTag);
            using (Bitmap b = graphObject.ExportBitmap())
            {
                GH_bmp.Value = b.Clone(new Rectangle(0, 0, b.Width, b.Height), b.PixelFormat);
                GH_bmp.ReportPart = graphObject.Create();
                DA.SetData(0, GH_bmp);
            }
        }

        private PointGraph dialogImage;

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalMenuItems(menu);
            Menu_AppendItem(menu, "Show Graph", ShowChart, this.Icon, (dialogImage != null), false);
        }

        private void ShowChart(object sender, EventArgs e)
        {
            if (dialogImage != null) dialogImage.ShowDialog();
        }


        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylPointGraph;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("d476c66a-0dd5-40a6-a30c-15e69a20ab16"); }
        }
    }
}