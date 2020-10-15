using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using Rhino.Geometry;
using PterodactylCharts;
using System.Windows.Forms;

namespace Pterodactyl
{
    public class PointGraphGH : GH_Component
    {
        public PointGraphGH()
          : base("Point Graph", "Point Graph",
              "Create point graph, if you want to generate Report Part - set Path",
              "Pterodactyl", "Basic Graphs")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Title", "Title", "Title of your graph", GH_ParamAccess.item, "Awesomeness of Pterodactyl plugin");
            pManager.AddNumberParameter("X Values", "X Values", "Values of x as list",
                                        GH_ParamAccess.list, new List<double> { 0.0, 0.5, 1.0, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5 });
            pManager.AddNumberParameter("Y Values", "Y Values", "Values of y as list",
                GH_ParamAccess.list, new List<double> { 1, 1.414214, 2, 2.828427, 4, 5.656854, 8, 11.313708, 16, 22.627417 });
            pManager.AddTextParameter("X Name", "X Name", "Sets x name", GH_ParamAccess.item, "Time");
            pManager.AddTextParameter("Y Name", "Y Name", "Sets y name", GH_ParamAccess.item, "Awesomeness");
            pManager.AddColourParameter("Color", "Color", "Sets data color", GH_ParamAccess.item, Color.FromArgb(0,0,0));
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
                            catch (Exception ex) { AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Unable to delete file at " + f + " : " + ex.Message); }
                        }
                    }
                }
            }
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string title = "";
            List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();
            string xName = "";
            string yName = "";
            Color color = new Color();
            string path = PterodactylGrasshopperBitmapGoo.CreateTemporaryFilePath(this);

            DA.GetData(0, ref title);
            DA.GetDataList(1, xValues);
            DA.GetDataList(2, yValues);
            DA.GetData(3, ref xName);
            DA.GetData(4, ref yName);
            DA.GetData(5, ref color);

            PointGraph graphObject = new PointGraph();
            graphObject.PointGraphData(true, title, xValues, yValues, xName, yName, color, path);

            graphObject.Export();
            dialogImage = graphObject;
            using (Image i = Image.FromFile(path))
            {
                using (Bitmap b = new Bitmap(i))
                {
                    string reportPart = graphObject.Create();
                    PterodactylGrasshopperBitmapGoo GH_bmp = new PterodactylGrasshopperBitmapGoo(b.Clone(new Rectangle(0, 0, b.Width, b.Height), b.PixelFormat)
                                                             , reportPart, path);
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
                            catch (Exception ex) { AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Unable to delete file at " + f + " : " + ex.Message); }
                        }
                    }
                }
            }
            base.RemovedFromDocument(document);
        }

        private PointGraph dialogImage;

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalMenuItems(menu);
            Menu_AppendItem(menu, "Show Graph", ShowChart, this.Icon, (dialogImage != null), false);
        }

        private void ShowChart(object sender, EventArgs e)
        {
            if (dialogImage != null) dialogImage.ShowDialog();
        }


        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylPointGraph;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("d476c66a-0dd5-40a6-a30c-15e69a20ab16"); }
        }
    }
}