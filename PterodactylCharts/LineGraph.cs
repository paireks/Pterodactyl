using System;
using System.Collections.Generic;
using System.IO;
using OxyPlot.WindowsForms;
using OxyPlot;
using System.Windows.Forms;
using OxyPlot.Series;

namespace PterodactylCharts
{
    public partial class LineGraph : Form
    {
        public LineGraph()
        {

            InitializeComponent();

            //Create Plotview object
            PlotView myPlot = new PlotView();

            //Create Plotmodel object
            var myModel = new PlotModel { Title = Title };

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

            //Assign PlotModel to PlotView
            myPlot.Model = myModel;

            //Set up plot for display
            myPlot.Dock = System.Windows.Forms.DockStyle.Bottom;
            myPlot.Location = new System.Drawing.Point(GraphSizeSettings[0], GraphSizeSettings[1]);
            myPlot.Size = new System.Drawing.Size(GraphSizeSettings[2], GraphSizeSettings[3]);
            myPlot.TabIndex = 0;

            //Add plot control to form
            Controls.Add(myPlot);
        }


    }
    public class LineGraphData
    {
        public LineGraphData(bool showGraph, string title,
            List<double> xValues, List<double> yValues, string xName,
            string yName,
            List<int> graphSizeSettings, string path)
        {
            ShowGraph = showGraph;
            Title = title;
            XValues = xValues;
            YValues = yValues;
            XName = xName;
            YName = yName;
            GraphSizeSettings = graphSizeSettings;
            Path = path;
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
