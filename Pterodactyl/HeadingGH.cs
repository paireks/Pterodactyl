using System;
using Grasshopper.Kernel;
using PterodactylEngine;

namespace Pterodactyl
{
    public class HeadingGH : GH_Component
    {
        public HeadingGH()
          : base("Heading", "Heading",
              "Creates heading",
              "Pterodactyl", "Parts")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Text", "Text", "Text for the heading",
                  GH_ParamAccess.item, "Sample text for heading");
            pManager.AddIntegerParameter("Level", "Level", "Level of the heading as integer. Should be between 1 and 6.",
                  GH_ParamAccess.item, 1);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string text = string.Empty;
            int level = 0;

            DA.GetData(0, ref text);
            DA.GetData(1, ref level);

            string reportPart;
            Heading reportObject = new Heading(text, level);
            reportPart = reportObject.Create();

            DA.SetData(0, reportPart);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylHeading;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("6d67b19c-bd15-44eb-9524-e0856ff55d1a"); }
        }
    }
}