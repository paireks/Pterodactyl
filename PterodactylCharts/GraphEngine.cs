using System.Drawing;
using OxyPlot.WindowsForms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

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

            if (Settings.Type == 0)
            {
                AddLineSeries(MyModel);
            }
            else if (Settings.Type == 1)
            {
                AddPointSeries(MyModel);
            }

            MyModel.LegendTitle = Elements.Legend.Title;
            LegendPosition legendPosition = (LegendPosition)Elements.Legend.Position;
            MyModel.LegendPosition = legendPosition;

            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = Settings.Axis.XAxisName });
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = Settings.Axis.YAxisName });

            myPlot.Model = MyModel;

            myPlot.Dock = System.Windows.Forms.DockStyle.Bottom;
            myPlot.Location = new System.Drawing.Point(0, 0);
            myPlot.Size = new System.Drawing.Size(Settings.Sizes.Width, Settings.Sizes.Height);
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
                    Background = OxyColor.FromArgb(
                        Settings.Colors.BackgroundColor.A,
                        Settings.Colors.BackgroundColor.R,
                        Settings.Colors.BackgroundColor.G,
                        Settings.Colors.BackgroundColor.B)
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
        public void AddLineSeries(PlotModel model)
        {

            for (int i = 0; i < Elements.Data.ValuesNames.Count; i++)
            {
                var lineSeries = new LineSeries
                {
                    Color = OxyColor.FromArgb(a: Settings.Colors.DataColors[i].A,
                        r: Settings.Colors.DataColors[i].R,
                        g: Settings.Colors.DataColors[i].G,
                        b: Settings.Colors.DataColors[i].B),
                    MarkerFill = OxyColors.Transparent,
                    DataFieldX = Settings.Axis.XAxisName,
                    DataFieldY = Settings.Axis.YAxisName,
                    Background = OxyColor.FromArgb(
                        a: Settings.Colors.BackgroundColor.A,
                        r: Settings.Colors.BackgroundColor.R,
                        g: Settings.Colors.BackgroundColor.G,
                        b: Settings.Colors.BackgroundColor.B)
                };

                lineSeries.Title = Elements.Data.ValuesNames[i];

                for (int j = 0; j < Elements.Data.XValues[i].Count; j++)
                {
                    lineSeries.Points.Add(new DataPoint(Elements.Data.XValues[i][j], Elements.Data.YValues[i][j]));
                }

                model.Series.Add(lineSeries);
            }
        }

        public void AddPointSeries(PlotModel model)
        {
            for (int i = 0; i < Elements.Data.ValuesNames.Count; i++)
            {
                var pointSeries = new ScatterSeries()
                {
                    MarkerType = MarkerType.Circle,
                    MarkerFill = OxyColor.FromArgb(a: Settings.Colors.DataColors[i].A,
                        r: Settings.Colors.DataColors[i].R,
                        g: Settings.Colors.DataColors[i].G,
                        b: Settings.Colors.DataColors[i].B),
                    DataFieldX = Settings.Axis.XAxisName,
                    DataFieldY = Settings.Axis.YAxisName,
                    Background = OxyColor.FromArgb(
                        a: Settings.Colors.BackgroundColor.A,
                        r: Settings.Colors.BackgroundColor.R,
                        g: Settings.Colors.BackgroundColor.G,
                        b: Settings.Colors.BackgroundColor.B)
                };

                pointSeries.Title = Elements.Data.ValuesNames[i];

                for (int j = 0; j < Elements.Data.XValues[i].Count; j++)
                {
                    pointSeries.Points.Add(new ScatterPoint(Elements.Data.XValues[i][j], Elements.Data.YValues[i][j]));
                }

                model.Series.Add(pointSeries);
            }
        }

        public bool ShowGraph { get; set; }
        public GraphElements Elements { get; set; }
        public GraphSettings Settings { get; set; }
        public string Path { get; set; }
        public PlotModel MyModel { get; set; }
    }
}
