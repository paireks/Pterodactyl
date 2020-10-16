using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using PterodactylEngine;

namespace Pterodactyl
{
    public class DynamicMathBlockGH : GH_Component
    {
        public DynamicMathBlockGH()
          : base("Dynamic Math Block", "Dynamic Math Block",
              "Creates dynamic math block, that can change variables values automatically. This Report Part might not appear properly in PDF exports.",
              "Pterodactyl", "Parts")
        {
        }
        public override bool IsBakeCapable => false;
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Text", "Text", "Math text written in TeX-style. Put dynamic variables in <> brackets. " +
                "For example: x - this is static variable, <x> - this is dynamic variable, that will change to given value.",
                GH_ParamAccess.item, @"2 \cdot sin(x) + cos(y) = 2 \cdot sin(<x>) + cos(<y>) = ...");
            pManager.AddTextParameter("Variables Symbols", "Variables Symbols",
                "List of symbols that represent dynamic values.",
                GH_ParamAccess.list, new List<string>
                    {"x", "y"});
            pManager.AddNumberParameter("Variables Values", "Variables Values", "Variables' values as list.",
                GH_ParamAccess.list, new List<double> {1.0, 2.0});
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Report Part", "Report Part", "Created part of the report", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string text = string.Empty;
            List<string> variablesSymbols = new List<string>();
            List<double> variablesValues = new List<double>();

            DA.GetData(0, ref text);
            DA.GetDataList(1, variablesSymbols);
            DA.GetDataList(2, variablesValues);

            string reportPart;
            DynamicMathBlock reportObject = new DynamicMathBlock(text, variablesSymbols, variablesValues);
            reportPart = reportObject.Format();

            DA.SetData(0, reportPart);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylDynamicMathBlock;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.tertiary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("29f4111e-1253-461b-9a66-d12e684fc17b"); }
        }
    }
}