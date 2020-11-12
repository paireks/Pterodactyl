using Grasshopper.Kernel;
using PterodactylEngine.Properties;
using ShapeDiver.Public.Grasshopper.Parameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylEngine
{
    public class PterodactylGrasshopperBitmapParam : GH_PersistentParam<PterodactylGrasshopperBitmapGoo>
    {
        public PterodactylGrasshopperBitmapParam()
          : base(new GH_InstanceDescription("Pterodactyl Report Part", "Pterodactyl Report Part", "Contains a collection of Pterodactyl Report Parts with corresponding Bitmap images", "Params", "Primitive"))
        {
        }
        public override Guid ComponentGuid => new Guid("CAC779EE-0FBD-4A2F-9BBA-8A89F6745F01");

        public override GH_Exposure Exposure => GH_Exposure.hidden;

        protected override Bitmap Icon => Resources.sd_parameter_bitmap_24x24;

        protected override PterodactylGrasshopperBitmapGoo PreferredCast(object data)
        {
            return base.PreferredCast(data);
        }

        protected override GH_GetterResult Prompt_Plural(ref List<PterodactylGrasshopperBitmapGoo> values)
        {
            return GH_GetterResult.cancel;
        }

        protected override GH_GetterResult Prompt_Singular(ref PterodactylGrasshopperBitmapGoo value)
        {
            return GH_GetterResult.cancel;
        }
    }
}
