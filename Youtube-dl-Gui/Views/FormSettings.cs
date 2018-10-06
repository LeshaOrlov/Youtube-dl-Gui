using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_dl_Gui
{
    public interface IFormSettings : IView
    {
        string PathYoutubeDL { get; set; }
        string Language { get; set; }
        event EventHandler ResetSettings;
        event EventHandler SaveSettings;
        event EventHandler LoadSettings;
    }

    public partial class FormSettings : Form, IFormSettings
    {
        public FormSettings()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Country))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Country);
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Country);
            }
            InitializeComponent();
        }

        #region проброс событий
        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            if (ResetSettings != null)
                ResetSettings(this, e);
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (SaveSettings != null)
                SaveSettings(this, e);
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new CultureInfo[]
             {
                CultureInfo.GetCultureInfo("ru-RU"),
                CultureInfo.GetCultureInfo("en-US"),

             };

            comboBox1.DisplayMember = "NativeName";
            comboBox1.ValueMember = "Name";

            if (!String.IsNullOrEmpty(Properties.Settings.Default.Country))
            {
                comboBox1.SelectedValue = Properties.Settings.Default.Country;
            }

            if (LoadSettings != null)
                LoadSettings(this, e);
        }
        #endregion

        #region IFormSettings

        public event EventHandler ResetSettings;
        public event EventHandler SaveSettings;
        public event EventHandler LoadSettings;

        //public event Action<string> ChangeLanguage;

        private new void Show()
        {

        }

        public string PathYoutubeDL
        {
            get { return fldYoutubeDL.Text; }
            set { fldYoutubeDL.Text = value; }
        }

        public string Language
        {
            get { return comboBox1.SelectedValue.ToString(); }
            set { comboBox1.SelectedValue = value; }
        }

        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = comboBox1.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            //if (comboBox1.SelectedItem.ToString() == "en-US")
            //{
            //    ChangeLanguage("en-US");
            //}
            //else if (comboBox1.SelectedItem.ToString() == "ru-RU")
            //{
            //    ChangeLanguage("ru-RU");
            //}
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
