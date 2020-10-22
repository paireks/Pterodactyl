using System;
using System.Collections.Generic;
using System.IO;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

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
            pManager.AddTextParameter("Report", "Report", "Report to export", GH_ParamAccess.item);
            pManager.AddTextParameter("File Name", "File Name", "File Name (without extension)", GH_ParamAccess.item, "ReportMarkdown");
            pManager.AddParameter(new Param_FilePath(), "Folder Path", "Path", "Folder where your files will be saved. Existing files will be overwritten.", GH_ParamAccess.item);
            this.Params.Input[2].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report", "Report", "Exported report", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            try
            {
                string md = "";
                if (!DA.GetData(0, ref md)) return;
                string mdOriginal = md;
                if (!PterodactylInfo.IsRunningOnWindowsServer)
                {
                    string fname = "";
                    if (!DA.GetData(1, ref fname)) return;
                    if (fname.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                    {
                        AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid File Name");
                        return;
                    }
                    GH_String fpath = new GH_String();
                    if (DA.GetData(2, ref fpath))
                    {
                        if (!Directory.Exists(fpath.Value))
                        {
                            if (Directory.Exists((new FileInfo(fpath.Value)).Directory.FullName)) fpath.Value = (new FileInfo(fpath.Value)).Directory.FullName;
                            else
                            {
                                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Please Select a valid Folder location to save the files. The selected folder does not exist.");
                                return;
                            }
                        }
                        foreach (string img in Directory.GetFiles(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()))
                        {
                            FileInfo f1 = new FileInfo(img);
                            if (f1.Extension == ".png")
                            {
                                if (!Directory.Exists(fpath.Value + "/" + fname + "_MD/")) Directory.CreateDirectory(fpath.Value + "/" + fname + "_MD/");
                                f1.CopyTo(fpath.Value + "/" + fname + "_MD/" + f1.Name, true);
                            }
                        }
                    }
                    md = md.Replace(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath(), (fname + "_MD/"));
                    File.WriteAllText(fpath.Value + "/" + fname + ".md", md);
                }
                else AddRuntimeMessage(GH_RuntimeMessageLevel.Remark, "Running on ShapeDiver Cloud");
                DA.SetData(0, mdOriginal);
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