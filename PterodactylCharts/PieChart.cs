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
    public partial class PieChart : Form
    {
        public PieChart()
        {
            InitializeComponent();
        }

        public void PieChartData(bool showGraph, string title,
            List<double> values, List<string> names,
            List<Color> colors, string path)
        {
            PieChartObject = new PieChartEngine(showGraph, title, values, names, colors, path);
            PlotView myPlot = PieChartObject.ChartCreator();
            Controls.Add(myPlot);
        }
        public string Create()
        {
            string reportPart = PieChartObject.Create();
            return reportPart;
        }

        public void Export()
        {
            PieChartObject.Export();
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

        public PieChartEngine PieChartObject { get; set; }
    }
}