using System;
using System.Collections.Generic;
using System.Drawing;
using OxyPlot.WindowsForms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace PterodactylCharts
{
    public class PointGraphEngine
    {

        public PointGraphEngine(bool showGraph, string title,
            List<double> xValues, List<double> yValues, string xName,
            string yName, Color color, string path)
        {
            ShowGraph = showGraph;
            Title = title;
            XValues = xValues;
            YValues = yValues;
            XName = xName;
            YName = yName;
            ColorData = color;
            Path = path;

            if (XValues.Count != YValues.Count)
            {
                throw new ArgumentException(
                    "X Values should match Y Values - check if both lists have the same number of elements.");
            }
        }

        public PlotView ChartCreator()
        {
            PlotView myPlot = new PlotView();

            MyModel = new PlotModel { Title = Title };

            var pointSeries = new ScatterSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColor.FromArgb(a: ColorData.A, r: ColorData.R, g: ColorData.G, b: ColorData.B),
                DataFieldX = "Time",
                DataFieldY = "Value",
                Background = OxyColors.White
            };

            for (int i = 0; i < XValues.Count; i++)
            {
                pointSeries.Points.Add(new ScatterPoint(XValues[i], YValues[i]));
            }

            MyModel.Series.Add(pointSeries);
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = XName });
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = YName });

            myPlot.Model = MyModel;

            myPlot.Dock = System.Windows.Forms.DockStyle.Bottom;
            myPlot.Location = new Point(0, 0);
            myPlot.Size = new Size(600, 400);
            myPlot.TabIndex = 0;

            return myPlot;
        }

        internal Bitmap ExportBitmap()
        {
            var pngExporter = new PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            return pngExporter.ExportToBitmap(MyModel);
        }

        public void Export()
        {
            if (Path.EndsWith(".png"))
            {
                var pngExporter = new PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
                pngExporter.ExportToFile(MyModel, Path);
            }
        }

        public string Create()
        {
            string reportPart;

            if (Path.EndsWith(".png"))
            {
                reportPart = "![" + Title + "](" + Path + ")";
            }
            else
            {
                reportPart = "![" + Title + "][" + Path + "]";
            }
            return reportPart;
        }


        public bool ShowGraph { get; set; }
        public string Title { get; set; }
        public List<double> XValues { get; set; }
        public List<double> YValues { get; set; }
        public string XName { get; set; }
        public string YName { get; set; }
        public Color ColorData { get; set; }
        public string Path { get; set; }
        public PlotModel MyModel { get; set; }
    }
}
