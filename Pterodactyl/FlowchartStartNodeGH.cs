using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylEngine;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class FlowchartStartNodeGH : GH_Component
    {
        public FlowchartStartNodeGH()
          : base("Flowchart Start Node", "Flowchart Start Node",
              "Add starting node for flowchart",
              "Pterodactyl", "Tools")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Text", "Text", "Add text inside node", GH_ParamAccess.item, "Text");
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
            string text = String.Empty;
            int shape = 0;

            DA.GetData(0, ref text);
            DA.GetData(1, ref shape);

            FlowchartNode nodeOut = new FlowchartNode(text, shape);

            DA.SetData(0, nodeOut);
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
            get { return new Guid("a62feed3-27e8-4f49-b309-160e99384796"); }
        }
    }
}