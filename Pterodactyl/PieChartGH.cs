using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylEngine;

namespace Pterodactyl
{
    public class PieChartGH : GH_Component
    {
        public PieChartGH()
          : base("Pie Chart", "Pie Chart",
              "Add pie chart",
              "Pterodactyl", "Gadgets")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Title", "Title", "Title of your pie chart", GH_ParamAccess.item, "Reaction to Pterodactyl plugin") ;
            pManager.AddTextParameter("Categories", "Categories", "Categories as text list",
                 GH_ParamAccess.list, new List<string> { "Happy", "Excited", "Holy cow"});
            pManager.AddNumberParameter("Values", "Values", "Values for each category as number list",
                 GH_ParamAccess.list, new List<double> { 54, 34, 1 });
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string title = "";
            List<string> categories = new List<string>();
            List<double> values = new List<double>();

            DA.GetData(0, ref title);
            DA.GetDataList(1, categories);
            DA.GetDataList(2, values);

            string report;
            PieChart reportObject = new PieChart(title, categories, values);
            report = reportObject.Create();

            DA.SetData(0, report);
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
            get { return new Guid("26a43f20-9ede-4f7c-b5dd-95ab3e2a9ad1"); }
        }
    }
}