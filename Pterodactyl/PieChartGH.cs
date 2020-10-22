using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
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
            pManager.AddParameter(new PterodactylGrasshopperBitmapParam(), "Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }

        protected override void BeforeSolveInstance()
        {
            base.BeforeSolveInstance();
            if (!System.IO.Directory.Exists(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()))
            {
                System.IO.Directory.CreateDirectory(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath());
            }
            else
            {
                if (System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()).Length > 0)
                {
                    foreach (string f in System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()))
                    {
                        if (f.Contains(this.InstanceGuid.ToString()))
                        {
                            try { System.IO.File.Delete(f); }
                            catch (Exception ex) { AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Unable to delete file at " + f + " : " + ex.Message); }
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
            List<Color> colors = new List<Color>();
            string path = PterodactylGrasshopperBitmapGoo.CreateTemporaryFilePath(this);

            DA.GetData(0, ref title);
            DA.GetDataList(1, values);
            DA.GetDataList(2, names);
            DA.GetDataList(3, colors);

            PieChart chartObject = new PieChart();
            chartObject.PieChartData(true, title, values, names, colors, path);

            chartObject.Export();
            dialogImage = chartObject;
            using (Image i = Image.FromFile(path))
            {
                using (Bitmap b = new Bitmap(i))
                {
                    string reportPart = chartObject.Create();
                    PterodactylGrasshopperBitmapGoo GH_bmp = new PterodactylGrasshopperBitmapGoo(b.Clone(new Rectangle(0, 0, b.Width, b.Height), b.PixelFormat)
                                                             , reportPart, path);
                    DA.SetData(0, GH_bmp);
                }
            }
        }

        public override void RemovedFromDocument(GH_Document document)
        {
            if (!System.IO.Directory.Exists(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()))
            {
                System.IO.Directory.CreateDirectory(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath());
            }
            else
            {
                if (System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()).Length > 0)
                {
                    foreach (string f in System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()))
                    {
                        if (f.Contains(this.InstanceGuid.ToString()))
                        {
                            try { System.IO.File.Delete(f); }
                            catch (Exception ex) { AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Unable to delete file at " + f + " : " + ex.Message); }
                        }
                    }
                }
            }
            base.RemovedFromDocument(document);
        }

        private PieChart dialogImage;

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