using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using ShapeDiver.Public.Grasshopper.Parameters;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using FSharp.Markdown;
using System.IO;
using OpenHtmlToPdf;

namespace Pterodactyl
{
    public class MDtoPDFComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MDtoPDFComponent class.
        /// </summary>
        public MDtoPDFComponent()
          : base("MD to PDF", "MD2PDF",
              "Convert Markdown to PDF",
              "Pterodactyl", "Utilities")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Markdown", "MD", "Markdown text", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new GrasshopperPdfDocumentParam(), "PDF", "PDF", "Converted PDF", GH_ParamAccess.item);
            pManager.AddTextParameter("HTML", "HTML", "HTML text", GH_ParamAccess.item);
        }

        protected override void BeforeSolveInstance()
        {
            base.BeforeSolveInstance();
            if (!System.IO.Directory.Exists(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath()))
            {
                System.IO.Directory.CreateDirectory(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath());
            }
            else
            {
                if (System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath()).Length > 0)
                {
                    foreach (string f in System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath()))
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
            string md = string.Empty;
            string path = PterodactylGrasshopperBitmapGoo.CreateTemporaryFilePath(this, "pdf");
            string pathHTML = PterodactylGrasshopperBitmapGoo.CreateTemporaryFilePath(this, "html");
            if (!DA.GetData(0, ref md)) return;
            try
            {
                //Create PDF
                MarkdownDocument mdDoc = Markdown.Parse(md);
                string html = Markdown.WriteHtml(mdDoc);
                System.IO.StreamWriter s = System.IO.File.CreateText(pathHTML);
                s.Write(html);
                s.Close();
                DA.SetData(1, html);
                using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    byte[] pdf_content = Pdf.From(html).OfSize(PaperSize.A4).Portrait().Content();
                    file.Write(pdf_content, 0, pdf_content.Length);
                    file.Close();
                }
            }
            catch (Exception ex2)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Unable to write pdf file at " + path + " : " + ex2.Message);
                return;
            }
            if (System.IO.File.Exists(path))
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

        public override void RemovedFromDocument(GH_Document document)
        {
            if (!System.IO.Directory.Exists(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath()))
            {
                System.IO.Directory.CreateDirectory(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath());
            }
            else
            {
                if (System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath()).Length > 0)
                {
                    foreach (string f in System.IO.Directory.GetFiles(PterodactylGrasshopperBitmapGoo.CreateTemporaryFolderPath()))
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
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("ffc2a368-9eb7-4a2f-b1e6-b9dec350ec71"); }
        }
    }
}