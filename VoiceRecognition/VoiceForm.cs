using Butler.Client;
using PiperHome;
using PiperHome.Kinect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Threax.AspNetCore.Halcyon.Client;
using Threax.AspNetCore.Halcyon.Client.OpenIdConnect;

namespace VoiceRecognition
{
    public partial class VoiceForm : Form
    {
        private VoiceCommands commands;
        private KinectVoiceRecognizer recognizer;
        private bool showSensorConnectedMessages = false;
        private bool connected = false;
        private bool foundConfig = false;

        public event Action ConfigurationChanged;

        public VoiceForm()
        {
            InitializeComponent();

            //Thanks to Bill at http://stackoverflow.com/questions/683896/any-way-to-create-a-hidden-main-window-in-c
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(-2000, -2000);
            this.Size = new Size(1, 1);

            this.Disposed += VoiceForm_Disposed;
            showInfoMenuItem.Click += ShowInfoMenuItem_Click;

            contextMenuStrip.VisibleChanged += ContextMenuStrip_VisibleChanged;
        }

        private void ContextMenuStrip_VisibleChanged(object sender, EventArgs e)
        {
            if (contextMenuStrip.Visible)
            {
                while (chooseAudioDevice.HasDropDownItems)
                {
                    (chooseAudioDevice.DropDownItems[0] as ToolStripMenuItem).Dispose();
                }
                chooseAudioDevice.DropDownItems.Clear();

                if (commands != null)
                {
                    foreach (var device in commands.PlaybackDeviceNames)
                    {
                        var menuItem = new ToolStripMenuItem(device);
                        menuItem.Click += (s, ea) =>
                        {
                            Config.PlaybackDeviceName = device;
                            commands.PlaybackDeviceName = device;
                            ConfigurationChanged?.Invoke();
                        };
                        chooseAudioDevice.DropDownItems.Add(menuItem);
                    }
                }
            }
        }

        /// <summary>
        /// Fetch the configuration from the server, will execute using
        /// the thread pool, so this will return immediately with no result.
        /// Call after all configuration has been set.
        /// </summary>
        public async Task fetchConfigurationAsync()
        {
            //Try to download
            AppCommandSetCollectionResult commandResult = null;
            bool retry = true;
            while (retry)
            {
                try
                {
                    commandResult = await LoadCommands();
                    retry = false;
                    foundConfig = true;
                }
                catch (Exception)
                {
                    Thread.Sleep(10000);
                }
            }

            this.Invoke(new Action(() =>
            {
                //Setup commands
                commands = new VoiceCommands(commandResult);
                commands.Restart += commands_Restart;
                commands.PlaybackDeviceName = Config.PlaybackDeviceName;

                //Setup kinect
                recognizer = new KinectVoiceRecognizer(Config.Hotword, commands.getCommands(), Config.Sensitivity);
                recognizer.SensorConnected += recognizer_SensorConnected;
                recognizer.SensorDisconnected += recognizer_SensorDisconnected;
                recognizer.initialize();
            }));
        }

        private async Task<AppCommandSetCollectionResult> LoadCommands()
        {
            var factory = new ClientCredentialsAccessTokenFactory<EntryPointInjector>(Config.ButlerClient.ClientCredentials, new BearerHttpClientFactory<EntryPointInjector>(new DefaultHttpClientFactory()));
            var injector = new EntryPointInjector(Config.ButlerClient.ServiceUrl, factory);
            var entry = await injector.Load();
            var commandResult = await entry.ListAppCommandSets(new AppCommandSetQuery()
            {
                Limit = int.MaxValue
            });
            return commandResult;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        void VoiceForm_Disposed(object sender, EventArgs e)
        {
            recognizer?.Dispose();
            commands?.Dispose();
        }

        public Config Config { get; set; }

        public ProcessStartInfo RestartInfo { get; private set; }

        void commands_Restart()
        {
            this.Invoke(new Action(() =>
            {
                buildRestart();
                Application.Exit();
            }));
        }

        public void showMessage(String message)
        {
            notifyIcon.ShowBalloonTip(10000, "Voice Recognition", message, ToolTipIcon.Info);
        }

        public void buildRestart()
        {
            String[] args = Environment.GetCommandLineArgs();
            RestartInfo = new ProcessStartInfo(args[0]);
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < args.Length; ++i)
            {
                sb.AppendFormat("{0} ", args[i]);
            }
            RestartInfo.Arguments = sb.ToString().Trim();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void recognizer_OnSpeechRecognized(string value, float confidence)
        {
            showMessage(String.Format("{0} - {1} {2}", DateTime.Now.ToShortTimeString(), value, confidence));
        }

        private void ShowInfoMenuItem_Click(object sender, EventArgs e)
        {
            showInfoMessage();
        }

        void recognizer_SensorDisconnected()
        {
            showSensorConnectedMessages = true;
            connected = false;
            showInfoMessage();
        }

        void recognizer_SensorConnected()
        {
            connected = true;
            if (showSensorConnectedMessages)
            {
                showInfoMessage();
            }
        }

        private void showInfoMessage()
        {
            if (foundConfig)
            {
                if (connected)
                {
                    this.showMessage(String.Format("Sensor connected, ready to listen.\nHotword: {0}\nSensitivity: {1}\nSensor: {2}", Config.Hotword, Config.Sensitivity, recognizer.SensorType));
                }
                else
                {
                    showMessage("Sensor Disconnected");
                }
            }
            else
            {
                showMessage($"Connecting to {Config.ButlerClient.ServiceUrl}.");
            }
        }

        private void verboseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verboseToolStripMenuItem.Checked = !verboseToolStripMenuItem.Checked;
            if(verboseToolStripMenuItem.Checked)
            {
                recognizer.OnSpeechRecognized += recognizer_OnSpeechRecognized;
            }
            else
            {
                recognizer.OnSpeechRecognized -= recognizer_OnSpeechRecognized;
            }
        }
    }
}
