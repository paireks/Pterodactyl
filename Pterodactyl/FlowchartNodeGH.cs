using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylEngine;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class FlowchartNodeGH : GH_Component
    {
        public FlowchartNodeGH()
          : base("Flowchart Node", "Flowchart Node",
              "Add node for flowchart",
              "Pterodactyl", "Tools")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Text", "Text", "Add text inside node", GH_ParamAccess.item, "Sample text");
            pManager.AddGenericParameter("Node/Link", "Node/Link", "Add inputs (flowchart nodes or links) or leave empty",
                GH_ParamAccess.list);
            pManager.AddIntegerParameter("Shape", "Shape",
                "Set shape of the node as int. 0 - rectangle, 1 - round edges, 2 - stadium-shaped," +
                " 3 - subroutine, 4 - cylindrical, 5 - circle, 6 - asymetric, 7 - rhombus, 8 - hexagon",
                GH_ParamAccess.item, 0);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Node", "Node", "Node for flowchart", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string text = string.Empty;
            List<FlowchartNode> nodes = new List<FlowchartNode>();
            int shape = 0;

            DA.GetData(0, ref text);
            DA.GetDataList(1, nodes);
            DA.GetData(2, ref shape);

            FlowchartNode nodeOut = new FlowchartNode(text, nodes, shape);

            DA.SetData(0, nodeOut);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylFlowchartNode;
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