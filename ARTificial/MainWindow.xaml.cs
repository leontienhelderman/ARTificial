using System.Windows;
using System.Windows.Controls;

namespace ARTificial
{
    public partial class MainWindow : Window
    {

        GCode gCode;
        FileNav fileNav;

        public string dpiSetting;

        // New instance of fileNav class with parameter
        public MainWindow()
        {
            InitializeComponent();
            fileNav = new FileNav(this);
        }

        // Calls the OpenFile function from the fileNav class.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fileNav.OpenFile();
        }

        // Calls the Convert function.
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            Convert();
        }

        // New instance of gCode class, calls function from gCode class
        private void Convert()
        {
            gCode = new GCode(fileNav.GetOpenFilePath(), TextboxDPI.Text, fileNav.GetSaveFilePath());
            gCode.LaunchCommandLineApp();
            ConvertText.Text = "Converted.";
        }

        public TextBlock GetFile1()
        {
            return this.file1;
        }

        public System.Windows.Controls.Image GetImage1()
        {
            return this.image1;
        }

        public TextBox GetTextboxDPI()
        {
            return this.TextboxDPI;
        }
    }
}

