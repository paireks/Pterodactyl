using ShapeDiver.Public.Grasshopper.Parameters.SDMLDoc;
using System;
using System.Collections.Generic;

namespace PterodactylEngine
{
    public class CreateReport
    {
        private List<string> _reportParts;
        private List<PterodactylGrasshopperBitmapGoo> _assets;
        private string _title;
        private bool _tableOfContents;


        public CreateReport(List<object> reportParts, string title, bool tableOfContents)
        {
            List<string> textParts = new List<string>();
            List<PterodactylGrasshopperBitmapGoo> assetParts = new List<PterodactylGrasshopperBitmapGoo>();
            foreach (object part in reportParts)
            {
                if (part is Grasshopper.Kernel.Types.GH_String)
                {
                    textParts.Add((part as Grasshopper.Kernel.Types.GH_String).Value);
                }
                else if (part is PterodactylGrasshopperBitmapGoo)
                {
                    assetParts.Add(part as PterodactylGrasshopperBitmapGoo);
                }
                else throw new InvalidCastException("Report Parts must be either text parts or image assets");
            }
            ReportParts = textParts;
            Assets = assetParts;
            TableOfContents = tableOfContents;
            Title = title;
        }

        public MarkdownDocument Create()
        {
            MarkdownDocument markdown = new MarkdownDocument();
            string report = "";

                if (Title != "")
            {
                report += "# " + Title + Environment.NewLine;
            }

            if (TableOfContents)
            {
                report += "[TOC]" + Environment.NewLine;
            }

            foreach (string part in ReportParts)
            {
                report += part + Environment.NewLine;
            }

            foreach (PterodactylGrasshopperBitmapGoo asset in Assets)
            {
                markdown.AddAsset(asset);
                report += asset.ReportPart + Environment.NewLine;
            }
            markdown.Markup = report;

            return markdown;
        }

        public List<string> ReportParts
        {
            get { return _reportParts; }
            set { _reportParts = value; }
        }

        public List<PterodactylGrasshopperBitmapGoo> Assets
        {
            get { return _assets; }
            set { _assets = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public bool TableOfContents
        {
            get { return _tableOfContents; }
            set { _tableOfContents = value; }
        }
    }
}
