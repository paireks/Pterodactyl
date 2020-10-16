using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylEngine;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class FlowchartLinkGH : GH_Component
    {
        public FlowchartLinkGH()
          : base("Flowchart Link", "Flowchart Link",
              "Add flowchart link between two nodes",
              "Pterodactyl", "Tools")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("Type", "Type", "Type as integer. 0 - normal, 1 - open, 2 - dotted, 3 - thick" , GH_ParamAccess.item, 0);
            pManager.AddGenericParameter("Node", "Node", "First node for link", GH_ParamAccess.item);
            pManager.AddTextParameter("Text", "Text", "Additional text that will be displayed on a link (optional)",
                GH_ParamAccess.item, "");
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Link", "Link",
                "Flowchart link, connect it with another node", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            int type = 0;
            FlowchartNode node = null;
            string text = string.Empty;

            DA.GetData(0, ref type);
            DA.GetData(1, ref node);
            DA.GetData(2, ref text);

            FlowchartLink link = new FlowchartLink(type, text);
            FlowchartNode nodeWithModifiedLink = link.ReturnModifiedNode(node);

            DA.SetData(0, nodeWithModifiedLink);

        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylFlowchartLink;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.secondary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("3de8e971-9c2e-4a73-bc1d-56ebfc0732ac"); }
        }
    }
}