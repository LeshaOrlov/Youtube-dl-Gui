﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Youtube_dl_Gui
{
    class MainPresenter
    {
        List<string> listURL = null;
        private IMainForm _mainForm;
        private IDownloadManager _downloadManager;

        public MainPresenter(IMainForm mainForm, IDownloadManager downloadManager)
        {
            _mainForm = mainForm;
            _downloadManager = downloadManager;
            _mainForm.DownloadClick += new EventHandler(StartDownloads);
            _mainForm.UpdateClick += new EventHandler(Update);
            _mainForm.VersionClick += new EventHandler(Version);
        }

        public async void StartDownloads(object sender, EventArgs e)
        {
            List<string> links = _mainForm.urlPaths;
            string commands = "";
            string options = "";
            string pathSave = _mainForm.DirPath;
            string formatDL = _mainForm.Format;
            var compleat = await Task<bool>.Factory.StartNew(() =>
            {
                foreach (var link in links)
                {
                    string output = "-o " + pathSave + "/" + "%(title)s.%(ext)s ";

                    switch (formatDL)
                    {
                        case "4K":
                            {
                                options = output + "-f bestvideo[ext=mp4]+bestaudio[ext=m4a] --merge-output-format mp4 ";
                                break;
                            }
                        case "Full HD 1080p":
                            {
                                options = output + "-f bestvideo[ext=mp4]+bestaudio[ext=m4a] --merge-output-format mp4 ";
                                break;
                            }
                        case "m4a":
                            {
                                string format_audio = "[ext=m4a]";
                                string format = "-f bestaudio" + format_audio + " ";
                                options = output + format;
                                break;
                            }
                        case "mp3":
                            {
                                string format_audio = "[ext=mp3]";
                                string format = "-f bestaudio" + format_audio + " ";
                                options = output + format;
                                break;
                            }

                    }

                    commands = options + link;
                    _downloadManager.UpdateStatus += ProgressUpdate;
                    var isread = _downloadManager.ReadStream(commands);
                };
                return true;
            });
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

        public void Run()
        {
            _mainForm.Show();
        }
    }
}
