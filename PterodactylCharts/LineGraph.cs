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

            ShowGraph = showGraph;
            Title = title;
            XValues = xValues;
            YValues = yValues;
            XName = xName;
            YName = yName;
            Path = path;

            PlotView myPlot = new PlotView();

            var myModel = new PlotModel {Title = Title};

            var lineSeries = new LineSeries
            {
                Color = OxyColors.Blue,
                MarkerFill = OxyColors.Transparent,
                DataFieldX = XName,
                DataFieldY = YName
            };

            for (int i = 0; i < XValues.Count; i++)
            {
                lineSeries.Points.Add(new DataPoint(XValues[i], YValues[i]));
            }

            myModel.Series.Add(lineSeries);
            myModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = XName });
            myModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = YName });

            myPlot.Model = myModel;

            myPlot.Dock = System.Windows.Forms.DockStyle.Bottom;
            myPlot.Location = new System.Drawing.Point(0, 0);
            myPlot.Size = new System.Drawing.Size(600, 400);
            myPlot.TabIndex = 0;

            Controls.Add(myPlot);

            if (Path.EndsWith(".png"))
            {
                var pngExporter = new PngExporter {Width = 600, Height = 400, Background = OxyColors.White};
                pngExporter.ExportToFile(myModel, Path);
            }
        }

        public string Create()
        {
            string reportPart = "";

            if (Path.EndsWith(".png"))
            {
                reportPart = "![" + Title + "](" + Path + ")";
            }
            else
            {
                reportPart = "";
            }
            return reportPart;
        }

        public bool ShowGraph { get; set; }
        public string Title { get; set; }
        public List<double> XValues { get; set; }
        public List<double> YValues { get; set; }
        public string XName { get; set; }
        public string YName { get; set; }
        public List<int> GraphSizeSettings { get; set; }
        public string Path { get; set; }
    }
}
