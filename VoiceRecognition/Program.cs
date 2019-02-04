using Newtonsoft.Json;
using PiperHome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceRecognition
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (VoiceForm form = new VoiceForm())
            {
                String configFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                configFolder = Path.Combine(configFolder, "Threax.Butler/Voice");
                if (!Directory.Exists(configFolder))
                {
                    Directory.CreateDirectory(configFolder);
                }

                String configFile = Path.GetFullPath(Path.Combine(configFolder, "VoiceConfig.json"));

                if (File.Exists(configFile))
                {
                    form.Config = LoadConfig(configFile);
                }

                if (form.Config?.ButlerClient?.ServiceUrl == null)
                {
                    var result = MessageBox.Show($"You must provide a service url in {configFile}. Click yes to create the file and open the folder.\nNo to just open the folder.\nCancel to do nothing and close.", "Configuration Required", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        SaveConfig(File.Exists(configFile) ? LoadConfig(configFile) : new Config(), configFile);
                        Process.Start("explorer.exe", Path.GetDirectoryName(configFile));
                    }
                    else if(result == DialogResult.No)
                    {
                        Process.Start("explorer.exe", Path.GetDirectoryName(configFile));
                    }
                    return;
                }

                form.ConfigurationChanged += () =>
                {
                    SaveConfig(form.Config, configFile);
                };

                Task.Run(() => form.fetchConfigurationAsync());

                try
                {
                    Application.Run(form);
                }
                catch (Exception)
                {
                    form.buildRestart();
                }

                if (form.RestartInfo != null)
                {
                    Process.Start(form.RestartInfo);
                }
            }
        }

        private static Config LoadConfig(string configFile)
        {
            using (var reader = new StreamReader(File.Open(configFile, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                return JsonConvert.DeserializeObject<Config>(reader.ReadToEnd());
            }
        }

        private static void SaveConfig(Config config, string configFile)
        {
            using (var writer = new StreamWriter(File.Open(configFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None)))
            {
                writer.Write(JsonConvert.SerializeObject(config, Formatting.Indented));
            }
        }
    }
}
