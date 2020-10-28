using System;
using System.Collections.Generic;
using System.IO;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;
using Markdig;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class ExportHTMLComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ExportHTMLComponent class.
        /// </summary>
        public ExportHTMLComponent()
          : base("Export HTML", "HTML",
              "Exports an HTML file with a folder containing referenced images. Assigning a local path for this component will only work when running locally (Local path will be ignored on the SHapeDiver platform).",
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
            pManager.AddTextParameter("Custom CSS", "CSS", "Use a stylesheet link or a CSS string for Custom CSS styling of the HTML page. Please ensure there are no errors in the link tag/CSS, or the output will not appear as expected. " +
                "Link Example: <link href=\"custom.css\" rel=\"stylesheet\" type=\"text/css\"> . " +
                "CSS Example: h1 { color: red; } . Do not use relative paths.", GH_ParamAccess.item);
            this.Params.Input[1].Optional = true;
            pManager.AddTextParameter("File Name", "File Name", "File Name (without extension)", GH_ParamAccess.item, "ReportHTML");
            pManager.AddParameter(new Param_FilePath(), "Folder Path", "Path", "Folder where your files will be saved. Existing files will be overwritten.", GH_ParamAccess.item);
            this.Params.Input[3].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("HTML", "HTML", "Exported HTML", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool CloudMode = true;
            try
            {
                string md = "";
                if (!DA.GetData(0, ref md)) return;
                string pathFolder = PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath();
                if (md.Contains("/replace_Pterodactyl_images/"))
                {
                    AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Do not use the phrase '/replace_Pterodactyl_images/' in the document!");
                    return;
                }
                md = md.Replace(pathFolder, "/replace_Pterodactyl_images/");
                md = md.Replace(".png)", ".png \"Embedded Image\")");
                MarkdownPipelineBuilder pipelineBuilder = new MarkdownPipelineBuilder();
                pipelineBuilder = pipelineBuilder.UseAdvancedExtensions().UseGridTables().UseFigures().UseDiagrams().UseMathematics();
                MarkdownPipeline pipeline = pipelineBuilder.Build();
                string css = "";
                if (DA.GetData(1, ref css))
                {
                    if (css.Contains("<script") || css.Contains("javascript") || css.Contains(".js"))
                    {
                        css = "";
                        AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Forbidden CSS Input");
                    }
                }
                string html = Markdown.ToHtml(md, pipeline);
                html = "<html><head><link href=\"https://cdn.rawgit.com/knsv/mermaid/6.0.0/dist/mermaid.css\" rel=\"stylesheet\" type=\"text/css\">" +
                    "<script src=\"https://polyfill.io/v3/polyfill.min.js?features=es6\"></script>" +
                    "<script id=\"MathJax-script\" async src=\"https://cdn.jsdelivr.net/npm/mathjax@3/es5/tex-mml-chtml.js\"></script>" + css + "</head>" +
                        "<body><script src=\"https://cdn.jsdelivr.net/npm/mermaid/dist/mermaid.min.js\"></script>" + html + "</body></html>";
                string htmlOriginal = html;
                if (!PterodactylInfo.IsRunningOnWindowsServer)
                {
                    GH_String fpath = new GH_String();
                    if (DA.GetData(3, ref fpath))
                    {
                        if (fpath.Value != null && fpath.Value != string.Empty)
                        {
                            if (!Directory.Exists(fpath.Value))
                            {
                                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Please Select a valid Folder location to save the files. The selected folder does not exist.");
                            }
                            else
                            {
                                CloudMode = false;
                                string fname = "";
                                if (!DA.GetData(2, ref fname)) return;
                                if (fname.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                                {
                                    AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid File Name");
                                    return;
                                }
                                foreach (string img in Directory.GetFiles(PterodactylGrasshopperBitmapGoo.GetTemporaryFolderPath()))
                                {
                                    FileInfo f1 = new FileInfo(img);
                                    if (f1.Extension == ".png")
                                    {
                                        if (!Directory.Exists(fpath.Value + "/" + fname + "_HTML/")) Directory.CreateDirectory(fpath.Value + "/" + fname + "_HTML/");
                                        f1.CopyTo(fpath.Value + "/" + fname + "_HTML/" + f1.Name, true);
                                    }
                                }
                                html = html.Replace("/replace_Pterodactyl_images/", (fname + "_HTML/"));
                                File.WriteAllText(fpath.Value + "/" + fname + ".html", html);
                            }
                        }                        
                    }
                }
                else
                {
                    AddRuntimeMessage(GH_RuntimeMessageLevel.Remark, "Running on ShapeDiver Cloud");
                }
                html = htmlOriginal.Replace("/replace_Pterodactyl_images/", pathFolder);
                DA.SetData(0, html);
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
                return Properties.Resources.exportHTML;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("985c609c-0331-4250-b7e3-fab6a3557538"); }
        }
    }
}