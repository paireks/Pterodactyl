using System.Collections.Generic;
using System.Drawing;
using OxyPlot.WindowsForms;
using System.Windows.Forms;

namespace PterodactylCharts
{
    public partial class PointGraph : Form
    {
        public PointGraph()
        {
            InitializeComponent();
        }

        public void PointGraphData(bool showGraph, string title,
            List<double> xValues, List<double> yValues, string xName,
            string yName, Color color, string path)
        {
            PointGraphObject = new PointGraphEngine(showGraph, title, xValues, yValues, xName, yName, color, path);
            PlotView myPlot = PointGraphObject.ChartCreator();
            Controls.Add(myPlot);
        }
        public string Create()
        {
            string reportPart = PointGraphObject.Create();
            return reportPart;
        }

        public void Export()
        {
            PointGraphObject.Export();
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
            Text = $@"Point Graph [{Size.Width}x{Size.Height}px] - Press Esc to close...";
        }

        public PointGraphEngine PointGraphObject { get; set; }
    }
}