using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PterodactylCategoryIcon : GH_AssemblyPriority
{
    public override GH_LoadingInstruction PriorityLoad()
    {
        Instances.ComponentServer.AddCategoryIcon("Pterodactyl", Pterodactyl.Properties.Resources.tab_icon);
        Instances.ComponentServer.AddCategorySymbolName("Pterodactyl", 'P');
        return GH_LoadingInstruction.Proceed;
    }
}
