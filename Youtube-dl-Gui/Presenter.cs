using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Youtube_dl_Gui
{
    class Presenter
    {
        private IMainForm _mainForm;
        private IDownloadManager _downloadManager;

        public Presenter(IMainForm mainForm, IDownloadManager downloadManager)
        {
            _mainForm = mainForm;
            _downloadManager = downloadManager;
            _mainForm.DownloadClick += new EventHandler(Download);
            _mainForm.UpdateClick += new EventHandler(Update);
            _mainForm.VersionClick += new EventHandler(Version);
        }

        public void Download(object sender, EventArgs e)
        {
            string link = _mainForm.urlPath;
            string commands = "";
            string options = "";
            string pathSave = _mainForm.DirPath;

            if (_mainForm.Video)
            {
                options = "-o " + pathSave + "%(title)s.%(ext)s " + "-f bestvideo[ext=mp4]+bestaudio[ext=m4a] --merge-output-format mp4 ";

            }
            else
                if (_mainForm.Audio)
            {
                string output = "-o " + pathSave + "%(title)s.%(ext)s ";

                string format_audio = "[ext=m4a]";
                string format = "-f bestaudio" + format_audio + " ";
                options = output + format;
            }

            commands = options + link;
            _downloadManager.UpdateStatus += ProgressUpdate;

            Thread task = new Thread(() => _downloadManager.ReadStream(commands));
            task.IsBackground = false;
            task.Start();
 
        }


        public void ProgressUpdate(string line)
        {
            int value = 0;
            string pattern = @"[0-9]+(?=\.[0-9]*%)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(line);
            if (matches.Count > 0)
            {
                Match match = matches[0];

                value = Int32.Parse(match.Value);
            }

            _mainForm.DisplayProgress(value);
        }

        public void Update(object sender, EventArgs e)
        {
            
            string commands = "--update";

            Thread task = new Thread(() => _downloadManager.ReadStream(commands));
            task.IsBackground = false;
            task.Start();

        }

        public void Version(object sender, EventArgs e)
        {

            string commands = "--update";

            Thread task = new Thread(() => _downloadManager.ReadStream(commands));
            task.IsBackground = false;
            task.Start();

        }
    }
}
