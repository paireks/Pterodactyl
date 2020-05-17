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
            System.IO.File.WriteAllText(Path, Report);
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public string Report
        {
            get { return _report; }
            set { _report = value; }
        }
    }
}
