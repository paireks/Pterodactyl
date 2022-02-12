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

        public PointGraphEngine PointGraphObject { get; set; }
        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.Escape:
                    this.Close();
                    return true; // signal that we've processed this key
            }

            // run base implementation
            return base.ProcessCmdKey(ref message, keys);
        }

        private void PointGraph_Load(object sender, System.EventArgs e)
        {

        }
    }
}