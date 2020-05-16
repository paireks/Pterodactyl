using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylEngine;

namespace Pterodactyl
{
    public class OrderedListGH : GH_Component
    {
        public OrderedListGH()
          : base("Ordered List", "Ordered List",
              "Add ordered list",
              "Pterodactyl", "Parts")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Items", "Items", "Different list items as text list",
                  GH_ParamAccess.list, new List<string> { "First element list",
                  "Second element list"});
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<string> text = new List<string>();

            DA.GetDataList(0, text);

            string report;
            OrderedList reportObject = new OrderedList(text);
            report = reportObject.Create();

            DA.SetData(0, report);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylOrderedList;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.secondary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("16078687-ab1b-4e4e-a71e-1877c40ce5f7"); }
        }
    }
}