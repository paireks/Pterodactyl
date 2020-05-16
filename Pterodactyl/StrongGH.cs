using System;
using System.Collections.Generic;

using Grasshopper.Kernel;


namespace Pterodactyl
{
    public class StrongGH : GH_Component
    {
        public StrongGH()
          : base("Strong", "Strong",
              "Format text -> strong",
              "Pterodactyl", "Format")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Text", "Text", "Text to format",
            GH_ParamAccess.item, "rrr!");
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylStrong;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("ba101baf-857e-4968-a05a-94aeb1c4f97d"); }
        }
    }
}