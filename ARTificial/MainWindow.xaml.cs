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
using System.Diagnostics;

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

        //instantiate/define classes
        Image image = new Image();
        GCode gCode;

        //Instantiate variables
        public string dpiSetting;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            gCode = new GCode(TextboxDPI.Text, TextboxOutputPath.Text);
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
    public class Image
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

            return new BitmapImage(new Uri(System.IO.Path.GetTempPath().ToString() + "sample" + count + ".png"));
            //count++;
        }
    }

    public class GCode 
    {
        private string dpi;
        private string exportPath;

        public GCode(string dpiSetting, string outputPath)
        {
            dpi = dpiSetting;
            exportPath = outputPath;
        }


        public void ConvertToGCode()
        {
            // command argument dingetje = "--dpi " + dpiSetting
        }

        public void LaunchCommandLineApp()
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = true;
            startInfo.FileName = "dcm2jpg.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "--output " + exportPath + " --dpi " + dpi;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
        }
    }
}

