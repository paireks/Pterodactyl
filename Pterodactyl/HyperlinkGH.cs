using System;
using Grasshopper.Kernel;
using PterodactylEngine;
using PterodactylEngine.MarkdownTools;

namespace Pterodactyl
{
    public class HyperlinkGH : GH_Component
    {
        public HyperlinkGH()
          : base("Hyperlink", "Hyperlink",
              "Add hyperlink",
              "Pterodactyl", "Parts")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Text", "Text", "Hyperlink text",
                  GH_ParamAccess.item, "Sample text for hyperlink");
            pManager.AddTextParameter("Link", "Link", "Destination, where hyperlink will move you after click",
                  GH_ParamAccess.item, "https://www.youtube.com/channel/UCfXkMo1rOMhKGBoNwd7JPsw/");
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string text = string.Empty;
            string link = string.Empty;

            DA.GetData(0, ref text);
            DA.GetData(1, ref link);

            string reportPart;
            Hyperlink reportObject = new Hyperlink(text, link);
            reportPart = reportObject.Create();

            DA.SetData(0, reportPart);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylHyperlink;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("28f4f7cd-060e-4a6a-b63a-88809f31c8a3"); }
        }
    }
}