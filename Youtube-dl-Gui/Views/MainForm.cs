using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Youtube_dl_Gui
{
    
    public interface IMainForm : IView
    {
        string DirPath { get; }
        List<string> urlPaths { get; }
        string Format { get; }
        
        int Progress { get; set; }
        bool Playlist { get; }
        void DisplayProgress(string line);
        event EventHandler DownloadClick;
        event EventHandler UpdateClick;
        event EventHandler VersionClick;
        //event EventHandler SettingsClick;
    }

    public partial class MainForm : Form, IMainForm
    {
        
        public MainForm()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Country))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Country);
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Country);
            }

            InitializeComponent();
            
            btnRun.Click += BtnRun_Click; 

        }

        #region Проброс событий
        private void BtnRun_Click(object sender, EventArgs e)
        {
            if (DownloadClick != null)
                DownloadClick(this, e);
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UpdateClick != null)
                UpdateClick(this, e);
        }

        private void версияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VersionClick != null)
                VersionClick(this, e);
        }

       

        #endregion

        #region IMainForm
        public string DirPath
        {
            get {return fldDownDir.Text; }
        }

        public string Format
        {
            get { return fldFormat.Text; }
        }


        public bool Playlist
        {
            get { return checkPlaylist.Checked; }
        }


        public int Progress
        {
            get
            {
                return progressBar1.Value;
            }
            set
            {
                progressBar1.Value = value;
            }
        }

        public List<string> urlPaths
        {
            get {
                List<string> links = new List<string>(
                           fldURL.Text.Split(new string[] { "\r\n" },
                           StringSplitOptions.RemoveEmptyEntries));
                return links;
            }
        }

        public event EventHandler UpdateClick;

        public  event EventHandler DownloadClick;

        public event EventHandler VersionClick;


        public new void Show()
        {
            Application.Run(this);
        }

        //public event EventHandler SettingsClick;
        #endregion

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            //formSettings.ChangeLanguage += СhooseLanguage;
            SettingsPresenter settingsPresenter = new SettingsPresenter(formSettings);

            formSettings.Show();
        }

        public void DisplayProgress(string _line)
        {
            Action action = () =>
            {
                //
                int value = 0;
                string pattern = @"[0-9]+(?=\.[0-9]*%)";
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(_line);
                if (matches.Count > 0)
                {
                    Match match = matches[0];
                    value = Int32.Parse(match.Value);
                    ProgessLabel.Text = _line;
                }
                progressBar1.Value = value;
            //
            if (_line.IndexOf(@"[download] Destination:")>-1)
            {
                    int startIndex = _line.LastIndexOf(@"\");
                    if (startIndex > -1)
                    { DownloadingLabel.Text = _line.Substring(startIndex+1); }
                    
            }

            //
            ConsoleText.Text += _line + Environment.NewLine;

            };
            this.InvokeEx(action);
        }
       

    private void btnOpenDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                fldDownDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

       



        //private void СhooseLanguage(string lang)
        //{
        //    Form form = this;
        //    foreach (Control c in form.Controls)
        //    {

        //        ComponentResourceManager resources = new ComponentResourceManager(typeof(FormSettings));
        //        resources.ApplyResources(c, c.Name, new CultureInfo(lang));
        //    }

        //}
    }
}
