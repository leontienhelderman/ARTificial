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

        // "openFilePath" gets defined here because it needs to be reachable outside of the OpenFile() function.
        private string openFilePath;

        public FileNav(MainWindow mainWindow)
        {
            // "openFilePath doesn't get initialized here because it gets its value in the OpenFile() function."
            this.mainWindow = mainWindow;
            image = new Image();
        }

        public void OpenFile()
        {
            // Opens file directory for user to choose an svg file.
            OpenFileDialog openFile = new OpenFileDialog();
            
            // Opens "my documents" folder in file explorer.
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            // Filters so only svg's can open.
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
                // "saveFilePath" gets defined and initialized here because it only needs to be reached within GetSaveFilePath().
                string saveFilePath = saveFile.FileName;
                return saveFilePath;
            }
            return "";
        }
    }
}
