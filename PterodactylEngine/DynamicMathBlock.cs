using System;
using System.Collections.Generic;
using System.Linq;

namespace PterodactylEngine
{
    public class DynamicMathBlock
    {
        private string _text;
        private List<string> _variablesSymbols;
        private List<double> _variablesValues;

        public DynamicMathBlock(string text, List<string> variablesSymbols, List<double> variablesValues)
        {
            Text = text;
            VariablesSymbols = variablesSymbols;
            VariablesValues = variablesValues;
        }

        public string Format()
        {
            var variables = 
                VariablesSymbols.Zip(VariablesValues, (s, v)
                    => new { VariablesSymbols = s, VariablesValues = v });

            string formatted = Text;

            foreach (var i in variables)
            {
                formatted = formatted.Replace("<" + i.VariablesSymbols + ">", i.VariablesValues.ToString());
            }

            string reportPart = "$$" + Environment.NewLine;
            reportPart += formatted + Environment.NewLine;
            reportPart += "$$";

            return reportPart;
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public List<string> VariablesSymbols
        {
            get { return _variablesSymbols; }
            set
            {
                if (value.Any())
                {
                    _variablesSymbols = value;
                }
                else
                {
                    throw new ArgumentException("Set Variables' Symbols (at least one). If you don't need to use " +
                                                "dynamic variables - use Math Block component instead");
                }
            }
        }

        public List<double> VariablesValues
        {
            get { return _variablesValues; }
            set { _variablesValues = value; }
        }
    }
}
