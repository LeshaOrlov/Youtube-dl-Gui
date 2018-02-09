using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_dl_Gui
{
    public interface IFormSettings
    {
        string PathYoutubeDL { get; set; }
        event EventHandler ResetSettings;
        event EventHandler SaveSettings;
        event EventHandler LoadSettings;
    }

    public partial class FormSettings : Form
    {
        public FormSettings()
        {
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
            if (LoadSettings != null)
                LoadSettings(this, e);
        }
        #endregion

        #region IFormSettings

        public event EventHandler ResetSettings;
        public event EventHandler SaveSettings;
        public event EventHandler LoadSettings;

        public string PathYoutubeDL
        {
            get { return fldYoutubeDL.Text; }
            set { fldYoutubeDL.Text = value; }
        }
        #endregion
    }
}
