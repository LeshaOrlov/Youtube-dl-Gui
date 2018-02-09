using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.RegularExpressions;

namespace Youtube_dl_Gui
{
    public interface ISettingsManager
    {
        void DownLoad(string pathFileSettings);
        void Save();


    }

    class SettingsManager: ISettingsManager
    {
        string pathFileSettings = "Settings";

        string pathYoutubeDL = "";

        public void DownLoad(string pathFileSettings)
        {
            using (StreamReader sr = new StreamReader(pathFileSettings))
            {
                while (!sr.EndOfStream)
                {
                    Setting setting = GetSetting(sr.ReadLine());
                    SetSetting(setting);
                }
            }
        }

        public void Save()
        {
            using (StreamWriter tr = new StreamWriter(new FileStream(pathFileSettings, FileMode.Create)))
            {
                tr.WriteLine("pathYoutubeDL = " + pathYoutubeDL);
                
            }
        }

        private Setting GetSetting(string settingLine)
        {
            Setting setting = new Setting();
           
            setting.Name = Regex.Match(settingLine, @"\w+").ToString().Trim();
            setting.Value = Regex.Match(settingLine, "\".+\"").ToString().Trim('"');

            return setting;
        }

        private void SetSetting(Setting setting)
        {
            switch (setting.Name)
            {
                case "pathYoutubeDL":
                    {
                        pathYoutubeDL = setting.Value;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
