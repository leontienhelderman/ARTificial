using System.Windows;
using System.Windows.Controls;

namespace ARTificial
{
    public partial class MainWindow : Window
    {

        GCode gCode;
        FileNav fileNav;

        public MainWindow()
        {
            InitializeComponent();
            fileNav = new FileNav(this);
        }

        public string dpiSetting;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fileNav.OpenFile();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            Convert();
        }

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

