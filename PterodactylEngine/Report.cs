using System;
using System.Collections.Generic;
using System.Text;

namespace PterodactylEngine
{
    public class Report
    {
        private List<string> _reportParts;
        private string _title;
        private bool _tableOfContents;


        public Report(List<string> reportParts, string title, bool tableOfContents)
        {
            ReportParts = reportParts;
            TableOfContents = tableOfContents;
            Title = title;
        }

        public string Create()
        {
            StringBuilder report = new StringBuilder();

            if (Title != "")
            {
                report.AppendLine("# " + Title);
            }

            if (TableOfContents)
            {
                report.AppendLine("[TOC]");
            }

            foreach (string part in ReportParts)
            {
                report.AppendLine(part);
            }

            return report.ToString();
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
