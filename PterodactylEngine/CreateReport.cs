using ShapeDiver.Public.Grasshopper.Parameters.SDMLDoc;
using System;
using System.Collections.Generic;

namespace PterodactylEngine
{
    public class CreateReport
    {
        private List<object> _reportParts;
        private string _title;
        private bool _tableOfContents;


        public CreateReport(List<object> reportParts, string title, bool tableOfContents)
        {
            List<object> rParts = new List<object>();
            foreach (object part in reportParts)
            {
                if (part is Grasshopper.Kernel.Types.GH_String)
                {
                    rParts.Add((part as Grasshopper.Kernel.Types.GH_String).Value);
                }
                else if (part is PterodactylGrasshopperBitmapGoo)
                {
                    rParts.Add(part as PterodactylGrasshopperBitmapGoo);
                }
                else throw new InvalidCastException("Report Parts must be either text parts or image assets");
            }
            ReportParts = rParts;
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

            foreach (object part in ReportParts)
            {
                if (part is string)
                {
                    report += (part as string) + Environment.NewLine;
                }
                else if (part is PterodactylGrasshopperBitmapGoo)
                {
                    markdown.AddAsset(part as PterodactylGrasshopperBitmapGoo);
                    report += (part as PterodactylGrasshopperBitmapGoo).ReportPart + Environment.NewLine;
                }
                else throw new InvalidCastException("Invalid Report Part Object");
            }
            markdown.Markup = report;

            return markdown;
        }

        public List<object> ReportParts
        {
            get { return _reportParts; }
            set { _reportParts = value; }
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
