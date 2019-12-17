using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using Svg;
using System.Drawing;
using System.Drawing.Imaging;

namespace ARTificial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //instantiate classes
        Image image = new Image();
        GCode gCode = new GCode();

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFile.Filter = "svg files (*.svg) | *.svg";
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == true)
            {
                file1.Text = "File loaded.";
                image1.Source = image.ConvertToPng(openFile);
            }
        }
    }
    class Image
    {
        // constructor
        public Image()
        {

        }

        int count = 0;
        public BitmapImage ConvertToPng(OpenFileDialog openFile)
        {
            string path = openFile.FileName;
            var svgDocument = Svg.SvgDocument.Open(path);
            svgDocument.ShapeRendering = SvgShapeRendering.Auto;
            Bitmap bmp = svgDocument.Draw((int)svgDocument.Width.Value, (int)svgDocument.Height.Value);
            bmp.Save(System.IO.Path.GetTempPath().ToString() + "sample" + count + ".png", ImageFormat.Png);

            count++;
            return new BitmapImage(new Uri(System.IO.Path.GetTempPath().ToString() + "sample" + count + ".png"));
        }
    }

    class GCode
    {
        public GCode()
        {

        }

        public void ConvertToGCode()
        {

        }
    }

}
