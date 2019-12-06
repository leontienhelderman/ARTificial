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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = "C:\\Users\\Lheld\\Pictures";
            openFile.Filter = "svg files (*.svg) | *.svg";
            openFile.RestoreDirectory = true;

            if(openFile.ShowDialog() == true)
            {
                file1.Text = "File loaded.";
                var svgDocument = Svg.SvgDocument.Open("C:\\Users\\Lheld\\Pictures\\generated_image.svg");
                svgDocument.ShapeRendering = SvgShapeRendering.Auto;

                Bitmap bmp = svgDocument.Draw(12, 12);
                bmp.Save("C:\\Users\\Lheld\\Pictures\\sample.png", ImageFormat.Png);

                string selectedFile = openFile.FileName;
                fileName.Content = selectedFile;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFile);
                bitmap.EndInit();
                image1.Source = bitmap;
            }
        }
    }
}
