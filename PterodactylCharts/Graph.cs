using OxyPlot.WindowsForms;
using System.Windows.Forms;

namespace PterodactylCharts
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
        }

        public void GraphData(bool showGraph, GraphElements graphElements, GraphSettings graphSettings, string path)
        {
            //set windows proportions to the size the user set
            ClientSize = new System.Drawing.Size(graphSettings.Sizes.Width, graphSettings.Sizes.Height);
            GraphObject = new GraphEngine(showGraph, graphElements, graphSettings, path);
            PlotView myPlot = GraphObject.ChartCreator();
            Controls.Add(myPlot);
            UpdateTitle();   
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
            // client size is more accurate measuere than Size. It corresponds to the saved file dimensions
            Text = $@"Graph [{ClientSize.Width}x{ClientSize.Height}px]"; // remove esc as it is intuitive
        }
    }
}
