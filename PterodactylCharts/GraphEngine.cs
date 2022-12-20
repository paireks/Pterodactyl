using System.Collections.Generic;
using System.Drawing;
using OxyPlot.WindowsForms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Annotations;
using System;
using System.Linq;

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

            MyModel = new PlotModel { Title = Settings.Title, TitleFontSize = Settings.TitleSize };
            int positionTier = 0;

            for (int i = 0; i < Elements.Data.DataTypes.Count; i++)
            {
                if (Elements.Data.DataTypes[i].TypeOfData == Enums.TypeOfData.Line)
                {
                    AddLineSeries(MyModel, Elements.Data.DataTypes[i], Elements.Data.ValuesNames[i],
                        Elements.Data.XValues[i], Elements.Data.YValues[i]);
                }
                else if (Elements.Data.DataTypes[i].TypeOfData == Enums.TypeOfData.Point)
                {
                    AddPointSeries(MyModel, Elements.Data.DataTypes[i], Elements.Data.ValuesNames[i],
                        Elements.Data.XValues[i], Elements.Data.YValues[i]);
                }
                else if (Elements.Data.DataTypes[i].TypeOfData  == Enums.TypeOfData.Scatter)
                {
                    MyModel.Axes.Add(CreateLinearColorAxis(i, positionTier));
                    positionTier++;
                    AddScatterSeries(MyModel, Elements.Data.DataTypes[i],
                        Elements.Data.XValues[i], Elements.Data.YValues[i], MyModel.Axes.Last().Key);
                }
                else
                {
                    AddAnnotations(MyModel, Elements.Data.DataTypes[i],
                        Elements.Data.XValues[i], Elements.Data.YValues[i]);
                }
            }

            MyModel.LegendTitle = Elements.Legend.Title;
            MyModel.LegendFontSize = Elements.Legend.TextSize;
            MyModel.LegendPosition = (LegendPosition)Elements.Legend.Position;
            MyModel.LegendPlacement = (LegendPlacement)Elements.Legend.Placement;
            MyModel.LegendOrientation = (LegendOrientation)Elements.Legend.Orientation;

            MyModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = Settings.Axis.XAxisName,
                MinimumPadding = Settings.Axis.GlobalAxisPadding,
                MaximumPadding = Settings.Axis.GlobalAxisPadding,
                FontSize = Settings.Axis.TextSize,
                AxisTitleDistance = 5
            });
            MyModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = Settings.Axis.YAxisName,
                FontSize = Settings.Axis.TextSize,
                MinimumPadding = Settings.Axis.GlobalAxisPadding,
                MaximumPadding = Settings.Axis.GlobalAxisPadding,
                AxisTitleDistance = 5
            });
            MyModel.Padding = new OxyThickness(Settings.Padding);
            myPlot.Model = MyModel;
            myPlot.Dock = System.Windows.Forms.DockStyle.Fill;
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
            else if (Path.EndsWith(".svg"))
            {
                var svgExporter = new OxyPlot.WindowsForms.SvgExporter
                {
                    Width = Settings.Sizes.Width,
                    Height = Settings.Sizes.Height,
                };
                svgExporter.ExportToFile(MyModel, Path);
            }
            else
                throw new ArgumentException("Supported file extensions are only .png or .svg");
        }

        public string Create()
        {
            string reportPart;

            if (Path.EndsWith(".png") || Path.EndsWith(".svg"))
            {
                reportPart = "![" + Settings.Title + "](" + Path + ")";
            }
            else
            {
                reportPart = "";
            }
            return reportPart;
        }

        private void AddLineSeries(PlotModel model, DataType dataType, string valueName, List<double> xValues, List<double> yValues)
        {
            var lineSeries = new LineSeries
            {
                Color = OxyColor.FromArgb(a: dataType.DataColor.A, r: dataType.DataColor.R, g: dataType.DataColor.G, b: dataType.DataColor.B),
                MarkerFill = OxyColors.Transparent,
                DataFieldX = Settings.Axis.XAxisName,
                DataFieldY = Settings.Axis.YAxisName,
                Background = OxyColor.FromArgb(a: Settings.GraphColor.A, r: Settings.GraphColor.R, g: Settings.GraphColor.G, b: Settings.GraphColor.B)
            };

            switch (dataType.LineInterpolation)
            {
                case 1:
                    lineSeries.InterpolationAlgorithm = InterpolationAlgorithms.UniformCatmullRomSpline;
                    break;
                case 2:
                    lineSeries.InterpolationAlgorithm = InterpolationAlgorithms.CatmullRomSpline;
                    break;
                case 3:
                    lineSeries.InterpolationAlgorithm = InterpolationAlgorithms.CanonicalSpline;
                    break;
                case 4:
                    lineSeries.InterpolationAlgorithm = InterpolationAlgorithms.ChordalCatmullRomSpline;
                    break;
            }

            lineSeries.LineStyle = (LineStyle) dataType.LineStyle;
            lineSeries.StrokeThickness = dataType.LineWeight;
            lineSeries.Title = valueName;

            for (int i = 0; i < xValues.Count; i++)
            {
                lineSeries.Points.Add(new DataPoint(xValues[i], yValues[i]));
            }

            model.Series.Add(lineSeries);
        }

        private void AddPointSeries(PlotModel model, DataType dataType, string valueName, List<double> xValues, List<double> yValues)
        {
            var pointSeries = new ScatterSeries()
            {
                MarkerType = (MarkerType)dataType.Marker,
                MarkerFill = OxyColor.FromArgb(a: dataType.DataColor.A, r: dataType.DataColor.R, g: dataType.DataColor.G, b: dataType.DataColor.B),
                DataFieldX = Settings.Axis.XAxisName,
                DataFieldY = Settings.Axis.YAxisName,
                Background = OxyColor.FromArgb(a: Settings.GraphColor.A, r: Settings.GraphColor.R, g: Settings.GraphColor.G, b: Settings.GraphColor.B)
            };

            if (dataType.Marker > 0)
            {
                pointSeries.MarkerSize = dataType.MarkerSizes[0];
                if (dataType.Marker > 4)
                    pointSeries.MarkerStroke = OxyColor.FromArgb(a: dataType.DataColor.A, r: dataType.DataColor.R, g: dataType.DataColor.G, b: dataType.DataColor.B);
            }
            else
                pointSeries.MarkerFill = OxyColors.Transparent;
            
            pointSeries.Title = valueName;

            for (int i = 0; i < xValues.Count; i++)
            {
                pointSeries.Points.Add(new ScatterPoint(xValues[i], yValues[i]));
            }

            model.Series.Add(pointSeries);
        }

        private void AddScatterSeries(PlotModel model, DataType dataType, List<double> xValues, List<double> yValues, string key)
        {
            var scatter = new ScatterSeries
            {
                MarkerType = (MarkerType)dataType.Marker,
                ColorAxisKey = key,
                DataFieldX = Settings.Axis.XAxisName,
                DataFieldY = Settings.Axis.YAxisName,
                Background = OxyColor.FromArgb(a: Settings.GraphColor.A, r: Settings.GraphColor.R, g: Settings.GraphColor.G, b: Settings.GraphColor.B),
                RenderInLegend = false
            };

            for (int i = 0; i < xValues.Count; i++)
            {
                scatter.Points.Add(new ScatterPoint(xValues[i], yValues[i], dataType.MarkerSizes[i], dataType.ScatterValues[i]));
            }

            model.Series.Add(scatter);
        }

        private void AddAnnotations(PlotModel model, DataType dataType, List<double> xValues, List<double> yValues)
        {
            if (xValues.Count != dataType.AnnotationTexts.Length)
                throw new ArgumentException("Annotation should contain count of items corresponding to X and Y axis");

            for (int i = 0; i < xValues.Count; i++)
            {
                var pta = new PointAnnotation
                {
                    X = xValues[i],
                    Y = yValues[i],
                    Text = dataType.AnnotationTexts[i],
                    FontSize = dataType.AnnotationTextSize
                };
                switch (dataType.AnnotationTextPosition)
                {
                    case 0:
                        pta.TextHorizontalAlignment = HorizontalAlignment.Center;
                        pta.TextVerticalAlignment = VerticalAlignment.Middle;
                        break;
                    case 1:
                        pta.TextHorizontalAlignment = HorizontalAlignment.Left;
                        pta.TextVerticalAlignment = VerticalAlignment.Middle;
                        break;
                    case 2:
                        pta.TextHorizontalAlignment = HorizontalAlignment.Right;
                        pta.TextVerticalAlignment = VerticalAlignment.Middle;
                        break;
                    case 3:
                        pta.TextHorizontalAlignment = HorizontalAlignment.Center;
                        pta.TextVerticalAlignment = VerticalAlignment.Top;
                        break;
                    case 4:
                        pta.TextHorizontalAlignment = HorizontalAlignment.Center;
                        pta.TextVerticalAlignment = VerticalAlignment.Bottom;
                        break;
                }
                pta.Fill = OxyColors.Transparent;
                model.Annotations.Add(pta);
            }
        }

        private LinearColorAxis CreateLinearColorAxis(int dataId, int positionTier)
        {
            return new LinearColorAxis
            {
                Position = AxisPosition.Right,
                Title = Elements.Data.ValuesNames[dataId],
                MinimumPadding = Settings.Axis.GlobalAxisPadding,
                MaximumPadding = Settings.Axis.GlobalAxisPadding,
                AxisTitleDistance = 5,
                PositionTier = positionTier, // this allows for multiple tiers if colors are provided in GH
                Key = "ColorAxis_" + dataId, // setting the key helps identify the tiers
                Minimum = Elements.Data.DataTypes[dataId].ScatterValues.Min(),
                Maximum = Elements.Data.DataTypes[dataId].ScatterValues.Max(),
                Palette = new OxyPalette(Elements.Data.DataTypes[dataId].ScatterPalette.Select(c =>
                    OxyColor.FromArgb(a: c.A, r: c.R, g: c.G, b: c.B)))
            };
        } 

        public bool ShowGraph { get; }
        public GraphElements Elements { get; }
        public GraphSettings Settings { get; }
        public string Path { get; }
        private PlotModel MyModel { get; set; }
    }
}
