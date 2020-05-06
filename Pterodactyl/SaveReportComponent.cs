using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;


namespace Pterodactyl
{
    public class SaveReportComponent : GH_Component
    {
        public SaveReportComponent()
          : base("Save Report", "Save Report",
              "Saves markdown file with your report data",
              "Pterodactyl", "Tools")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Report", "Report", "Report to save", GH_ParamAccess.item, "Empty");
            pManager.AddTextParameter("Path", "Path", "Path where your file will be saved, should end up with .md",
                GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string path = string.Empty;
            DA.GetData(1, ref path);



            string[] lines = { "# First line", "Second line", "Third line" };
            System.IO.File.WriteAllLines(path, lines);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("2cfe90c9-bca3-4d6d-9243-d5212107066c"); }
        }
    }
}
