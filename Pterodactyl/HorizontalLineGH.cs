using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylEngine;

namespace Pterodactyl
{
    public class HorizontalLineGH : GH_Component
    {
        public HorizontalLineGH()
          : base("Horizontal Line", "Horizontal Line",
              "Add horizontal line",
              "Pterodactyl", "Parts")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {

        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report (Markdown text)", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string reportPart;
            HorizontalLine reportObject = new HorizontalLine();
            reportPart = reportObject.Create();

            DA.SetData(0, reportPart);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylHorizontalLine;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("db6a6683-e51e-4a89-bb5e-3cdea64bda4e"); }
        }
    }
}