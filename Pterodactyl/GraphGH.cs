using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Grasshopper.Kernel;
using PterodactylCharts;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class GraphGH : GH_Component
    {
        public GraphGH()
          : base("Graph", "Graph",
              "Create graph, if you want to generate Report Part - set Path",
              "Pterodactyl", "Advanced Graph")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Elements", "Graph Elements", "Add graph elements", GH_ParamAccess.item);
            pManager.AddGenericParameter("Graph Settings", "Graph Settings", "Add graph settings", GH_ParamAccess.item);
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
            GraphElements graphElements = null;
            GraphSettings graphSettings = null;
            string path = PterodactylGrasshopperBitmapGoo.CreateTemporaryFilePath(this);

            DA.GetData(0, ref graphElements);
            DA.GetData(1, ref graphSettings);

            Graph graphObject = new Graph();
            graphObject.GraphData(true, graphElements, graphSettings, path);

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

        private Graph dialogImage;

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
                return Properties.Resources.PterodactylGraph;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("32ea2490-6ab7-4090-9de2-e2414d0932c0"); }
        }
    }
}