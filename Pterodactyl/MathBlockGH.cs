using System;
using Grasshopper.Kernel;
using PterodactylEngine;

namespace Pterodactyl
{
    public class MathBlockGH : GH_Component
    {
        public MathBlockGH()
          : base("Math Block", "Math Block",
              "Creates math block",
              "Pterodactyl", "Parts")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Text", "Text", "Math text written in TeX-style",
                GH_ParamAccess.item, @"\bold{Euler's \; identity }\\ e^{i \pi} + 1 = 0");
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
            MathBlock reportObject = new MathBlock(text);
            reportPart = reportObject.Create();

            DA.SetData(0, reportPart);
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
            get { return new Guid("2a4c7686-7e6b-4421-b0f3-1210b604247c"); }
        }
    }
}