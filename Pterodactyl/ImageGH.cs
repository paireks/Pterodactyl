using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylEngine;

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
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Title", "Title", "Image title",
                GH_ParamAccess.item, "Title");
            pManager.AddTextParameter("Path", "Path", "Local path to image",
                GH_ParamAccess.item);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string title = "";
            string path = "";

            DA.GetData(0, ref title);
            DA.GetData(1, ref path);

            string reportPart;
            Image reportObject = new Image(title, path);
            reportPart = reportObject.Create();

            DA.SetData(0, reportPart);

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