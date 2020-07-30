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
    public partial class ColumnChart : Form
    {
        public ColumnChart()
        {
            InitializeComponent();
        }

        public void ColumnChartData(bool showGraph, string title,
            List<double> values, List<string> names, string textFormat,
            List<Color> colors, string path)
        {
            ColumnChartObject = new ColumnChartEngine(showGraph, title, values, names, textFormat, colors, path);
            PlotView myPlot = ColumnChartObject.ChartCreator();
            Controls.Add(myPlot);
        }
        public string Create()
        {
            string reportPart = ColumnChartObject.Create();
            return reportPart;
        }

        public void Export()
        {
            ColumnChartObject.Export();
        }

        public ColumnChartEngine ColumnChartObject { get; set; }
    }
}