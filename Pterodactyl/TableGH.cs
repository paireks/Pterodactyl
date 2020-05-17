using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylEngine;

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
            pManager.AddIntegerParameter("Alignment", "Alignment", "Alignment for each column as matching integer list. 0 = left, 1 = center, 2 = right", GH_ParamAccess.list);
            pManager.AddTextParameter("Data Tree", "Data Tree", "Data as tree. Each branch is treated as one column." +
                " Inside each branch should be a list of text elements, elements represent rows inside that column.", GH_ParamAccess.tree);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.list);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<string> headings = new List<string>();
            List<int> alignment = new List<int>();
            Grasshopper.Kernel.Data.GH_Structure<Grasshopper.Kernel.Types.GH_String> dataTree = new Grasshopper.Kernel.Data.GH_Structure<Grasshopper.Kernel.Types.GH_String>();
            
            DA.GetDataList(0, headings);
            DA.GetDataList(1, alignment);
            DA.GetDataTree("Data Tree", out dataTree);

            int currentColumnHeight = 1;

            for (int i = 0; i < dataTree.Branches.Count; i++) //for each column check for highest
            {
                if (dataTree.get_Branch(i).Count > currentColumnHeight)
                {
                    currentColumnHeight = dataTree.get_Branch(i).Count;
                }
            }

            string[,] dataTreeArray = new string[dataTree.Branches.Count, currentColumnHeight];

            for (int i = 0; i < dataTree.Branches.Count; i++) //for each column
            {
                for (int j = 0; j < dataTree.get_Branch(i).Count; j++)
                {
                    dataTreeArray[i, j] = dataTree.get_Branch(i)[j].ToString();
                }
            }
            

            List<string> report;
            Table reportObject = new Table(headings, alignment, dataTreeArray);
            report = reportObject.Create();

            DA.SetDataList(0, report);


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