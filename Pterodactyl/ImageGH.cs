using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Grasshopper.Kernel;
using PterodactylEngine;
using ShapeDiver.Public.Grasshopper.Parameters;

namespace Pterodactyl
{
    public class ImageGH : GH_Component
    {
        public ImageGH()
          : base("Image", "Image",
              "Add image from given directory",
              "Pterodactyl", "Parts")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Title", "Title", "Image title",
                GH_ParamAccess.item, "Title");
            pManager.AddParameter(new GrasshopperBitmapParam(), "Image", "Image", "Image to use. Right-click to set an Image or Multiple Images." +
                "If you wish to add an image by path (Local use only), try using Squid (ShapeDiver version - included in the ShapeDiver installation).",
                GH_ParamAccess.item);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new PterodactylGrasshopperBitmapParam(), "Report Part", "Report Part", "Created part of the report (Markdown text with referenced Image)", GH_ParamAccess.item);
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
            GrasshopperBitmapGoo GH_b = new GrasshopperBitmapGoo();
            string path = PterodactylGrasshopperBitmapGoo.CreateTemporaryFilePath(this);

            DA.GetData(0, ref title);
            DA.GetData(1, ref GH_b);

            try { GH_b.Value.Save(path, ImageFormat.Png); }
            catch (Exception ex)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Unable to write to file at " + path + " : " + ex.Message);
                return;
            }

            PterodactylEngine.Image reportObject = new PterodactylEngine.Image(title, path);
            using (System.Drawing.Image i = System.Drawing.Image.FromFile(path))
            {
                using (Bitmap b = new Bitmap(i))
                {
                    string reportPart = reportObject.Create();
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

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylImage;
            }
        }

        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.quarternary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("e91741eb-da38-434b-941d-faa8f6ecf389"); }
        }
    }
}