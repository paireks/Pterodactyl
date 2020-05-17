using System;

namespace PterodactylEngine
{
    public class HorizontalLine
    {
        public string Create()
        {
            string reportPart = "";
            string linePart = new string('-', 6);

            reportPart = Environment.NewLine + linePart + Environment.NewLine;

            return reportPart;
        }
    }
}
