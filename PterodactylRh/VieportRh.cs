using System;
using System.Drawing;
using System.IO;
using Rhino.Display;

namespace PterodactylRh
{
    public class VieportRh
    {
        public void Capture(string vieportName, string pathToFile, bool drawAxes, bool drawGrid, bool drawGridAxes, bool transparentBackground)
        {
            var view = Rhino.RhinoDoc.ActiveDoc.Views.Find(vieportName, false);
            var view_capture = new ViewCapture
            {
                Width = view.ActiveViewport.Size.Width,
                Height = view.ActiveViewport.Size.Height,
                ScaleScreenItems = false,
                DrawAxes = drawAxes,
                DrawGrid = drawGrid,
                DrawGridAxes = drawGridAxes,
                TransparentBackground = transparentBackground
            };

            var bitmap = view_capture.CaptureToBitmap(view);
            if (null != bitmap)
            {
                bitmap.Save(pathToFile, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        public Bitmap CaptureToBitmap(string vieportName, bool drawAxes, bool drawGrid, bool drawGridAxes, bool transparentBackground)
        {
            var view = Rhino.RhinoDoc.ActiveDoc.Views.Find(vieportName, false);
            var view_capture = new ViewCapture
            {
                Width = view.ActiveViewport.Size.Width,
                Height = view.ActiveViewport.Size.Height,
                ScaleScreenItems = false,
                DrawAxes = drawAxes,
                DrawGrid = drawGrid,
                DrawGridAxes = drawGridAxes,
                TransparentBackground = transparentBackground
            };

            return view_capture.CaptureToBitmap(view);
        }
    }
}