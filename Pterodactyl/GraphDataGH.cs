using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PterodactylCharts;
using Rhino.Geometry;

namespace Pterodactyl
{
    public class GraphDataGH : GH_Component
    {
        public GraphDataGH()
          : base("Graph Data", "Graph Data",
              "Create data for graph",
              "Pterodactyl", "Advanced Graph")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("X Values", "X Values", "Values of x as tree of lists." +
                                                                " Each tree branch should be a list of x values." +
                                                                " Each branch represents new series of data.",
                GH_ParamAccess.tree);
            pManager.AddNumberParameter("Y Values", "Y Values", "Values of y as tree of lists." +
                                                                " Each tree branch should be a list of y values." +
                                                                " Each branch represents new series of data.",
                GH_ParamAccess.tree);
            pManager.AddTextParameter("Values Names", "Values Names",
                "List of names of values, each item should match each branch of X and Y Values. It will appear if" +
                " Show Legend == True.", GH_ParamAccess.list);
            pManager.AddGenericParameter("Data Type", "Data Type",
                "Set data type as list, each data type should match each series of data", GH_ParamAccess.list);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph Data", "Graph Data", "Graph data", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Grasshopper.Kernel.Data.GH_Structure<Grasshopper.Kernel.Types.GH_Number> xValuesTree = new Grasshopper.Kernel.Data.GH_Structure<Grasshopper.Kernel.Types.GH_Number>();
            Grasshopper.Kernel.Data.GH_Structure<Grasshopper.Kernel.Types.GH_Number> yValuesTree = new Grasshopper.Kernel.Data.GH_Structure<Grasshopper.Kernel.Types.GH_Number>();
            List<string> valuesNames = new List<string>();
            List<DataType> dataTypes = new List<DataType>();

            DA.GetDataTree("X Values", out xValuesTree);
            DA.GetDataTree("Y Values", out yValuesTree);
            DA.GetDataList(2, valuesNames);
            DA.GetDataList(3, dataTypes);

            List<List<double>> xValues = new List<List<double>>();
            List<List<double>> yValues = new List<List<double>>();

            for (int i = 0; i < valuesNames.Count; i++)
            {
                List<double> currentBranchXValues = new List<double>();
                for (int j = 0; j < xValuesTree.get_Branch(i).Count; j++)
                {
                    currentBranchXValues.Add(Convert.ToDouble(xValuesTree.get_Branch(i)[j].ToString()));
                }
                xValues.Add(currentBranchXValues);

                List<double> currentBranchYValues = new List<double>();
                for (int j = 0; j < yValuesTree.get_Branch(i).Count; j++)
                {
                    currentBranchYValues.Add(Convert.ToDouble(yValuesTree.get_Branch(i)[j].ToString()));
                }
                yValues.Add(currentBranchYValues);
            }

            GraphData graphData = new GraphData(xValues, yValues, valuesNames, dataTypes);

            DA.SetData(0, graphData);
        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.PterodactylGraphData;
            }
        }
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.tertiary; }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("74472dd4-f46e-4dcd-895b-e650f09760c3"); }
        }
    }
}