using System.Collections.Generic;
using System.Drawing;
using OxyPlot.WindowsForms;
using System.Windows.Forms;

namespace PterodactylCharts
{
    public partial class ColumnChart : Form
    {
        public ColumnChart()
        {
            InitializeComponent();
        }

        public void ColumnChartData(bool showGraph, string title,
            List<double> values, List<string> names, string textFormat,
            List<Color> colors, string path)
        {
            ColumnChartObject = new ColumnChartEngine(showGraph, title, values, names, textFormat, colors, path);
            PlotView myPlot = ColumnChartObject.ChartCreator();
            Controls.Add(myPlot);
        }
        public string Create()
        {
            string reportPart = ColumnChartObject.Create();
            return reportPart;
        }

        public void Export()
        {
            ColumnChartObject.Export();
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
            Text = $@"Column Chart [{Size.Width}x{Size.Height}px] - Press Esc to close...";
        }

        public ColumnChartEngine ColumnChartObject { get; set; }
    }
}