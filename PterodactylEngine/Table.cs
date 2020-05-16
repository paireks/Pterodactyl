using System;
using System.Collections.Generic;

namespace PterodactylEngine
{
    public class Table
    {
        private List<string> _headings;
        private List<int> _alignment;
        private Grasshopper.DataTree<string> _dataTree;

        public Table(List<string> headings, List<int> alignment, Grasshopper.DataTree<string> dataTree)
        {
            Headings = _headings;
            Alignment = _alignment;
            DataTree = _dataTree;
        }

        public List<string> Create()
        {
            List<string> reportPartLines = new List<string>();

            for (int i = 0; i < DataTree.BranchCount; i++) // for each column
            {
                int currentMax = Headings[i].Length;

                for (int j = 0; j < DataTree.Branch(i).Count; j++) // for each line in that column -> search longest string for column
                {
                    if (DataTree.Branch(i)[j].Length > currentMax)
                    {
                        currentMax = DataTree.Branch(i)[j].Length;
                    }
                }

                for (int j = 0; j < DataTree.Branch(i).Count; j++) // for each line in that column -> add new text for each line
                {
                    if (j == 0) // creating heading
                    {
                        string spacingAfterHeading = new String(' ', currentMax - Headings[i].Length - 3);
                        reportPartLines[0] += "| " + Headings[i] + spacingAfterHeading + " ";
                    }
                    else if (j == 1) // typing alignment
                    {
                        string alignmentStart;
                        string alignmentEnd;

                        if (Alignment[i] == 0) { alignmentStart = "-"; alignmentEnd = "-"; }
                        else if (Alignment[i] == 1) { alignmentStart = ":"; alignmentEnd = ":"; }
                        else { alignmentStart = "-"; alignmentEnd = ":"; }

                        string alignmentMiddle = new String('-', currentMax - Headings[i].Length - 5);

                        reportPartLines[1] += "| " + alignmentStart + alignmentMiddle + alignmentEnd + " ";
                    }
                    else // creating rows
                    {
                        string spacingForCurrentRow = new String(' ', currentMax - Headings[i].Length - 3);
                        reportPartLines[j] += "| " + DataTree.Branch(i)[j] + " ";
                    }
                }
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

        public Grasshopper.DataTree<string> DataTree
        {
            get { return _dataTree; }
            set { _dataTree = value; }
        }

        public List<int> MaxStringLength
        {
            get
            {
                List<int> listOfMaxLettersForEachColumn = new List<int>();
                
                for (int i = 0; i < DataTree.BranchCount; i++) // for each column
                {
                    int currentMax = Headings[i].Length;

                    for (int j = 0; j < DataTree.Branch(i).Count; j++) // for each line in that column -> search longest string for column
                    {
                        if (DataTree.Branch(i)[j].Length > currentMax)
                        {
                            currentMax = DataTree.Branch(i)[j].Length;
                        }
                    }

                    listOfMaxLettersForEachColumn.Add(currentMax);
                }

                return listOfMaxLettersForEachColumn;
            }
        }
    }
}
