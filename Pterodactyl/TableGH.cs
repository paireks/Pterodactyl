using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class TableGH : GH_Component
    {
        public TableGH()
          : base("Table", "Table",
              "Insert table",
              "Pterodactyl", "Parts")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Table Headings", "Table Headings", "Headings inside table as text list", GH_ParamAccess.list);
            pManager.AddNumberParameter("Alignment", "Alignment", "Alignment for each column as matching integer list. 0 = left, 1 = center, 2 = right", GH_ParamAccess.list);
            pManager.AddTextParameter("Data Tree", "Data Tree", "Data as tree", GH_ParamAccess.tree);
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
                return Properties.Resources.PterodactylTable;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("a495a759-ad79-446c-9272-644766102a8b"); }
        }
    }
}