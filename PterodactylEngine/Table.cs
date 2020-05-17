using System;
using System.Collections.Generic;

namespace PterodactylEngine
{
    public class Table
    {
        private List<string> _headings;
        private List<int> _alignment;
        private string[,] _dataTree;

        public Table(List<string> headings, List<int> alignment, string[,] dataTree)
        {
            Headings = headings;
            Alignment = alignment;
            DataTree = dataTree;

            if (headings.Count != alignment.Count)
            {
                throw new ArgumentException("Headings list should match alignment list. " +
                    "Check if both input lists have the same number of elements.");
            }

            if (headings.Count != dataTree.GetLength(0))
            {
                throw new ArgumentException("Headings list should match number of columns given in data tree. " +
                    "Check if both inputs have the same number of elements.");
            }

        }

        public List<string> Create()
        {
            return new List<string>();
        }

        public List<string> Headings
        {
            get { return _headings; }
            set { _headings = value; }
        }

        public List<int> Alignment
        {
            get { return _alignment; }
            set { _alignment = value; }
        }

        public string[,] DataTree
        {
            get { return _dataTree; }
            set { _dataTree = value; }
        }

        public List<int> ColumnSizes
        {
            get
            {
                List<int> listOfMaxLettersForEachColumn = new List<int>();
                
                for (int i = 0; i < Headings.Count; i++) // for each column
                {
                    int currentMax = Math.Max(Headings[i].Length, 4);

                    for (int j = 0; j < DataTree.GetLength(1); j++) // for each line in that column -> search longest string for column
                    {
                        if (DataTree[i, j].Length > currentMax)
                        {
                            currentMax = DataTree[i, j].Length;
                        }
                    }

                    listOfMaxLettersForEachColumn.Add(currentMax);
                }

                return listOfMaxLettersForEachColumn;
            }
        }

        public string HeadingReport
        {
            get 
            {
                string headingsReportPart = "";
                for (int i = 0; i < Headings.Count; i++) //for each column
                {
                    string spaces = new string(' ', ColumnSizes[i] - Headings[i].Length);
                    headingsReportPart += "| " + Headings[i] + spaces + " ";
                }
                headingsReportPart += "|";

                return headingsReportPart;
            }
        }

        public string AlignmentReport
        {
            get
            {
                string alignmentreportPart = "";


                for (int i = 0; i < Headings.Count; i++) //for each column
                {
                    string alignmentStartSymbol = "-";
                    string alignmentEndSymbol = "-";
                    if (Alignment[i] == 1)
                    {
                        alignmentStartSymbol = ":";
                        alignmentEndSymbol = ":";
                    }
                    else if (Alignment[i] == 2)
                    {
                        alignmentEndSymbol = ":";
                    }
                    else{}

                    string symbols = new string('-', ColumnSizes[i] - 2);
                    alignmentreportPart += "| " + alignmentStartSymbol + symbols + alignmentEndSymbol + " ";
                }
                alignmentreportPart += "|";

                return alignmentreportPart;
            }
        }

    }
}
