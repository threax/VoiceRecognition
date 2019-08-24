using Microsoft.Extensions.Configuration;
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
using Threax.Extensions.Configuration.SchemaBinder;

namespace VoiceRecognition
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var appDir = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

                using (VoiceForm form = new VoiceForm())
                {
                    var configBuilder = new ConfigurationBuilder();
                    configBuilder.AddJsonFile(Path.Combine(appDir, "appsettings.json"));
                    configBuilder.AddJsonFile(Path.Combine(appDir, "appsettings.Production.json"), optional: true);
                    configBuilder.AddJsonFile(Path.Combine(appDir, "appsettings.secrets.json"), optional: true);
                    var config = configBuilder.Build();
                    var appConfig = new Config();
                    config.Bind(appConfig);
                    form.Config = appConfig;

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
            catch(Exception e)
            {
                MessageBox.Show(e.Message, e.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            using (var writer = new StreamWriter(File.Open(configFile, FileMode.Create, FileAccess.Write, FileShare.None)))
            {
                writer.Write(JsonConvert.SerializeObject(config, Formatting.Indented));
            }
        }
    }
}
