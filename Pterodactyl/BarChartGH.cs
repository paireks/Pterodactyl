using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using Rhino.Geometry;
using PterodactylCharts;
using System.Windows.Forms;
using ShapeDiver.Public.Grasshopper.Parameters.SDMLDoc;
using PterodactylEngine;
using ShapeDiver.Public.Grasshopper.Parameters;

namespace Pterodactyl
{
    public class BarChartGH : GH_Component
    {
        public BarChartGH()
          : base("Bar Chart", "Bar Chart",
              "Create bar chart, if you want to generate Report Part - set Path",
              "Pterodactyl", "Basic Graphs")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            //pManager.AddBooleanParameter("Show Graph", "Show Graph", "True = show graph, False = hide", GH_ParamAccess.item, false);
            pManager.AddTextParameter("Title", "Title", "Title of your chart", GH_ParamAccess.item, "Wingspan comparison (size matters)");
            pManager.AddNumberParameter("Values", "Values", "Values for each bar as list",
                GH_ParamAccess.list, new List<double> { 0.68, 0.81, 1.00, 1.20, 1.60, 6.00 });
            pManager.AddTextParameter("Bar Names", "Bar Names", "Sets bar names as list", GH_ParamAccess.list, 
                new List<string> {"Pigeon","Duck", "Crow", "Owl", "Peacock", "Pterodactyl"});
            pManager.AddTextParameter("Text Format", "Text Format", "Set text format", GH_ParamAccess.item, "{0:0.00[m]}");
            pManager.AddColourParameter("Colors", "Colors", "Sets data colors, each color for each bar", GH_ParamAccess.list,
                new List<Color>
                {
                    Color.FromArgb(255, 110, 110),
                    Color.FromArgb(7,173,148),
                    Color.FromArgb(153,255,0),
                    Color.FromArgb(255,119,0),
                    Color.FromArgb(168,45,160),
                    Color.FromArgb(115,115,115)
                });
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new PterodactylGrasshopperBitmapParam(), "Report Part", "Report Part", "Created part of the report (Markdown text with referenced Image)", GH_ParamAccess.item);
        }
        public override bool IsBakeCapable => false;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string title = "";
            List<double> values = new List<double>();
            List<string> names = new List<string>();
            string textFormat = "";
            List<Color> colors = new List<Color>();

            DA.GetData(0, ref title);
            DA.GetDataList(1, values);
            DA.GetDataList(2, names);
            DA.GetData(3, ref textFormat);
            DA.GetDataList(4, colors);

            BarChart chartObject = new BarChart();
            dialogImage = chartObject;
            PterodactylGrasshopperBitmapGoo GH_bmp = new PterodactylGrasshopperBitmapGoo();
            chartObject.BarChartData(true, title, values, names, textFormat, colors, GH_bmp.ReferenceTag);
            using (Bitmap b = chartObject.ExportBitmap())
            {
                GH_bmp.Value = b.Clone(new Rectangle(0, 0, b.Width, b.Height), b.PixelFormat);
                GH_bmp.ReportPart = chartObject.Create();
                DA.SetData(0, GH_bmp);
            }
        }

        private BarChart dialogImage;

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
                return Properties.Resources.PterodactylBarChart;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("eecd2d5e-918e-42ee-b7ab-aee8b49b3ecd"); }
        }
    }
}