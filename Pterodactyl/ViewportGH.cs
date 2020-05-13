using System;
using Grasshopper.Kernel;
using PterodactylRh;
using PterodactylEngine;

namespace Pterodactyl
{
    public class ViewportGH : GH_Component
    {
        public ViewportGH()
          : base("Viewport", "Viewport",
              "Capture selected Rhino viewport and insert to report as image",
              "Pterodactyl", "Parts")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Title", "Title", "Title image",
                  GH_ParamAccess.item, "Example");
            pManager.AddTextParameter("Viewport Name", "Viewport Name", "Name of the viewport",
                  GH_ParamAccess.item);
            pManager.AddTextParameter("Path", "Path", "Directory where image of your viewport will be saved. Should end up with .png",
                  GH_ParamAccess.item);
            pManager.AddBooleanParameter("Draw Axes", "Draw Axes", "Boolean, true = draw axes",
                  GH_ParamAccess.item, false);
            pManager.AddBooleanParameter("Draw Grid", "Draw Grid", "Boolean, true = draw grid",
                  GH_ParamAccess.item, false);
            pManager.AddBooleanParameter("Draw Grid Axes", "Draw Grid Axes", "Boolean, true = draw grid axes",
                  GH_ParamAccess.item, false);
            pManager.AddBooleanParameter("Transparent Background", "Transparent Background", "Boolean, true = transparent background",
                  GH_ParamAccess.item, true);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string title = string.Empty;
            string viewportName = string.Empty;
            string pathToFile = string.Empty;
            bool drawAxes = false;
            bool drawGrid = false;
            bool drawGridAxes = false;
            bool transparentBackground = true;
            DA.GetData(0, ref title);
            DA.GetData(1, ref viewportName);
            DA.GetData(2, ref pathToFile);
            DA.GetData(3, ref drawAxes);
            DA.GetData(4, ref drawGrid);
            DA.GetData(5, ref drawGridAxes);
            DA.GetData(6, ref transparentBackground);

            VieportRh reportDocument = new VieportRh();
            reportDocument.Capture(viewportName, pathToFile, drawAxes, drawGrid, drawGridAxes, transparentBackground);

            string reportPart;
            Image reportObject = new Image(title, pathToFile);
            reportPart = reportObject.Create();

            DA.SetData(0, reportPart);
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
            get { return GH_Exposure.quarternary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("8b413c79-f96e-4fad-9cd9-80f7d9989f8a"); }
        }
    }
}