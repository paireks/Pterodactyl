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
    public partial class BarChart : Form
    {
        public BarChart()
        {
            InitializeComponent();
        }

        public void BarChartData(bool showGraph, string title,
            List<double> values, List<string> names, string textFormat,
            List<Color> colors, string path)
        {
            BarChartObject = new BarChartEngine(showGraph, title, values, names, textFormat, colors, path);
            PlotView myPlot = BarChartObject.ChartCreator();
            Controls.Add(myPlot);
        }
        public string Create()
        {
            string reportPart = BarChartObject.Create();
            return reportPart;
        }

        public void Export()
        {
            BarChartObject.Export();
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.Escape:
                    this.Close();
                    return true; // signal that we've processed this key
            }

            // run base implementation
            return base.ProcessCmdKey(ref message, keys);
        }

        public BarChartEngine BarChartObject { get; set; }
    }
}
