using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using Rhino.Geometry;
using PterodactylCharts;
//using ShapeDiver.Public.Grasshopper.Parameters;

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
            //pManager.AddTextParameter("Path", "Path", "Set path where graph should be saved as .png file" +
            //                                          " if you want to save it, and/or if you want to create Report Part. Remember to end " +
            //                                          "path with .png extension.",
            //    GH_ParamAccess.item, "");
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new PterodactylGrasshopperBitmapParam(), "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }

        protected override void BeforeSolveInstance()
        {
            base.BeforeSolveInstance();
            if (!System.IO.Directory.Exists(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath()))
            {
                System.IO.Directory.CreateDirectory(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath());
            }
            else
            {
                if (System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath()).Length > 0)
                {
                    foreach (string f in System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath()))
                    {
                        if (f.Contains(this.InstanceGuid.ToString()))
                        {
                            try { System.IO.File.Delete(f); }
                            catch (Exception ex) { AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Unable to delete file at " + f + ": " + ex.Message); }
                        }
                    }
                }
            }
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string title = "";
            List<double> values = new List<double>();
            List<string> names = new List<string>();
            string textFormat = "";
            List<Color> colors = new List<Color>();
            string path = PterodactylGrasshopperBitmapGoo.CreateTemporaryFilePath(this);

            DA.GetData(0, ref title);
            DA.GetDataList(1, values);
            DA.GetDataList(2, names);
            DA.GetData(3, ref textFormat);
            DA.GetDataList(4, colors);

            BarChart chartObject = new BarChart();
            chartObject.BarChartData(false, title, values, names, textFormat, colors, path);

            chartObject.Export();
            using (Image i = Image.FromFile(path))
            {
                using (Bitmap b = new Bitmap(i))
                {
                    string reportPart = chartObject.Create();
                    PterodactylGrasshopperBitmapGoo GH_bmp = new PterodactylGrasshopperBitmapGoo(b.Clone(new Rectangle(0, 0, b.Width, b.Height), b.PixelFormat)
                                                             , reportPart);
                    DA.SetData(0, GH_bmp);
                }
            }
        }

        public override void RemovedFromDocument(GH_Document document)
        {
            if (!System.IO.Directory.Exists(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath()))
            {
                System.IO.Directory.CreateDirectory(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath());
            }
            else
            {
                if (System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath()).Length > 0)
                {
                    foreach (string f in System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath()))
                    {
                        if (f.Contains(this.InstanceGuid.ToString()))
                        {
                            try { System.IO.File.Delete(f); }
                            catch (Exception ex) { AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Unable to delete file at " + f + ": " + ex.Message); }
                        }
                    }
                }
            }
            base.RemovedFromDocument(document);
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