using System;
using System.Collections.Generic;

namespace PterodactylEngine
{
    public class CreateReport
    {
        private List<string> _reportParts;
        private string _title;
        private bool _tableOfContents;


        public CreateReport(List<string> reportParts, string title, bool tableOfContents)
        {
            ReportParts = reportParts;
            TableOfContents = tableOfContents;
            Title = title;
        }

        public string Create()
        {
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

            return report;
        }

        public List<string> ReportParts
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
