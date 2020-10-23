using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;
using OpenHtmlToPdf;
using PdfSharp.Pdf.IO;
using Rhino.Geometry;
using ShapeDiver.Public.Grasshopper.Parameters;

namespace Pterodactyl
{
    public class ExportPDFComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ExportPDFComponent class.
        /// </summary>
        public ExportPDFComponent()
          : base("Export PDF", "PDF",
              "Exports a PDF of the Report by printing the exported HTML to a PDF. Assigning a local path for this component will only work when running locally (Local path will be ignored on the SHapeDiver platform).",
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
            pManager.AddTextParameter("HTML", "HTML", "Exported HTML from the 'Export HTML' Component", GH_ParamAccess.item);
            pManager.AddTextParameter("Page Size", "PageSize", "Page Size for the exported PDF", GH_ParamAccess.item, "A4");
            pManager.AddTextParameter("File Name", "File Name", "File Name (without extension)", GH_ParamAccess.item, "ReportPDF");
            pManager.AddParameter(new Param_FilePath(), "Folder Path", "Path", "Folder where your files will be saved. Existing files will be overwritten.", GH_ParamAccess.item);
            this.Params.Input[3].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new GrasshopperPdfDocumentParam(), "PDF", "PDF", "Converted PDF", GH_ParamAccess.item);
        }

        protected override void BeforeSolveInstance()
        {
            base.BeforeSolveInstance();
            if (!System.IO.Directory.Exists(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()))
            {
                System.IO.Directory.CreateDirectory(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath());
            }
            else
            {
                if (System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()).Length > 0)
                {
                    foreach (string f in System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()))
                    {
                        if (f.Contains(this.InstanceGuid.ToString()))
                        {
                            try { System.IO.File.Delete(f); }
                            catch (Exception ex) { AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Unable to delete file at " + f + " : " + ex.Message); }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            try
            {
                string html = "";
                if (!DA.GetData(0, ref html)) return;
                string psize = "A4";
                if (!DA.GetData(1, ref psize)) return;
                PropertyInfo[] propertyInfos = typeof(PaperSize).GetProperties(BindingFlags.Public | BindingFlags.Static);
                List<string> sizes = new List<string>();
                foreach (PropertyInfo p in propertyInfos)
                {
                    sizes.Add(p.Name);
                }
                if (!sizes.Contains(psize))
                {
                    AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Page Size is not valid. Try \"A4\" or \"Letter\"");
                    return;
                }
                PaperSize paperSize = (PaperSize)(typeof(PaperSize).GetProperty(psize).GetValue(null));
                if (paperSize != null)
                {
                    string path = PterodactylGrasshopperBitmapGoo.CreateTemporaryFilePath(this, "pdf");
                    using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        byte[] pdf_content = Pdf.From(html)
                            .OfSize(paperSize)
                            .WithObjectSetting("web.enableJavascript", "true")
                            .WithObjectSetting("load.jsdelay", "500")
                            .Portrait()
                            .Content();
                        file.Write(pdf_content, 0, pdf_content.Length);
                        file.Close();
                    }
                    if (!PterodactylInfo.IsRunningOnWindowsServer)
                    {
                        GH_String fpath = new GH_String();
                        if (DA.GetData(3, ref fpath))
                        {
                            try
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
                                string fname = "";
                                if (!DA.GetData(2, ref fname)) return;
                                if (fname.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                                {
                                    AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid File Name");
                                    return;
                                }
                                FileInfo f = new FileInfo(path);
                                f.CopyTo(fpath.Value + "/" + fname + ".pdf", true);
                            }
                            catch (Exception ex)
                            {
                                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Export Failed: " + ex.Message);
                            }
                        }
                    }
                    if (File.Exists(path))
                    {
                        GrasshopperPdfDocumentGoo GH_pdf = new GrasshopperPdfDocumentGoo(PdfReader.Open(path, PdfDocumentOpenMode.Import));
                        DA.SetData(0, GH_pdf);
                    }
                    else
                    {
                        AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Unable to read pdf file at " + path + " : File does not exist");
                        return;
                    }
                }
                else
                {
                    AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Page Size is not valid. Try \"A4\" or \"Letter\"");
                    return;
                }
            }
            catch (Exception ex)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Exception Caught: " + ex.Message);
            }            
        }

        public override void RemovedFromDocument(GH_Document document)
        {
            if (!System.IO.Directory.Exists(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()))
            {
                System.IO.Directory.CreateDirectory(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath());
            }
            else
            {
                if (System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()).Length > 0)
                {
                    foreach (string f in System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()))
                    {
                        if (f.Contains(this.InstanceGuid.ToString()))
                        {
                            try { System.IO.File.Delete(f); }
                            catch (Exception ex) { AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Unable to delete file at " + f + " : " + ex.Message); }
                        }
                    }
                }
            }
            base.RemovedFromDocument(document);
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
                return Properties.Resources.export;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("9fd0dd97-674c-442c-bbf6-45848306dc5a"); }
        }
    }
}