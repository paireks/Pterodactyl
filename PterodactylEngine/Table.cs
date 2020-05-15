using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylEngine
{
    public class Table
    {
        public void Test()
        {
            Grasshopper.DataTree<string> dataTree = new Grasshopper.DataTree<string>();
            dataTree.Branch(0)[0] = "lol";
        }
    }
}
