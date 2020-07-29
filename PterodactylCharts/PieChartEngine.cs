using System;
using System.Collections.Generic;
using System.Drawing;
using OxyPlot.WindowsForms;
using OxyPlot;
using System.Windows.Forms;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace PterodactylCharts
{
    public class PieChartEngine
    {

        public PieChartEngine(bool showGraph, string title,
            List<double> values, List<string> names, List<Color> colors, string path)
        {
            ShowGraph = showGraph;
            Title = title;
            Values = values;
            Names = names;
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

            var pieSeries = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            for (int i = 0; i < Values.Count; i++)
            {
                pieSeries.Slices.Add(new PieSlice(Names[i], Values[i]) { IsExploded = false,
                    Fill = OxyColor.FromArgb(Colors[i].A, Colors[i].R, Colors[i].G, Colors[i].B) });
            }

            MyModel.Series.Add(pieSeries);

            myPlot.Model = MyModel;

            myPlot.Dock = DockStyle.Bottom;
            myPlot.Location = new Point(0, 0);
            myPlot.Size = new Size(400, 400);
            myPlot.TabIndex = 0;

            return myPlot;
        }

        public void Export()
        {
            if (Path.EndsWith(".png"))
            {
                var pngExporter = new PngExporter { Width = 400, Height = 400, Background = OxyColors.White };
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
        public List<Color> Colors { get; set; }
        public string Path { get; set; }
        public PlotModel MyModel { get; set; }
    }
}
