using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_dl_Gui
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DownloadManager downloadManager = new DownloadManager();
            SettingsManager settingsManager = new SettingsManager();
            MainForm mainForm = new MainForm();

            MainPresenter presenter = new MainPresenter(mainForm, downloadManager);

            Application.Run(mainForm);
        }
    }
}
