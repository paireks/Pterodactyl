using System;
using Grasshopper.Kernel;
using PterodactylEngine;

namespace Pterodactyl
{
    public class QuoteGH : GH_Component
    {
        public QuoteGH()
          : base("Quote", "Quote",
              "Add quote",
              "Pterodactyl", "Parts")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Text", "Text", "Quote text", GH_ParamAccess.item,
                "\"Look at you, you look so superficial, you probably judge things by their physical appearance.\""
                 + " - Xavier Renegade Angel");
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report (Markdown text)", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string text = string.Empty;

            DA.GetData(0, ref text);

            string reportPart;
            Quote reportObject = new Quote(text);
            reportPart = reportObject.Create();

            DA.SetData(0, reportPart);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylQuote;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("f5b094d0-d5f2-4f06-8f5d-bae1b39c78c7"); }
        }
    }
}