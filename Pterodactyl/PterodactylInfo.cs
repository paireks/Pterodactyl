﻿using System;
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
                return null;
            }
        }
        public override string Description
        {
            get
            {
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
                return "Wojciech Radaczynski";
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
                return "1.2.0.0";
            }
        }
    }
}
