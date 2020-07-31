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

            LinkOutTextPart = " --> ";

            if (InputNodes != null)
            {
                foreach (var node in InputNodes)
                {
                    for (int i = 0; i < node.FlowchartPart.Count; i++)
                    {
                        FlowchartPart.Add(node.FlowchartPart[i]);
                    }

                    FlowchartPart.Add(node.Text + node.LinkOutTextPart + ShapeTextPart[Shape, 0] + Text + ShapeTextPart[Shape, 1]);
                }
            }
        }

        public List<string> FlowchartPart { get; set; }
        public string Text { get; set; }
        public List<FlowchartNode> InputNodes { get; set; }
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
