using System.Collections.Generic;
using System.Drawing;
using OxyPlot.WindowsForms;
using System.Windows.Forms;

namespace PterodactylCharts
{
    public partial class BarChart : Form
    {
        public BarChart()
        {
            InitializeComponent();
        }

        public void BarChartData(bool showGraph, string title,
            List<double> values, List<string> names, string textFormat,
            List<Color> colors, string path)
        {
            BarChartObject = new BarChartEngine(showGraph, title, values, names, textFormat, colors, path);
            PlotView myPlot = BarChartObject.ChartCreator();
            Controls.Add(myPlot);
        }
        public string Create()
        {
            string reportPart = BarChartObject.Create();
            return reportPart;
        }

        public void Export()
        {
            BarChartObject.Export();
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.Escape:
                    Close();
                    return true;
            }
            return base.ProcessCmdKey(ref message, keys);
        }
        
        private void OnResize(object sender, System.EventArgs e)
        {
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            Text = $@"Bar Chart [{ClientSize.Width}x{ClientSize.Height}px]";
        }

        public BarChartEngine BarChartObject { get; set; }
    }
}
