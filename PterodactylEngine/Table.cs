using System;
using System.Collections.Generic;
using System.Text;

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
            List<string> reportParts = new List<string>();

            List<int> listOfMaxLettersForEachColumn = new List<int>();


            StringBuilder headingsReportPart = new StringBuilder();
            StringBuilder alignmentReportPart = new StringBuilder();
            List<StringBuilder> rows = new List<StringBuilder>();

            for (int i = 0; i < Headings.Count; i++) //for each column
            {
                int currentMax = Math.Max(Headings[i].Length, 4);

                for (int j = 0;
                    j < DataTree.GetLength(1);
                    j++) // for each line in that column -> search longest string for column
                {
                    if (DataTree[i, j].Length > currentMax)
                    {
                        currentMax = DataTree[i, j].Length;
                    }
                }

                if (i == 0)
                {
                    for (int j = 0; j < DataTree.GetLength(1); j++)
                    {
                        StringBuilder newCell = new StringBuilder();
                        newCell.AppendFormat("| {0}{1} ", DataTree[i, j], new string(' ', currentMax - DataTree[i, j].Length));
                        rows.Add(newCell);
                    }
                }
                else if (0 < i && i < Headings.Count)
                {
                    for (int j = 0; j < DataTree.GetLength(1); j++)
                    {
                        rows[j].AppendFormat("| {0}{1} ", DataTree[i, j], new string(' ', currentMax - DataTree[i, j].Length));
                    }
                }
                else
                {
                    for (int j = 0; j < DataTree.GetLength(1); j++)
                    {
                        rows[j].AppendFormat("|");
                    }
                }

                headingsReportPart.AppendFormat("| {0}{1} ", Headings[i],
                    new string(' ', currentMax - Headings[i].Length));

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

                string symbols = new string('-', currentMax - 2);
                alignmentReportPart.AppendFormat("| {0}{1}{2} ", alignmentStartSymbol, symbols, alignmentEndSymbol);


            }

            headingsReportPart.AppendFormat("|");
            alignmentReportPart.Append("|");

            reportParts.Add(headingsReportPart.ToString());
            reportParts.Add(alignmentReportPart.ToString());

            foreach (var row in rows)
            {
                row.Append("|");
                reportParts.Add(row.ToString());
            }

            return reportParts;
        }

        public List<string> Headings
        {
            get { return _headings; }
            set { _headings = value; }
        }

        public List<int> Alignment
        {
            get { return _alignment; }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    if (new List<int> { 0, 1, 2 }.Contains(value[i]))
                    {
                        _alignment = value;
                    }
                    else
                    {
                        throw new ArgumentException("Alignment should be an integer between 0 and 2");
                    }
                }
            }
        }
        public string[,] DataTree
        {
            get { return _dataTree; }
            set { _dataTree = value; }
        }
    }
}
