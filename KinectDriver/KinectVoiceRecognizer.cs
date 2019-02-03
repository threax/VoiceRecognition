using Microsoft.Speech.AudioFormat;
using Microsoft.Speech.Recognition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PiperHome.Kinect
{
    public class KinectVoiceRecognizer : IDisposable
    {
        public delegate void SpeechRecognizedDelegate(String value, float confidence);
        public event SpeechRecognizedDelegate OnSpeechRecognized;
        public event Action SensorDisconnected;
        public event Action SensorConnected;

        private KinectSensorManager sensorManager;
        private SpeechRecognitionEngine speechEngine;
        private Dictionary<String, Action> speechActions = new Dictionary<string, Action>();
        private IEnumerable<Tuple<String, Action>> commands;
        private String prefix;
        private double sensitivity;

        public KinectVoiceRecognizer(String prefix, IEnumerable<Tuple<String, Action>> commands, double sensitivity)
        {
            this.prefix = prefix + " {0}";
            this.commands = commands;
            this.sensitivity = sensitivity;

            this.sensorManager = new KinectMultiSensorManager();
            sensorManager.SensorConnected += sensorManager_SensorConnected;
            sensorManager.SensorDisconnected += sensorManager_SensorDisconnected;
        }

        public void initialize()
        {
            sensorManager.initialize();
        }

        public void Dispose()
        {
            destroySpeechEngine();
            sensorManager.Dispose();
        }

        public String SensorType
        {
            get
            {
                return sensorManager.Type;
            }
        }

        void sensorManager_SensorConnected(KinectSensorManager sensorManager)
        {
            destroySpeechEngine();

            Console.WriteLine("{0} Found", sensorManager.Type);

            RecognizerInfo ri = GetKinectRecognizer();

            if (null != ri)
            {
                this.speechEngine = new SpeechRecognitionEngine(ri.Id);

                var choices = new Choices();

                foreach (var command in commands)
                {
                    //Ignore
                    choices.Add(new SemanticResultValue(command.Item1, "IGNORE"));
                    //Require prefix
                    speechActions.Add(command.Item1, command.Item2);
                    choices.Add(new SemanticResultValue(String.Format(prefix, command.Item1), command.Item1));
                }

                var gb = new GrammarBuilder { Culture = ri.Culture };
                gb.Append(choices);

                var g = new Grammar(gb);

                speechEngine.LoadGrammar(g);

                speechEngine.SpeechRecognized += speechEngine_SpeechRecognized;
                speechEngine.SpeechRecognitionRejected += speechEngine_SpeechRecognitionRejected;

                // For long recognition sessions (a few hours or more), it may be beneficial to turn off adaptation of the acoustic model. 
                // This will prevent recognition accuracy from degrading over time.
                speechEngine.UpdateRecognizerSetting("AdaptationOn", 0);

                speechEngine.SetInputToAudioStream(sensorManager.startAudioSource(), new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
                speechEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                //No recognizer
            }

            if(SensorConnected != null)
            {
                SensorConnected.Invoke();
            }
        }

        private void destroySpeechEngine()
        {
            if (speechEngine != null)
            {
                speechActions.Clear();
                ThreadPool.QueueUserWorkItem(se =>
                {
                    (se as IDisposable).Dispose();
                }, speechEngine);
                speechEngine = null;
            }
        }

        void sensorManager_SensorDisconnected(KinectSensorManager obj)
        {
            if(SensorDisconnected != null)
            {
                SensorDisconnected.Invoke();
            }
            destroySpeechEngine();
        }

        void speechEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String value = e.Result.Semantics.Value.ToString();

            if (e.Result.Confidence >= sensitivity)
            {
                Action action;
                if(speechActions.TryGetValue(value, out action))
                {
                    action.Invoke();
                }
            }

            if(OnSpeechRecognized != null)
            {
                OnSpeechRecognized.Invoke(value, e.Result.Confidence);
            }
        }

        void speechEngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            
        }

        /// <summary>
        /// Gets the metadata for the speech recognizer (acoustic model) most suitable to
        /// process audio from Kinect device.
        /// </summary>
        /// <returns>
        /// RecognizerInfo if found, <code>null</code> otherwise.
        /// </returns>
        private static RecognizerInfo GetKinectRecognizer()
        {
            foreach (RecognizerInfo recognizer in SpeechRecognitionEngine.InstalledRecognizers())
            {
                string value;
                recognizer.AdditionalInfo.TryGetValue("Kinect", out value);
                if ("True".Equals(value, StringComparison.OrdinalIgnoreCase) && "en-US".Equals(recognizer.Culture.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return recognizer;
                }
            }

            return null;
        }
    }
}
