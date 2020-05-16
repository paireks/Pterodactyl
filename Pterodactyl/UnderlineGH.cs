using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class UnderlineGH : GH_Component
    {
        public UnderlineGH()
          : base("Underline", "Underline",
              "Format text -> underline",
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
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylUnderline;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("1386bcfa-a262-429d-ab64-55b36b18ca2a"); }
        }
    }
}