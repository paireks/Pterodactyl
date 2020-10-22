using GH_IO.Serialization;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using ShapeDiver.Public.Grasshopper.Parameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        
        public PterodactylGrasshopperBitmapGoo(Bitmap b, string r, string p) : base(b)
        {
            this.ReportPart = r;
            this.FilePath = p;
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

        private string _filePath = "";
        public string FilePath { 
            get
            {
                return this._filePath;
            }
            set
            {
                this._filePath = value;
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
            return new PterodactylGrasshopperBitmapGoo(b, this.ReportPart, this.FilePath);
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
            if (!reader.ItemExists("FilePath"))
            {
                this.FilePath = null;
                return false;
            }

            this.Value = reader.GetDrawingBitmap("Image");
            this.ReportPart = reader.GetString("ReportPart");
            this.FilePath = reader.GetString("FilePath");
            return true;
        }

        public new bool Write(GH_IWriter writer)
        {
            writer.SetDrawingBitmap("Image", this.Value);
            writer.SetString("ReportPart", this.ReportPart);
            writer.SetString("FilePath", this.FilePath);
            return true;
        }

        public static string CreateTemporaryFilePath(GH_Component owner, string format = "png")
        {
            if (!System.IO.Directory.Exists(Path.GetTempPath() + "Pterodactyl\\")) System.IO.Directory.CreateDirectory(Path.GetTempPath() + "Pterodactyl\\");
            return (Path.GetTempPath() + "Pterodactyl\\" + ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds().ToString() + "_"
                                                                                                            + owner.InstanceGuid.ToString() + "." + format);
        }
        public static string GetTemporaryFolderPath()
        {
            if (!System.IO.Directory.Exists(Path.GetTempPath() + "Pterodactyl\\")) System.IO.Directory.CreateDirectory(Path.GetTempPath() + "Pterodactyl\\");
            return (Path.GetTempPath() + "Pterodactyl\\");
        }
    }
}
