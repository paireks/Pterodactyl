using System;
using Grasshopper.Kernel;
using PterodactylEngine;


namespace Pterodactyl
{
    public class SaveReportGH : GH_Component
    {
        public SaveReportGH()
          : base("Save Report", "Save Report",
              "Saves markdown file with your report data",
              "Pterodactyl", "Tools")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Report", "Report", "Report to save", GH_ParamAccess.item, "Empty");
            pManager.AddTextParameter("Path", "Path", "Path where your file will be saved, should end up with .md",
                GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string report = string.Empty;
            DA.GetData(0, ref report);

            string path = string.Empty;
            DA.GetData(1, ref path);

            SaveReport reportDocument = new SaveReport(report, path);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("2cfe90c9-bca3-4d6d-9243-d5212107066c"); }
        }
    }
}
