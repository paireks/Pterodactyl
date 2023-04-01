using System.Collections.Generic;
using System.Text;

namespace PterodactylEngine
{
    public class Report
    {
        public Report(List<string> reportParts, string title, bool tableOfContents, bool autoSpacing)
        {
            ReportParts = reportParts;
            TableOfContents = tableOfContents;
            Title = title;
            AutoSpacing = autoSpacing;
        }

        public string Create()
        {
            StringBuilder report = new StringBuilder();

            if (AutoSpacing)
            {
                if (Title != "")
                {
                    report.AppendLine("# " + Title);
                    report.AppendLine();
                }

                if (TableOfContents)
                {
                    report.AppendLine("[TOC]");
                    report.AppendLine();
                }

                foreach (string part in ReportParts)
                {
                    report.AppendLine(part);
                    report.AppendLine();
                }
            }
            else
            {
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
            }
            
            return report.ToString();
        }

        public List<string> ReportParts { get; set; }

        public string Title { get; set; }

        public bool TableOfContents { get; set; }

        public bool AutoSpacing { get; set; }
    }
}
