using ShapeDiver.Public.Grasshopper.Parameters.SDMLDoc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PterodactylEngine
{
    public class MarkdownDocument : IMLDoc
    {
        List<IMLDocAsset> m_assets;
        string m_markup;
        public MarkdownDocument()
        {
            this.m_assets = new List<IMLDocAsset>();
            this.m_markup = string.Empty;
        }

        public string ContentType => "text/markdown";

        public string Markup { get => m_markup; set => m_markup = value; }

        public IEnumerable<IMLDocAsset> Assets => (IEnumerable<IMLDocAsset>)m_assets;

        public string AddAsset(IMLDocAsset Asset)
        {
            string refTag = Utils.GenerateUniqueReferenceString();
            this.m_assets.Add(Asset);
            return refTag;
        }

        public string GetDocumentWithEmbeddedAssets()
        {
            if (this.m_assets.Count() > 0)
            {
                string markupOut = this.m_markup + "\n\n";
                foreach (IMLDocAsset asset in this.m_assets)
                {
                    using (MemoryStream ms = asset.ToStream())
                    {
                        string data = Convert.ToBase64String(ms.ToArray());
                        markupOut += ("\n[" + asset.ReferenceTag + "]:data:" + (asset.ContentType) + ";base64," + data);
                    }
                }
                return markupOut;
            }
            else return this.m_markup;
        }

        public bool WriteDocumentToFile(string FilePath, bool WriteAssetsToFolder = true)
        {
            try
            {
                string markupOut = this.m_markup;
                using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(markupOut);
                        fs.Flush();
                    }
                }
                string assetFolder = ((new FileInfo(FilePath).Directory.FullName) + "\\" + (new FileInfo(FilePath).Name.Split('.')[0]) + "\\");
                Directory.CreateDirectory(assetFolder);
                if (WriteAssetsToFolder)
                {
                    foreach (IMLDocAsset asset in this.m_assets)
                    {
                        string filename = assetFolder + asset.ReferenceTag + Utils.GetDefaultExtension(asset.ContentType);
                        markupOut = markupOut.Replace(asset.ReferenceTag, filename);
                        using (MemoryStream ms = asset.ToStream())
                        {
                            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                            {
                                ms.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
