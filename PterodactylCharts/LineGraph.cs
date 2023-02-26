using System.Collections.Generic;
using System.Drawing;
using OxyPlot.WindowsForms;
using System.Windows.Forms;

namespace PterodactylCharts
{
    public partial class LineGraph : Form
    {
        public LineGraph()
        {
            InitializeComponent();
        }

        public void LineGraphData(bool showGraph, string title,
            List<double> xValues, List<double> yValues, string xName, string yName,
            Color color, string path)
        {
            LineGraphObject = new LineGraphEngine(showGraph, title, xValues, yValues, xName, yName, color, path);
            PlotView myPlot = LineGraphObject.ChartCreator();
            Controls.Add(myPlot);
        }
        public string Create()
        {
            string reportPart = LineGraphObject.Create();
            return reportPart;
        }

        public void Export()
        {
            LineGraphObject.Export();
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
            Text = $@"Line Graph [{ClientSize.Width}x{ClientSize.Height}px]";
        }

        public LineGraphEngine LineGraphObject { get; set; }
    }
}
