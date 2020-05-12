using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylEngine
{
    public class TaskList
    {
        private List<string> _text;
        private List<bool> _done;

        public TaskList(List<string> text, List<bool> done)
        {
            Text = text;
            Done = done;

            if (Text.Count != Done.Count) 
            {
                throw new ArgumentException("Text values should match boolean (done) values." +
                    "Check if both input lists have the same number of elements.");
            }
        }

        public string Create()
        {
            string reportPart = "";
            for (int i = 0; i < Text.Count; i++)
            {
                if (Done[i] == true) { reportPart += "- [x] "; }
                else { reportPart += "- [ ] "; }
                reportPart += Text[i];
                if (i+1 != Text.Count) { reportPart += Environment.NewLine; }
            }
            return reportPart;
        }

        public List<string> Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public List<bool> Done
        {
            get { return _done; }
            set { _done = value; }
        }
    }
}
