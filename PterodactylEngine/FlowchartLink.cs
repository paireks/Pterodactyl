using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylEngine
{
    public class FlowchartLink
    {
        public FlowchartLink(int linkType, string text)
        {
            LinkType = linkType;
            Text = text;

            if (LinkType < 0 || LinkType > 3)
            {
                throw new ArgumentException("Link type can be only between 0 and 3");
            }
        }

        public FlowchartNode ReturnModifiedNode(FlowchartNode node)
        {
            if (String.IsNullOrEmpty(Text))
            {
                node.LinkOutTextPart = LinkTextPart[LinkType, 1];
            }
            else
            {
                node.LinkOutTextPart = LinkTextPart[LinkType, 0] + Text + LinkTextPart[LinkType, 1];
            }

            return node;
        }

        public string Text { get; set; }
        public int LinkType { get; set; }

        private string[,] LinkTextPart
        {
            get
            {
                string[,] linkTextPart = new string[4, 2];

                // Normal
                linkTextPart[0, 0] = " -- ";
                linkTextPart[0, 1] = " --> ";

                // Open
                linkTextPart[1, 0] = " -- ";
                linkTextPart[1, 1] = " --- ";

                // Dotted
                linkTextPart[2, 0] = " -. ";
                linkTextPart[2, 1] = " .-> ";

                // Thick
                linkTextPart[3, 0] = " == ";
                linkTextPart[3, 1] = " ==> ";


                return linkTextPart;
            }
        }
    }
}
