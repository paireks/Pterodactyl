using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylEngine
{
    public class OrderedList
    {
        private List<string> _text;

        public OrderedList(List<string> text)
        {
            Text = text;
        }

        public string Create()
        {
            string reportPart = "";
            for (int i = 0; i < Text.Count; i++)
            {
                reportPart += (i + 1).ToString() + ". ";
                reportPart += Text[i];
                if (i + 1 != Text.Count) { reportPart += Environment.NewLine; }
            }
            return reportPart;
        }

        public List<string> Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}
