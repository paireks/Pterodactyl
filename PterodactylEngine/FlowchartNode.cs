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
        private string _text;
        public FlowchartNode(string text, List<FlowchartNode> inputNodes, int shape)
        {
            Text = text;
            InputNodes = inputNodes;
            Shape = shape;

            FlowchartReportsPart = new List<string>();

            LinkOutTextPart = " --> ";
            NodeOutTextPart = ShapeTextPart[Shape, 0] + Text + ShapeTextPart[Shape, 1];

            if (InputNodes == null) return;
            foreach (var inputNode in InputNodes)
            {
                for (int i = 0; i < inputNode.FlowchartReportsPart.Count; i++)
                {
                    if (!FlowchartReportsPart.Contains(inputNode.FlowchartReportsPart[i]))
                    {
                        FlowchartReportsPart.Add(inputNode.FlowchartReportsPart[i]);
                    }
                }

                string newFlowchartReportPart = inputNode.NodeOutTextPart + inputNode.LinkOutTextPart + NodeOutTextPart;

                if (!FlowchartReportsPart.Contains(newFlowchartReportPart))
                {
                    FlowchartReportsPart.Add(newFlowchartReportPart);
                }
            }
        }

        public FlowchartNode(string text, int shape)
        {
            Text = text;
            Shape = shape;

            FlowchartReportsPart = new List<string>();

            LinkOutTextPart = " --> ";
            NodeOutTextPart = ShapeTextPart[Shape, 0] + Text + ShapeTextPart[Shape, 1];
        }

        public override string ToString()
        {
            return "Flowchart Node: " + Text;
        }

        public List<string> FlowchartReportsPart { get; set; }

        public string Text
        {
            get { return _text; }
            set { _text = value.Replace(" ", "_"); }
        }
        public List<FlowchartNode> InputNodes { get; set; }
        public string NodeOutTextPart { get; }
        public string LinkOutTextPart { get; set; }
        public int Shape { get; set; }
        private string[,] ShapeTextPart
        {
            get
            {
                string[,] shapeTextPart = new string[9, 2];

                // Rectangle
                shapeTextPart[0, 0] = "";
                shapeTextPart[0, 1] = "";

                // Round edges
                shapeTextPart[1, 0] = "(";
                shapeTextPart[1, 1] = ")";

                //Stadium shaped
                shapeTextPart[2, 0] = "([";
                shapeTextPart[2, 1] = "])";

                //Subroutine
                shapeTextPart[3, 0] = "[[";
                shapeTextPart[3, 1] = "]]";

                //Database
                shapeTextPart[4, 0] = "[(";
                shapeTextPart[4, 1] = ")]";

                //Circle
                shapeTextPart[5, 0] = "((";
                shapeTextPart[5, 1] = "))";

                //Asymetric
                shapeTextPart[6, 0] = ">";
                shapeTextPart[6, 1] = "]";

                //Rhombus
                shapeTextPart[7, 0] = "{";
                shapeTextPart[7, 1] = "}";

                //Hexagon
                shapeTextPart[8, 0] = "{{";
                shapeTextPart[8, 1] = "}}";

                return shapeTextPart;
            }
        }
    }
}
