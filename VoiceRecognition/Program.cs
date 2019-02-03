using Engine;
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
                configFolder = Path.Combine(configFolder, "PiperHomeVoiceRecognition");
                if (!Directory.Exists(configFolder))
                {
                    Directory.CreateDirectory(configFolder);
                }

                String configFile = Path.Combine(configFolder, "VoiceConfig.ini");
                ConfigFile config = new ConfigFile(configFile);

                if (File.Exists(configFile))
                {
                    config.loadConfigFile();
                }

                var section = config.createOrRetrieveConfigSection("Program");

                form.ConfigurationChanged += () =>
                {
                    section.setValue("Host", form.Host);
                    section.setValue("Hotword", form.Hotword);
                    section.setValue("Sensitivity", form.Sensitivity);
                    section.setValue("PlaybackDeviceName", form.PlaybackDeviceName);
                    config.writeConfigFile();
                };
                form.Host = section.getValue("Host", "http://home.threax.com");
                form.Hotword = section.getValue("Hotword", "collins");
                form.Sensitivity = section.getValue("Sensitivity", 0.55);
                form.PlaybackDeviceName = section.getValue("PlaybackDeviceName", (String)null);
                int restartMinutes = section.getValue("RestartTime", 30);

                Task.Run(() => form.fetchConfigurationAsync());

                if (!File.Exists(configFile))
                {
                    config.writeConfigFile();
                }

                try
                {
                    //Timer t = new Timer();
                    //t.Interval = (int)TimeSpan.FromMinutes(restartMinutes).TotalMilliseconds;
                    //t.Tick += (s, e) =>
                    //{
                    //    t.Stop();
                    //    form.buildRestart();
                    //    Application.Exit();
                    //};
                    //t.Start();

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
    }
}
