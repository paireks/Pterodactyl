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
            GraphObject = new GraphEngine(showGraph, graphElements, graphSettings, path);
            PlotView myPlot = GraphObject.ChartCreator();
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
    }
}
