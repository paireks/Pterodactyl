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
    public class ColumnChartEngine
    {

        public ColumnChartEngine(bool showGraph, string title,
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

            var columnSeries = new ColumnSeries
            {
                Background = OxyColors.White

            };

            for (int i = 0; i < Values.Count; i++)
            {
                columnSeries.Items.Add(new ColumnItem { Value = Values[i], Color = OxyColor.FromArgb(a: Colors[i].A, r: Colors[i].R, g: Colors[i].G, b: Colors[i].B) });
            }

            columnSeries.LabelFormatString = TextFormat;
            columnSeries.LabelPlacement = LabelPlacement.Middle;

            MyModel.Series.Add(columnSeries);

            MyModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                ItemsSource = Names
            });

            myPlot.Model = MyModel;

            myPlot.Dock = DockStyle.Bottom;
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
        public List<double> Values { get; set; }
        public List<string> Names { get; set; }
        public string TextFormat { get; set; }
        public List<Color> Colors { get; set; }
        public string Path { get; set; }
        public PlotModel MyModel { get; set; }
    }
}
