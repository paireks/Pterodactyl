using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Grasshopper.Kernel;
using PterodactylCharts;
using PterodactylEngine;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class PieChartGH : GH_Component
    {
        public PieChartGH()
          : base("Pie Chart", "Pie Chart",
              "Create pie chart, if you want to generate Report Part - set Path",
              "Pterodactyl", "Basic Graphs")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Title", "Title", "Title of your chart", GH_ParamAccess.item, "Reaction to Pterodactyl plugin");
            pManager.AddNumberParameter("Values", "Values", "Values for each slice as list",
                GH_ParamAccess.list, new List<double> { 54, 34, 1 });
            pManager.AddTextParameter("Slices Names", "Slices Names", "Sets slices names as list", GH_ParamAccess.list,
                new List<string> { "Happy", "Excited", "Holy cow" });
            pManager.AddColourParameter("Colors", "Colors", "Sets data colors, each color for each slice", GH_ParamAccess.list,
                new List<Color>
                {
                    Color.FromArgb(255,119,0),
                    Color.FromArgb(168,45,160),
                    Color.FromArgb(115,115,115)
                });
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new PterodactylGrasshopperBitmapParam(), "Report Part", "Report Part", "Created part of the report (Markdown text)", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string title = "";
            List<double> values = new List<double>();
            List<string> names = new List<string>();
            List<Color> colors = new List<Color>();

            DA.GetData(0, ref title);
            DA.GetDataList(1, values);
            DA.GetDataList(2, names);
            DA.GetDataList(3, colors);

            PterodactylCharts.PieChart chartObject = new PterodactylCharts.PieChart();
            dialogImage = chartObject;
            PterodactylGrasshopperBitmapGoo GH_bmp = new PterodactylGrasshopperBitmapGoo();
            chartObject.PieChartData(true, title, values, names, colors, GH_bmp.ReferenceTag);
            using (Bitmap b = chartObject.ExportBitmap())
            {
                GH_bmp.Value = b.Clone(new Rectangle(0, 0, b.Width, b.Height), b.PixelFormat);
                GH_bmp.ReportPart = chartObject.Create();
                DA.SetData(0, GH_bmp);
            }
        }

        private PterodactylCharts.PieChart dialogImage;

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalMenuItems(menu);
            Menu_AppendItem(menu, "Show Chart", ShowChart, this.Icon, (dialogImage != null), false);
        }

        private void ShowChart(object sender, EventArgs e)
        {
            if (dialogImage != null) dialogImage.ShowDialog();
        }


        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylPieChart;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("39dd40f8-cd47-4da4-8716-36d735954ef6"); }
        }
    }
}