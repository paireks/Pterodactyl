using System;
using System.Drawing;
using System.Linq;
using System.Management;
using Grasshopper.Kernel;

namespace Pterodactyl
{
    public class PterodactylInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "Pterodactyl [ShapeDiver Version]";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                return null;
            }
        }
        public override string Description
        {
            get
            {
                return "Pterodactyl will help you to create reports. This version of Pterodactyl is supported by ShapeDiver.";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("136fc04c-dbc3-4b83-a736-d15c893b21ca");
            }
        }

        public override string AuthorName
        {
            get
            {
                return "Wojciech Radaczynski and Praneet Mathur [for ShapeDiver]";
            }
        }
        public override string AuthorContact
        {
            get
            {
                return "w.radaczynski@gmail.com";
            }
        }
        public override string Version
        {
            get
            {
                return "1.3.0.0";
            }
        }

        public static bool IsRunningOnWindowsServer
        {
            get
            {
                string name = (string)((from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                            select x.GetPropertyValue("Caption")).FirstOrDefault());
                if (name != null) return (name.Contains("server") || name.Contains("Server"));
                else return false;
            }
        }
    }
}
