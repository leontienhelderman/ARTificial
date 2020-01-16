using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTificial
{
    public class FileNav
    {
        private MainWindow mainWindow;
        private Image image;
        private string openFilePath;
        private string saveFilePath;

        public FileNav(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            image = new Image();
        }

        public void OpenFile()
        {
            // Opens file directory for user to choose an svg file.
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFile.Filter = "svg files (*.svg) | *.svg";
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == true)
            {
                mainWindow.GetFile1().Text = "File loaded.";
                mainWindow.GetImage1().Source = image.ConvertToPng(openFile);
                openFilePath = openFile.FileName;
            }
        }

        public string GetOpenFilePath()
        {
            return openFilePath;
        }

        public string GetSaveFilePath()
        {
            // Opens file directory for user to choose where to save the gcode file.
            SaveFileDialog saveFile = new SaveFileDialog()
            {
                FileName = "G-Code.GCODE",
                Filter = "GCODE (*GCODE) | *GCODE",
                Title = "Save Gcode",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (saveFile.ShowDialog() == true)
            {
                saveFilePath = saveFile.FileName;
                return saveFilePath;
            }
            return "";
        }
    }
}
