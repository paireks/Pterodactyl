using System;

namespace PterodactylEngine
{
    public class Emphasis
    {
        private string _text;

        public Emphasis(string text)
        {
            Text = text;
        }

        public string Create()
        {
            string reportPart = "*" + Text + "*";

            return reportPart;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}
