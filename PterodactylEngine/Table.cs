using System;
using System.Collections.Generic;

namespace PterodactylEngine
{
    public class Table
    {
        public string Create(List<string> headings, List<string> alignment, Grasshopper.DataTree<string> dataTree)
        {
            List<int> maxLengthOfStringInColumn = new List<int>();

            for (int i = 0; i < dataTree.BranchCount; i++)
            {
                int currentMax = headings[i].Length;

                for (int j = 0; j < dataTree.Branch(i).Count; j++)
                {
                    if (dataTree.Branch(i)[j].Length > currentMax)
                    {
                        currentMax = dataTree.Branch(i)[j].Length;
                    }
                }

                maxLengthOfStringInColumn.Add(currentMax);
            }



            return String.Empty;
        }
    }
}
