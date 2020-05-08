using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylEngine
{
    public class SaveReport
    {
        private string _report;
        private string _path;

        public SaveReport(string report, string path)
        {
            Report = report;
            Path = path;
        }

        public string Path
        {
            get { return _path; }
            set
            {
                if (Uri.IsWellFormedUriString(value, UriKind.Absolute))
                {
                    _path = value;
                }
            }
        }

        public string Report
        {
            get { return _report; }
            set { _report = value; }
        }



    }
}
