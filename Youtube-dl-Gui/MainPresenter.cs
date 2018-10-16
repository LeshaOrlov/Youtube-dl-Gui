using System;
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
        private IMainForm _mainForm;
        private IDownloadManager _downloadManager;

        //конструктор
        public MainPresenter(IMainForm mainForm, IDownloadManager downloadManager)
        {
            _mainForm = mainForm;
            _downloadManager = downloadManager;
            _mainForm.DownloadClick += new EventHandler(StartDownloads);
            _mainForm.UpdateClick += new EventHandler(Update);
            _mainForm.VersionClick += new EventHandler(Version);
        }

        //Создает главную форму
        public void Run()
        {
            _mainForm.Show();
        }

        //Обработчик события загрузки
        public async void StartDownloads(object sender, EventArgs e)
        {
            List<string> listURL = _mainForm.urlPaths;
            string command = "";
            string options = "";
            string pathSave = _mainForm.DirPath;
            string formatDL = _mainForm.Format;
            string playlist = "--no-playlist ";
            if (_mainForm.Playlist) playlist = "--yes-playlist ";
            
            var compleat = await Task<bool>.Factory.StartNew(() =>
            {
                foreach (var link in listURL)
                {
                    //Формирование строки команды
                    string output = "-o " + "\""+pathSave + "/" + "%(title)s.%(ext)s"+ "\" ";
                    switch (formatDL)
                    {
                        case "4K":
                            {
                                options = output + "-f bestvideo[height<=2160]+bestaudio[ext=m4a] --merge-output-format mp4 ";
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
                    command = playlist + options + link;

                    downloadLink(command);
                };
                return true;
            });
        }

        //загружает по ссылке
        public void downloadLink(string command)
        {
            _downloadManager.UpdateStatus += ProgressUpdate;
            var isread = _downloadManager.ReadStream(command);
            
        }


        public void ProgressUpdate(string line)
        {
            _mainForm.DisplayProgress(line);
        }

        //Обновление youtube-dl
        public void Update(object sender, EventArgs e)
        {
            string commands = "--update";

            Thread task = new Thread(() => _downloadManager.ReadStream(commands));

            task.IsBackground = false;
            task.Start();
        }

        //Версия youtube-dl
        public void Version(object sender, EventArgs e)
        {
            string commands = "--update";

            Thread task = new Thread(() => _downloadManager.ReadStream(commands));
            task.IsBackground = false;
            task.Start();
        }

       

        public void UpdateProgram()
        {
            //WebClient client = new WebClient();
            //client.DownloadProgressChanged += Client_DownloadProgressBar;
            //client.DownloadFileCompleted += Client_DownloadFileCompleted;
            //string url = "https://yt-dl.org/latest/youtube-dl.exe";

            //if (!string.IsNullOrEmpty(url))
            //{
            //    Thread task = new Thread(() =>
            //    {

            //        Uri uri = new Uri(url);
            //        string nameFile = Path.GetFileName(uri.AbsolutePath);

            //        client.DownloadFileAsync(uri, nameFile);
            //    });
            //    task.Start();
            //}

        }


        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //MessageBox.Show("download comlete", "Message", MessageBoxButtons.OK);
        }

        //private void Client_DownloadProgressBar(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    Invoke(new MethodInvoker(delegate ()
        //    {
        //        progressDownload.Value = e.ProgressPercentage;
        //    }


        //    ));

        //}
    }
}
