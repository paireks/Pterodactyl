using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace Pterodactyl
{
    public class PterodactylInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "Pterodactyl";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "Pterodactyl will help you to create reports";
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
                //Return a string identifying you or your company.
                return "Wojciech Radaczyński";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "w.radaczynski@gmail.com";
            }
        }
    }
}
