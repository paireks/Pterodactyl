using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylEngine;
using PterodactylEngine.MarkdownTools;

namespace Pterodactyl
{
    public class StrikeGH : GH_Component
    {
        public StrikeGH()
          : base("Strike", "Strike",
              "Format text -> strike",
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
            Strike reportObject = new Strike(text);
            reportPart = reportObject.Create();

            DA.SetData(0, reportPart);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylStrike;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("0e037e2b-b035-4a34-97e5-7c3b95a40dbb"); }
        }
    }
}