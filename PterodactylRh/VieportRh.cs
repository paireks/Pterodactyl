using System;
using System.IO;
using Rhino.Display;

namespace PterodactylRh
{
    public class VieportRh
    {
        public void Capture(string vieportName)
        {
            var another_view = Rhino.RhinoDoc.ActiveDoc.Views.Find(vieportName, false);
            var view_capture = new ViewCapture
            {
                Width = another_view.ActiveViewport.Size.Width,
                Height = another_view.ActiveViewport.Size.Height,
                ScaleScreenItems = false,
                DrawAxes = false,
                DrawGrid = false,
                DrawGridAxes = false,
                TransparentBackground = true
            };

            var bitmap = view_capture.CaptureToBitmap(another_view);
            if (null != bitmap)
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var filename = Path.Combine(path, "SampleCsViewCapture.png");
                bitmap.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}