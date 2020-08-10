using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylEngine;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class CodeBlockGH : GH_Component
    {
        public CodeBlockGH()
          : base("Code Block", "Code Block",
              "Creates code block",
              "Pterodactyl", "Parts")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Programming Language", "Programming Language",
                "Programming language that was used in code", GH_ParamAccess.item, "python");
            pManager.AddTextParameter("Code", "Code", "Code as text", GH_ParamAccess.item, "print(\"Hello, is it me you're looking for?\")");
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string programmingLanguage = string.Empty;
            string code = string.Empty;

            DA.GetData(0, ref programmingLanguage);
            DA.GetData(1, ref code);

            string reportPart;
            CodeBlock reportObject = new CodeBlock(programmingLanguage, code);
            reportPart = reportObject.Create();

            DA.SetData(0, reportPart);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylCodeBlock;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.tertiary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("05443fa7-a7ec-4471-be39-44fa62faf893"); }
        }
    }
}