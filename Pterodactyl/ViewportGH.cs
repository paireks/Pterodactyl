using System;
using Grasshopper.Kernel;
using PterodactylRh;

namespace Pterodactyl
{
    public class ViewportGH : GH_Component
    {
        public ViewportGH()
          : base("Viewport", "Viewport",
              "Capture selected Rhino viewport and insert to report as image",
              "Pterodactyl", "Parts")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Viewport Name", "Viewport Name", "Name of the viewport",
                  GH_ParamAccess.item);
            pManager.AddIntegerParameter("Path", "Path", "Directory where image of your viewport will be saved. Should end up with .png",
                  GH_ParamAccess.item, 1);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string viewportName = string.Empty;
            DA.GetData(0, ref viewportName);


            VieportRh reportDocument = new VieportRh();
            reportDocument.Capture(viewportName);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
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