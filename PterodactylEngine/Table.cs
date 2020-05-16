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
        }

        public List<string> Create()
        {
            List<string> reportPartLines = new List<string>();

            for (int i = 0; i < Headings.Count; i++) // for each column
            {
                int currentMax = Headings[i].Length;
            }

            return reportPartLines;
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

        public List<int> MaxStringLength
        {
            get
            {
                List<int> listOfMaxLettersForEachColumn = new List<int>();
                
                for (int i = 0; i < Headings.Count; i++) // for each column
                {
                    int currentMax = Headings[i].Length;

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
    }
}
