using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using PterodactylCharts;

namespace Pterodactyl
{
    public class AnnotationDataGH : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the AnnotationDataGH class.
        /// </summary>
        public AnnotationDataGH()
           : base("Point Annotation", "Point Anntotation",
               "Add point tag",
               "Pterodactyl", "Advanced Graph")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Text", "Text", "Annotation text", GH_ParamAccess.list);
            pManager.AddNumberParameter("Size", "Size", "Choose text size 6 - 48pt", GH_ParamAccess.item, 9d);

        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Data Type", "Data Type", "Set data type", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<string> tags = new List<string>();
            double size = 0;

            DA.GetDataList(0, tags);
            DA.GetData(1, ref size);

            DataType dataType = new DataType(tags.ToArray(), size);

            DA.SetData(0, dataType);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactyAnnotationData;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.quarternary; }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("f587f294-ce6a-4ffd-9256-13e7fc27c12e"); }
        }
    }
}