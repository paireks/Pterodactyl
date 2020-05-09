using System;

namespace PterodactylEngine
{
    public class MathBlock
    {
        private string _text;

        public MathBlock(string text)
        {
            Text = text;
        }

        public string Create()
        {
            string reportPart = "$$" + Environment.NewLine;
            reportPart += Text + Environment.NewLine;
            reportPart += "$$";

            return reportPart;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}
