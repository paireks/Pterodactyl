using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using PterodactylEngine;
using ShapeDiver.Public.Grasshopper.Parameters;

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
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Report Parts", "Report Parts", "Report parts (Markdown text) as list", GH_ParamAccess.list);
            pManager.AddTextParameter("Title", "Title", "Sets report's title", GH_ParamAccess.item, "");
            pManager.AddBooleanParameter("Table Of Contents", "Table Of Contents", "Creates table of contents if True", GH_ParamAccess.item, false);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new ShapeDiverMLDocParam(), "Report", "Report", "Created report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<object> reportParts = new List<object>();
            string title = string.Empty;
            bool tableOfContents = false;

            DA.GetDataList(0, reportParts);
            DA.GetData(1, ref title);
            DA.GetData(2, ref tableOfContents);

            CreateReport reportObject = new CreateReport(reportParts, title, tableOfContents);
            MarkdownDocument report = reportObject.Create();

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