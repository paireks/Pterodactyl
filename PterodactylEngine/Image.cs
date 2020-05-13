using System;
using System.Collections.Generic;

namespace PterodactylEngine
{
    public class Image
    {
        private string _text;
        private string _path;

        public Image(string text, string path)
        {
            Text = text;
            Path = path;
        }

        public string Create()
        {
            string reportPart = "![" + Text + "](" + Path + ")";

            return reportPart;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }
}

