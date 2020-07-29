using System;
using System.Collections.Generic;
using System.Text;

namespace PterodactylCharts
{
    public class GraphData
    {
        public GraphData(List<List<double>> xValues,
            List<List<double>> yValues,
            List<string> valuesNames,
            List<DataType> dataTypes)
        {
            XValues = xValues;
            YValues = yValues;
            ValuesNames = valuesNames;
            DataTypes = dataTypes;
        }
        public override string ToString()
        {
            StringBuilder stringRepresentation = new StringBuilder();
            stringRepresentation.AppendFormat("Graph Data{0}Series of data: {1}", Environment.NewLine, ValuesNames.Count);
            return stringRepresentation.ToString();
        }

        public List<List<double>> XValues { get; set; }
        public List<List<double>> YValues { get; set; }
        public List<string> ValuesNames { get; set; }
        public List<DataType> DataTypes { get; set; }
    }
}
