using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylEngine
{
    public class Flowchart
    {
        public Flowchart(bool direction, List<FlowchartNode> lastNodes)
        {
            Direction = direction;
            LastNodes = lastNodes;
        }

        public string Create()
        {
            StringBuilder reportPart = new StringBuilder();

            reportPart.AppendFormat("```mermaid" + Environment.NewLine);

            reportPart.AppendFormat(Direction ? "graph LR" : "graph TD");

            reportPart.AppendFormat(Environment.NewLine);

            List<string> rewrittenFlowchartReportParts = new List<string>();

            foreach (var node in LastNodes)
            {
                foreach (var flowchartReportPart in node.FlowchartReportsPart)
                {
                    if (!rewrittenFlowchartReportParts.Contains(flowchartReportPart))
                    {
                        reportPart.AppendFormat(flowchartReportPart + Environment.NewLine);
                        rewrittenFlowchartReportParts.Add(flowchartReportPart);
                    }
                }
            }

            reportPart.AppendFormat("```");

            return reportPart.ToString();
        }

        public bool Direction { get; set; }
        public List<FlowchartNode> LastNodes { get; set; }
    }
}
