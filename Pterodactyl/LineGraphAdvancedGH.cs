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
            pManager.AddTextParameter("X Name", "X Name", "Sets x name", GH_ParamAccess.item, "Time");
            pManager.AddTextParameter("Y Name", "Y Name", "Sets y name", GH_ParamAccess.item, "Awesomeness");
            pManager.AddColourParameter("Colors", "Colors", "Colors as list. Number of colors should match number of branches " +
                                                            "in X and Y Values inputs.", GH_ParamAccess.item, Color.FromArgb(0, 0, 0));
            pManager.AddColourParameter("Background Color", "Background Color", "Sets color of the background",
                GH_ParamAccess.item, Color.FromArgb(255, 255, 255));
            pManager.AddNumberParameter("Graph Width", "Graph Width", "Sets graph width", GH_ParamAccess.item, 600);
            pManager.AddNumberParameter("Graph Height", "Graph Height", "Sets graph height", GH_ParamAccess.item, 400);
            pManager.AddTextParameter("Text Annotations", "Text Annotations",
                "Test annotations as list, should match Text Locations.",
                GH_ParamAccess.list);
            pManager.AddPointParameter("Text Locations", "Text Locations",
                "Text locations as list of points, that match Text Annotations.",
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