using System.Collections.Generic;
using System.Drawing;
using OxyPlot.WindowsForms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using PterodactylCharts.Enums;

namespace PterodactylCharts
{
    public class GraphEngine
    {
        public GraphEngine(bool showGraph, GraphElements graphElements, GraphSettings graphSettings, string path)
        {
            ShowGraph = showGraph;
            Elements = graphElements;
            Settings = graphSettings;
            Path = path;
        }
        public PlotView ChartCreator()
        {
            PlotView myPlot = new PlotView();

            MyModel = new PlotModel { Title = Settings.Title };

            for (int i = 0; i < Elements.Data.ValuesNames.Count; i++)
            {
                if (Elements.Data.DataTypes[i].TypeOfData == TypeOfData.Line)
                {
                    AddLineSeries(MyModel, Elements.Data.DataTypes[i], Elements.Data.ValuesNames[i],
                        Elements.Data.XValues[i], Elements.Data.YValues[i]);
                }
                else
                {
                    AddPointSeries(MyModel, Elements.Data.DataTypes[i], Elements.Data.ValuesNames[i],
                        Elements.Data.XValues[i], Elements.Data.YValues[i]);
                }
            }

            MyModel.LegendTitle = Elements.Legend.Title;
            LegendPosition legendPosition = (LegendPosition)Elements.Legend.Position;
            MyModel.LegendPosition = legendPosition;

            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = Settings.Axis.XAxisName });
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = Settings.Axis.YAxisName });

            myPlot.Model = MyModel;

            myPlot.Dock = System.Windows.Forms.DockStyle.Bottom;
            myPlot.Location = new Point(0, 0);
            myPlot.Size = new Size(Settings.Sizes.Width, Settings.Sizes.Height);
            myPlot.TabIndex = 0;

            return myPlot;
        }

        public void Export()
        {
            if (Path.EndsWith(".png"))
            {
                var pngExporter = new PngExporter
                {
                    Width = Settings.Sizes.Width,
                    Height = Settings.Sizes.Height,
                    Background = OxyColor.FromArgb(Settings.GraphColor.A, Settings.GraphColor.R, Settings.GraphColor.G, Settings.GraphColor.B)
                };
                pngExporter.ExportToFile(MyModel, Path);
            }
        }

        public string Create()
        {
            string reportPart;

            if (Path.EndsWith(".png"))
            {
                reportPart = "![" + Settings.Title + "](" + Path + ")";
            }
            else
            {
                reportPart = "";
            }
            return reportPart;
        }
        public void AddLineSeries(PlotModel model, DataType dataType, string valueName, List<double> xValues, List<double> yValues)
        {
            var lineSeries = new LineSeries
            {
                Color = OxyColor.FromArgb(a: dataType.DataColor.A, r: dataType.DataColor.R, g: dataType.DataColor.G, b: dataType.DataColor.B),
                MarkerFill = OxyColors.Transparent,
                DataFieldX = Settings.Axis.XAxisName,
                DataFieldY = Settings.Axis.YAxisName,
                Background = OxyColor.FromArgb(a: Settings.GraphColor.A, r: Settings.GraphColor.R, g: Settings.GraphColor.G, b: Settings.GraphColor.B)
            };

            lineSeries.Title = valueName;

            for (int i = 0; i < xValues.Count; i++)
            {
                lineSeries.Points.Add(new DataPoint(xValues[i], yValues[i]));
            }

            model.Series.Add(lineSeries);
        }

        public void AddPointSeries(PlotModel model, DataType dataType, string valueName, List<double> xValues, List<double> yValues)
        {
            var pointSeries = new ScatterSeries()
            {
                MarkerType = (MarkerType)dataType.Marker,
                MarkerFill = OxyColor.FromArgb(a: dataType.DataColor.A, r: dataType.DataColor.R, g: dataType.DataColor.G, b: dataType.DataColor.B),
                DataFieldX = Settings.Axis.XAxisName,
                DataFieldY = Settings.Axis.YAxisName,
                Background = OxyColor.FromArgb(a: Settings.GraphColor.A, r: Settings.GraphColor.R, g: Settings.GraphColor.G, b: Settings.GraphColor.B)
            };

            pointSeries.Title = valueName;

            for (int i = 0; i < xValues.Count; i++)
            {
                pointSeries.Points.Add(new ScatterPoint(xValues[i], yValues[i]));
            }

            model.Series.Add(pointSeries);
        }

        public bool ShowGraph { get; set; }
        public GraphElements Elements { get; set; }
        public GraphSettings Settings { get; set; }
        public string Path { get; set; }
        public PlotModel MyModel { get; set; }
    }
}
