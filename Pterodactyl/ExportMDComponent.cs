using System;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;
using PterodactylEngine;
using ShapeDiver.Public.Grasshopper.Parameters;
using ShapeDiver.Public.Grasshopper.Parameters.SDMLDoc;

namespace Pterodactyl
{
    public class ExportMDComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ExportMDComponent class.
        /// </summary>
        public ExportMDComponent()
          : base("Export MD", "MD",
              "Exports an MD file along with a folder containing the referenced images. Assigning a local path for this component will only work when running locally (Local path will be ignored on the SHapeDiver platform).",
              "Pterodactyl", "Report")
        {
        }
        public override bool IsBakeCapable => false;
        public override GH_Exposure Exposure => GH_Exposure.secondary;

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddParameter(new ShapeDiverMLDocParam(), "Report", "Report", "Report to export", GH_ParamAccess.item);
            pManager.AddParameter(new Param_FilePath(), "File Path", "Path", "Path where your file(s) will be saved. Existing files will be overwritten.", GH_ParamAccess.item);
            this.Params.Input[1].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new ShapeDiverMLDocParam(), "Report", "Report", "Exported report", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (DA.Iteration > 0) return;
            bool CloudMode = true;
            try
            {
                MarkdownDocument md = null;
                if (!DA.GetData(0, ref md)) return;
                if (!Utils.IsRunningOnWindowsServer)
                {
                    GH_String fpath = new GH_String();
                    if (DA.GetData(1, ref fpath))
                    {
                        if (fpath.Value != null && fpath.Value != string.Empty)
                        {
                            CloudMode = false;
                            md.WriteDocumentToFile(fpath.Value, true);
                        }
                    }
                }
                DA.SetData(0, md);
                if (CloudMode) this.Message = "Cloud Mode";
                else this.Message = string.Empty;
            }
            catch (Exception ex)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Exception Caught: " + ex.Message);
            }
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Properties.Resources.exportMD;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("cef3d8f9-96c1-43ed-a64a-3de6d38b4891"); }
        }
    }
}