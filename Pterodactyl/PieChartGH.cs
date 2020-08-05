using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using PterodactylCharts;
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
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Show Graph", "Show Graph", "True = show graph, False = hide", GH_ParamAccess.item, false);
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
            List<Color> colors = new List<Color>();
            string path = "";

            DA.GetData(0, ref showGraph);
            DA.GetData(1, ref title);
            DA.GetDataList(2, values);
            DA.GetDataList(3, names);
            DA.GetDataList(4, colors);
            DA.GetData(5, ref path);

            PieChart chartObject = new PieChart();
            chartObject.PieChartData(showGraph, title, values, names, colors, path);
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
            get { return new Guid("39dd40f8-cd47-4da4-8716-36d735954ef6"); }
        }
    }
}