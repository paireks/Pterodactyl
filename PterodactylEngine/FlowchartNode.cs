using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylEngine
{
    public class FlowchartNode
    {
        public FlowchartNode(string text, List<FlowchartNode> inputNodes, int shape)
        {
            Text = text;
            InputNodes = inputNodes;
            Shape = shape;

            FlowchartPart = new List<string>();

            if (InputNodes != null)
            {
                foreach (var node in InputNodes)
                {
                    for (int i = 0; i < node.FlowchartPart.Count; i++)
                    {
                        FlowchartPart.Add(node.FlowchartPart[i]);
                    }

                    FlowchartPart.Add(node.Text + " --> " + Text);
                }
            }
        }

        public List<string> FlowchartPart { get; set; }
        public string Text { get; set; }
        public List<FlowchartNode> InputNodes { get; set; }
        public int Shape { get; set; }
    }
}
