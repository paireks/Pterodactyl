using System.Collections.Generic;
using System.Drawing;
using OxyPlot.WindowsForms;
using System.Windows.Forms;

namespace PterodactylCharts
{
    public partial class PieChart : Form
    {
        public PieChart()
        {
            InitializeComponent();
        }

        public void PieChartData(bool showGraph, string title,
            List<double> values, List<string> names,
            List<Color> colors, string path)
        {
            PieChartObject = new PieChartEngine(showGraph, title, values, names, colors, path);
            PlotView myPlot = PieChartObject.ChartCreator();
            Controls.Add(myPlot);
        }
        public string Create()
        {
            string reportPart = PieChartObject.Create();
            return reportPart;
        }

        public void Export()
        {
            PieChartObject.Export();
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
            Text = $@"Pie Chart [{Size.Width}x{Size.Height}px] - Press Esc to close...";
        }

        public PieChartEngine PieChartObject { get; set; }
    }
}