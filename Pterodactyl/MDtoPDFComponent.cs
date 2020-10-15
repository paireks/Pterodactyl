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
using System.Windows.Forms;

namespace Pterodactyl
{
    public class MDtoPDFComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MDtoPDFComponent class.
        /// </summary>
        public MDtoPDFComponent()
          : base("Publish Report", "Publish",
              "Converts Markdown to PDF and HTML. Creates .html and .pdf files for publishing. Right-Click to save the created files to a location.",
              "Pterodactyl", "Report")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Report", "Report", "Markdown text", GH_ParamAccess.item);
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
            path = PterodactylGrasshopperBitmapGoo.CreateTemporaryFilePath(this, "pdf");
            pathHTML = PterodactylGrasshopperBitmapGoo.CreateTemporaryFilePath(this, "html");
            pathMD = PterodactylGrasshopperBitmapGoo.CreateTemporaryFilePath(this, "md");
            if (!DA.GetData(0, ref md)) return;
            try
            {
                //Create PDF
                MarkdownDocument mdDoc = Markdown.Parse(md);
                html = Markdown.WriteHtml(mdDoc);
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

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            Menu_AppendItem(menu, "Set Save Location...", SetSaveLocation, null, true, false);
            Menu_AppendItem(menu, "Save Files", SaveFiles, null, true, false);
            base.AppendAdditionalMenuItems(menu);
        }

        private void SaveFiles(object sender, EventArgs e)
        {
            try
            {
                if ((SaveLocation == null) || (!Directory.Exists(SaveLocation)))
                {
                    SetSaveLocation(sender, e);
                }
                if (!Directory.Exists(SaveLocation)) Directory.CreateDirectory(SaveLocation);
                if (md != string.Empty && html != string.Empty && File.Exists(path))
                {
                    //FileInfo f = new FileInfo(pathMD);
                    //System.IO.StreamWriter s1 = System.IO.File.CreateText(SaveLocation + "/" + f.Name);
                    //s1.Write(md);
                    //s1.Close();
                    FileInfo f = new FileInfo(pathHTML);
                    System.IO.StreamWriter s = System.IO.File.CreateText(SaveLocation + "/" + f.Name);
                    s.Write(html);
                    s.Close();
                    f = new FileInfo(path);
                    f.CopyTo(SaveLocation + "/" + f.Name, true);
                }
            }
            catch (Exception ex)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Unable to save files at " + SaveLocation + " : " + ex.Message);
                return;
            }
        }

        public string SaveLocation;
        string path;
        string pathHTML;
        string pathMD;
        string md = string.Empty;
        string html = string.Empty;

        private void SetSaveLocation(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.Description = "Select a folder to save the created files";
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            if ((SaveLocation != null) && (Directory.Exists(SaveLocation)))
            {
                folderBrowserDialog.SelectedPath = SaveLocation;
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                SaveLocation = folderBrowserDialog.SelectedPath;
            }
        }

        public override bool Write(GH_IO.Serialization.GH_IWriter writer)
        {
            // First add our own field.
            writer.SetString("SaveLocation", SaveLocation);
            // Then call the base class implementation.
            return base.Write(writer);
        }
        public override bool Read(GH_IO.Serialization.GH_IReader reader)
        {
            // First read our own field.
            SaveLocation = reader.GetString("SaveLocation");
            // Then call the base class implementation.
            return base.Read(reader);
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
            get { return new Guid("ffc2a368-9eb7-4a2f-b1e6-b9dec350ec71"); }
        }
    }
}