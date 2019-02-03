using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PiperHome.Kinect
{
    public class Kinect2SensorManager : KinectSensorManager
    {
        private object activeSensorLock = new object();
        private KinectSensor activeSensor;
        private KinectAudioStream convertStream = null;
        private bool connected;
        private List<KinectSensor> openedSensors = new List<KinectSensor>();

        public event Action<KinectSensorManager> StatusChanged;

        public event Action<KinectSensorManager> SensorConnected;
        public event Action<KinectSensorManager> SensorDisconnected;

        public Kinect2SensorManager()
        {
            
        }

        public void Dispose()
        {
            lock (activeSensorLock)
            {
                disconnectSensor();
                foreach (var sensor in openedSensors)
                {
                    sensor.Close();
                }
                openedSensors.Clear();
            }
        }

        public void initialize()
        {
            ThreadPool.QueueUserWorkItem((state) =>
            {
                findSensor();
            });
        }

        public Stream startAudioSource()
        {
            if (this.activeSensor != null)
            {
                // grab the audio stream
                IReadOnlyList<AudioBeam> audioBeamList = this.activeSensor.AudioSource.AudioBeams;
                Stream audioStream = audioBeamList[0].OpenInputStream();

                // create the convert stream
                this.convertStream = new KinectAudioStream(audioStream);
                this.convertStream.SpeechActive = true;
                return convertStream;
            }
            throw new Exception("No kinect sensor activated");
        }

        public KinectSensor Sensor
        {
            get
            {
                return activeSensor;
            }
        }

        public String Type
        {
            get
            {
                return "Kinect 2.0";
            }
        }

        public bool Connected
        {
            get
            {
                return connected;
            }
            private set
            {
                if (connected != value)
                {
                    connected = value;
                    if (StatusChanged != null)
                    {
                        if (StatusChanged != null)
                        {
                            StatusChanged.Invoke(this);
                        }
                    }
                }
            }
        }

        private void findSensor()
        {
            lock (activeSensorLock)
            {
                if (activeSensor == null)
                {
                    KinectSensor localSensor = KinectSensor.GetDefault();

                    //If a sensor was found start it and enable its skeleton listening.
                    if (localSensor != null)
                    {
                        // Start the sensor!
                        try
                        {
                            localSensor.Open();
                            localSensor.IsAvailableChanged += LocalSensor_IsAvailableChanged;
                            processSensorConnected(localSensor);
                            openedSensors.Add(localSensor);
                        }
                        catch (IOException)
                        {
                            localSensor = null;
                        }
                    }
                }
            }
        }

        private void processSensorConnected(KinectSensor sensor)
        {
            lock (activeSensorLock)
            {
                if (sensor.IsAvailable)
                {
                    if (activeSensor == null)
                    {
                        activeSensor = sensor;
                        Connected = true;
                        if (SensorConnected != null)
                        {
                            SensorConnected.Invoke(this);
                        }
                    }
                }
                else
                {
                    if (activeSensor == sensor)
                    {
                        disconnectSensor();
                    }
                }
            }
        }

        private void LocalSensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs e)
        {
            processSensorConnected(sender as KinectSensor);
        }

        private void disconnectSensor()
        {
            lock (activeSensorLock)
            {
                if (activeSensor != null)
                {
                    activeSensor = null;
                    Connected = false;

                    if (SensorDisconnected != null)
                    {
                        SensorDisconnected.Invoke(this);
                    }
                }
            }
        }
    }
}
