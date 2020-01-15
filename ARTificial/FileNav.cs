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
