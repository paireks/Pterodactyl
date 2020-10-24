using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using PterodactylEngine;

namespace Pterodactyl
{
    public class UnorderedListGH : GH_Component
    {
        public UnorderedListGH()
          : base("Unordered List", "Unordered List",
              "Add unordered list",
              "Pterodactyl", "Parts")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Items", "Items", "Different list items as text list",
                   GH_ParamAccess.list, new List<string> { "First element list",
                  "Second element list"});
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report (Markdown text)", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<string> text = new List<string>();

            DA.GetDataList(0, text);

            string report;
            UnorderedList reportObject = new UnorderedList(text);
            report = reportObject.Create();

            DA.SetData(0, report);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylUnorderedList;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.secondary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("2435071b-dcfa-4b6c-9d1b-cc621c941c15"); }
        }
    }
}