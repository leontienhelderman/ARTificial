using Microsoft.Win32;
using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ARTificial
{
    public class Image
    {
        // int so different svg's get different file names.
        private int count;

        public Image()
        {
            count = 0;
        }

        // Converts chosen svg to png.
        public BitmapImage ConvertToPng(OpenFileDialog openFile)
        {
            // Creates a string from the filename.
            string path = openFile.FileName;
            
            // Opens chosen svg by using the "path" string.
            var svgDocument = Svg.SvgDocument.Open(path);
            svgDocument.ShapeRendering = SvgShapeRendering.Auto;
            
            // Draws bitmap using the width and height values of the svg.
            Bitmap bmp = svgDocument.Draw((int)svgDocument.Width.Value, (int)svgDocument.Height.Value);
            
            // Saves the bitmap as a .png
            bmp.Save(System.IO.Path.GetTempPath().ToString() + "sample" + count + ".png", ImageFormat.Png);
            
            // Saves png image in a temporary path.
            BitmapImage image = new BitmapImage(new Uri(System.IO.Path.GetTempPath().ToString() + "sample" + count + ".png"));
            
            // count + 1, this way you can convert multiple svg's without them getting the same name as png.
            count++;
            return image;
        }
    }
}
