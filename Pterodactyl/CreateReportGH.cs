using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using PterodactylEngine;

namespace Pterodactyl
{
    public class CreateReportGH : GH_Component
    {
        public CreateReportGH()
          : base("Create Report", "Create Report",
              "Creates report",
              "Pterodactyl", "Report")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Report Parts", "Report Parts", "Report parts as list", GH_ParamAccess.list, "Empty");
            pManager.AddTextParameter("Title", "Title", "Sets report's title", GH_ParamAccess.item, "");
            pManager.AddBooleanParameter("Table Of Contents", "Table Of Contents", "Creates table of contents if True", GH_ParamAccess.item, false);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report", "Report", "Created report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<string> reportParts = new List<string>();
            string title = string.Empty;
            bool tableOfContents = false;

            DA.GetDataList(0, reportParts);
            DA.GetData(1, ref title);
            DA.GetData(2, ref tableOfContents);

            string report;
            CreateReport reportObject = new CreateReport(reportParts, title, tableOfContents);
            report = reportObject.Create();

            DA.SetData(0, report);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylCreateReport;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("61d2c8be-586d-4d92-9dcf-5f54bf1a7e3a"); }
        }
    }
}