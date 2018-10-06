using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Youtube_dl_Gui
{
    public interface IDownloadManager
    {
        bool ReadStream(string commands);
        event Action<string> UpdateStatus;
    }

    class DownloadManager: IDownloadManager
    {
        public event Action<string> UpdateStatus;

        public bool ReadStream(string commands)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "youtube-dl.exe",
                    Arguments = commands,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                }
            };

            process.Start();

            using (StreamReader pReader = process.StandardOutput)
            {
                string line = "";

                
                if (pReader.BaseStream.CanRead)
                {
                    while (!pReader.EndOfStream)
                    {
                        line = pReader.ReadLine();
                        
                        if (UpdateStatus != null)
                            UpdateStatus(line);

                        
                    }
                }
            }

            process.WaitForExit();
            process.Close();
            return true;
        }

       
    }
}
