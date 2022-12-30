using System;
using System.Collections.Generic;
using System.Text;

namespace PterodactylCharts
{
    public class GraphData
    {
        public GraphData(List<List<double>> xValues, List<List<double>> yValues,
            List<string> valuesNames, List<DataType> dataTypes)
        {
            XValues = xValues;
            YValues = yValues;
            ValuesNames = valuesNames;
            DataTypes = dataTypes;

            if (XValues.Count != YValues.Count)
            {
                throw new ArgumentException("X Values tree should have the same number of branches like Y Values tree");
            }
            if (XValues.Count != ValuesNames.Count)
            {
                throw new ArgumentException("X Values tree's number of branches != Values Names elements of list");
            }
            if (XValues.Count != DataTypes.Count)
            {
                throw new ArgumentException("X Values tree's number of branches != Data Types elements of list");
            }
            for (int i = 0; i < XValues.Count; i++)
            {
                if (XValues[i].Count != YValues[i].Count)
                {
                    throw new ArgumentException("Inside each branch of X Values and Y Values trees numbers of elements of lists should match");
                }
            }
            foreach (var dt in dataTypes)
            {
                if (dt.TypeOfData == Enums.TypeOfData.Scatter && dt.ScatterValues.Length != xValues.Count)
                    throw new ArgumentException("X Values and Y Values' tree branch numbers of elements should match Scatter Values' count");
            }
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
