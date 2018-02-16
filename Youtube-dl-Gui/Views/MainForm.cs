﻿using System;
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
    
    public interface IMainForm : IView
    {
        string DirPath { get; }
        string urlPath { get; }
        string Format { get; }
        int Progress { get; set; }
        void DisplayProgress(int value);
        event EventHandler DownloadClick;
        event EventHandler UpdateClick;
        event EventHandler VersionClick;
        //event EventHandler SettingsClick;
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

        public string Format
        {
            get { return fldFormat.Text; }
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


        public new void Show()
        {
            Application.Run(this);
        }

        //public event EventHandler SettingsClick;
        #endregion

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            SettingsPresenter settingsPresenter = new SettingsPresenter(formSettings);
            formSettings.Show();
        }

        public void DisplayProgress(int _value)
        {
            Action action = () =>
            {
                progressBar1.Value = _value;
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
    }
}