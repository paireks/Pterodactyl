using System;
using System.Collections.Generic;

namespace PterodactylEngine
{
    public class Hyperlink
    {
        private string _text;
        private string _link;

        public Hyperlink(string text, string link)
        {
            Text = text;
            Link = link;
        }

        public string Create()
        {
            string reportPart = "[" + Text + "](" + Link + ")";

            return reportPart;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }
    }
}

