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

namespace Youtube_dl_Gui
{
    public interface IMainForm
    {
        string DirPath { get; }
        string urlPath { get; }
        int Progress { get; set; }
        bool Audio { get; }
        bool Video { get; }
        void DisplayProgress(int value);
        event EventHandler DownloadClick;
        event EventHandler UpdateClick;
        event EventHandler VersionClick;
    }

    public partial class MainForm : Form, IMainForm
    {
       
        public MainForm()
        {
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

        public bool Audio
        {
            get
            {
                return checkAudio.Checked;
            }
        }

        public bool Video
        {
            get
            {
                return checkVideo.Checked;
            }
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

        public string urlPath
        {
            get { return fldURL.Text; }
        }

        public event EventHandler UpdateClick;

        public  event EventHandler DownloadClick;

        public event EventHandler VersionClick;
        #endregion

        public void DisplayProgress(int _value)
        {
            Action action = () =>
            {
                progressBar1.Value = _value;
            };
            this.InvokeEx(action);
        }


    }
}
