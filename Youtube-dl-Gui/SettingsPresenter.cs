using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_dl_Gui
{
   
    class SettingsPresenter
    {
        
        private IFormSettings _formSettings;

        public SettingsPresenter(IFormSettings formSettings)
        {

            _formSettings = formSettings;
            _formSettings.LoadSettings += new EventHandler(LoadSettings);
            _formSettings.ResetSettings += new EventHandler(ResetSettings);
            _formSettings.SaveSettings += new EventHandler(SaveSettings);
        }

        public void SaveSettings(object sender, EventArgs e)
        {
            Properties.Settings.Default.Country = _formSettings.Language;
            Properties.Settings.Default.Save();
        }

        public void ResetSettings(object sender, EventArgs e)
        {
            
        }

        public void LoadSettings(object sender, EventArgs e)
        {
            _formSettings.PathYoutubeDL = Properties.Settings.Default.YoutubeDLPath;

            if (!String.IsNullOrEmpty(Properties.Settings.Default.Country))
            {
                _formSettings.Language = Properties.Settings.Default.Country;
            }
        }
    }
}
