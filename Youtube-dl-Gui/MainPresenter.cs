﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.ComponentModel;

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
            string playlist = "--no-playlist ";
            if (_mainForm.Playlist) playlist = "--yes-playlist ";
            
            var compleat = await Task<bool>.Factory.StartNew(() =>
            {
                foreach (var link in links)
                {
                    string output = "-o " + "\""+pathSave + "/" + "%(title)s.%(ext)s"+ "\" ";

                    switch (formatDL)
                    {
                        case "4K":
                            {
                                options = output + "-f bestvideo[ext=mp4]+bestaudio[ext=m4a] --merge-output-format mp4 ";
                                break;
                            }
                        case "Full HD 1080p":
                            {
                                options = output + "-f bestvideo[height<=1080]+bestaudio[ext=m4a] --merge-output-format mp4 ";
                                break;
                            }
                        case "HD 720p":
                            {
                                options = output + "-f bestvideo[height<=720]+bestaudio[ext=m4a] --merge-output-format mp4 ";
                                break;
                            }
                        case "m4a":
                            {
                                string format_audio = "[ext=m4a]";
                                string format = "-f bestaudio" + format_audio + " ";
                                options = output + format;
                                break;
                            }
                        case "MP3":
                            {
                                string format_audio = "--extract-audio --audio-format mp3";
                                string format = "-f bestaudio" + " " + format_audio + " ";
                                options = output + format;
                                break;
                            }
                    }

                    commands = playlist + options + link;
                    _downloadManager.UpdateStatus += ProgressUpdate;
                    var isread = _downloadManager.ReadStream(commands);
                };
                return true;
            });
        }

        public void ProgressUpdate(string line)
        {
            _mainForm.DisplayProgress(line);
            
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

        public void UpdateProgram()
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += Client_DownloadProgressBar;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
            string url = "https://yt-dl.org/latest/youtube-dl.exe";

            if (!string.IsNullOrEmpty(url))
            {
                Thread task = new Thread(() =>
                {

                    Uri uri = new Uri(url);
                    string nameFile = Path.GetFileName(uri.AbsolutePath);

                    client.DownloadFileAsync(uri, nameFile);
                });
                task.Start();
            }

        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //MessageBox.Show("download comlete", "Message", MessageBoxButtons.OK);
        }

        private void Client_DownloadProgressBar(object sender, DownloadProgressChangedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                progressDownload.Value = e.ProgressPercentage;
            }


            ));

        }
    }
}
