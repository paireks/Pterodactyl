using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class GetTemporaryPathComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GetTemporaryPathComponent class.
        /// </summary>
        public GetTemporaryPathComponent()
          : base("Get Temp Path", "Get Path",
              "Gets the temporary file path of an image based Report part (Chart, Graph or Image). THIS COMPONENT IS NOT SUPPORTED ON THE SHAPEDIVER PLATFORM",
              "Pterodactyl", "Tools")
        {
        }
        public override bool IsBakeCapable => false;

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddParameter(new PterodactylGrasshopperBitmapParam(), "Report Part", "Report Part", "Image based Report Part", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param_FilePath(), "Temp File Path", "Temp File Path", "Temporary File Path to the Image of the Report Part", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            PterodactylGrasshopperBitmapGoo goo = null;
            if (!DA.GetData(0, ref goo)) return;
            if (!goo.IsValid)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid Report Part : " + goo.IsValidWhyNot);
                return;
            }
            DA.SetData(0, new GH_String(goo.FilePath));
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
                return Properties.Resources.temp;
            }
        }

        public override GH_Exposure Exposure => GH_Exposure.tertiary;

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("b09c74ab-d26c-46f6-85d2-b4d96f47caf6"); }
        }
    }
}