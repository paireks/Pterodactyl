using System;

namespace PterodactylEngine
{
    public class Underline
    {
        private string _text;

        public Underline(string text)
        {
            Text = text;
        }

        public string Create()
        {
            string reportPart = "<u>" + Text + "</u>";

            return reportPart;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}
