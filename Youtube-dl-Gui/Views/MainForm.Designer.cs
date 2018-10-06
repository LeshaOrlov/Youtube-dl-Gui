namespace Youtube_dl_Gui
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
         {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnRun = new System.Windows.Forms.Button();
            this.fldURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.программаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.версияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fldFormat = new System.Windows.Forms.ComboBox();
            this.fldDownDir = new System.Windows.Forms.ComboBox();
            this.checkPlaylist = new System.Windows.Forms.CheckBox();
            this.DownloadingLabel = new System.Windows.Forms.Label();
            this.ConsoleText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ProgessLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            resources.ApplyResources(this.btnRun, "btnRun");
            this.btnRun.Name = "btnRun";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // fldURL
            // 
            resources.ApplyResources(this.fldURL, "fldURL");
            this.fldURL.Name = "fldURL";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // btnOpenDir
            // 
            resources.ApplyResources(this.btnOpenDir, "btnOpenDir");
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.UseVisualStyleBackColor = true;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.программаToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.toolStripMenuItem2,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            resources.ApplyResources(this.файлToolStripMenuItem, "файлToolStripMenuItem");
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            resources.ApplyResources(this.открытьToolStripMenuItem, "открытьToolStripMenuItem");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            resources.ApplyResources(this.выходToolStripMenuItem, "выходToolStripMenuItem");
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            resources.ApplyResources(this.настройкиToolStripMenuItem, "настройкиToolStripMenuItem");
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            resources.ApplyResources(this.изменитьToolStripMenuItem, "изменитьToolStripMenuItem");
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // программаToolStripMenuItem
            // 
            this.программаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьToolStripMenuItem,
            this.версияToolStripMenuItem});
            this.программаToolStripMenuItem.Name = "программаToolStripMenuItem";
            resources.ApplyResources(this.программаToolStripMenuItem, "программаToolStripMenuItem");
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            resources.ApplyResources(this.обновитьToolStripMenuItem, "обновитьToolStripMenuItem");
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // версияToolStripMenuItem
            // 
            this.версияToolStripMenuItem.Name = "версияToolStripMenuItem";
            resources.ApplyResources(this.версияToolStripMenuItem, "версияToolStripMenuItem");
            this.версияToolStripMenuItem.Click += new System.EventHandler(this.версияToolStripMenuItem_Click);
            // 
            // fldFormat
            // 
            this.fldFormat.FormattingEnabled = true;
            this.fldFormat.Items.AddRange(new object[] {
            resources.GetString("fldFormat.Items"),
            resources.GetString("fldFormat.Items1"),
            resources.GetString("fldFormat.Items2"),
            resources.GetString("fldFormat.Items3"),
            resources.GetString("fldFormat.Items4"),
            resources.GetString("fldFormat.Items5")});
            resources.ApplyResources(this.fldFormat, "fldFormat");
            this.fldFormat.Name = "fldFormat";
            // 
            // fldDownDir
            // 
            this.fldDownDir.FormattingEnabled = true;
            this.fldDownDir.Items.AddRange(new object[] {
            resources.GetString("fldDownDir.Items"),
            resources.GetString("fldDownDir.Items1"),
            resources.GetString("fldDownDir.Items2"),
            resources.GetString("fldDownDir.Items3")});
            resources.ApplyResources(this.fldDownDir, "fldDownDir");
            this.fldDownDir.Name = "fldDownDir";
            // 
            // checkPlaylist
            // 
            resources.ApplyResources(this.checkPlaylist, "checkPlaylist");
            this.checkPlaylist.Name = "checkPlaylist";
            this.checkPlaylist.UseVisualStyleBackColor = true;
            // 
            // DownloadingLabel
            // 
            resources.ApplyResources(this.DownloadingLabel, "DownloadingLabel");
            this.DownloadingLabel.Name = "DownloadingLabel";
            // 
            // ConsoleText
            // 
            resources.ApplyResources(this.ConsoleText, "ConsoleText");
            this.ConsoleText.Name = "ConsoleText";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // ProgessLabel
            // 
            resources.ApplyResources(this.ProgessLabel, "ProgessLabel");
            this.ProgessLabel.Name = "ProgessLabel";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProgessLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ConsoleText);
            this.Controls.Add(this.DownloadingLabel);
            this.Controls.Add(this.checkPlaylist);
            this.Controls.Add(this.fldDownDir);
            this.Controls.Add(this.fldFormat);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fldURL);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox fldURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnOpenDir;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem программаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem версияToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox fldFormat;
        private System.Windows.Forms.ComboBox fldDownDir;
        private System.Windows.Forms.CheckBox checkPlaylist;
        private System.Windows.Forms.Label DownloadingLabel;
        private System.Windows.Forms.TextBox ConsoleText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ProgessLabel;
    }
}

