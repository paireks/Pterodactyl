using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylEngine;

namespace Pterodactyl
{
    public class EmphasisGH : GH_Component
    {
        public EmphasisGH()
          : base("Emphasis", "Emphasis",
              "Format text -> emphasis",
              "Pterodactyl", "Format")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Text", "Text", "Text to format",
            GH_ParamAccess.item, "roar!");
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string text = string.Empty;

            DA.GetData(0, ref text);

            string reportPart;
            Emphasis reportObject = new Emphasis(text);
            reportPart = reportObject.Create();

            DA.SetData(0, reportPart);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylEmphasis;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("92a5c76a-6b8f-40bc-846c-95b6868c924f"); }
        }
    }
}