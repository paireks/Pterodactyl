using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using Rhino.Geometry;
using PterodactylCharts;

namespace Pterodactyl
{
    public class BarChartGH : GH_Component
    {
        public BarChartGH()
          : base("Bar Chart", "Bar Chart",
              "Create bar chart",
              "Pterodactyl", "Basic Graphs")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Show Graph", "Show Graph", "True = show graph, False = hide", GH_ParamAccess.item, false);
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
            pManager.AddTextParameter("Path", "Path", "Set path where graph should be saved as .png file" +
                                                      " if you want to save it, and/or if you want to create Report Part. Remember to end " +
                                                      "path with .png extension.",
                GH_ParamAccess.item, "");
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool showGraph = false;
            string title = "";
            List<double> values = new List<double>();
            List<string> names = new List<string>();
            string textFormat = "";
            List<Color> colors = new List<Color>();
            string path = "";

            DA.GetData(0, ref showGraph);
            DA.GetData(1, ref title);
            DA.GetDataList(2, values);
            DA.GetDataList(3, names);
            DA.GetData(4, ref textFormat);
            DA.GetDataList(5, colors);
            DA.GetData(6, ref path);

            BarChart chartObject = new BarChart();
            chartObject.BarChartData(showGraph, title, values, names, textFormat, colors, path);
            if (showGraph)
            {
                chartObject.ShowDialog();
            }

            chartObject.Export();
            string reportPart = chartObject.Create();

            DA.SetData(0, reportPart);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("eecd2d5e-918e-42ee-b7ab-aee8b49b3ecd"); }
        }
    }
}