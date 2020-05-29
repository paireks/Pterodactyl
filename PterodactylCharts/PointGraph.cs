using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using OxyPlot.WindowsForms;
using OxyPlot;
using System.Windows.Forms;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace PterodactylCharts
{
    public partial class PointGraph : Form
    {
        public PointGraph()
        {
            InitializeComponent();
        }

        public void PointGraphData(bool showGraph, string title,
            List<double> xValues, List<double> yValues, string xName,
            string yName, Color color, string path)
        {
            PointGraphObject = new PointGraphEngine(showGraph, title, xValues, yValues, xName, yName, color, path);
            PlotView myPlot = PointGraphObject.ChartCreator();
            Controls.Add(myPlot);
        }
        public string Create()
        {
            string reportPart = PointGraphObject.Create();
            return reportPart;
        }

        public void Export()
        {
            PointGraphObject.Export();
        }

        public PointGraphEngine PointGraphObject { get; set; }
    }
}