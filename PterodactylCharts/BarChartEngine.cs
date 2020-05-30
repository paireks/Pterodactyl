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
    public class BarChartEngine
    {

        public BarChartEngine(bool showGraph, string title,
            List<double> values, List<string> names, string textFormat, List<Color> colors, string path)
        {
            ShowGraph = showGraph;
            Title = title;
            Values = values;
            Names = names;
            TextFormat = textFormat;
            Colors = colors;
            Path = path;

            if (Values.Count != Names.Count || Values.Count != Colors.Count)
            {
                throw new ArgumentException(
                    "Values should match Names and Colors - check if each list has the same number of elements.");
            }
        }

        public PlotView ChartCreator()
        {
            PlotView myPlot = new PlotView();

            MyModel = new PlotModel { Title = Title };

            var barSeries = new BarSeries
            {
                Background = OxyColors.White

            };

            for (int i = 0; i < Values.Count; i++)
            {
                barSeries.Items.Add(new BarItem{Value = Values[i], Color = OxyColor.FromArgb(a: Colors[i].A, r: Colors[i].R, g: Colors[i].G, b: Colors[i].B)});
            }

            barSeries.LabelFormatString = TextFormat;
            barSeries.LabelPlacement = LabelPlacement.Middle;

            MyModel.Series.Add(barSeries);

            MyModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = Names
            });

            myPlot.Model = MyModel;

            myPlot.Dock = System.Windows.Forms.DockStyle.Bottom;
            myPlot.Location = new System.Drawing.Point(0, 0);
            myPlot.Size = new System.Drawing.Size(600, 400);
            myPlot.TabIndex = 0;

            return myPlot;
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
                reportPart = "";
            }
            return reportPart;
        }

        public bool ShowGraph { get; set; }
        public string Title { get; set; }
        public List<double> Values { get; set; }
        public List<string> Names { get; set; }
        public string TextFormat { get; set; }
        public List<Color> Colors { get; set; }
        public string Path { get; set; }
        public PlotModel MyModel { get; set; }
    }
}
