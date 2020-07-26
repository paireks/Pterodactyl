﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class FlowchartNodesGH : GH_Component
    {
        public FlowchartNodesGH()
          : base("Flowchart Nodes", "Flowchart Nodes",
              "Add node for flowchart",
              "Pterodactyl", "Tools")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Id", "Id", "Id name of the node", GH_ParamAccess.item);
            pManager.AddTextParameter("Text", "Text", "Add text inside node", GH_ParamAccess.item, "Sample text");
            pManager.AddGenericParameter("Input", "Input", "Add inputs (flowchart nodes or links) or leave empty", GH_ParamAccess.list);
            pManager.AddIntegerParameter("Shape", "Shape",
                "Set shape of the node as int. 0 - rectangle, 1 - round edges, 2 - stadium-shaped," +
                " 3 - subroutine, 4 - cylindrical, 5 - circle, 6 - asymetric, 7 - rhombus, 8 - hexagon",
                GH_ParamAccess.item, 0);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Flowchart Node", "Flowchart Node", "Node for flowchart", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.secondary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("030544d6-8a19-4793-a224-e61f7c422fdf"); }
        }
    }
}