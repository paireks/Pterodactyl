using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylEngine
{
    public class PieChart
    {
        private string _title;
        private List<string> _categories;
        private List<double> _values;

        public PieChart(string title, List<string> categories, List<double> values)
        {
            Title = title;
            Categories = categories;
            Values = values;

            if (Categories.Count != Values.Count)
            {
                throw new ArgumentException("Categories list should match values list. " +
                    "Check if both input lists have the same number of elements.");
            }
        }

        public string Create()
        {
            string reportPart = "```mermaid" + Environment.NewLine + "pie title " + Title + Environment.NewLine;
            for (int i = 0; i < Categories.Count; i++)
            {
                reportPart += "    \"" + Categories[i] + "\" : " + Values[i] + Environment.NewLine;
            }
            reportPart += "```";
            return reportPart;
        }
        public string Title
        {
            get { return _title; }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Set Pie Chart title");
                }
                else
                {
                    _title = value;
                }
            }
        }
        public List<string> Categories
        {
            get { return _categories; }
            set
            {
                if (value.Any())
                {
                    _categories = value;
                }
                else
                {
                    throw new ArgumentException("Set categories");
                }
            }
        }
        public List<double> Values
        {
            get { return _values; }
            set
            {
                if (value.Any())
                {
                    _values = value;
                }
                else
                {
                    throw new ArgumentException("Set values");
                }
            }
        }
    }
}
