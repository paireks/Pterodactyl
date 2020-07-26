using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylCharts
{
    public class GraphData
    {
        public GraphData(List<List<double>> xValues,
            List<List<double>> yValues,
            List<string> valuesNames)
        {
            XValues = xValues;
            YValues = yValues;
            ValuesNames = valuesNames;
        }

        public List<List<double>> XValues { get; set; }
        public List<List<double>> YValues { get; set; }
        public List<string> ValuesNames { get; set; }
    }
}
