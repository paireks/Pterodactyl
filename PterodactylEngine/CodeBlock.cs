using System;

namespace PterodactylEngine
{
    public class CodeBlock
    {
        private string _programmingLanguage;
        private string _code;

        public CodeBlock(string programmingLanguage, string code)
        {
            ProgrammingLanguage = programmingLanguage;
            Code = code;
        }

        public string Create()
        {
            string reportPart = "```" + ProgrammingLanguage + Environment.NewLine;
            reportPart += Code + Environment.NewLine;
            reportPart += "```";

            return reportPart;
        }

        public string ProgrammingLanguage
        {
            get { return _programmingLanguage; }
            set { _programmingLanguage = value; }
        }
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
    }
}
