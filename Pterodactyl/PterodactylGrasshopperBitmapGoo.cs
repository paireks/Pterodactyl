using GH_IO.Serialization;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using ShapeDiver.Public.Grasshopper.Parameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pterodactyl
{
    class PterodactylGrasshopperBitmapGoo : GrasshopperBitmapGoo
    {
        public PterodactylGrasshopperBitmapGoo() : base()
        {
        }

        public PterodactylGrasshopperBitmapGoo(PterodactylGrasshopperBitmapGoo b) : base((GrasshopperBitmapGoo)b)
        {
        }

        public PterodactylGrasshopperBitmapGoo(Image b) : base(b)
        {
        }

        public PterodactylGrasshopperBitmapGoo(Bitmap b) : base(b)
        {
        }
        
        public PterodactylGrasshopperBitmapGoo(Bitmap b, string p) : base(b)
        {
            this.ReportPart = p;
        }

        private string _reportPart = "";
        public string ReportPart { 
            get
            {
                return this._reportPart;
            }
            set
            {
                this._reportPart = value;
            }
        }

        public override string ToString()
        {
            string v = this;
            return v;
        }

        public static implicit operator string(PterodactylGrasshopperBitmapGoo v)
        {
            return v.ReportPart;
        }

        public new IGH_Goo Duplicate()
        {
            Bitmap b = (Bitmap)this.Value.Clone();
            return new PterodactylGrasshopperBitmapGoo(b, this.ReportPart);
        }

        public new bool Read(GH_IReader reader)
        {
            if (!reader.ItemExists("Image"))
            {
                this.Value = null;
                return false;
            }
            if (!reader.ItemExists("ReportPart"))
            {
                this.ReportPart = null;
                return false;
            }

            this.Value = reader.GetDrawingBitmap("Image");
            this.ReportPart = reader.GetString("ReportPart");
            return true;
        }

        public new bool Write(GH_IWriter writer)
        {
            writer.SetDrawingBitmap("Image", this.Value);
            writer.SetString("ReportPart", this.ReportPart);
            return true;
        }

        public static string CreateTemporaryFilePath(GH_Component owner, string format = "png")
        {
            if (!System.IO.Directory.Exists(Grasshopper.Folders.AppDataFolder + "Pterodactyl\\")) System.IO.Directory.CreateDirectory(Grasshopper.Folders.AppDataFolder + "Pterodactyl\\");
            return (Grasshopper.Folders.AppDataFolder + "Pterodactyl\\" + ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds().ToString() + "_"
                                                                                                            + owner.InstanceGuid.ToString() + "." + format);
        }
        public static string CreateTemporaryFolderPath()
        {
            if (!System.IO.Directory.Exists(Grasshopper.Folders.AppDataFolder + "Pterodactyl\\")) System.IO.Directory.CreateDirectory(Grasshopper.Folders.AppDataFolder + "Pterodactyl\\");
            return (Grasshopper.Folders.AppDataFolder + "Pterodactyl\\");
        }
    }
}
