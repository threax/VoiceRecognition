using System.Speech.Synthesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using NAudio.Wave;
using System.Threading;

namespace PiperHome
{
    public class VoiceCommands : IDisposable
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();
        private PiperHomeClient client;
        private VoiceConfig voiceConfig;
        private bool unlocked = true;
        private DateTime lastLockedCommandTime = DateTime.Now;

        /// <summary>
        /// Called when restart is heard. Can be on any random thread will need to synchronize if important.
        /// </summary>
        public event Action Restart;

        public VoiceCommands(PiperHomeClient client, VoiceConfig voiceConfig)
        {
            this.client = client;
            this.voiceConfig = voiceConfig;
        }

        public void Dispose()
        {
            synth.Dispose();
        }

        public IEnumerable<Tuple<String, Action>> getCommands()
        {
            foreach (var command in voiceConfig.Commands)
            {
                yield return Tuple.Create<String, Action>(command.Name, () => runCommand(command));
            }

            yield return Tuple.Create<String, Action>("host screen off", VoiceCommands.MonitorOff);
            yield return Tuple.Create<String, Action>("host restart", restart);
            yield return Tuple.Create<String, Action>("lock", lockCommands);
            yield return Tuple.Create<String, Action>("unlock", unlockCommands);
        }

        public String PlaybackDeviceName { get; set; }

        public IEnumerable<String> PlaybackDeviceNames
        {
            get
            {
                int waveOutDevices = WaveOut.DeviceCount;
                for (int device = 0; device < waveOutDevices; device++)
                {
                    yield return WaveOut.GetCapabilities(device).ProductName;
                }
            }
        }

        private void runCommand(VoiceCommand command)
        {
            if (unlocked)
            {
                try
                {
                    Task t = Task.Run(async () =>
                    {
                        var executeTask = command.executeAsync(client);
                        speak(command.Message);
                        await executeTask;
                    });
                    t.Wait();
                }
                catch(Exception)
                {
                    speak($"error running {command.Name}");
                }
            }
            else
            {
                DateTime thisLockedCommandTime = DateTime.Now;
                if ((thisLockedCommandTime - lastLockedCommandTime).TotalSeconds < 10)
                {
                    speak("I am locked");
                }
                lastLockedCommandTime = thisLockedCommandTime;
            }
        }

        private void speakSync(String message)
        {
            using (var waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset))
            {
                speak(message, () =>
                {
                    waitHandle.Set();
                });
                waitHandle.WaitOne();
            }
        }

        private void speak(String message, Action playbackStoppedCallback = null)
        {
            try
            {
                int deviceNumber = 0;
                if(PlaybackDeviceName != null)
                {
                    int waveOutDevices = WaveOut.DeviceCount;
                    for (int device = 0; device < waveOutDevices; device++)
                    {
                        if(WaveOut.GetCapabilities(device).ProductName == PlaybackDeviceName)
                        {
                            deviceNumber = device;
                            break;
                        }
                    }
                }

                MemoryStream memStream = new MemoryStream();
                synth.SetOutputToWaveStream(memStream);
                synth.Speak(message);
                memStream.Seek(0, SeekOrigin.Begin);

                WaveStream waveStream = new WaveFileReader(memStream);
                WaveChannel32 volumeStream = new WaveChannel32(waveStream);
                volumeStream.PadWithZeroes = false;
                WaveOutEvent player = new WaveOutEvent();
                player.DeviceNumber = deviceNumber;
                player.PlaybackStopped += (sender, args) =>
                {
                    //This will leak if this never fires (from an exception or something)
                    //This is not normal and has never come up, this always runs fine
                    playbackStoppedCallback?.Invoke();
                    player.Dispose();
                    volumeStream.Dispose();
                    waveStream.Dispose();
                    memStream.Dispose();
                };

                player.Init(volumeStream);
                player.Play();
            }
            catch (Exception ex)
            {
                while (ex != null)
                {
                    Console.WriteLine(ex.ToString());
                    ex = ex.InnerException;
                }
            }
        }

        private void lockCommands()
        {
            speak("Locking");
            unlocked = false;
        }

        private void unlockCommands()
        {
            speak("Unlocking");
            unlocked = true;
        }

        private void restart()
        {
            if (Restart != null)
            {
                ThreadPool.QueueUserWorkItem((arg) =>
                {
                    speakSync("Restarting");
                    Restart.Invoke();
                });
            }
        }

        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        //Monitor off
        private static int WM_SYSCOMMAND = 0x0112;
        private static uint SC_MONITORPOWER = 0xF170;

        public static void MonitorOff()
        {
            SendMessage(GetConsoleWindow(), WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)2);
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
    }
}
