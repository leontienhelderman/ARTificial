using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTificial
{
    public class GCode
    {
        private string dpi;
        private string exportPath;
        private string inputFile;

        public GCode(string inputFile, string dpiSetting, string outputPath)
        {
            dpi = dpiSetting;
            this.inputFile = inputFile;
            exportPath = outputPath;
        }

        public void LaunchCommandLineApp()
        {
            // Use ProcessStartInfo class.
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = true;
            // Currently hard-coded, should change to OpenFileDialog for location selection. Change the file location to where you have juicy-gcode.exe have installed.
            startInfo.FileName = "C:\\Users\\LHeld\\Desktop\\juicy-gcode-0.1.0.5\\juicy-gcode.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = inputFile + " --output " + exportPath + " --dpi " + dpi;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                // Because of the try catch statement the application won't crash when the try{} can't be executed.
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
