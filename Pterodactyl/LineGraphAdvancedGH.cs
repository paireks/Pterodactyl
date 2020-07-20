using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using Rhino.Geometry;
using PterodactylCharts;

namespace Pterodactyl
{
    public class LineGraphAdvancedGH : GH_Component
    {
        public LineGraphAdvancedGH()
          : base("Line Graph Advanced", "Line Graph Advanced",
              "Create complex line graph",
              "Pterodactyl", "Advanced Graphs")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Show Graph", "Show Graph", "True = show graph, False = hide",
                GH_ParamAccess.item, false);
            pManager.AddTextParameter("Title", "Title", "Title of your graph",
                GH_ParamAccess.item, "Awesomeness of Pterodactyl plugin");
            pManager.AddNumberParameter("X Values", "X Values", "Values of x as tree of lists." +
                                                                " Each tree branch should be a list of x values." +
                                                                " Each branch represents new series of data.",
                GH_ParamAccess.tree);
            pManager.AddNumberParameter("Y Values", "Y Values", "Values of y as tree of lists." +
                                                                " Each tree branch should be a list of y values." +
                                                                " Each branch represents new series of data.",
                GH_ParamAccess.tree);
            pManager.AddTextParameter("Values Names", "Values Names",
                "List of names of values, each item should match each branch of X and Y Values. It will appear if" +
                " Show Legend == True.", GH_ParamAccess.list);
            pManager.AddBooleanParameter("Show Legend", "Show Legend", "If true - legend will appear",
                GH_ParamAccess.item);
            pManager.AddTextParameter("Legend Title", "Legend Title", "Legend title",
                GH_ParamAccess.item, "Legend");
            pManager.AddIntegerParameter("Legend Position", "Legend Position",
                "Legend Position as integer from 0 to 11. 0-2 = Top positions, 3-5 = Bottom positions, 6-8 = Left positions," +
                "9-11 = Right positions.", GH_ParamAccess.item, 0);
            pManager.AddTextParameter("X Name", "X Name", "Sets x name", GH_ParamAccess.item, "Time");
            pManager.AddTextParameter("Y Name", "Y Name", "Sets y name", GH_ParamAccess.item, "Awesomeness");
            pManager.AddColourParameter("Colors", "Colors", "Colors as list. Number of colors should match number of branches " +
                                                            "in X and Y Values inputs.", GH_ParamAccess.list, Color.FromArgb(0, 0, 0));
            pManager.AddColourParameter("Background Color", "Background Color", "Sets color of the background",
                GH_ParamAccess.item, Color.FromArgb(255, 255, 255));
            pManager.AddIntegerParameter("Graph Width", "Graph Width", "Sets graph width as integer", GH_ParamAccess.item, 600);
            pManager.AddIntegerParameter("Graph Height", "Graph Height", "Sets graph height as integer", GH_ParamAccess.item, 400);
            pManager.AddTextParameter("Text Annotations", "Text Annotations",
                "Text annotations as list, should match Text Locations.",
                GH_ParamAccess.list);
            pManager.AddPointParameter("Text Locations", "Text Locations",
                "Text locations as list of points, that match Text Annotations. Only reads X and Y value of points.",
                GH_ParamAccess.list);
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
            Grasshopper.Kernel.Data.GH_Structure<Grasshopper.Kernel.Types.GH_Number> xValuesTree = new Grasshopper.Kernel.Data.GH_Structure<Grasshopper.Kernel.Types.GH_Number>();
            Grasshopper.Kernel.Data.GH_Structure<Grasshopper.Kernel.Types.GH_Number> yValuesTree = new Grasshopper.Kernel.Data.GH_Structure<Grasshopper.Kernel.Types.GH_Number>();
            List<string> valuesNames = new List<string>();
            bool showLegend = false;
            string legentTitle = "";
            int legendPosition = new int();
            string xName = "";
            string yName = "";
            List<Color> colors = new List<Color>();
            Color backgroundColor = new Color();
            int graphWidth = new int();
            int graphHeight = new int();
            List<string> textAnnotations = new List<string>();
            List<Point3d> textLocations = new List<Point3d>();
            string path = "";

            DA.GetData(0, ref showGraph);
            DA.GetData(1, ref title);
            DA.GetDataTree("X Values", out xValuesTree);
            DA.GetDataTree("Y Values", out yValuesTree);
            DA.GetDataList(4, valuesNames);
            DA.GetData(5, ref showLegend);
            DA.GetData(6, ref legentTitle);
            DA.GetData(7, ref legendPosition);
            DA.GetData(8, ref xName);
            DA.GetData(9, ref yName);
            DA.GetDataList(10, colors);
            DA.GetData(11, ref backgroundColor);
            DA.GetData(12, ref graphWidth);
            DA.GetData(13, ref graphHeight);
            DA.GetDataList(14, textAnnotations);
            DA.GetDataList(15, textLocations);
            DA.GetData(16, ref path);

            List<List<double>> xValues = new List<List<double>>();
            List<List<double>> yValues = new List<List<double>>();

            for (int i = 0; i < colors.Count; i++)
            {
                List<double> currentBranchXValues = new List<double>();
                for (int j = 0; j < xValuesTree.get_Branch(i).Count; j++)
                {
                    currentBranchXValues.Add(Convert.ToDouble(xValuesTree.get_Branch(i)[j].ToString()));
                }
                xValues.Add(currentBranchXValues);

                List<double> currentBranchYValues = new List<double>();
                for (int j = 0; j < yValuesTree.get_Branch(i).Count; j++)
                {
                    currentBranchYValues.Add(Convert.ToDouble(yValuesTree.get_Branch(i)[j].ToString()));
                }
                yValues.Add(currentBranchYValues);
            }

            List<double> textLocationXValues = new List<double>();
            List<double> textLocationYValues = new List<double>();

            for (int i = 0; i < textLocations.Count; i++)
            {
                textLocationXValues.Add(textLocations[i].X);
                textLocationYValues.Add(textLocations[i].Y);
            }

            LineGraph graphObject = new LineGraph();
            graphObject.LineGraphData(showGraph, title,
                xValues, yValues, valuesNames,
                showLegend, legentTitle, legendPosition,
                xName, yName,
                colors, backgroundColor,
                graphWidth, graphHeight,
                textAnnotations,
                textLocationXValues, textLocationYValues,
                path);

            if (showGraph)
            {
                graphObject.ShowDialog();
            }

            graphObject.Export();
            string reportPart = graphObject.Create();

            DA.SetData(0, reportPart);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylLineGraph;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("f8a1062d-2d9b-49df-8dec-f705f7d8d5fe"); }
        }
    }
}