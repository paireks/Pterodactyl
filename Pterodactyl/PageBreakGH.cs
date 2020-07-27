using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using PterodactylEngine;


namespace Pterodactyl
{
    public class PageBreakGH : GH_Component
    {
        public PageBreakGH()
            : base("Page Break", "Page Break",
                "Insert page break, so it will be visible when export to .pdf",
                "Pterodactyl", "Parts")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {

        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            DA.SetData(0, "<div style=\"page-break-after: always;\"></div>" + Environment.NewLine);
        }
        protected override Bitmap Icon
        {
            get
            {
                return null;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("ba101baf-857e-4968-a05a-94aeb1c4f97e"); }
        }
    }
}