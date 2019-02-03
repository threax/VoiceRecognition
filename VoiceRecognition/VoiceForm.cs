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
            if(contextMenuStrip.Visible)
            {
                while(chooseAudioDevice.HasDropDownItems)
                {
                    (chooseAudioDevice.DropDownItems[0] as ToolStripMenuItem).Dispose();
                }
                chooseAudioDevice.DropDownItems.Clear();

                foreach(var device in commands.PlaybackDeviceNames)
                {
                    var menuItem = new ToolStripMenuItem(device);
                    menuItem.Click += (s, ea) =>
                    {
                        PlaybackDeviceName = device;
                        commands.PlaybackDeviceName = device;
                        ConfigurationChanged?.Invoke();
                    };
                    chooseAudioDevice.DropDownItems.Add(menuItem);
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
            //Setup client
            var options = new ButlerClientOptions()
            {
                ServiceUrl = "https://localhost:44362/api",
                ClientCredentials = new ClientCredentailsAccessTokenFactoryOptions()
                {
                    ClientId = "Butler.Test.Kinect",
                    ClientSecret = "notyetdefined",
                    IdServerHost = "https://localhost:44390",
                    Scope = "Butler"
                }
            };

            var factory = new ClientCredentialsAccessTokenFactory<EntryPointInjector>(options.ClientCredentials, new BearerHttpClientFactory<EntryPointInjector>(new DefaultHttpClientFactory()));
            var injector = new EntryPointInjector(options.ServiceUrl, factory);
            var entry = await injector.Load();
            var commandResult = await entry.ListAppCommandSets(new AppCommandSetQuery()
            {
                Limit = int.MaxValue
            });
            //Try to download
            //while (voiceConfig == null)
            //{
            //    try
            //    {
            //        voiceConfig = await client.getVoiceConfigAsync();
            //        foundConfig = true;
            //    }
            //    catch (Exception)
            //    {
            //        Thread.Sleep(10000);
            //    }
            //}

            this.Invoke(new Action(() =>
            {
                //Setup commands
                commands = new VoiceCommands(commandResult);
                commands.Restart += commands_Restart;
                commands.PlaybackDeviceName = PlaybackDeviceName;

                //Setup kinect
                recognizer = new KinectVoiceRecognizer(Hotword, commands.getCommands(), Sensitivity);
                recognizer.SensorConnected += recognizer_SensorConnected;
                recognizer.SensorDisconnected += recognizer_SensorDisconnected;
                recognizer.initialize();
            }));
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

        public String Host { get; set; }

        public String Hotword { get; set; }

        public double Sensitivity { get; set; }

        /// <summary>
        /// The playback device to use. null Uses the system default.
        /// </summary>
        public String PlaybackDeviceName { get; set; }

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
                    this.showMessage(String.Format("Sensor connected, ready to listen.\nHotword: {0}\nSensitivity: {1}\nSensor: {2}", Hotword, Sensitivity, recognizer.SensorType));
                }
                else
                {
                    showMessage("Sensor Disconnected");
                }
            }
            else
            {
                showMessage($"Connecting to {Host}.");
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
