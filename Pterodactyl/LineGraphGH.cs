using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using PterodactylCharts;

namespace Pterodactyl
{
    public class LineGraphGH : GH_Component
    {
        public LineGraphGH()
          : base("Line Graph", "Line Graph",
              "Create line graph",
              "Pterodactyl", "Graphs")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Show Graph", "Show Graph", "True = show graph, False = hide", GH_ParamAccess.item, false);
            pManager.AddTextParameter("Title", "Title", "Title of your graph", GH_ParamAccess.item, "Awesomeness of Pterodactyl plugin");
            pManager.AddNumberParameter("X Values", "X Values", "Values of x as list",
                                        GH_ParamAccess.list, new List<double> {0.0, 1.0});
            pManager.AddNumberParameter("Y Values", "Y Values", "Values of y as list",
                GH_ParamAccess.list, new List<double> { 0.0, 10.0 });
            pManager.AddTextParameter("X Name", "X Name", "Sets x name", GH_ParamAccess.item, "Time");
            pManager.AddTextParameter("Y Name", "Y Name", "Sets y name", GH_ParamAccess.item, "Awesomeness");
            pManager.AddIntegerParameter("Graph Size Settings", "Graph Size Settings",
                "Graph settings created by Graph Size Settings component", GH_ParamAccess.list, new List<int>{0, 0, 500, 500});
            pManager.AddTextParameter("Path", "Path", "Set path where graph should be saved as .png file" +
                                                      " if you want to save it, and/or if you want to create Report Part",
                GH_ParamAccess.item);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool showGraph = false;
            string title = "";
            List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();
            string xName = "";
            string yName = "";
            List<int> graphSizeSettings = new List<int>();
            string path = "";

            DA.GetData(0, ref showGraph);
            DA.GetData(1, ref title);
            DA.GetDataList(2, xValues);
            DA.GetDataList(3, yValues);
            DA.GetData(4, ref xName);
            DA.GetData(5, ref yName);
            DA.GetDataList(6, graphSizeSettings);
            DA.GetData(7, ref path);

            LineGraphData graphObject = new LineGraphData(showGraph, title, xValues, yValues, xName, yName, graphSizeSettings, path);
            if (showGraph)
            {
                graphObject.ShowDialog();
            }
            
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
            get { return new Guid("d476c66a-0dd5-40a6-a30c-15e69a20ab15"); }
        }
    }
}