using System;
using Grasshopper.Kernel;
using PterodactylRh;
using PterodactylEngine;

namespace Pterodactyl
{
    public class ViewportGH : GH_Component
    {
        public ViewportGH()
          : base("Viewport", "Viewport",
              "Capture selected Rhino viewport and insert to report as image. THIS COMPONENT IS NOT SUPPORTED ON THE SHAPEDIVER PLATFORM",
              "Pterodactyl", "Parts")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Title", "Title", "Title image",
                  GH_ParamAccess.item, "Example");
            pManager.AddTextParameter("Viewport Name", "Viewport Name", "Name of the viewport",
                  GH_ParamAccess.item);
            //pManager.AddTextParameter("Path", "Path", "Directory where image of your viewport will be saved. Should end up with .png",
            //      GH_ParamAccess.item);
            pManager.AddBooleanParameter("Draw Axes", "Draw Axes", "Boolean, true = draw axes",
                  GH_ParamAccess.item, false);
            pManager.AddBooleanParameter("Draw Grid", "Draw Grid", "Boolean, true = draw grid",
                  GH_ParamAccess.item, false);
            pManager.AddBooleanParameter("Draw Grid Axes", "Draw Grid Axes", "Boolean, true = draw grid axes",
                  GH_ParamAccess.item, false);
            pManager.AddBooleanParameter("Transparent Background", "Transparent Background", "Boolean, true = transparent background",
                  GH_ParamAccess.item, true);
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
            string title = string.Empty;
            string viewportName = string.Empty;
            string pathToFile = PterodactylGrasshopperBitmapGoo.CreateTemporaryFilePath(this);
            bool drawAxes = false;
            bool drawGrid = false;
            bool drawGridAxes = false;
            bool transparentBackground = true;
            DA.GetData(0, ref title);
            DA.GetData(1, ref viewportName);
            //DA.GetData(2, ref pathToFile);
            DA.GetData(2, ref drawAxes);
            DA.GetData(3, ref drawGrid);
            DA.GetData(4, ref drawGridAxes);
            DA.GetData(5, ref transparentBackground);

            VieportRh reportDocument = new VieportRh();
            reportDocument.Capture(viewportName, pathToFile, drawAxes, drawGrid, drawGridAxes, transparentBackground);

            //string reportPart;
            Image reportObject = new Image(title, pathToFile);
            //reportPart = reportObject.Create();

            //DA.SetData(0, reportPart);
            using (System.Drawing.Image i = System.Drawing.Image.FromFile(pathToFile))
            {
                using (System.Drawing.Bitmap b = new System.Drawing.Bitmap(i))
                {
                    string reportPart = reportObject.Create();
                    PterodactylGrasshopperBitmapGoo GH_bmp = new PterodactylGrasshopperBitmapGoo(b.Clone(new System.Drawing.Rectangle(0, 0, b.Width, b.Height), b.PixelFormat)
                                                             , reportPart, pathToFile);
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

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylViewport;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.quarternary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("8b413c79-f96e-4fad-9cd9-80f7d9989f8a"); }
        }
    }
}