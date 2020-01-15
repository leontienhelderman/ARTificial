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
        private int count = 0;

        public BitmapImage ConvertToPng(OpenFileDialog openFile)
        {
            string path = openFile.FileName;
            var svgDocument = Svg.SvgDocument.Open(path);
            svgDocument.ShapeRendering = SvgShapeRendering.Auto;
            Bitmap bmp = svgDocument.Draw((int)svgDocument.Width.Value, (int)svgDocument.Height.Value);
            bmp.Save(System.IO.Path.GetTempPath().ToString() + "sample" + count + ".png", ImageFormat.Png);
            BitmapImage image = new BitmapImage(new Uri(System.IO.Path.GetTempPath().ToString() + "sample" + count + ".png"));
            count++;
            return image;
        }
    }
}
