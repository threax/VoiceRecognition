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
    public class Kinect1SensorManager : KinectSensorManager
    {
        private KinectSensor activeSensor;
        private KinectStatus currentStatus;

        public event Action<KinectSensorManager> StatusChanged;

        public event Action<KinectSensorManager> SensorConnected;
        public event Action<KinectSensorManager> SensorDisconnected;

        public Kinect1SensorManager()
        {
            KinectSensor.KinectSensors.StatusChanged += KinectSensors_StatusChanged;
        }

        public void Dispose()
        {
            disconnectSensor();
        }

        public void initialize()
        {
            findSensor();
        }

        public Stream startAudioSource()
        {
            return activeSensor.AudioSource.Start();
        }

        public KinectStatus CurrentStatus
        {
            get
            {
                return currentStatus;
            }
            private set
            {
                if (currentStatus != value)
                {
                    currentStatus = value;
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
                return "Kinect 1.0";
            }
        }

        void KinectSensors_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            if (CurrentStatus != e.Status)
            {
                CurrentStatus = e.Status;
                switch (currentStatus)
                {
                    case KinectStatus.Disconnected:
                        if (e.Sensor == activeSensor)
                        {
                            disconnectSensor();
                        }
                        break;
                    case KinectStatus.Connected:
                        findSensor();
                        break;
                }
            }
        }

        private void findSensor()
        {
            if (activeSensor == null)
            {
                KinectSensor localSensor = null;
                // Look through all sensors and start the first connected one.
                foreach (var potentialSensor in KinectSensor.KinectSensors)
                {
                    if (potentialSensor.Status == KinectStatus.Connected)
                    {
                        localSensor = potentialSensor;
                        break;
                    }
                }

                //If a sensor was found start it and enable its skeleton listening.
                if (localSensor != null)
                {
                    // Start the sensor!
                    try
                    {
                        localSensor.Start();
                        CurrentStatus = KinectStatus.Connected;
                    }
                    catch (IOException)
                    {
                        localSensor = null;
                    }

                    activeSensor = localSensor; //Make the class aware of the sensor

                    if (activeSensor != null)
                    {
                        if (SensorConnected != null)
                        {
                            SensorConnected.Invoke(this);
                        }
                    }
                }
            }
        }

        private void disconnectSensor()
        {
            if (activeSensor != null)
            {
                KinectSensor localSensor = activeSensor;
                activeSensor = null;
                CurrentStatus = KinectStatus.Disconnected;
                localSensor.Stop();
                localSensor.Dispose();

                if(SensorDisconnected != null)
                {
                    SensorDisconnected.Invoke(this);
                }
            }
        }
    }
}
