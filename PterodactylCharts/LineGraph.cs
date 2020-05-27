using System;
using System.Collections.Generic;
using System.IO;
using OxyPlot.WindowsForms;
using OxyPlot;
using System.Windows.Forms;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace PterodactylCharts
{
    public partial class LineGraph : Form
    {
        public LineGraph()
        {
            InitializeComponent();
        }

        public void LineGraphData(bool showGraph, string title,
            List<double> xValues, List<double> yValues, string xName,
            string yName, string path)
        {
            LineGraphObject = new LineGraphEngine(showGraph, title, xValues, yValues, xName, yName, path);
            PlotView myPlot = LineGraphObject.ChartCreator();
            Controls.Add(myPlot);
        }
        public string Create()
        {
            string reportPart = LineGraphObject.Create();
            return reportPart;
        }

        public void Export()
        {
            LineGraphObject.Export();
        }

        public LineGraphEngine LineGraphObject { get; set; }
    }
}
