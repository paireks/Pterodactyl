using GH_IO.Serialization;
using Grasshopper.Kernel.Types;
using ShapeDiver.Public.Grasshopper.Parameters;
using ShapeDiver.Public.Grasshopper.Parameters.SDMLDoc;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PterodactylEngine
{
    public class PterodactylGrasshopperBitmapGoo : GrasshopperBitmapGoo, IMLDocAsset
    {
        string _refTag;
        public PterodactylGrasshopperBitmapGoo() : base()
        {
            this._refTag = "image_" + Utils.GenerateUniqueReferenceString();
        }

        public PterodactylGrasshopperBitmapGoo(PterodactylGrasshopperBitmapGoo b) : base((GrasshopperBitmapGoo)b)
        {
            this._refTag = "image_" + Utils.GenerateUniqueReferenceString();
        }

        public PterodactylGrasshopperBitmapGoo(System.Drawing.Image b) : base(b)
        {
            this._refTag = "image_" + Utils.GenerateUniqueReferenceString();
        }

        public PterodactylGrasshopperBitmapGoo(Bitmap b) : base(b)
        {
            this._refTag = "image_" + Utils.GenerateUniqueReferenceString();
        }

        public PterodactylGrasshopperBitmapGoo(Bitmap b, string reportPart) : this(b)
        {
            this._refTag = "image_" + Utils.GenerateUniqueReferenceString();
            this._reportPart = reportPart;
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

        public string ReferenceTag => this._refTag;

        public object AssetContent { 
            get
            {
                return this.Value;
            }
            set
            {
                if (value is Bitmap || value is System.Drawing.Image)
                {
                    this.Value = value as Bitmap;
                }
                else throw new InvalidCastException();
            }
        }

        public string ContentType => "image/png";

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
            PterodactylGrasshopperBitmapGoo p = new PterodactylGrasshopperBitmapGoo(b);
            p.ReportPart = this.ReportPart;
            p._refTag = this._refTag;
            return p;
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
            if (!reader.ItemExists("RefTag"))
            {
                this._refTag = null;
                return false;
            }

            this.Value = reader.GetDrawingBitmap("Image");
            this.ReportPart = reader.GetString("ReportPart");
            this._refTag = reader.GetString("RefTag");
            return true;
        }

        public new bool Write(GH_IWriter writer)
        {
            writer.SetDrawingBitmap("Image", this.Value);
            writer.SetString("ReportPart", this.ReportPart);
            writer.SetString("RefTag", this._refTag);
            return true;
        }

        public MemoryStream ToStream()
        {
            MemoryStream ms = new MemoryStream();
            this.Value.Save(ms, ImageFormat.Png);
            return ms;
        }
    }
}
