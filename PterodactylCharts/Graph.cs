using OxyPlot.WindowsForms;
using System.Windows.Forms;

namespace PterodactylCharts
{
    public partial class Graph : Form
    {
        string title = "Graph";
        public Graph()
        {
            InitializeComponent();
        }

        public void GraphData(bool showGraph, GraphElements graphElements, GraphSettings graphSettings, string path)
        {
            GraphObject = new GraphEngine(showGraph, graphElements, graphSettings, path);
            PlotView myPlot = GraphObject.ChartCreator();
            this.Size = myPlot.Size;
            Text = $"{title} [{this.Size.Width}x{this.Size.Height}px] - Press Esc to close ...  ";
            Controls.Add(myPlot);
        }
        public string Create()
        {
            string reportPart = GraphObject.Create();
            return reportPart;
        }

        public void Export()
        {
            GraphObject.Export();
        }

        public GraphEngine GraphObject { get; set; }

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


        private void Graph_Load(object sender, System.EventArgs e)
        {

        }

        private void Graph_SizeChanged(object sender, System.EventArgs e)
        {
            Text = $"{title} [{this.Size.Width}x{this.Size.Height}px] - Press Esc to close ...  ";
        }
    }
}
