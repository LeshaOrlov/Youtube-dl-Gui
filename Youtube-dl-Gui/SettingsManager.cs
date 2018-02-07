using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.RegularExpressions;

namespace Youtube_dl_Gui
{
    public interface I



    class SettingsManager
    {
        string pathFileSettings = "Settings";

        string pathYoutubeDL = "";

        void DownLoad(string pathFileSettings)
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

        void Save()
        {
            using (StreamWriter tr = new StreamWriter(new FileStream(pathFileSettings, FileMode.Create)))
            {
                tr.WriteLine("pathYoutubeDL = " + pathYoutubeDL);
                
            }
        }

        Setting GetSetting(string settingLine)
        {
            Setting setting = new Setting();
           
            setting.Name = Regex.Match(settingLine, @"\w+").ToString().Trim();
            setting.Value = Regex.Match(settingLine, "\".+\"").ToString().Trim('"');

            return setting;
        }

        void SetSetting(Setting setting)
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
