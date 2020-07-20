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
    public partial class LineGraph : Form
    {
        public LineGraph()
        {
            InitializeComponent();
        }

        public void LineGraphData(bool showGraph, string title,
            List<double> xValues, List<double> yValues, string xName, string yName,
            Color color, string path)
        {
            LineGraphObject = new LineGraphEngine(showGraph, title, xValues, yValues, xName, yName, color, path);
            PlotView myPlot = LineGraphObject.ChartCreator();
            Controls.Add(myPlot);
        }
        public void LineGraphData(bool showGraph, string title,
            List<List<double>> xValues, List<List<double>> yValues,
            List<string> valuesNames,
            bool showLegend, string legendTitle, int legendPositionAsInt,
            string xName, string yName,
            List<Color> colors, Color backgroundColor,
            int graphWidth, int graphHeight,
            List<string> textAnnotations,
            List<double> textLocationXValues, List<double> textLocationYValues,
            string path)
        {
            LineGraphObject = new LineGraphEngine(
                showGraph, title,
                xValues, yValues, valuesNames,
                showLegend, legendTitle, legendPositionAsInt,
                xName, yName,
                colors, backgroundColor,
                graphWidth, graphHeight,
                textAnnotations,
                textLocationXValues, textLocationYValues,
                path);
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
