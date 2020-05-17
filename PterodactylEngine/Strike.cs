using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylEngine
{
    public class Strike
    {
        private string _text;

        public Strike(string text)
        {
            Text = text;
        }

        public string Create()
        {
            string reportPart = "~~" + Text + "~~";

            return reportPart;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}
