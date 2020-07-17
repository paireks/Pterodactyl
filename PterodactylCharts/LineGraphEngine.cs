using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using OxyPlot.WindowsForms;
using OxyPlot;
using System.Windows.Forms;
using System.Xml;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace PterodactylCharts
{
    public class LineGraphEngine
    {

        public LineGraphEngine(bool showGraph, string title,
            List<double> xValues, List<double> yValues,
            string xName, string yName,
            Color color, string path)
        {
            ShowGraph = showGraph;
            Title = title;
            XValues = xValues;
            YValues = yValues;
            XName = xName;
            YName = yName;
            Colors = new List<Color> {color};
            BackgroundColor = Color.FromArgb(255, 255, 255);
            GraphWidth = 600;
            GraphHeight = 400;
            Path = path;

            if (XValues.Count != YValues.Count)
            {
                throw new ArgumentException(
                    "X Values should match Y Values - check if both lists have the same number of elements.");
            }
        }

        public LineGraphEngine(bool showGraph, string title,
            double[,] xValues, double[,] yValues,
            string xName, string yName,
            List<Color> colors, Color backgroundColor,
            int graphWidth, int graphHeight,
            List<string> textAnnotations, 
            List<double> textLocationXValues, List<double> textLocationYValues,
            string path)
        {
            ShowGraph = showGraph;
            Title = title;
            XValuesTable = xValues;
            YValuesTable = yValues;
            XName = xName;
            YName = yName;
            Colors = colors;
            BackgroundColor = backgroundColor;
            GraphWidth = graphWidth;
            GraphHeight = graphHeight;
            TextAnnotations = textAnnotations;
            TextLocationXValues = textLocationXValues;
            TextLocationYValues = textLocationYValues;
            Path = path;
        }

        public PlotView ChartCreator()
        {
            PlotView myPlot = new PlotView();

            MyModel = new PlotModel { Title = Title };

            for (int i = 0; i < Colors.Count; i++)
            {
                var lineSeries = new LineSeries
                {
                    Color = OxyColor.FromArgb(a: Colors[i].A, r: Colors[i].R, g: Colors[i].G, b: Colors[i].B),
                    MarkerFill = OxyColors.Transparent,
                    DataFieldX = XName,
                    DataFieldY = YName,
                    Background = OxyColor.FromArgb(
                        a: BackgroundColor.A,
                        r: BackgroundColor.R,
                        g: BackgroundColor.G,
                        b: BackgroundColor.B)
                };

                for (int j = 0; j < XValues.Count; j++)
                {
                    lineSeries.Points.Add(new DataPoint(XValues[j], YValues[j]));
                }

                MyModel.Series.Add(lineSeries);
            }


            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = XName });
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = YName });

            myPlot.Model = MyModel;

            myPlot.Dock = System.Windows.Forms.DockStyle.Bottom;
            myPlot.Location = new System.Drawing.Point(0, 0);
            myPlot.Size = new System.Drawing.Size(GraphWidth, GraphHeight);
            myPlot.TabIndex = 0;

            return myPlot;
        }

        public void Export()
        {
            if (Path.EndsWith(".png"))
            {
                var pngExporter = new PngExporter { Width = GraphWidth, Height = GraphHeight,
                    Background = OxyColor.FromArgb(
                        BackgroundColor.A,
                        BackgroundColor.R,
                        BackgroundColor.G,
                        BackgroundColor.B)};
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
                reportPart = "";
            }
            return reportPart;
        }


        public bool ShowGraph { get; set; }
        public string Title { get; set; }
        public List<double> XValues { get; set; }
        public double[,] XValuesTable { get; set; }
        public List<double> YValues { get; set; }
        public double[,] YValuesTable { get; set; }
        public string XName { get; set; }
        public string YName { get; set; }
        public List<Color> Colors { get; set; }
        public Color BackgroundColor { get; set; }
        public int GraphWidth { get; set; }
        public int GraphHeight { get; set; }
        public List<string> TextAnnotations { get; set; }
        public List<double> TextLocationXValues { get; set; }
        public List<double> TextLocationYValues { get; set; }
        public string Path { get; set; }
        public PlotModel MyModel { get; set; }
    }
}
